using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace lir
{
    class Program
    {

        static System.Timers.Timer delay = new System.Timers.Timer();
        static AutoResetEvent reset = new AutoResetEvent(false);

        private static void InitTimer()
        {
            delay.Interval = 60;
            delay.Elapsed += OnTimedEvent;
            delay.Enabled = false;
        }

        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            ((System.Timers.Timer)sender).Enabled = false;
            reset.Set();
        }

        static void Print(string print)
        {
            InitTimer();

            foreach (char l in print)
            {
                Console.Write(l);
                delay.Enabled = true;

                reset.WaitOne();
            }
            Console.Write("\n");
        }

        static void Main(string[] args)
        {
            Console.Title = "Lost in... RUSSIA";
            Console.WriteLine("Ładowanie gry...");
            Thread.Sleep(1500);
            var file = new FileStream("test.ogg", FileMode.Open, FileAccess.Read);
            var player = new SoundPlayer(new OggDecodeStream(file));
            player.PlayLooping();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@" _               _      _                _____  _    _  _____ _____ _____          ");
            Console.WriteLine(@"| |             | |    (_)              |  __ \| |  | |/ ____/ ____|_   _|   /\    ");
            Console.WriteLine(@"| |     ___  ___| |_    _ _ __          | |__) | |  | | (___| (___   | |    /  \   ");
            Console.WriteLine(@"| |    / _ \/ __| __|  | | '_ \         |  _  /| |  | |\___ \\___ \  | |   / /\ \  ");
            Console.WriteLine(@"| |___| (_) \__ \ |_   | | | | |_ _ _   | | \ \| |__| |____) |___) |_| |_ / ____ \ ");
            Console.WriteLine(@"|______\___/|___/\__|  |_|_| |_(_|_|_)  |_|  \_\\____/|_____/_____/|_____/_/    \_\");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Lost in... RUSSIA");
            Console.WriteLine("Autor: DBanaszewski & Paulina Jabłońska");
            Console.WriteLine("Wersja: 0.0.2.0");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.CursorVisible = false;
            Print("Kliknij dowolny przycisk, aby zacząć grę...");
            Console.ReadKey();
            Console.Clear();
            player.Stop();
            Console.ForegroundColor = ConsoleColor.Green;
            Print("3 marzec 1953 2:00 (wtorek)");
            Thread.Sleep(1500);
            Console.ForegroundColor = ConsoleColor.White;
            Print("W środku nocy ktoś łomocze do drzwi.");
            Thread.Sleep(2500);
            Print("Otwierasz a tam smutni panowie w nie do końca dopasowanych mundurach.");
            Thread.Sleep(2500);
            Print("Już wiesz, że będzie źle.");
            player.PlaySync();
            Print("Już wiesz, że będzie źle.");
            Print("Już wiesz, że będzie źle.");
            Print("Już wiesz, że będzie źle.");
            Print("Już wiesz, że będzie źle.");
            Print("Już wiesz, że będzie źle.");
            Print("Już wiesz, że będzie źle.");
            Print("Już wiesz, że będzie źle.");
            Print("Już wiesz, że będzie źle.");
            Print("Już wiesz, że będzie źle.");
            Console.ReadKey();
        }
    }
}
