namespace Utility;

public static class Flavor
{
    private static Random random = new();

    public static void Intro()
    {
        Console.WriteLine("===================================================================");
        Console.WriteLine("                    OCTO-TECH SYSTEMS v2.0");
        Console.WriteLine("              The Pinnacle of Scientific Superiority");
        Console.WriteLine("===================================================================");
        Console.WriteLine("Initializing... \n");

        Console.WriteLine("[OK] Loading Octo-Arms Interface...");
        Console.WriteLine("[OK] Booting Central Neural Processor...");
        Console.WriteLine("[OK] Engaging Quantum Algorithm Dynamics...");
        Console.WriteLine("[OK] Activating Laser Matrix Subsystem...");
        Console.WriteLine("[OK] Syncing Satellite Uplink...");
        Console.WriteLine();

        Console.WriteLine("Welcome, esteemed user, to the grandest technological achievement of this age.");
        Console.WriteLine("Created by the unparalleled genius, Dr. Otto Octavius!\n");

        Console.WriteLine(":: Warnings ::");
        Console.WriteLine("- Any unauthorized access will result in immediate retaliation.");
        Console.WriteLine("- Handle with the respect fitting of my brilliance.\n");

        Console.WriteLine("Octo-Tech> All systems operational and awaiting orders.");
        Console.WriteLine("Octo-Tech> Your world is now in the grasp of Dr. Octopus!\n");
        Console.WriteLine("===================================================================");
    }

    public static async Task Authorized()
    {
        for (int i = 0; i < random.Next(50,100); i++)
        {
            await Task.Delay(random.Next(5,10));
            Console.Write(".");
        }
        Console.WriteLine("ACCESS GRANTED");
        Console.WriteLine("Authorized. Welcome Doctor Otto Octavius.");
        Console.WriteLine("===================================================================");
    }
}