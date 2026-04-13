using System;
using System.Media;
using System.Threading;
using static System.Console;
using System.Speech.Synthesis;
using Part1;

namespace CombinedApp
{
    // Simple class to store user info
    public class UserAccount
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    internal class Program
    {
        static UserAccount currentUser = new UserAccount();

        static SpeechSynthesizer speech = new SpeechSynthesizer();

        static void Main(string[] args)
        {
            SpeechSynthesizer voice = new SpeechSynthesizer(); 
            
            Console.Title = "Cybersecurity System";

            PlayVoice();
            ShowLogo();

           
            WriteLine("*********************************************************************************************************************");
            Console.ForegroundColor = ConsoleColor.White;
            WriteLine(" █████   ███   █████          ████                                                 █████                  █████████             █████                        ███████████            █████   \r\n░░███   ░███  ░░███          ░░███                                                ░░███                  ███░░░░░███           ░░███                        ░░███░░░░░███          ░░███    \r\n ░███   ░███   ░███   ██████  ░███   ██████   ██████  █████████████    ██████     ███████    ██████     ███     ░░░  █████ ████ ░███████   ██████  ████████  ░███    ░███  ██████  ███████  \r\n ░███   ░███   ░███  ███░░███ ░███  ███░░███ ███░░███░░███░░███░░███  ███░░███   ░░░███░    ███░░███   ░███         ░░███ ░███  ░███░░███ ███░░███░░███░░███ ░██████████  ███░░███░░░███░   \r\n ░░███  █████  ███  ░███████  ░███ ░███ ░░░ ░███ ░███ ░███ ░███ ░███ ░███████      ░███    ░███ ░███   ░███          ░███ ░███  ░███ ░███░███████  ░███ ░░░  ░███░░░░░███░███ ░███  ░███    \r\n  ░░░█████░█████░   ░███░░░   ░███ ░███  ███░███ ░███ ░███ ░███ ░███ ░███░░░       ░███ ███░███ ░███   ░░███     ███ ░███ ░███  ░███ ░███░███░░░   ░███      ░███    ░███░███ ░███  ░███ ███\r\n    ░░███ ░░███     ░░██████  █████░░██████ ░░██████  █████░███ █████░░██████      ░░█████ ░░██████     ░░█████████  ░░███████  ████████ ░░██████  █████     ███████████ ░░██████   ░░█████ \r\n     ░░░   ░░░       ░░░░░░  ░░░░░  ░░░░░░   ░░░░░░  ░░░░░ ░░░ ░░░░░  ░░░░░░        ░░░░░   ░░░░░░       ░░░░░░░░░    ░░░░░███ ░░░░░░░░   ░░░░░░  ░░░░░     ░░░░░░░░░░░   ░░░░░░     ░░░░░  \r\n                                                                                                                      ███ ░███                                                              \r\n                                                                                                                     ░░██████                                                               \r\n                                                                                                                      ░░░░░░                                                                ");
            Console.ResetColor();
            WriteLine("*********************************************************************************************************************");

            Write("\nEnter your name: ");
            string userName = ReadLine();

            if (string.IsNullOrWhiteSpace(userName))
                userName = "User";

            speech.SpeakAsync("Welcome to the Cybersecurity System, " + userName);

            voice.Speak("Welcome to the Cybersecurity System, " + userName);

            WriteLine("*****************************************************************************************");
            Console.ForegroundColor = ConsoleColor.Green;
            UIHelper.TypeText("How can I be of service for you today?");
            UIHelper.TypeText("HELLO!What would you like to do today?");
            UIHelper.TypeText("What is phishing?");
            UIHelper.TypeText("How to create a strong password?");
            UIHelper.TypeText("How to stay safe online?");
            Console.ResetColor();
            WriteLine("*****************************************************************************************");

            
            string input = "";

            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("\nHello " + userName + "! Welcome to the system.");
            ResetColor();

            Thread.Sleep(1000);
            RunChat(userName);
        }

        
        

        // Chatbot section
        static void RunChat(string userName)
        {
            Clear();
            Header("Chat Bot");

            WriteLine("Type 'exit' to go back.\n");

            while (true)
            {
                Write("Please ask me a question, " + userName + ": ");
                string input = ReadLine()?.ToLower();

                if (input == "exit")
                {
                    WriteLine("Bot: Bye " + userName);
                    break;
                }

                Write("Bot: ");

                if (string.IsNullOrWhiteSpace(input))
                {
                    TypeText("I didn't get that.");
                }
                else if (input.Contains("how are you"))
                {
                    TypeText("I'm good, thanks.");
                }
                else if (input.Contains("phishing"))
                {
                    TypeText("Phishing is when someone tries to trick you into giving info.A type of cyberattack where scammers impersonate trusted entities—like banks, bosses, or popular brands—to trick individuals into revealing sensitive information. ");
                }
                else if (input.Contains("password"))
                {
                    TypeText("Use strong passwords with numbers and symbols,secret string of characters—letters, numbers, or symbols—used to prove your identity and gain access to a resource, like a smartphone, email account, or bank portal. In cybersecurity, it is considered a \"knowledge factor\" because it relies on something you know.To create a strong password in 2026, you should shift your focus from complexity (random symbols) to length (long strings of words). Modern hacking tools can guess a short, complex password like P@$$w0rd! in seconds, but a long passphrase can take centuries.Aim for at least 15 characters. Length is the single most important factor in password strength. A 15-character password made of simple lowercase letters is actually stronger than an 8-character password with symbols and numbers");
                }
                else if (input.Contains("safe"))
                {
                    TypeText("Avoid strange links and check websites.Staying safe online is mostly about building a few simple habits to protect your identity, your data, and your money. Since we just talked about phishing and passwords, here is how to put it all together into a complete \"defense shield.\".");
                }
                else
                {
                    TypeText("Not sure what you mean.");
                }

                Thread.Sleep(300);
            }
        }

       

        // Helpers
        static void TypeText(string text, int delay = 25)
        {
            foreach (char c in text)
            {
                Write(c);
                Thread.Sleep(delay);
            }
            WriteLine();
        }

        static void Header(string title)
        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine(new string('-', 40));
            WriteLine(title);
            WriteLine(new string('-', 40));
            ResetColor();
        }

        static void ShowLogo()
        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("============================ CYBER SECURITY SYSTEM =============================================");
            ResetColor();
        }

        static void InvalidOption()
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("Wrong option.");
            ResetColor();
            Thread.Sleep(800);
        }

        static void ExitApp()
        {
            Header("Exit");
            WriteLine("Goodbye!");
            Thread.Sleep(800);
        }

        static void PlayVoice()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("How can I help you today?");
            }
            catch
            {

                //ignore
            }
            try
            {
                SoundPlayer player = new SoundPlayer("greeting.wav");
                player.Play();
            }
            catch
            {
                try
                {
                    // SpeechSynthesizer.SpeakAsync("Goodbye and have a great day!");
                    using (SpeechSynthesizer synth = new SpeechSynthesizer())
                    {
                        synth.SpeakAsync("Goodbye and have a great day!");
                    }
                }
                catch (Exception)
                {
                    WriteLine("Goodbye and have a great day!");
                }
            }
           
        }
    }
}


