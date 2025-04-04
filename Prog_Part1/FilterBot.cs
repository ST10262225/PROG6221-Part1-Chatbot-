using System;
using System.Collections.Generic;
using System.Linq;

namespace Prog_Part1
{
    class FilterBot
    {
        // Dictionary to store responses for various cybersecurity-related topics.
        private Dictionary<string, List<string>> responses = new Dictionary<string, List<string>>();

        // A set of common words to ignore in the input.
        private HashSet<string> ignoreWords = new HashSet<string>
        {
            "is", "the", "a", "can", "i", "my", "what", "about", "tell", "me", "how"
        };

        // Random object to select random responses from the available ones.
        private Random random = new Random();

        // Constructor initializes the FilterBot and stores the predefined responses.
        public FilterBot()
        {
            StoreResponses();
        }

        // Method to populate the 'responses' dictionary with cybersecurity-related information.
        private void StoreResponses()
        {
            // Adding responses related to 'password' keyword.
            responses["password"] = new List<string>
            {
                "Passwords need to be protected and kept safe.",
                "Use a mix of letters, numbers, and special characters for better security.",
                "Avoid using the same password for multiple accounts."
            };

            // Adding responses related to 'security' keyword.
            responses["security"] = new List<string>
            {
                "Security is essential to protect your data from cyber threats.",
                "Use two-factor authentication whenever possible.",
                "Keep your software and systems updated to stay secure."
            };

            // Adding responses related to 'phishing' keyword.
            responses["phishing"] = new List<string>
            {
                "Phishing is an attempt to steal personal information by pretending to be a trustworthy source.",
                "Never click on suspicious links in emails or messages.",
                "Always verify the sender before providing any personal details."
            };

            // Adding responses related to 'malware' keyword.
            responses["malware"] = new List<string>
            {
                "Malware is malicious software designed to harm or exploit your device.",
                "Use reliable antivirus software and keep it updated.",
                "Avoid downloading files from unknown sources."
            };

            // Adding responses related to 'firewall' keyword.
            responses["firewall"] = new List<string>
            {
                "A firewall is a security system that monitors and controls network traffic.",
                "Firewalls help prevent unauthorized access to your computer or network.",
                "Ensure your firewall is always enabled for better security."
            };

            // Adding responses related to 'encryption' keyword.
            responses["encryption"] = new List<string>
            {
                "Encryption is the process of converting data into a secure format.",
                "It helps protect sensitive information from unauthorized access.",
                "Always encrypt important data before transmitting it online."
            };

            // Adding responses related to 'social' engineering keyword.
            responses["social"] = new List<string>
            {
                "Social engineering is a manipulation technique used to trick people into revealing confidential information.",
                "Be cautious of unexpected requests for personal data.",
                "Verify the identity of people asking for sensitive information before sharing anything."
            };

            // Adding responses related to 'authentication' keyword.
            responses["authentication"] = new List<string>
            {
                "Authentication verifies your identity before granting access to a system.",
                "Multi-factor authentication (MFA) adds an extra layer of security.",
                "Never share your authentication credentials with anyone."
            };

            // Adding responses related to 'privacy' keyword.
            responses["privacy"] = new List<string>
            {
                "Data privacy ensures that personal information is protected from unauthorized access.",
                "Adjust your privacy settings on social media to limit who can see your data.",
                "Be mindful of the information you share online."
            };

            // Adding responses related to 'vpn' keyword.
            responses["vpn"] = new List<string>
            {
                "A VPN (Virtual Private Network) encrypts your internet connection to protect your data and privacy.",
                "Using a VPN helps you stay secure on public Wi-Fi networks by hiding your IP address.",
                "A VPN allows you to access region-restricted content while keeping your online activity private."
            };

            // Adding responses related to '2fa' keyword.
            responses["2fa"] = new List<string>
            {
                "Two-Factor Authentication (2FA) adds an extra security step by requiring a second verification method, like a text code.",
                "Always enable 2FA on important accounts to prevent unauthorized access, even if your password gets stolen.",
                "Authenticator apps like Google Authenticator or Authy are safer than SMS codes, which can be intercepted."
            };

            // Adding responses related to 'wifi' keyword.
            responses["wifi"] = new List<string>
            {
                "Public Wi-Fi networks are often unsecured, making it easy for hackers to intercept your data.",
                "Avoid logging into banking or sensitive accounts while connected to public Wi-Fi.",
                "Using a VPN on public Wi-Fi helps encrypt your data and keeps your browsing private."
            };

            // Adding responses related to 'safe browsing' keyword.
            responses["safe browsing"] = new List<string>
            {
                "Always check the URL before entering personal information—phishing sites often look identical to real ones.",
                "Look for 'HTTPS' in the website address—it means your connection is secure.",
                "Avoid clicking on pop-ups or ads claiming you won a prize—they are often scams."
            };
        }

        // Method to get a response based on the user's input.
        public string GetResponse(string input)
        {
            // Convert input to lowercase and split it into words.
            string lowerInput = input.ToLower();

            // First, check if any multi-word phrases match.
            List<string> responsesToReturn = new List<string>();

            foreach (var phrase in responses.Keys)
            {
                if (lowerInput.Contains(phrase))
                {
                    responsesToReturn.Add(responses[phrase][random.Next(responses[phrase].Count)]);
                }
            }

            // If we have any responses from the multi-word phrases check, return them.
            if (responsesToReturn.Count > 0)
            {
                return string.Join("\n", responsesToReturn);
            }

            // If no multi-word phrases matched, proceed with checking individual words.
            List<string> words = lowerInput
                                  .Split(new char[] { ' ', ',', '.', '?' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Where(word => !ignoreWords.Contains(word)) // Ignore common words
                                  .ToList();

            // Find keywords that match the stored responses.
            List<string> matchedKeywords = words.Where(word => responses.ContainsKey(word)).ToList();

            // If there are matched keywords, return random responses for each matched keyword.
            if (matchedKeywords.Count > 0)
            {
                List<string> selectedResponses = matchedKeywords
                    .Select(keyword => responses[keyword][random.Next(responses[keyword].Count)])
                    .ToList();

                return string.Join("\n", selectedResponses); // Join selected responses with a newline
            }

            // If no matched keywords or phrases, return a default message.
            return "I'm sorry, I don't have an answer for that yet. Try asking something else about cybersecurity!";
        }

    }
}




