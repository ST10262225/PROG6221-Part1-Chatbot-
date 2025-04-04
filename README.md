Chatbot project

*Summary The program developed in C# is a console focused chatbot application. The chatbot centers on conversation with the users giving responses according to the recognized keywords relevant to cybersecurity.

*Specifications

Receives user input and performs keyword analysis
Provides responses according to the matched keywords
Displays messages in different colors for clarity of the text
Validates user input according to pre-set criteria (for example, length of the name, handling of the password reply)
*Requirements

.NET 6.0 or later
A C# compatible IDE (e.g., Visual Studio, Visual Studio Code)
Windows, macOS, or Linux with .NET installed
*Usage

Run the application in the terminal.
Enter your name (must be at least 3 letters and contain only alphabetic characters).
Type a question or keyword related to cybersecurity.
The chatbot will analyze your input and respond accordingly.
If the input is too long (more than 500 characters) or too short (less than 3 characters), the chatbot will ask you to be more concise.
*Code structure Program.cs - Initializes the chatbot (welcome message, name validation). - Handles user input (checks for empty/long responses). - Processes responses (matches keywords, changes text colors). - Manages password validation (tracks if password response was handled). - Runs a continuous loop (allows ongoing conversation until exit).

Filterbot.cs - Filters and processes user input to detect inappropriate or restricted words. - Checks for keyword matches to determine appropriate responses. - Handles password-related responses and tracks if they have been addressed. - Ensures user input meets specific criteria (e.g., name validation, message length limits). - Manages response customization like changing text colors for better readability.
