package br.com.jfesm.jf_esm.game.Socket;

import okhttp3.Response;
import okhttp3.WebSocket;
import okhttp3.WebSocketListener;
import okio.ByteString;

public final class EchoWebSocketListener extends WebSocketListener {

    private String response;
    private String closeMessage;
    private static final int NORMAL_CLOSURE_STATUS = 1000;

    @Override
    public void onOpen(WebSocket webSocket, Response response) {
//        webSocket.send("Hello, it's SSaurel !");
//        webSocket.close(NORMAL_CLOSURE_STATUS, "Goodbye !");
    }

    @Override
    public void onMessage(WebSocket webSocket, String text) {
        response = text;
    }

    @Override
    public void onMessage(WebSocket webSocket, ByteString bytes) {
        response = "Receiving bytes : " + bytes.hex();
    }

    @Override
    public void onClosing(WebSocket webSocket, int code, String reason) {
        webSocket.close(NORMAL_CLOSURE_STATUS, null);
        closeMessage = "Closing : " + code + " / " + reason;
    }

    @Override
    public void onFailure(WebSocket webSocket, Throwable t, Response response) {
        this.response = "Error : " + t.getMessage();
    }

    public String getResponse() {
        return response;
    }

    public String getCloseMessage() {
        return closeMessage;
    }
}