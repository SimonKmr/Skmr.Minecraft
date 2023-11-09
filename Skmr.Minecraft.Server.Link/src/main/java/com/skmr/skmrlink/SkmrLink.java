package com.skmr.skmrlink;


import org.apache.hc.client5.http.impl.classic.CloseableHttpClient;
import org.apache.hc.client5.http.impl.classic.HttpClients;
import org.apache.hc.client5.http.impl.io.PoolingHttpClientConnectionManagerBuilder;
import org.apache.hc.client5.http.ssl.NoopHostnameVerifier;
import org.apache.hc.client5.http.ssl.SSLConnectionSocketFactoryBuilder;
import org.apache.hc.client5.http.ssl.TrustAllStrategy;
import org.apache.hc.core5.http.ClassicHttpRequest;
import org.apache.hc.core5.http.HttpEntity;
import org.apache.hc.core5.http.io.entity.EntityUtils;
import org.apache.hc.core5.http.io.support.ClassicRequestBuilder;
import org.apache.hc.core5.ssl.SSLContextBuilder;
import org.bukkit.plugin.java.JavaPlugin;

import java.io.IOException;
import java.security.KeyManagementException;
import java.security.KeyStoreException;
import java.security.NoSuchAlgorithmException;
import java.util.Date;

public final class SkmrLink extends JavaPlugin {
    @Override
    public void onEnable() {
        // Plugin startup logic
        Update();
    }

    @Override
    public void onDisable() {
        // Plugin shutdown logic

        System.out.println("Good Bye!");

    }

    private Date lastPlayerOnline;
    public void Update(){
        int playerCount = getPlayerCount();

        if (playerCount > 0) lastPlayerOnline = new Date();

        if (isOverThreshold()) sendShutdownRequest();
    }
    public static void sendShutdownRequest() {
        String url = "https://127.0.0.1:7166/Uptime";

        CloseableHttpClient client = null;
        try {
            client = HttpClients.custom()
                    .setConnectionManager(PoolingHttpClientConnectionManagerBuilder.create()
                            .setSSLSocketFactory(SSLConnectionSocketFactoryBuilder.create()
                                    .setSslContext(SSLContextBuilder.create()
                                            .loadTrustMaterial(TrustAllStrategy.INSTANCE)
                                            .build())
                                    .setHostnameVerifier(NoopHostnameVerifier.INSTANCE)
                                    .build())
                            .build())
                    .build();
        } catch (NoSuchAlgorithmException e) {
            throw new RuntimeException(e);
        } catch (KeyManagementException e) {
            throw new RuntimeException(e);
        } catch (KeyStoreException e) {
            throw new RuntimeException(e);
        }

        ClassicHttpRequest httpDelete = ClassicRequestBuilder.delete(url).build();

        try {
            client.execute(httpDelete, response -> {
                System.out.println(response.getCode()+ " "+ response.getReasonPhrase());
                final HttpEntity entity1 = response.getEntity();

                EntityUtils.consume(entity1);
                return null;
            });
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
    public int getPlayerCount(){
        return this.getServer().getOnlinePlayers().toArray().length;
    }
    public boolean isOverThreshold(){
        Date current = new Date();
        long difference = current.getTime() - lastPlayerOnline.getTime();
        //threshold = mins * seconds per min * milliseconds per second
        long threshold = 10 * 60 * 1000;

        return difference > threshold;
    }
}
