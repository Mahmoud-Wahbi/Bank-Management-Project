using System;
using System.Drawing; // You need to add this line to control fonts
using System.Windows.Forms;
using Business;

namespace Presentation
{
    public partial class frmAIChatBot : Form
    {
        private readonly AiClient _ai;

        public frmAIChatBot()
        {
            InitializeComponent();
            _ai = new AiClient();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string userInput = txtInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(userInput)) return;

            // 1. Display the user's message with its specific format
            AppendMessage("👤 You: ", userInput, Color.DarkBlue, false);

            txtInput.Clear();
            txtInput.Focus();
            btnSend.Enabled = false;

            // 2. Display a "thinking..." message
            AppendMessage("🤖 Bot: ", "Thinking...", Color.Gray, true);

            // This is a simple way to find and remove the last line
            int thinkingStartIndex = txtChat.Text.LastIndexOf("🤖 Bot: Thinking...");
            if (thinkingStartIndex != -1)
            {
                txtChat.Select(thinkingStartIndex, txtChat.Text.Length - thinkingStartIndex);
                txtChat.SelectedText = "";
            }

            try
            {
                AiResponse aiResponse = await _ai.AskAsync(userInput);

                if (!string.IsNullOrEmpty(aiResponse.Reply))
                {
                    // 3. Display the bot's response with full formatting
                    AppendFormattedBotResponse(aiResponse.Reply);
                }
                else
                {
                    AppendMessage("🤖 Bot: ", "I could not understand your request.", Color.Red, false);
                }
            }
            catch (Exception ex)
            {
                AppendMessage("🤖 Error: ", ex.Message, Color.DarkRed, false);
            }
            finally
            {
                btnSend.Enabled = true;
                txtInput.Focus();
            }
        }

        /// <summary>
        /// A function to format and display the bot's response which contains Markdown.
        /// </summary>
        private void AppendFormattedBotResponse(string markdownResponse)
        {
            // Display the start of the message "Bot:"
            AppendMessage("🤖 Bot: ", "", Color.Black, false);

            var lines = markdownResponse.Split(new[] { '\n' }, StringSplitOptions.None);

            foreach (var line in lines)
            {
                // Reset any previous formatting for the new line
                txtChat.SelectionBullet = false;
                txtChat.SelectionIndent = 0;
                txtChat.SelectionFont = new Font("Segoe UI", 11, FontStyle.Regular);
                txtChat.SelectionColor = Color.FromArgb(50, 50, 50); // Dark gray color

                string trimmedLine = line.Trim();

                if (trimmedLine.StartsWith("- "))
                {
                    txtChat.SelectionBullet = true;
                    txtChat.SelectionIndent = 20; // Indentation for the list
                    AppendTextWithBold(trimmedLine.Substring(2) + "\n");
                }
                else if (string.IsNullOrWhiteSpace(trimmedLine))
                {
                    txtChat.AppendText(Environment.NewLine);
                }
                else
                {
                    AppendTextWithBold(trimmedLine + "\n");
                }
            }
            txtChat.AppendText(Environment.NewLine);
            ScrollToBottom();
        }

        /// <summary>
        /// A function that finds and applies **bold** formatting.
        /// </summary>
        private void AppendTextWithBold(string text)
        {
            var parts = text.Split(new[] { "**" }, StringSplitOptions.None);
            for (int i = 0; i < parts.Length; i++)
            {
                // The normal part
                if (i % 2 == 0)
                {
                    txtChat.SelectionFont = new Font("Segoe UI", 11, FontStyle.Regular);
                    txtChat.AppendText(parts[i]);
                }
                // The part that should be bold
                else
                {
                    txtChat.SelectionFont = new Font("Segoe UI", 11, FontStyle.Bold);
                    txtChat.AppendText(parts[i]);
                }
            }
        }

        /// <summary>
        /// A general function to add text with a specific color and font.
        /// </summary>
        private void AppendMessage(string prefix, string message, Color color, bool isItalic)
        {
            txtChat.SelectionStart = txtChat.TextLength;
            txtChat.SelectionLength = 0;

            txtChat.SelectionColor = color;
            var fontStyle = isItalic ? FontStyle.Italic : FontStyle.Bold;
            txtChat.SelectionFont = new Font("Segoe UI", 12, fontStyle);
            txtChat.AppendText(prefix);

            txtChat.SelectionColor = Color.FromArgb(40, 40, 40);
            txtChat.SelectionFont = new Font("Segoe UI", 11, FontStyle.Regular);
            txtChat.AppendText(message + Environment.NewLine + Environment.NewLine);

            ScrollToBottom();
        }

        private void ScrollToBottom()
        {
            txtChat.SelectionStart = txtChat.TextLength;
            txtChat.ScrollToCaret();
        }

        private void frmAIChatBot_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

            AppendFormattedBotResponse("Welcome! I'm your financial assistant. How can I help you today?");

            txtInput.Focus();
        }
    }
}