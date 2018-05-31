package br.com.jfesm.jf_esm.game.activities;

import android.os.Bundle;
import android.app.Activity;

import br.com.jfesm.jf_esm.game.R;
import br.com.jfesm.jf_esm.game.Socket.SocketService;

public class WaitingPlayes extends Activity {



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_waiting_playes);
        SocketService service = (SocketService) getIntent().getSerializableExtra("socket_service");
    }

}
