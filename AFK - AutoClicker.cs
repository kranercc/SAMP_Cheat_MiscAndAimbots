using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SAMP_CHEAT_KRANE
{
    public partial class AFK___AutoClicker : UserControl
    {
        AFK_Cheat afkCheat;
        public AFK___AutoClicker()
        {
            InitializeComponent();

            afkCheat = new AFK_Cheat();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }




        private void buttonEnable_Click(object sender, EventArgs e)
        {
            Thread writeLastLine;
            afkCheat.init();
            writeLastLine = new Thread(() => afkCheat.chatLog());
            writeLastLine.Start();

            timerChat.Enabled = true;
            timerChat.Start();


            Thread moveAround = new Thread(() => afkCheat.moveAround());
            moveAround.Start();

        }

        private void timerChat_Tick(object sender, EventArgs e)
        {

            if(afkCheat.TextLog != "")
            {
                richTextBoxChat.Text += afkCheat.TextLog;
                afkCheat.TextLog = "";
                // set the current caret position to the end
                richTextBoxChat.SelectionStart = richTextBoxChat.Text.Length;
                // scroll it automatically
                richTextBoxChat.ScrollToCaret();

            }




        }


        /*
         * AFK_Cheat afkCheat = new AFK_Cheat();
            Thread writeLastLine;

            writeLastLine = new Thread(() => afkCheat.chatLog(richTextBoxChat));
            writeLastLine.Start();
         */
    }
}
