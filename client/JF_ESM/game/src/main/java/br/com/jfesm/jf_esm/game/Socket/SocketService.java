package br.com.jfesm.jf_esm.game.Socket;

import java.io.Serializable;

import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.WebSocket;

public class SocketService {

    private OkHttpClient client;
    private WebSocket ws;
    private EchoWebSocketListener listener;

    public SocketService() {
        client = new OkHttpClient();
        Request request = new Request.Builder().url("ws://10.0.2.2:5000/sala").build();
        listener = new EchoWebSocketListener();
        ws = client.newWebSocket(request, listener);
//        client.dispatcher().executorService().shutdown();
    }

    public String getResponse() {
        return listener.getResponse();
    }
}
