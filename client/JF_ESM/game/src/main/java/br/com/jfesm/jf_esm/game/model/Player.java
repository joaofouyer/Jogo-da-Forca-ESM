package br.com.jfesm.jf_esm.game.model;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Player {

    @SerializedName("Id")
    @Expose
    private String id;
    @SerializedName("Name")
    @Expose
    private String name;
    @SerializedName("EstaPronto")
    @Expose
    private boolean estaPronto;

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public boolean getEstaPronto() {
        return estaPronto;
    }

    public void setEstaPronto(boolean estaPronto) {
        this.estaPronto = estaPronto;
    }

}


