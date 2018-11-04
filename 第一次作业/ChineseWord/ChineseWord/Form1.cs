using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Microsoft.International.Converters.PinYinConverter;
using Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter;
using DotNetSpeech;

namespace ChineseWord
{
    public partial class ChineseWord : Form
    {
        public ChineseWord()
        {
            InitializeComponent();
        }

        private void buttonGetPinYin_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim().Length == 0)
            {
                return;
            }
            string pin_str = "";
            foreach (char one_char in textBox1.Text.Trim().ToCharArray())
            {
                int ch_int = (int)one_char;
                string str_char_int = string.Format("{0}", ch_int);
                if (ch_int > 127)
                {
                    ChineseChar ch = new ChineseChar(one_char);
                    ReadOnlyCollection<string> pinyin = ch.Pinyins;
                    foreach (string pin in pinyin)
                    {
                        pin_str += pin;
                    }
                }
            }
            textBox2.Text = pin_str;
        }

        private void ChineseChar_Load(object sender, EventArgs e)
        {

        }

        private void buttonTtoS_Click(object sender, EventArgs e)
        {
            textBox2.Text = ChineseConverter.Convert(textBox1.Text.Trim(), ChineseConversionDirection.TraditionalToSimplified);
        }

        private void buttonStoT_Click(object sender, EventArgs e)
        {
            textBox2.Text = ChineseConverter.Convert(textBox1.Text.Trim(), ChineseConversionDirection.SimplifiedToTraditional);
        }

        private void buttonTTS_Click(object sender, EventArgs e)
        {
            try
            {
                SpeechVoiceSpeakFlags spFlags = SpeechVoiceSpeakFlags.SVSFlagsAsync;
                SpVoice voice = new SpVoice();
                voice.Speak(textBox1.Text.Trim(), spFlags);
            }
            catch(Exception except){
                MessageBox.Show(except.Message);
            }
        }
    }
}
