package br.com.jfesm.jf_esm.game;

import android.os.AsyncTask;

import java.io.DataOutputStream;
import java.io.IOException;
import java.io.PrintWriter;
import java.net.Socket;

public class MessageSender extends AsyncTask<Void, Void, Void> {
    Socket socket;
    DataOutputStream dataOutput;
    PrintWriter printWriter;


    @Override
    protected Void doInBackground(Void... voids) {
        try {
            socket = new Socket("192.168.15.25", 5000);
        } catch (IOException ex) {
            ex.printStackTrace();
        }
        return null;
    }
}
