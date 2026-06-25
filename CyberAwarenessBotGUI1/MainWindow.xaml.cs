using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CyberAwarenessBotGUI1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            try { CyberAwarenessBot.UIHelper.PlayGreetingAudio(); }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine("Audio playback issue: " + ex.Message); }

            txtChatLog.AppendText("System: CyberAwareness Assistant UI Initialized successfully.\r\n");
            txtChatLog.AppendText("Bot: Hello! I am your Cyber Security Awareness Assistant. What is your name?\r\n");

            RefreshTaskGrid();
        }
        // this method saves the activity to the log file.

        private void RefreshTaskGrid()
        {
            try
            {
                List<DatabaseHelper.CyberTask> activeTasks = DatabaseHelper.GetAllTasks();
                dgTasks.ItemsSource = null;
                dgTasks.ItemsSource = activeTasks;

                int totalTasksCount = activeTasks.Count;
                int completedTasksCount = 0;
                int pendingTasksCount = 0;

                foreach (var task in activeTasks)
                {
                    if (task.IsCompleted) completedTasksCount++;
                    else pendingTasksCount++;
                }

                lblTotalCount.Text = totalTasksCount.ToString();
                lblPendingCount.Text = pendingTasksCount.ToString();
                lblCompletedCount.Text = completedTasksCount.ToString();
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine("DataGrid refresh issue: " + ex.Message); }
        }

        private void BtnFormAdd_Click(object sender, RoutedEventArgs e)
        {
            string title = txtFormTitle.Text.Trim();
            string desc = txtFormDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Please enter a valid Security Task Title.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtFormTitle.Focus();
                return;
            }

            try
            {
                int selectedDays = Convert.ToInt32(sliderDays.Value);
                DatabaseHelper.AddTask(title, desc, selectedDays);

                // Track this action
                ActivityLogger.LogAction($"Task Added: '{title}'");

                txtChatLog.AppendText($"[System]: Successfully added task: {title}\r\n");
                ChatScrollViewer.ScrollToEnd();

                txtFormTitle.Clear();
                txtFormDescription.Clear();
                sliderDays.Value = 7;
                RefreshTaskGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnVisualComplete_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button triggerButton && triggerButton.Tag != null)
            {
                int recordId = Convert.ToInt32(triggerButton.Tag);
                DatabaseHelper.CompleteTask(recordId);
                txtChatLog.AppendText($"[Dashboard Event]: Task ID {recordId} flagged as COMPLETED.\r\n");
                RefreshTaskGrid();
            }
        }

        private void BtnVisualDelete_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button triggerButton && triggerButton.Tag != null)
            {
                int recordId = Convert.ToInt32(triggerButton.Tag);
                DatabaseHelper.DeleteTask(recordId);
                txtChatLog.AppendText($"[Dashboard Event]: Task ID {recordId} purged from records.\r\n");
                RefreshTaskGrid();
            }
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e) => ProcessChatInput();

        private void TxtUserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) ProcessChatInput();
        }

        private void ProcessChatInput()
        {
            string rawInput = txtUserInput.Text.Trim();
            if (string.IsNullOrEmpty(rawInput)) return;

            txtChatLog.AppendText("You: " + rawInput + "\r\n");
            string inputLower = rawInput.ToLower();

            if (inputLower =="exit" || inputLower =="quit")
                    {
                txtChatLog.AppendText("Bot: Goodbye! Staying secure is a continuous journey...");
                ActivityLogger.LogAction("User exited the application.");
                System.Windows.Application.Current.Shutdown();
                return;
            }

            // 1. INTERCEPT: Activity Log Check
            if (inputLower.Contains("show activity log") || inputLower.Contains("what have you done"))
            {

                var recentLogs = ActivityLogger.GetRecentLogs(10);
                string response = "Here is a summary of recent actions:\n" + string.Join("\n", recentLogs);
                txtChatLog.AppendText("Bot: " + response + "\r\n");
            }
            // 2. EXISTING ENGINE: Proceed to your UIHelper logic
            else
            {
                string responseBot = "";
                try { responseBot = CyberAwarenessBot.UIHelper.GetResponse(rawInput); }
                catch { responseBot = "System input processed successfully."; }
                txtChatLog.AppendText("Bot: " + responseBot + "\r\n");
            }

            txtUserInput.Clear();
            ChatScrollViewer.ScrollToEnd();
            RefreshTaskGrid();
        }
    }
}
