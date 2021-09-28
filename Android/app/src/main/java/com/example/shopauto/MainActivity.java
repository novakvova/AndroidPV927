package com.example.shopauto;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    EditText txtInfo;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        txtInfo = findViewById(R.id.txtInfo);
    }
    public void onClickInfo(View view) {
        Toast.makeText(this,txtInfo.getText(), Toast.LENGTH_LONG).show();
    }
}