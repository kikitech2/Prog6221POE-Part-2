# Guardians of your Intergrity - CyberAwarenessBot

 (note : part three is the CyberAwarenessBotGUI1 folder and the program.cs and UIHelper.cs in the part 1 folder.)

## Project Description - PART 1
I developed a C# command-line application that functions as a basic Cybersecurity Awareness Chatbot to provide an interactive cybersecurity awareness to all South Africans. It features specialized modules for Phishing emails, Password Security, and Safe Browsing ( recognising suspicious links ) in a meaningful way to educate users on various forms of cyberattacks that targets individuals, businesses and governmnet institutions.

# Features
- ##Multimedia##: A Personalized voice greeting ('greeting.wav') and a ASCII art logo called Guardians of your Integrity - SA's leading CyberAwarenessBot.
- ##Enhanced UI##: Theres a custom typing feature displaying a color-coded status, and professional dividers.
- ##Continuous Integration: Automated build testing via GitHub Actions.

## Setup & Usage Instructions
1. I cloned the respository to my local machine.
2. The 'greeting.wav' file is located in the root directory.
3. Open the 'Prog Poe Part 1.sln' file in the Visual Studio.
4. Press ##F5## or click ##Start## to run the application.
5. Each Part has been pushed to GitHub with the link submitted on Arc.
6. Continuous Integration (CI) implemented through GitHub Actions and Workflow i have provided a screenshot.
7. I produced a video presentation of my code for Part 1 demonstrating a full explanation of my code running and provided an unlisted Youtube video with my personalized voice.

## CI Workflow Status
<img width="938" height="615" alt="image" src="https://github.com/user-attachments/assets/8f35ee9a-ef5c-4e45-8c4c-268bbfe02921" />

## Project Description - PART 2
For Part 2 I developed a Graphical User Interface (GUI) that handles the dynamic responses, sentiment detection and Memory storage of the appliaction. I expanded my Cybersecurity Awareness Chatbot named "Guardians of Your Integrity" to engage more with the user to recall information shared between the bot and the user and have implemented a sentiment detection that allows the chatbot to match the various tones of the user to make it more user-friendly and simulates a natural conversation flow that is interactive until the user decides to exit the application.

# Features
- ##Multimedia##: The Personalized voice greeting ('greeting.wav') has been incorporated into the GUI Interface and also displays a text of the voice greeting for users that suffer from any hearing or chooses to understand subtitles better. The ASCII art logo called Guardians of your Integrity - SA's leading CyberAwarenessBot.
- ##Enhanced UI##: Theres a custom typing feature displaying a color-coded status, and professional dividers.
- ##Continuous Integration##: Automated build testing via GitHub Actions.
- ##GUI Design##: Is neatly situated with proper spacing and design elements. The logo is in a bright Cyan color that is supported with a dark background to give that galaxy appeal and makes the logo stand out better.
- ##Implementation##: The ASCII art is translated effectively into the GUI application.
- ##Keyword Recogintion##: The chatbot is designed to recoginse and respond to specific related topics and general inquiries. For example: "phishing", "passwords", "2fa", "mfa", "randsomeware", "spyware", etc. This responses provide guidance on each personalised response made by the user.
- ##Random Responses##: The chatbot selects one of several informative responses and uses the List collection method to manage these responses effectively to keep interactions varied and engaging.
- ##Conversation Flow##: The chatbot maintains the flow of converations between the user and the bot so if there is an instance that the user is confused, misspelling or asks for more details the chatbot is designed to continue the current topic and not restart or end the program.
- ##Memory and Recall##: The memory feature allows the chatbot to remeber users information that can be used later in the conversation as it is designed to store certain information provided by the user.
- ##Sentiment Detecion##: Chatbot is designed to create empathetic interactions between the user when they express emotions like "scared", "safe", "devasted", etc. To enable words of encouragement as well as advising them to stay calm under pressure about a certain topic.
- ##Error Handling##: The chatbot is designed function smoothly when it encounters unexpected inputs and finds it hard to read keywords.Therefore the program has default responses and keywords for those instances to avoid the program from crashing.

  ## Setup & Usage Instructions
1. Open the 'Prog Poe Part 1.sln' file in the Visual Studio.
2. Press ##F5## or click ##Start## to run the application.
3. The greeting.wav is in the prog part 1 folder.
4. Click the green start button and the user is welcomed by an audio track that is played immmediately.
5. The terminal screen should display a perfectly aligned GUARDIANS ASCII banner. Below the the header it will display the subtitle of the greeting that matches the recording. Exactly- Bot: Hello! I am your Cybersecurity Awareness Assistant, What is your name? And underneath it will show the system memory register that proves the first phase that has been excuted successfully.
6. The user can test cybersecurity topics like phishing and the bot should display a warning message or if the user chooses ransomeware the bot gives a critical alert and if the user chooses the 2FA/MFA the bot gives educational advice.
7. They system has the sentiment analyser that gets shown underneath the bots responses.
8. Finally once the user chooses to clear it will remove all conversation hisory and if the user wishes to exit , the program ends.
9. Each Part has been pushed to GitHub with the link submitted on Arc.
10. Continuous Integration (CI) implemented through GitHub Actions and Workflow i have provided a screenshot.
11. I produced a video presentation of my code for Part 2 demonstrating a full explanation of my code running and provided an unlisted Youtube video with my personalized voice.

## ASCII Art Image
<img width="502" height="378" alt="image" src="https://github.com/user-attachments/assets/27520e27-92e2-4c86-9078-f99295fc012c" />

## Part 3

In my Part 3, i enhanced the exisiting GUI from my part 2 with additional functionalities that allows users to control the GUI. This Cyberawareness GUI-based console application is designed on the c# and WPF platform to educate users on the ditgital safety when interacting with various tasks, quizzes and automated assistance. 

## Setup Instructions
- This project is running on the Visual Studio 2022 with the .NET Desktop Development workload installed.
- External pakage - NuGet package for the microsoft SQL.
- SQL Server Express
- SQL Server Management Studio for the database management.
- The name of the database is CyberAwarenessDB and it links to the DatabaseHelper.cs project in Visual studios.

## Features
- Task Management - The task assistant is the MySQL that stores the users cybersecurity tasks and manage their data. This adds, tracks, and complete security-focused tasks with a persistent SQL backend.
- The Cybersecurity mini quiz - test users knowledge of cybersecurity that consists of 10 questions that covers topics like phishing, password safety, safe browsing, and social engineering that are formated as a multiple choice based quiz platform where the quiz will generate the score at the end of the quiz.
- The NLP in the chatbot is designed to recognise various tasks to add reminders or keyword detection to help with.
- ActivityLogging is automatic recording of user actions providing a transparent audit trail of the session.

## Walkthrough
- Launch the application
- System message appears in the chatlog which confirms that the UI is activated.
- Exisiting data will appear which shows that the application is connected to the SQL database.
- Audio greeting
- Enter user name
- Task Assistant - The user can insert the task title and description on the right side of the GUI as well as moving the 'Day' slider and click on Add task.
- The new task will appear in the DataGrid immediately. Stat labels like total,pending and completed will automatically be updated when the user decides to interact with the controls.
- User can click on 'Complete' when they have uploaded a new task.
- This is all controlled by the activity logger whenever a user makes a query. And the list of recent actions will appear in the chat log.
- The user can also which sides to ask the chatbot questions on the left side of the GUI about 'phishing' or 'passwords'
- The user can also go type 'quiz' into the chatbox where the user will enter a mini game on various cybersecurity questions.
- The user can type exit into the chatbox whenever they want to leave.

  <img width="1475" height="916" alt="image" src="https://github.com/user-attachments/assets/3550999f-4818-4cc3-bc03-74fa07e58d58" />




  
## Youtube link
- YOUTUBE LINK : https://youtu.be/gvz8vB6jWzQ
- YOUTUBE LINK PART 2: https://youtu.be/emr358NgIAg
## References
Troelsen, A. and Japikse, P. (2021). Pro C# 9 with .NET 5: Foundational Principles and Practices in Programming. 10th edn. New York: Apress.
.
