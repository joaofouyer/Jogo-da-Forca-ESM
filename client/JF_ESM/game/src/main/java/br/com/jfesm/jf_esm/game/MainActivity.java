package br.com.jfesm.jf_esm.game;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;

import java.io.BufferedWriter;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.net.InetAddress;

import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.WebSocket;
import java.net.Socket;
import java.net.UnknownHostException;


public class MainActivity extends Activity {
    private Socket socket;
    private static final int SERVERPORT = 5000;
    private static final String SERVER_IP = "10.0.2.2";
    private OkHttpClient client = new OkHttpClient();


    @Override
    public void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);

        setContentView(R.layout.activity_main);


        new Thread(new ClientThread()).start();

    }


    public void onClick(View view) {

        try {

//        EditText et = (EditText) findViewById(R.id.EditText01);

//        String str = et.getText().toString();

            String str = "Test";
            PrintWriter out = new PrintWriter(new BufferedWriter(

                    new OutputStreamWriter(socket.getOutputStream())),

                    true);

            out.println(str);

        } catch (UnknownHostException e) {

            e.printStackTrace();

        } catch (IOException e) {

            e.printStackTrace();

        } catch (Exception e) {

            e.printStackTrace();

        }

    }


    class ClientThread implements Runnable {


        @Override

        public void run() {


            try {

                InetAddress serverAddr = InetAddress.getByName(SERVER_IP);

Request request  = new Request.Builder().url("ws://10.0.2.2:5000/ws").build();
WebSocket ws = client.newWebSocket(request, null);
                socket = new Socket(serverAddr, SERVERPORT);


            } catch (UnknownHostException e1) {
                e1.printStackTrace();
            } catch (IOException e1) {
                e1.printStackTrace();
            }

        }


    }
}

