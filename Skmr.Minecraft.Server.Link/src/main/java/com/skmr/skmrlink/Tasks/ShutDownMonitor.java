package com.skmr.skmrlink.Tasks;

import com.skmr.skmrlink.SkmrLink;
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

import java.io.IOException;
import java.security.KeyManagementException;
import java.security.KeyStoreException;
import java.security.NoSuchAlgorithmException;
import java.util.Date;

public class ShutDownMonitor implements Runnable {



    private SkmrLink main;
    private Date lastPlayerOnline;

    public ShutDownMonitor(SkmrLink main){
        this.main = main;
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
        return main.getServer().getOnlinePlayers().toArray().length;
    }
    public boolean isOverThreshold(){
        Date current = new Date();
        long difference = current.getTime() - lastPlayerOnline.getTime();
        //threshold = mins * seconds per min * milliseconds per second
        long threshold = 2 * 60 * 1000;

        return difference > threshold;
    }
    @Override
    public void run(){
        int playerCount = getPlayerCount();

        if (playerCount > 0) lastPlayerOnline = new Date();

        if (isOverThreshold()) sendShutdownRequest();

        System.out.println("Players Online: "+playerCount+" lastPlayerOnline: "+lastPlayerOnline);
    }

}
