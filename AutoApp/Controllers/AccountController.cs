using AutoApp.Data.Identity;
using AutoApp.Helpers;
using AutoApp.Models;
using AutoApp.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AutoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IJwtTokenService _jwtTokenService;

        public AccountController(UserManager<AppUser> userManager,
            IJwtTokenService jwtTokenService,
            IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            var user = _mapper.Map<AppUser>(model);
            string fileNameSavePath = String.Empty;
            if (model.Photo != null)
            {
                string randomFilename = Path.GetRandomFileName() + ".jpg";

                string dirPath = Path.Combine(Directory.GetCurrentDirectory(), "images");
                fileNameSavePath = Path.Combine(dirPath, randomFilename);

                using (Bitmap bitmap = ImageWorker.Base64StringToBitmap(model.Photo))
                {
                    Bitmap savedImage = ImageWorker.CreateImage(bitmap, 400, 360);
                    if (savedImage != null)
                    {
                        savedImage.Save(fileNameSavePath, ImageFormat.Jpeg);
                    }
                };

                user.Photo = randomFilename;
            }

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                if (!string.IsNullOrEmpty(fileNameSavePath))
                    System.IO.File.Delete(fileNameSavePath);
                return BadRequest(result.Errors);
            }
            //result = await _userManager.AddToRoleAsync(user, "user");
            //if (!result.Succeeded)
            //{
            //    return BadRequest(result.Errors);
            //}

            return Ok(new
            {
                token = _jwtTokenService.CreateToken(user)
            });
        }
    }
}
