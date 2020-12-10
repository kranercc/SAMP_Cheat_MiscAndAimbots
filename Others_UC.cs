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
    public partial class Others_UC : UserControl
    {
        Cheaturi cheats;
        public Others_UC()
        {
            InitializeComponent();
            cheats = new Cheaturi();
            cheats.init();

         
           
        }

        Thread autoTeleportToCheckPoint;
        private void labelAutoTeleportToCheckpoint_Click(object sender, EventArgs e)
        {
            
        }

        private void labelTeleportToCheckpoint_Click(object sender, EventArgs e)
        {
            
        }

        private void labelOnlyWheels_Click(object sender, EventArgs e)
        {

            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void labelPNSFree_Click(object sender, EventArgs e)
        {

        }

        Thread accuracy;
        private void labelNobulletSpread_Click(object sender, EventArgs e)
        {
            
        }

        private void labelInfiniteAmmo_Click(object sender, EventArgs e)
        {
            

        }

        private void trackBar_Gravity_Scroll(object sender, EventArgs e)
        {
            
        }

        private void trackBar_Brightness_Scroll(object sender, EventArgs e)
        {
            
        }

        private void label_enable_aimbot_Click(object sender, EventArgs e)
        {
           
        }

        private void label_Disable_Fps_Limit_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void toggleOnlyWheels_OnValueChange(object sender, EventArgs e)
        {
            if (underlineOnlyWheels.LineColor != Color.ForestGreen)
            {
                cheats.Wheels_only("1");
                underlineOnlyWheels.LineColor = Color.ForestGreen;

            }
            else
            {
                cheats.Wheels_only("0");
                underlineOnlyWheels.LineColor = Color.DimGray;

            }
        }

        private void togglePnsFree_OnValueChange(object sender, EventArgs e)
        {
            if (underlinePnSFree.LineColor != Color.ForestGreen)
            {
                cheats.PnS_Free("1");
                underlinePnSFree.LineColor = Color.ForestGreen;

            }
            else
            {
                cheats.PnS_Free("0");
                underlinePnSFree.LineColor = Color.DimGray;

            }
        }

        private void toggleDisableFpsLimit_OnValueChange(object sender, EventArgs e)
        {
            if (underline_disable_fps_limit.LineColor != Color.ForestGreen)
            {


                cheats.disable_fps_limiter(true);

                underline_disable_fps_limit.LineColor = Color.ForestGreen;

            }
            else
            {

                cheats.disable_fps_limiter(false);

                underline_disable_fps_limit.LineColor = Color.DimGray;

            }
        }

        Thread plain_aimbot;
        private void toggleAimbot_OnValueChange(object sender, EventArgs e)
        {
            if (underline_aimbot.LineColor != Color.ForestGreen)
            {

                //new Thread(() => cheats.MuzzleAim(cheats.GetClosestEnemy())).Start();


                //new Thread(() => cheats.SmoothAim(cheats.GetClosestEnemy())).Start();

                plain_aimbot = new Thread(() => cheats.AimToPlayer(cheats.GetClosestEnemy()));
                plain_aimbot.Start();

                underline_aimbot.LineColor = Color.ForestGreen;

            }
            else
            {

                plain_aimbot.Abort();
                underline_aimbot.LineColor = Color.DimGray;

            }
        }

        private void toggleAutoTPtoCheckpoint_OnValueChange(object sender, EventArgs e)
        {
            if (underlineAutoTeleportToCheckpoint.LineColor != Color.ForestGreen)
            {
                autoTeleportToCheckPoint = new Thread(() => cheats.teleportToCheckpoint(true));
                autoTeleportToCheckPoint.Start();
                underlineAutoTeleportToCheckpoint.LineColor = Color.ForestGreen;

            }
            else
            {
                autoTeleportToCheckPoint.Abort();
                underlineAutoTeleportToCheckpoint.LineColor = Color.DimGray;

            }
        }

        private void toggleTpToCheckpoint_OnValueChange(object sender, EventArgs e)
        {
            if (underlineTeleportToCheckpoint.LineColor != Color.ForestGreen)
            {
                cheats.teleportToCheckpoint(false);
                underlineTeleportToCheckpoint.LineColor = Color.ForestGreen;

            }
            else
            {
                underlineTeleportToCheckpoint.LineColor = Color.DimGray;

            }
        }

        private void toggleInfiniteAmmo_OnValueChange(object sender, EventArgs e)
        {
            if (underlineInfiniteAmmo.LineColor != Color.ForestGreen)
            {
                cheats.Infinite_Ammo("1");
                underlineInfiniteAmmo.LineColor = Color.ForestGreen;

            }
            else
            {
                cheats.Infinite_Ammo("0");
                underlineInfiniteAmmo.LineColor = Color.DimGray;

            }
        }

        private void toggleNoBulletSpread_OnValueChange(object sender, EventArgs e)
        {
            if (underlineNoBulletSpread.LineColor != Color.ForestGreen)
            {
                accuracy = new Thread(() => cheats.Accuracy());
                accuracy.Start();
                underlineNoBulletSpread.LineColor = Color.ForestGreen;

            }
            else
            {
                accuracy.Abort();
                underlineNoBulletSpread.LineColor = Color.DimGray;

            }
        }

        private void sliderGravity_ValueChanged(object sender, EventArgs e)
        {
            label_gravity.Text = "Gravity: " + cheats.get_Gravity().ToString() + " - SV: " + sliderGravity.Value;
            cheats.set_Gravity(sliderGravity.Value / 1000f);
        }

        private void sliderBrightness_ValueChanged(object sender, EventArgs e)
        {
            label_brightness.Text = "Brightness: " + cheats.get_Brightness().ToString();
            cheats.set_Brightness(sliderBrightness.Value);
        }

        Thread smoothed_aimbot;
        private void toggleSmootashedAimbot_OnValueChange(object sender, EventArgs e)
        {
            if (underlineSmoothedAimbot.LineColor != Color.ForestGreen)
            {

                //new Thread(() => cheats.MuzzleAim(cheats.GetClosestEnemy())).Start();


                //new Thread(() => cheats.SmoothAim(cheats.GetClosestEnemy())).Start();

                smoothed_aimbot = new Thread(() => cheats.SmoothAim(cheats.GetClosestEnemy()));
                smoothed_aimbot.Start();

                underlineSmoothedAimbot.LineColor = Color.ForestGreen;

            }
            else
            {

                smoothed_aimbot.Abort();
                underlineSmoothedAimbot.LineColor = Color.DimGray;

            }
        }
    }
}
