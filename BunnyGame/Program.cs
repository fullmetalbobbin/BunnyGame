using System;

namespace BunnyGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new BunnyGame())
                game.Run();
        }
    }
}
