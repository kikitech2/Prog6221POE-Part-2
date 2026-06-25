using System;
using System.Media;
using System.Threading;

namespace CyberAwarenessBot
{
    public static class UIHelper
    {
        public static int Score = 0;
        public static int QuestionsAnswered = 0;

        public static void PlayGreetingAudio()
        {
            try { SoundPlayer player = new SoundPlayer("greeting.wav"); player.Play(); }
            catch { Console.WriteLine("[Audio System: File not found]"); }
        }

        public static void DisplayLogo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            int logoWidth = 60;
            int consoleWidth = Console.WindowWidth;
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
                "                                                            ",
                "                --- GUARDIANS OF YOUR INTEGRITY ---             ",
                "============================================================"
            };

            foreach (string line in logoLines) { Console.WriteLine(padding + line); Thread.Sleep(80); }
            Console.ResetColor();
            Console.WriteLine(new string('=', consoleWidth) + "\n");
        }

        public static void TypeMessage(string message)
        {
            foreach (char c in message) { Console.Write(c); Thread.Sleep(30); }
            Console.WriteLine();
        }

        public static string GetResponse(string rawInput)
        {
            string input = rawInput.ToLower();

            // 1. Initial Name Greeting
            if (QuestionsAnswered == 0 && !input.Contains("quiz") && input.Length > 2 && !input.Contains("a") && !input.Contains("b") && !input.Contains("c"))
            {
                return "\nThat's an interesting input! I'm here to help with cyber security. Try asking me about 'passwords', 'phishing', or type 'quiz' to start the challenge.";
            }

            // 2. Quiz Reset
            if (input == "quiz") { Score = 0; QuestionsAnswered = 0; return "\n--- CYBER SECURITY QUIZ ---\nQ1: Which is a strong password?\n  A) 123456\n  B) Password123\n  C) P@ssw0rd!_2026\n\nType your answer (A, B, or C)."; }

            // 3. 10-Question Logic
            if (QuestionsAnswered < 10)
            {
                string feedback = "";
                // Scoring Logic
                if (QuestionsAnswered == 0) { if (input == "c") Score++; feedback = (input == "c") ? "Correct!" : "Incorrect. Correct was C."; }
                else if (QuestionsAnswered == 1) { if (input == "b") Score++; feedback = (input == "b") ? "Correct!" : "Incorrect. Correct was B (Phishing)."; }
                else if (QuestionsAnswered == 2) { if (input == "a") Score++; feedback = (input == "a") ? "Correct!" : "Incorrect. Correct was A (MFA)."; }
                else if (QuestionsAnswered == 3) { if (input == "b") Score++; feedback = (input == "b") ? "Correct!" : "Incorrect. Correct was B (No)."; }
                else if (QuestionsAnswered == 4) { if (input == "a") Score++; feedback = (input == "a") ? "Correct!" : "Incorrect. Correct was A (Software)."; }
                else if (QuestionsAnswered == 5) { if (input == "c") Score++; feedback = (input == "c") ? "Correct!" : "Incorrect. Correct was C (Never)."; }
                else if (QuestionsAnswered == 6) { if (input == "a") Score++; feedback = (input == "a") ? "Correct!" : "Incorrect. Correct was A (Encryption)."; }
                else if (QuestionsAnswered == 7) { if (input == "b") Score++; feedback = (input == "b") ? "Correct!" : "Incorrect. Correct was B (Traffic)."; }
                else if (QuestionsAnswered == 8) { if (input == "b") Score++; feedback = (input == "b") ? "Correct!" : "Incorrect. Correct was B (Prompted)."; }
                else if (QuestionsAnswered == 9) { if (input == "a") Score++; feedback = (input == "a") ? "Correct!" : "Incorrect. Correct was A (Manipulating)."; }

                QuestionsAnswered++;

                if (QuestionsAnswered < 10)
                {
                    string[] nextQs = {
                        "\nQ2: What is Phishing?\n  A) Sport\n  B) Email attack\n  C) Browser",
                        "\nQ3: What does MFA stand for?\n  A) Multi-Factor Auth\n  B) File Access\n  C) My App",
                        "\nQ4: Is public Wi-Fi safe?\n  A) Yes\n  B) No\n  C) Maybe",
                        "\nQ5: What is Malware?\n  A) Malicious Software\n  B) Cool app\n  C) Hardware",
                        "\nQ6: Should you share your OTP?\n  A) Yes\n  B) Friends\n  C) Never",
                        "\nQ7: What is Ransomware?\n  A) Data encryption\n  B) Virus scan\n  C) Game",
                        "\nQ8: What is a VPN used for?\n  A) Gaming\n  B) Encrypting traffic\n  C) Windows",
                        "\nQ9: How often update software?\n  A) Never\n  B) When prompted\n  C) Yearly",
                        "\nQ10: What is Social Engineering?\n  A) Manipulating people\n  B) Coding\n  C) Marketing"
                    };
                    return $"\n{feedback}\n{nextQs[QuestionsAnswered - 1]}\n\nType A, B, or C.";
                }
                return $"\n{feedback}\n--- QUIZ COMPLETE ---\nYour final score is {Score}/10.";
            }

            return "\nType 'quiz' to start again!";
        }
    }
}
