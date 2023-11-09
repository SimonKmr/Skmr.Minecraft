package com.skmr.skmrlink;


import com.skmr.skmrlink.Tasks.ShutDownMonitor;
import org.bukkit.plugin.java.JavaPlugin;
import org.bukkit.scheduler.BukkitScheduler;

public final class SkmrLink extends JavaPlugin {
    @Override
    public void onEnable() {
        // Plugin startup log
        BukkitScheduler scheduler = getServer().getScheduler();
        scheduler.scheduleSyncRepeatingTask(
                this,
                new ShutDownMonitor(this),
                minutesToTicks(1L),
                minutesToTicks(1L)
        );
    }

    private static long minutesToTicks(long minutes){
        return 20L*60L*minutes;
    }

    @Override
    public void onDisable() {
        // Plugin shutdown logic

        System.out.println("Good Bye!");

    }


}
