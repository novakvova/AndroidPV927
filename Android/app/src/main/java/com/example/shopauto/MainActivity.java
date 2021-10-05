package com.example.shopauto;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class MainActivity extends AppCompatActivity {

    EditText txtInfo;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        txtInfo = findViewById(R.id.txtInfo);
    }
    public void onClickInfo(View view) {
        //Toast.makeText(this,txtInfo.getText(), Toast.LENGTH_LONG).show();
        Intent intent = new Intent(this, RegisterActivity.class);
        startActivity(intent);
//        MainActivity intasnce = this;
//        NetworkService.getInstance()
//                .getJSONApi()
//                .getPostWithID()
//                .enqueue(new Callback<List<Currency>>() {
//                    @Override
//                    public void onResponse(@NonNull Call<List<Currency>> call, @NonNull Response<List<Currency>> response) {
//                        List<Currency> post = response.body();
//                        //Toast.makeText(intasnce,post.getBuy(), Toast.LENGTH_LONG).show();
//                    }
//
//                    @Override
//                    public void onFailure(@NonNull Call<List<Currency>> call, @NonNull Throwable t) {
//                        t.printStackTrace();
//                    }
//                });
    }
}