using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberAwarenessBot
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Multimedia and visual setup
            UIHelper.PlayGreetingAudio();
            UIHelper.DisplayLogo();

            // 2. Initializes the chatbot
            ChatBot myAssistant = new ChatBot();

            // 3. Start the actual conversation
            myAssistant.StartConversation();

            Console.WriteLine("\n  Session ended. Press any key to close...");
            Console.ReadKey();
        }
    }
}
