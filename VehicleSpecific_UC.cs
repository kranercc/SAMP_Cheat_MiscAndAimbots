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
    public partial class VehicleSpecific_UC : UserControl
    {
        Cheaturi cheats;
        public VehicleSpecific_UC()
        {
            InitializeComponent();
            cheats = new Cheaturi();
            cheats.init();
        }

        Thread autoRepair;

        private void toggle_auto_repair_OnValueChange(object sender, EventArgs e)
        {
            if (underlineAutoRepair.LineColor != Color.ForestGreen)
            {
                autoRepair = new Thread(() => cheats.Auto_Repair());
                autoRepair.Start();
                underlineAutoRepair.LineColor = Color.ForestGreen;

            }
            else
            {
                autoRepair.Abort();
                underlineAutoRepair.LineColor = Color.DimGray;

            }
        }

        private void labelNeverExplode_Click(object sender, EventArgs e)
        {
            
        }


        Thread autoExplode;
        private void labelAutoExplodeCar_Click(object sender, EventArgs e)
        {
           
        }

        Thread autowheelrepair_BIKE;
        private void labelWheelRepairBike_Click(object sender, EventArgs e)
        {
           
        }

        private void VehicleSpecific_UC_Load(object sender, EventArgs e)
        {

        }

        Thread rotateCar;
        private void labelAutoFlip_Click(object sender, EventArgs e)
        {
            
        }


        Thread NeverExplode;
        private void toggle_Never_Explode_OnValueChange(object sender, EventArgs e)
        {
            if (underlineNeverExplode.LineColor != Color.ForestGreen)
            {
                NeverExplode = new Thread(() => cheats.Never_Explode());
                NeverExplode.Start();
                underlineNeverExplode.LineColor = Color.ForestGreen;

            }
            else
            {
                NeverExplode.Abort();
                underlineNeverExplode.LineColor = Color.DimGray;

            }
        }


        private void labelNeverExplode_Click_1(object sender, EventArgs e)
        {
           
        }

        private void labelDriveOnWater_Click(object sender, EventArgs e)
        {
            
        }

        Thread infiniteNos;
        private void labelInfiniteNOS_Click(object sender, EventArgs e)
        {
            
        }

        private void labelAllcarshaveNOS_Click(object sender, EventArgs e)
        {
           
        }

        private void labelPerfectHandling_Click(object sender, EventArgs e)
        {
            
        }

        private void labelPerfectTraction_Click(object sender, EventArgs e)
        {
            
        }

        Thread car_wheel_autorepair;
        private void labelWheelRepairCar_Click(object sender, EventArgs e)
        {
            
        }

        private void label_car_levitation_Click(object sender, EventArgs e)
        {
            
        }

        private void toggle_Explode_Vehicle_OnValueChange(object sender, EventArgs e)
        {

        }

        private void labelExplodeCar_Click(object sender, EventArgs e)
        {

        }

        private void toggle_auto_explode_vehicle_OnValueChange(object sender, EventArgs e)
        {
            if (underlineAutoExplodeVehicle.LineColor != Color.ForestGreen)
            {
                autoExplode = new Thread(() => cheats.Explode_car(true));
                autoExplode.Start();
                underlineAutoExplodeVehicle.LineColor = Color.ForestGreen;

            }
            else
            {
                autoExplode.Abort();
                underlineAutoExplodeVehicle.LineColor = Color.DimGray;

            }
        }

        private void AutoWheelRepairCar_OnValueChange(object sender, EventArgs e)
        {
            if (underlineWheelRepairCar.LineColor != Color.ForestGreen)
            {
                car_wheel_autorepair = new Thread(() => cheats.Car_wheels_autorepair());
                car_wheel_autorepair.Start();
                underlineWheelRepairCar.LineColor = Color.ForestGreen;

            }
            else
            {
                car_wheel_autorepair.Abort();
                underlineWheelRepairCar.LineColor = Color.DimGray;

            }
        }

        private void ToggleAutoWheelRepairBike_OnValueChange(object sender, EventArgs e)
        {
            if (underlineWheelRepairBike.LineColor != Color.ForestGreen)
            {
                autowheelrepair_BIKE = new Thread(() => cheats.Bike_wheels_autorepair());
                autowheelrepair_BIKE.Start();
                underlineWheelRepairBike.LineColor = Color.ForestGreen;

            }
            else
            {
                autowheelrepair_BIKE.Abort();
                underlineWheelRepairBike.LineColor = Color.DimGray;

            }
        }

        private void toggleInfiniteNos_OnValueChange(object sender, EventArgs e)
        {
            if (underlineInfiniteNOS.LineColor != Color.ForestGreen)
            {
                infiniteNos = new Thread(() => cheats.Infinite_NOS());
                infiniteNos.Start();
                underlineInfiniteNOS.LineColor = Color.ForestGreen;

            }
            else
            {
                infiniteNos.Abort();
                underlineInfiniteNOS.LineColor = Color.DimGray;

            }
        }

        private void toggleAllCarsHaveNos_OnValueChange(object sender, EventArgs e)
        {
            if (underlineAllcarshaveNOS.LineColor != Color.ForestGreen)
            {
                cheats.All_Cars_Have_NOS("1");
                underlineAllcarshaveNOS.LineColor = Color.ForestGreen;

            }
            else
            {
                cheats.All_Cars_Have_NOS("0");
                underlineAllcarshaveNOS.LineColor = Color.DimGray;

            }
        }

        private void toggleDriveOnWater_OnValueChange(object sender, EventArgs e)
        {
            if (underlineDriveOnWater.LineColor != Color.ForestGreen)
            {
                cheats.Drive_on_water("1");
                underlineDriveOnWater.LineColor = Color.ForestGreen;

            }
            else
            {
                cheats.Drive_on_water("0");
                underlineDriveOnWater.LineColor = Color.DimGray;

            }
        }

        private void toggleRotateCar_OnValueChange(object sender, EventArgs e)
        {
            if (underlineRotateCar.LineColor != Color.ForestGreen)
            {
                rotateCar = new Thread(() => cheats.RotateCar());
                rotateCar.Start();
                underlineRotateCar.LineColor = Color.ForestGreen;

            }
            else
            {
                rotateCar.Abort();
                underlineRotateCar.LineColor = Color.DimGray;

            }
        }

        private void toggleImprovedTraction_OnValueChange(object sender, EventArgs e)
        {
            if (underlineImprovedTraction.LineColor != Color.ForestGreen)
            {
                cheats.Improved_Traction(true);
                underlineImprovedTraction.LineColor = Color.ForestGreen;

            }
            else
            {
                cheats.Improved_Traction(false);
                underlineImprovedTraction.LineColor = Color.DimGray;

            }
        }

        private void togglePerfectHandling_OnValueChange(object sender, EventArgs e)
        {
            if (underlinePerfectHandling.LineColor != Color.ForestGreen)
            {
                cheats.Perfect_Handling("1");
                underlinePerfectHandling.LineColor = Color.ForestGreen;

            }
            else
            {
                cheats.Perfect_Handling("0");
                underlinePerfectHandling.LineColor = Color.DimGray;

            }
        }

        Thread carLevitation;
        private void toggleCarLevitation_OnValueChange(object sender, EventArgs e)
        {
            if (underline_car_levitation.LineColor != Color.ForestGreen)
            {

                carLevitation = new Thread(() => { cheats.Car_Levitation(); });
                carLevitation.Start();

                    
                underline_car_levitation.LineColor = Color.ForestGreen;
                             
            }
            else
            {
                cheats.gta_san_adreas_Process.Kill();
                MessageBox.Show("SAMP closed to protect the account! \nReopen The Cheat!");
                System.Diagnostics.Process.GetCurrentProcess().Kill();

                underline_car_levitation.LineColor = Color.DimGray;

            }
        }
    }
}
//    Thread standardTCPServerThread = new Thread(() => standardServerThread.Start(/* whatever arguments */));
