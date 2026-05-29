using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

// This links your GUI project directly to your original console project files
using CyberAwarenessBot;

namespace CyberAwarenessBotGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Constructor that runs automatically when the program launches
        public MainWindow()
        {
            // Initializes the XAML layout components
            InitializeComponent();

            // Safe call to run your audio file greeting from your original project
            try
            {
                CyberAwarenessBot.UIHelper.PlayGreetingAudio();
            }
            catch (Exception ex)
            {
                // Handles missing file exceptions safely without freezing the interface
            }

            // Add initial greeting logs straight into the main chat box log terminal
            txtChatLog.AppendText("System: CyberAwareness Assistant UI Initialized successfully.\n");
            txtChatLog.AppendText("Bot: Welcome! I am your personal CyberAwareness Assistant. How can I protect you today?\n\n");
        }

        // Action method that executes whenever a user clicks the SEND button
        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            // Only execute if the text entry box is not completely empty
            if (txtUserInput.Text.Trim() != "")
            {
                // Appends the user text message phrase onto the log display screen
                txtChatLog.AppendText("User: " + txtUserInput.Text + "\n");

                // Temporary static bot response to test visual processing flow
                txtChatLog.AppendText("Bot: I've noted that concern down. Let's process that keyword...\n\n");

                // Resets the user text box field so it is clean for the next statement
                txtUserInput.Clear();

                // Automatically positions the scrollbar at the bottom row of text
                ChatScrollViewer.ScrollToBottom();
            }
        }

        // Action method that catches when a key is hit inside the user entry textbox
        private void TxtUserInput_KeyDown(object sender, KeyEventArgs e)
        {
            // If the specific key hit matches the keyboard Enter button
            if (e.Key == Key.Enter)
            {
                // Run the exact same sequence as clicking the SEND button
                BtnSend_Click(this, new RoutedEventArgs());
            }
        }
    }
}
