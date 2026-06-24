using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberAwarenessBotGUI1
{
    public class Question
    {
        public string Text { get; set; }
        public List<string> Options { get; set; }
        public int CorrectIndex { get; set; }
        public string Explanation { get; set; }
    }

    public static class QuizManager
    {
        public static List<Question> GetQuestions()
        {
            return new List<Question>
        {
            new Question { Text = "What is phishing?", Options = new List<string> { "A game", "A malicious attempt to obtain sensitive info", "A file format", "A type of hardware" }, CorrectIndex = 1, Explanation = "Phishing uses deception to trick users into revealing passwords." },
            new Question { Text = "Is 2FA a good security practice?", Options = new List<string> { "Yes", "No" }, CorrectIndex = 0, Explanation = "2FA provides an extra layer of protection beyond just a password." },
            new Question { Text = "What should you do if you receive a suspicious email?", Options = new List<string> { "Reply to it", "Click the link", "Delete/Report it", "Forward it" }, CorrectIndex = 2, Explanation = "Deleting or reporting avoids interaction with malicious actors." },
            new Question { Text = "Should you reuse passwords across different sites?", Options = new List<string> { "Yes", "No" }, CorrectIndex = 1, Explanation = "Reuse leads to 'credential stuffing' attacks." },
            new Question { Text = "Does HTTPS guarantee a site is safe?", Options = new List<string> { "Yes", "No" }, CorrectIndex = 1, Explanation = "HTTPS means encrypted, not necessarily legitimate." },
            new Question { Text = "What is social engineering?", Options = new List<string> { "Network coding", "Manipulating people to divulge info", "Fixing PCs", "A firewall type" }, CorrectIndex = 1, Explanation = "It exploits human trust rather than software flaws." },
            new Question { Text = "Is public Wi-Fi safe for banking?", Options = new List<string> { "Yes", "No" }, CorrectIndex = 1, Explanation = "Public Wi-Fi is easily intercepted by hackers." },
            new Question { Text = "Do security updates need to be installed?", Options = new List<string> { "Only if I want", "Yes, to patch vulnerabilities", "No, they slow things down", "Only at night" }, CorrectIndex = 1, Explanation = "Updates fix security holes." },
            new Question { Text = "Are weak passwords easy to crack?", Options = new List<string> { "Yes", "No" }, CorrectIndex = 0, Explanation = "Automated tools crack weak passwords in seconds." },
            new Question { Text = "Is a firewall necessary?", Options = new List<string> { "No", "Yes, to monitor traffic" }, CorrectIndex = 1, Explanation = "Firewalls act as a gatekeeper for network traffic." }
        };
        }
    }
}
