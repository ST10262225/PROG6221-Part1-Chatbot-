using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading; // For typing effect
using Figgle; // ASCII Art Library

namespace Prog_Part1
{
    public class Program
    {
        static FilterBot bot = new FilterBot(); // Instance of the chatbot

        static void Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Bot";
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Play the voice greeting
            PlayGreeting();

            // Display the ASCII art logo
            DisplayAsciiArt();

            // Handle user interaction
            UserInput();
        }

        // Method for playing the voice greeting
        static void PlayGreeting()
        {
            string relativePath = @"Audio\greeting.wav";
            string absolutePath = Path.GetFullPath(relativePath); // Convert it to an absolute path
            Console.ForegroundColor = ConsoleColor.Yellow;

            if (!File.Exists(absolutePath))
            {
                // Display warning if the audio file is missing
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("⚠ Warning: Audio file not found. Skipping greeting...");
                Console.ResetColor();
                return;
            }

            try
            {
                // Try loading and playing the sound
                using (SoundPlayer player = new SoundPlayer(absolutePath))
                {
                    player.Load();  // Load the audio file
                    player.PlaySync();  // Play the audio file synchronously
                }
            }
            catch (Exception ex)
            {
                // Handle errors if audio fails to play
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error playing greeting: " + ex.Message);
                Console.ResetColor();
            }
        }

        // Method for displaying the ASCII art logo
        static void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(FiggleFonts.Standard.Render("CyberSentinel"));
            Console.ResetColor();
        }

        // Method for handling user interaction
        static void UserInput()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nPlease enter your name: ");
            Console.ResetColor();
            string Name = Console.ReadLine()?.Trim();

            // Ensure the user enters a valid name
            while (string.IsNullOrEmpty(Name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Chatbot: ");
                DisplayTypingEffect("Name cannot be empty. Please enter your name: ");
                Console.ResetColor();
                Name = Console.ReadLine()?.Trim();
            }

            // Welcome message with typing effect
            string message = $"Hello, {Name}! Welcome to the Cybersecurity Awareness Bot. I am here to help you stay safe online";
            DisplayTypingEffect(message);

            // Display a bordered welcome message
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(new string('*', message.Length + 4));
            string borderedMessage = $"* {message} *";
            Console.WriteLine(new string('*', message.Length + 4));
            Console.ResetColor();

            Console.WriteLine("\nAsk me anything about cybersecurity, or type 'exit' to leave.\n");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You: ");
                Console.ResetColor();
                string userInput = Console.ReadLine()?.Trim().ToLower();

                // Ensure the user enters a valid question
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Chatbot: ");
                    DisplayTypingEffect("Please enter a valid question.");
                    Console.ResetColor();
                    continue;
                }

                // Exit condition
                if (userInput == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    DisplayTypingEffect("\nChatbot: Thank you for chatting! Stay safe online.");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    Console.Clear(); // Clears screen before exiting
                    break;
                }

                // Clean user input by removing punctuation
                var cleanedInput = new string(userInput.Where(c => !char.IsPunctuation(c)).ToArray());

                // Get response from chatbot
                string response = bot.GetResponse(cleanedInput);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Chatbot: ");
                DisplayTypingEffect(response);
                Console.ResetColor();
            }
        }

        // Method for displaying text with a typing effect
        static void DisplayTypingEffect(string message, int delay = 50)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay); // Delay for effect
            }
            Console.WriteLine();
        }
    }
}
