using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;

namespace SAMP_CHEAT_KRANE
{
    public partial class Form1 : Form
    {
        Cheaturi cheats;
        Mem mem;
        int process_ID_San_Andreeas;

        
        public Form1()
        {
            
            InitializeComponent();
            CenterToScreen();
            
            playerSpecific_UC1.Hide();
            vehicleSpecific_UC1.Hide();
            others_UC1.Hide();
            afK___AutoClicker1.Hide();

            

            
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void bunifuTileButtonPlayerSpecific_Click(object sender, EventArgs e)
        {
            others_UC1.Hide();
            afK___AutoClicker1.Hide();
            vehicleSpecific_UC1.Hide();
            playerSpecific_UC1.Show();
        }

        private void bunifuTileButtonVehicles_Click(object sender, EventArgs e)
        {
            others_UC1.Hide();
            playerSpecific_UC1.Hide();
            afK___AutoClicker1.Hide();
            vehicleSpecific_UC1.Show();            
        }

        private void bunifuTileButtonOthers_Click(object sender, EventArgs e)
        {
            playerSpecific_UC1.Hide();
            vehicleSpecific_UC1.Hide();
            afK___AutoClicker1.Hide();
            others_UC1.Show();
        }

        private void tileAFK_Click(object sender, EventArgs e)
        {
            playerSpecific_UC1.Hide();
            vehicleSpecific_UC1.Hide();
            others_UC1.Hide();
            afK___AutoClicker1.Show();

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();

        }
    }
}
