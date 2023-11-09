package com.skmr.skmrlink;


import org.bukkit.plugin.java.JavaPlugin;

import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URL;

public final class SkmrLink extends JavaPlugin {

    @Override
    public void onEnable() {
        // Plugin startup logic
        System.out.println("Hello World!");
        try {
            sendShutdownToManager();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public void onDisable() {
        // Plugin shutdown logic

        System.out.println("Good Bye!");

    }

    public void sendShutdownToManager() throws IOException {
        HttpURLConnection connection = null;

        URL url = new URL("127.0.0.1:7166/Uptime");
        HttpURLConnection con = (HttpURLConnection) url.openConnection();
        con.setRequestMethod("DELETE");

        int responseCode = con.getResponseCode();
        System.out.println("DELETE request reponseCode: "+responseCode);
    }

    public int getPlayerCount(){
        return this.getServer().getOnlinePlayers().toArray().length;
    }
}
