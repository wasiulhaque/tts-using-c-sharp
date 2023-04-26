using System;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace TTS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        SpeechSynthesizer reader = new SpeechSynthesizer();
        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1 != null)
            {
                reader.Dispose();
                reader = new SpeechSynthesizer();
                reader.SpeakAsync(richTextBox1.Text);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string[] words = richTextBox1.Text.Split();
            string currentWord = words[words.Length - 1];
            string lastChar = "";
            if (currentWord != "")
            {
                lastChar = currentWord.Substring(currentWord.Length - 1);

            }
            if (lastChar == "")
            {
                reader.SpeakAsync("space");
            }
            if (lastChar != null)
            {
                reader.SpeakAsync(lastChar);
            }
        }
    }
}
