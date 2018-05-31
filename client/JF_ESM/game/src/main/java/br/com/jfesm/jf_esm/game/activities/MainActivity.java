package br.com.jfesm.jf_esm.game.activities;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import com.google.gson.Gson;

import java.io.BufferedWriter;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.io.Serializable;
import java.net.InetAddress;

import br.com.jfesm.jf_esm.game.R;
import br.com.jfesm.jf_esm.game.Socket.SocketService;
import br.com.jfesm.jf_esm.game.model.Player;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;
import okhttp3.WebSocket;
import okhttp3.WebSocketListener;
import okio.ByteString;

import java.net.Socket;
import java.net.UnknownHostException;


public class MainActivity extends Activity {
    private Button start;
    private SocketService service;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        start = findViewById(R.id.start_button);
        start.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                start();
            }
        });
    }
    private void start() {
        service = new SocketService();
        Gson gson = new Gson();
        System.out.print(service.getResponse());
        Player player = gson.fromJson(service.getResponse(), Player.class);
        Bundle extras = new Bundle();

//        extras.putSerializable("socket_service",service);

        Intent intent = new Intent(this, WaitingPlayes.class);
//        intent.putExtras(extras);
        this.startActivity(intent);
    }
    private void output(final String txt) {
        runOnUiThread(new Runnable() {
            @Override
            public void run() {
                System.out.println(txt);
            }
        });
    }
}

