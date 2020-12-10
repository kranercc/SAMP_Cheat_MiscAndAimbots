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
    public partial class PlayerSpecific_UC : UserControl
    {
        Cheaturi cheats;
        public PlayerSpecific_UC()
        {
            InitializeComponent();

            cheats = new Cheaturi();
            cheats.init();
        }

        private void PlayerSpecific_UC_Load(object sender, EventArgs e)
        {

        }

        private void labelInfiniteRun_Click(object sender, EventArgs e)
        {
            
            

        }

        private void labelInfiniteOxygen_Click(object sender, EventArgs e)
        {
            
        }

        private void player_weight_bar_set_Scroll(object sender, EventArgs e)
        {

        }

        private void toggleJumpSuicide_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void toggleJumpSuicideName_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void metroTrackBarPlayerWeight_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void bunifuSlider_Player_weight_ValueChanged(object sender, EventArgs e)
        {
            bunifuGauge_Player_weight.Value = bunifuSlider_Player_weight.Value;
            cheats.set_Player_Weight(bunifuSlider_Player_weight.Value);
        }

        private void toggleInfiniteRun_OnValueChange(object sender, EventArgs e)
        {
            if (bunifuSeparatorInfiniteRunUnderline.LineColor != Color.ForestGreen)
            {
                cheats.Infinite_run("1");
                bunifuSeparatorInfiniteRunUnderline.LineColor = Color.ForestGreen;

            }
            else
            {
                cheats.Infinite_run("0");
                bunifuSeparatorInfiniteRunUnderline.LineColor = Color.DimGray;

            }
        }
        Thread Infinite_oxygen;

        private void toggle_infinite_oxygen_OnValueChange(object sender, EventArgs e)
        {
            if (underlineInfiniteOxygen.LineColor != Color.ForestGreen)
            {
                Infinite_oxygen = new Thread(() => cheats.Infinite_oxygen());
                Infinite_oxygen.Start();
                underlineInfiniteOxygen.LineColor = Color.ForestGreen;

            }
            else
            {
                Infinite_oxygen.Abort();
                underlineInfiniteOxygen.LineColor = Color.DimGray;

            }
        }

        private void toggle_jump_suicide_OnValueChange(object sender, EventArgs e)
        {
            if (toggle_jump_suicide.Value)
            {
                cheats.Jump_Suicide();
            }

        }
    }
}
