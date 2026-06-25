using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CyberAwarenessBotGUI1
{
    public partial class QuizWindow : Window
    {
        private int currentIdx = 0;
        private int score = 0;
        // Fixed: Explicit type instead of 'var'

        private List<Question> questions = QuizManager.GetQuestions();

        public QuizWindow()
        {
            InitializeComponent();
            LoadQuestion();
        }

        private void LoadQuestion()
        {
            var q = questions[currentIdx];
            txtQuestion.Text = $"Question {currentIdx + 1}: {q.Text}";
            stackAnswers.Children.Clear();
            txtFeedback.Text = "";
            btnNext.Visibility = Visibility.Collapsed;

            foreach (var option in q.Options)
            {
                Button btn = new Button { Content = option, Margin = new Thickness(5) };
                // Use a local variable to capture the index correctly
                string selectedOption = option;
                btn.Click += (s, e) => CheckAnswer(q.Options.IndexOf(selectedOption));
                stackAnswers.Children.Add(btn);
            }
        }

        private void CheckAnswer(int idx)
        {
            var q = questions[currentIdx];
            if (idx == q.CorrectIndex)
            {
                score++;
                txtFeedback.Text = "Correct! " + q.Explanation;
            }
            else
            {
                txtFeedback.Text = "Wrong. " + q.Explanation;
            }

            foreach (var child in stackAnswers.Children)
                ((Button)child).IsEnabled = false;

            btnNext.Visibility = Visibility.Visible;
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            currentIdx++;
            if (currentIdx < questions.Count)
                LoadQuestion();
            else
                MessageBox.Show($"Quiz Complete! Final Score: {score}/{questions.Count}");
            ActivityLogger.LogAction("Completed Cybersecurity Quiz");
        }
    }
}
