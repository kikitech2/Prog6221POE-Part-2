// See https://aka.ms/new-console-template for more information
using System;
using System.Media;
using System.Threading;

namespace CyberAwarenessBot
{
    public static class UIHelper
    {
        public static void PlayGreetingAudio()
        {
            try
            {
                // The greeting.wav is the name of the video cue flie and handles the visuals of the user experience.
                // Using my personlized voice I made the bot sound more 'human like' and interactive.
                SoundPlayer player = new SoundPlayer("greeting.wav");
                player.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Audio System: File not found, continuing with text only...]");
            }
        }
        public static void DisplayLogo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            // The logo is exactly 60 characters wide
            int logoWidth = 60;
            int consoleWidth = Console.WindowWidth;

            // Calculate how many spaces we need on the left to center it
            // If the console is smaller than the logo, we default to 0 to avoid errors
            int leftPadding = Math.Max(0, (consoleWidth - logoWidth) / 2);
            string padding = new string(' ', leftPadding);

            string[] logoLines = {
        "============================================================",
        "  ______ _    _  _    _____  _____  _____  ___   _   _  _____ ",
        " |  ____| |  | || | |  __ \\|  __ \\|_   _|/ _ \\ | \\ | |/ ____|",
        " | |  __| |  | || | | |__) | |  | | | | / /_\\ \\|  \\| | (___  ",
        " | | |_ | |  | || | |  _  /| |  | | | | |  _  || . ` |\\___ \\ ",
        " | |__| | |__| || | | | \\ \\| |__| |_| |_| | | || |\\  |____) |",
        "  \\______|______| |_|_|  \\_\\_____/|_____|_| |_||_| \\_|_____/ ",
        "                                                              ",
        "               --- GUARDIANS OF YOUR INTEGRITY ---             ",
        "============================================================"
    };

            foreach (string line in logoLines)
            {
                // Add the padding to the start of every line
                Console.WriteLine(padding + line);
                System.Threading.Thread.Sleep(80);
            }

            // Visual structure of the interface to enhance the chatbots appearance
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;

            
            string subHeading1 = "          SA's Leading Cyber Awareness Assistant            ";
            Console.WriteLine(padding + subHeading1);

            // This line now dynamically stretches to the full width of the window
            string fullWidthLine = new string('=', Console.WindowWidth);
            Console.WriteLine(fullWidthLine + "\n");

            Console.ResetColor();
        }
        // Displays the typing effect for a conversational feel.
        public static void TypeMessage(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(70);
            }
            Console.WriteLine();

        }
    }
}

        
