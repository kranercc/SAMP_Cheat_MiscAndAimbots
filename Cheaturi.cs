using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memory;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
namespace SAMP_CHEAT_KRANE
{
    class Cheaturi
    {
        Cheaturi cheats;
        Mem mem;
        int process_ID_San_Andreeas;

        public Process gta_san_adreas_Process;

        Helper_Funcs helpers = new Helper_Funcs();

        public void init()
        {
            mem = new Mem();
            while (true)
            {
                try
                {
                    gta_san_adreas_Process = Process.GetProcessesByName("gta_sa")[0];
                    process_ID_San_Andreeas = Process.GetProcessesByName("gta_sa")[0].Id;

                    mem.OpenProcess(process_ID_San_Andreeas);
                    break;
                }
                catch (Exception)
                {
                    MessageBox.Show("Samp Not Open");
                }
            }
        }

        [DllImport("user32.dll", SetLastError = true)]

        public static extern short GetAsyncKeyState(int vKey);
        const int VK_LEFTARROW = 0x25;
        const int VK_RIGHTARROW = 0x27;
        /*
         * Pointeri
         */

        string frame_limiter_PTR = "0xBA6794"; //byte - 1 on - 0 off

        string Brightness_PTR = "0xBA6784"; //4bytes
        string Gravity_PTR = "0x863984"; //float

        string All_cars_have_nos_PTR = "0x969165";
        string perfect_handling_PTR = "0x96914C";
        string perfect_accuracy_PTR = "gta_sa.exe+0x77CDC8";
        string drive_on_water_PTR = "0x969152";
        string nos_remaining_PTR = "0xBA18FC,0x8A4";
        string pns_free_PTR = "0x96C009"; //byte 0 1
        string traction_level_PTR = "0xBA18FC,0x94";

        string infinite_ammo_PTR = "0x969178";
        string infinite_run_PTR = "0xB7CEE4";
        string infinite_oxygen_PTR = "gta_sa.exe+77CDE0";


        string wheels_only_PTR = "0x96914B";
        string car_health = "0xBA18FC,4C0";
        string car_burn_time_PTR = "0xBA18FC,8E4";


        string[] vehicle_rotation_axis = { "0xBA18FC,14,0", "0xBA18FC,14,4", "0xBA18FC,14,8" };
        string vehicle_speed_X_axis_Rotate = "0xBA18FC,50";
        string Current_Vehicle_PTR = "0xBA18FC";
        string nearestCar = "0xB6F5F0,C0";

        //markergta_sa.exe+7A8774
        string[] marker_coordonates = { "gta_sa.exe+7A8770", "gta_sa.exe+7A8774" };

        //checkpoint
        string[] checkpoint_coordonates = { "gta_sa.exe+87DEC8", "gta_sa.exe+87DECC", "gta_sa.exe+87DED0" };


        //my player
        string[] position_x_y_z = { "0xB6F5F0,14,30", "0xB6F5F0,14,34", "0xB6F5F0,14,38" };
        string[] vehicle_position_x_y_z = { "0xBA18FC,14,30", "0xBA18FC,14,34", "0xBA18FC,14,38" };
        string[] position_crosshair_x_y = { "gta_sa.exe+76F258", "gta_sa.exe+76F248" };
        string ptr_player_weight = "0xB6F5F0,8C"; // float
        string ptr_player_health = "0xB6F5F0,540";

        //play list
        List<string> PlayerList;
        List<string> player_and_position;

        //Bike Specific
        string front_bike_tire = "0xBA18FC,65D";
        string rear_bike_tire = "0xBA18FC,65C";

        //car specific
        string[] car_tire_offsets = { "5a5", "5a6", "5a7", "5a8" }; //byte 0 repair 1 flat

        //obj list
        //pool start 0xB7CD98  + 320 fiecare
        string PlayerStartPool = "0xB7CD98";
        int playerStartPool_INC;


        //
        // PLAYER SPECIFIC 
        //
        #region Player Specific


        public void Infinite_run(string YES_NO)
        {
            mem.writeMemory(infinite_run_PTR, "byte", YES_NO);
        }

        public void Infinite_oxygen()
        {

            while (true)
            {
                Thread.Sleep(1000 / 60);
                float oxygenLevel = mem.readFloat(infinite_oxygen_PTR);

                if (oxygenLevel < 1000)
                {
                    mem.writeMemory(infinite_oxygen_PTR, "float", "3900");
                }
            }


        }

        public void Infinite_Ammo(string YES_NO)
        {
            mem.writeMemory(infinite_ammo_PTR, "byte", YES_NO);
        }

        public void set_Player_Weight(int weight_in_kg)
        {
            mem.writeMemory(ptr_player_weight, "float", weight_in_kg.ToString());
        }

        public float get_Player_Weight()
        {
            return mem.readFloat(ptr_player_weight);
        }


        public void Jump_Suicide()
        {
            float playerWeight = mem.readFloat(ptr_player_weight);

            new Thread(() => {

                while (true)
                {
                    if (mem.readFloat(ptr_player_health) > 0)
                    {
                        mem.writeMemory(ptr_player_weight, "float", "-1");
                    }
                    else
                    {
                        mem.writeMemory(ptr_player_weight, "float", playerWeight.ToString());
                        break;
                    }
                }

            }).Start();
            

        }

        #endregion


        //
        // Vehicle Specific
        //

        #region Vehicle Specific


        public void All_Cars_Have_NOS(string YES_NO)
        {
            mem.writeMemory(All_cars_have_nos_PTR, "byte", YES_NO);
        }
        public void Perfect_Handling(string YES_NO)
        {
            mem.writeMemory(perfect_handling_PTR, "byte", YES_NO);
        }
        public void Improved_Traction(bool YES_NO)
        {
            if (YES_NO)
            {
                mem.writeMemory(traction_level_PTR, "float", "0.5");
            }
            else
            {
                mem.writeMemory(traction_level_PTR, "float", "1");
            }
        }
        public void Infinite_NOS()
        {
            while (true)
            {
                Thread.Sleep(1000 / 60);
                float current_nos_level = mem.readFloat(nos_remaining_PTR);

                if (current_nos_level < -0.8)
                {
                    mem.writeMemory(nos_remaining_PTR, "float", "-0.1");
                }
            }
        }
        public void Drive_on_water(string YES_NO)
        {
            mem.writeMemory(drive_on_water_PTR, "byte", YES_NO);
        }
        public void Auto_Repair()
        {
            while (true)
            {
                float current_car_health = mem.readFloat(car_health);
                System.Threading.Thread.Sleep(1000 / 100);
                if (current_car_health < 700)
                {
                    mem.writeMemory(car_health, "float", "999");
                }

            }
        }
        public void Never_Explode()
        {
            while (true)
            {
                float carBurnTime = mem.readFloat(car_burn_time_PTR);
                Thread.Sleep(1000 / 60);

                if (carBurnTime > 0)
                {
                    mem.writeMemory(car_burn_time_PTR, "float", "1000");
                }
                else
                {

                }
            }
        }
        public void Explode_car(bool auto)
        {
            if (auto == false)
            {
                mem.writeMemory(car_health, "float", "0");
            }

            else
            {
                while (true)
                {
                    mem.writeMemory(car_health, "float", "0");
                }
            }
        }
        public void Bike_wheels_autorepair()
        {
            while (true)
            {
                int[] bikeWheelHP = { mem.readByte(front_bike_tire), mem.readByte(rear_bike_tire) };
                System.Threading.Thread.Sleep(1000 / 60);

                if (bikeWheelHP[0] == 1 || bikeWheelHP[1] == 1)
                {
                    mem.writeMemory(front_bike_tire, "byte", "0");
                    mem.writeMemory(rear_bike_tire, "byte", "0");
                }
            }
        }
        public void Car_wheels_autorepair()
        {
            while (true)
            {
                int[] car_wheel_hp = { mem.readByte(car_tire_offsets[0]), mem.readByte(car_tire_offsets[1]), mem.readByte(car_tire_offsets[2]), mem.readByte(car_tire_offsets[3]) };
                System.Threading.Thread.Sleep(1000 / 60);

                if (car_wheel_hp[0] == 1 || car_wheel_hp[1] == 1 || car_wheel_hp[2] == 1 || car_wheel_hp[3] == 1)
                {
                    mem.writeMemory(car_tire_offsets[0], "byte", "0");
                    mem.writeMemory(car_tire_offsets[1], "byte", "0");
                    mem.writeMemory(car_tire_offsets[2], "byte", "0");
                    mem.writeMemory(car_tire_offsets[3], "byte", "0");

                }
            }
        }
        public void RotateCar()
        {

            while (true)
            {
                Thread.Sleep(1000 / 60);
                float current_XRotation_speed = mem.readFloat(vehicle_speed_X_axis_Rotate);
                //monitor keypress 
                if (GetAsyncKeyState(VK_LEFTARROW) != 0)
                {
                    float newSpeed = current_XRotation_speed + (-0.01f);
                    mem.writeMemory(vehicle_speed_X_axis_Rotate, "float", newSpeed.ToString());
                }

                if (GetAsyncKeyState(VK_RIGHTARROW) != 0)
                {
                    float newSpeed = current_XRotation_speed + 0.01f;
                    mem.writeMemory(vehicle_speed_X_axis_Rotate, "float", newSpeed.ToString());

                }


            }
        }


        public void Car_Levitation()
        {
            string accelerationNS = "0xBA18FC,0x4C";

            while (true)
            {
                Thread.Sleep(1000 / 60);

                mem.writeMemory(accelerationNS, "float", "0.6");

            }
            
        }
        #endregion

        //
        //  Others
        //

        #region Other Options

        public void teleportToPlayer(string playerAddrs)
        {

            float x = mem.readFloat(playerAddrs + ",14,30");
            float y = mem.readFloat(playerAddrs + ",14,34");
            float z = mem.readFloat(playerAddrs + ",14,38");

            mem.writeMemory(position_x_y_z[0], "float", x.ToString());
            mem.writeMemory(position_x_y_z[1], "float", y.ToString());
            mem.writeMemory(position_x_y_z[2], "float", z.ToString());


        }



        public void AFK_fall_time()
        {
            bool platform = false;
            float platform_level = 0.0f;

            bool thread_started = false;
            while (true)
            {

                if (GetAsyncKeyState(0x21) != 0)
                {
                    if (platform_level == 0.0f)
                    {
                        if (mem.readInt(Current_Vehicle_PTR) == 0)
                        {
                            platform_level = mem.readFloat(position_x_y_z[2]) + 1.0f;
                        }
                        else
                        {
                            platform_level = mem.readFloat(vehicle_position_x_y_z[2]) + 1.0f;
                        }

                    }
                    else
                    {
                        platform_level += 1.0f;
                    }
                    Thread.Sleep(100);

                }
                if (GetAsyncKeyState(0x22) != 0)
                {
                    if (platform_level == 0.0f)
                    {
                        if (mem.readInt(Current_Vehicle_PTR) == 0)
                        {
                            platform_level = mem.readFloat(position_x_y_z[2]) - 1.0f;
                        }
                        else
                        {
                            platform_level = mem.readFloat(vehicle_position_x_y_z[2]) - 1.0f;
                        }
                    }
                    else
                    {
                        platform_level -= 1.0f;
                    }

                    Thread.Sleep(100);

                }

                 

                Thread platform_thread = null; 

                if (!thread_started && platform_level != 0.0f)
                {
                    platform_thread = new Thread(() =>
                    {
                        while (true)
                        {
                            if (mem.readInt(Current_Vehicle_PTR) == 0)
                            {
                                mem.writeMemory(position_x_y_z[2], "float", (platform_level).ToString());

                            }
                            else
                            {
                                mem.writeMemory(vehicle_position_x_y_z[2], "float", (platform_level).ToString());
                            }
                            Thread.Sleep(100);
                            if (GetAsyncKeyState(0x20) != 0)
                            {
                                try
                                {
                                    thread_started = false;
                                    platform_level = 0.0f;
                                    break;
                                }
                                catch
                                {
                                    MessageBox.Show("couldn't abort thread");
                                }
                            }
                        }
                    });

                    platform_thread.Start();

                    Console.WriteLine("thread started");

                    thread_started = true;


                }



            }
        }


        public void teleportToCheckpoint(bool auto)
        {

            float xCP = mem.readFloat(checkpoint_coordonates[0]);
            float yCP = mem.readFloat(checkpoint_coordonates[1]);
            float zCP = mem.readFloat(checkpoint_coordonates[2]) + 5;

            if (xCP != 0.0f || yCP != 0.0f)
            {

                if (mem.readInt(Current_Vehicle_PTR) != 0)
                {
                    //teleport vehicle
                    mem.writeMemory(vehicle_position_x_y_z[0], "float", xCP.ToString());
                    mem.writeMemory(vehicle_position_x_y_z[1], "float", yCP.ToString());
                    mem.writeMemory(vehicle_position_x_y_z[2], "float", zCP.ToString());

                }
                else
                {
                    mem.writeMemory(position_x_y_z[0], "float", xCP.ToString());
                    mem.writeMemory(position_x_y_z[1], "float", yCP.ToString());
                    mem.writeMemory(position_x_y_z[2], "float", zCP.ToString());

                }

            }


            if (auto)
            {
                bool alreadyTeleported = false;

                float oldxCP = 0.0f;

                while (true)
                {

                    if (oldxCP != mem.readFloat(checkpoint_coordonates[0]))
                    {
                        alreadyTeleported = false;
                    }

                    if (helpers.getDistanceBetween2Points(xCP, mem.readFloat(position_x_y_z[0]), yCP, mem.readFloat(position_x_y_z[1])) > 10 && alreadyTeleported == false)

                    {
                        if (xCP != 0.0f || yCP != 0.0f)
                        {
                            System.Threading.Thread.Sleep(1000 / 60);
                            xCP = mem.readFloat(checkpoint_coordonates[0]);
                            yCP = mem.readFloat(checkpoint_coordonates[1]);
                            zCP = mem.readFloat(checkpoint_coordonates[2]) + 5;


                            if (mem.readInt(Current_Vehicle_PTR) != 0)
                            {
                                mem.writeMemory(vehicle_position_x_y_z[0], "float", xCP.ToString());
                                mem.writeMemory(vehicle_position_x_y_z[1], "float", yCP.ToString());
                                mem.writeMemory(vehicle_position_x_y_z[2], "float", zCP.ToString());
                            }
                            else
                            {
                                mem.writeMemory(position_x_y_z[0], "float", xCP.ToString());
                                mem.writeMemory(position_x_y_z[1], "float", yCP.ToString());
                                mem.writeMemory(position_x_y_z[2], "float", zCP.ToString());
                            }
                            oldxCP = xCP;
                            alreadyTeleported = true;
                        }
                    }
                }
            }
        }
        public void PnS_Free(string YES_NO)
        {
            mem.writeMemory(pns_free_PTR, "byte", YES_NO);
        }


        public float get_Gravity()
        {
            return mem.readFloat(Gravity_PTR);
        }

        public void set_Gravity(float x)
        {
            mem.writeMemory(Gravity_PTR, "float", x.ToString());
        }

        public int get_Brightness()
        {
            return mem.readInt(Brightness_PTR);
        }

        public void set_Brightness(int x)
        {
            mem.writeMemory(Brightness_PTR, "int", x.ToString());
        }



        //problematic
        public void teleportToMarker()
        {
            float xMarker = mem.readFloat(marker_coordonates[0]);
            float yMarker = mem.readFloat(marker_coordonates[1]);

            mem.writeMemory(position_x_y_z[0], "float", xMarker.ToString());
            mem.writeMemory(position_x_y_z[1], "float", yMarker.ToString());
        }
        public void Accuracy()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(1000 / 60);
                mem.writeMemory(perfect_accuracy_PTR, "int", "0");

            }
        }
        public void Wheels_only(string YES_NO)
        {
            mem.writeMemory(wheels_only_PTR, "byte", YES_NO);
        }
        public List<string> GetAllPlayers()
        {
            List<string> players = new List<string>();

            for (int i = 0; i < 140; i++)
            {

                int player_addy = mem.readInt("samp.dll+0x000AD7FC," + helpers.convertIntToHex(i * 4).ToString());

                if (player_addy != 0)
                {
                    players.Add("samp.dll+0x000AD7FC," + helpers.convertIntToHex(i * 4).ToString());


                }
            }

            return players;
        }

        public string GetClosestEnemy()
        {

            string playerToReturn = "";

            List<string> allPlayers = GetAllPlayers();

            float dummy_distance = 69420;

            for (int i = 1; i < allPlayers.Count; i++)
            {
                if (mem.readFloat(allPlayers[i] + ",0x540") == 0) { continue; }

                float nearestCarX = mem.readFloat(allPlayers[i] + ",14,30");
                float nearestCarY = mem.readFloat(allPlayers[i] + ",14,34");
                float nearestCarZ = mem.readFloat(allPlayers[i] + ",14,38");

                float myX = mem.readFloat(position_x_y_z[0]);
                float myY = mem.readFloat(position_x_y_z[1]);
                float myZ = mem.readFloat(position_x_y_z[2]);


                //calc distance

                float Distance = (float)(Math.Sqrt(Math.Pow(nearestCarX - myX, 2)) + Math.Sqrt(Math.Pow(nearestCarY - myY, 2)) + Math.Sqrt(Math.Pow(nearestCarZ - myZ, 2)));

                if (Distance < dummy_distance)
                {
                    playerToReturn = allPlayers[i];
                    dummy_distance = Distance;
                }



                //Console.WriteLine(nearestCarX.ToString() + " <> " + nearestCarY.ToString() + " <> " + nearestCarZ.ToString() + " || " + myX.ToString() + " -- " + myY.ToString() + " -- " + myZ.ToString() + " ### " + Distance.ToString());


            }

            return playerToReturn;

        }


        public void SmoothAim(string playerPointer)
        {
            //{ 0xB6EC14, 0xB6EC10 }
            float x_Enemy = 0.0f; float y_Enemy = 0.0f; float z_Enemy = 0.0f;
            float xMe = 0.0f; float yMe = 0.0f; float zMe = 0.0f;
            mem.writeMemory("0xB6EC14", "float", "0.5");
            mem.writeMemory("0xB6EC10", "float", "0.5");


            while (true)
            {

                Thread.Sleep(1000 / 500);

                playerPointer = GetClosestEnemy();

                try
                {
                    x_Enemy = mem.readFloat((playerPointer + ",14,30"));
                    y_Enemy = mem.readFloat((playerPointer + ",14,34"));
                    z_Enemy = mem.readFloat((playerPointer + ",14,38"));

                    xMe = mem.readFloat("0xB6F9CC");
                    yMe = mem.readFloat("0xB6F9D0");
                    zMe = mem.readFloat("0xB6F9D4");

                    float difX = xMe - x_Enemy;
                    float difY = yMe - y_Enemy;
                    float difZ = zMe - z_Enemy;

                    float hyp = (float)Math.Sqrt(difX * difX + difY * difY);

                    float x_NewAngle = (float)((float)Math.Atan2(difY, difX));
                    float y_NewAngle = -(float)Math.Asin(difZ / hyp);

                    float x_CurrentAngle = mem.readFloat(position_crosshair_x_y[0]);
                    float y_CurrentAngle = mem.readFloat(position_crosshair_x_y[1]);


                    float diff_x_Angle = x_NewAngle - x_CurrentAngle;
                    float diff_y_Angle = y_NewAngle - y_CurrentAngle;

                    float x_smoothed = diff_x_Angle / 10.0f;
                    float y_smoothed = diff_y_Angle / 2.0f;

                    x_CurrentAngle += x_smoothed;
                    y_CurrentAngle += y_smoothed;


                    Console.WriteLine(diff_x_Angle + " | " + diff_y_Angle);

                    
                    //click stanga in joc
                    //if (mem.readInt("0xB7347A") != 0)
                    if(GetAsyncKeyState(0x02) != 0)
                    {

                        mem.writeMemory(position_crosshair_x_y[0], "float", x_CurrentAngle.ToString());

                        if (y_smoothed > -0.777f && y_smoothed < 0.777f)
                        {
                            mem.writeMemory(position_crosshair_x_y[1], "float", y_CurrentAngle.ToString());
                        }
                    }

                }
                catch
                {

                }
            }
        }

        /* problematic */
        public void MuzzleAim(string playerPointer)
        {
            //{ 0xB6EC14, 0xB6EC10 }
            float x_Enemy = 0.0f; float y_Enemy = 0.0f; float z_Enemy = 0.0f;
            float xMe = 0.0f; float yMe = 0.0f; float zMe = 0.0f;
            


            while (true)
            {

                Thread.Sleep(1000 / 500);

                playerPointer = GetClosestEnemy();

                try
                {
                    x_Enemy = mem.readFloat((playerPointer + ",14,30"));
                    y_Enemy = mem.readFloat((playerPointer + ",14,34"));
                    z_Enemy = mem.readFloat((playerPointer + ",14,38"));

                    xMe = mem.readFloat("0xB6F9CC");
                    yMe = mem.readFloat("0xB6F9D0");
                    zMe = mem.readFloat("0xB6F9D4");

                    float difX = xMe - x_Enemy;
                    float difY = yMe - y_Enemy;
                    float difZ = zMe - z_Enemy;

                    float hyp = (float)Math.Sqrt(difX * difX + difY * difY);

                    float x_NewAngle = (float)((float)Math.Atan2(difY, difX));
                    float y_NewAngle = -(float)Math.Asin(difZ / hyp);

                    float x_CurrentAngle = mem.readFloat(position_crosshair_x_y[0]);
                    float y_CurrentAngle = mem.readFloat(position_crosshair_x_y[1]);


                    float diff_x_Angle = x_NewAngle - x_CurrentAngle;
                    float diff_y_Angle = y_NewAngle - y_CurrentAngle;

                    float x_smoothed = diff_x_Angle / 10.0f;
                    float y_smoothed = diff_y_Angle / 2.0f;

                    x_CurrentAngle += x_smoothed;
                    y_CurrentAngle += y_smoothed;


                    float xPunctu = (0.5f - diff_x_Angle);
                    float yPunctu = (0.5f - diff_y_Angle);


                    float difX2 = mem.readFloat(position_x_y_z[0]) - x_Enemy;
                    float difY2 = mem.readFloat(position_x_y_z[1]) - y_Enemy;
                    float difZ2 = mem.readFloat(position_x_y_z[2]) - z_Enemy;

                    float hyp2 = (float)(Math.Sqrt(difX2 * difX2 + difY2 * difY2));

                    float new_xPunctu = (float)Math.Atan2(difY2, difX2);
                    float new_yPunctu = -(float)Math.Asin(difZ2 / hyp2);





                    Console.WriteLine((new_xPunctu-x_NewAngle) + " | " + (new_yPunctu-y_NewAngle) + " <> " + (x_NewAngle - new_xPunctu));


                    //click stanga in joc
                    //if (mem.readInt("0xB7347A") != 0)
                    if (GetAsyncKeyState(0x02) != 0)
                    {

                        mem.writeMemory("0xB6EC14", "float", xPunctu.ToString());
                        mem.writeMemory("0xB6EC10", "float", yPunctu.ToString());
                        
                    }

                }
                catch
                {

                }
            }
        }


        public void AimToPlayer(string playerPointer)
        {
            //{ 0xB6EC14, 0xB6EC10 }
            float x_Enemy = 0.0f; float y_Enemy = 0.0f; float z_Enemy = 0.0f;
            float xMe = 0.0f; float yMe = 0.0f; float zMe = 0.0f;
            mem.writeMemory("0xB6EC14", "float", "0.5");
            mem.writeMemory("0xB6EC10", "float", "0.5");


            while (true)
            {

                Thread.Sleep(1000 / 500);

                playerPointer = GetClosestEnemy();

                try
                {
                    x_Enemy = mem.readFloat((playerPointer + ",14,30"));
                    y_Enemy = mem.readFloat((playerPointer + ",14,34"));
                    z_Enemy = mem.readFloat((playerPointer + ",14,38"));

                    //xMe = mem.readFloat(position_x_y_z[0]);
                    //yMe = mem.readFloat(position_x_y_z[1]);
                    //zMe = mem.readFloat(position_x_y_z[2]);
                    xMe = mem.readFloat("0xB6F9CC");
                    yMe = mem.readFloat("0xB6F9D0");
                    zMe = mem.readFloat("0xB6F9D4");

                    float difX = xMe - x_Enemy;
                    float difY = yMe - y_Enemy;
                    float difZ = zMe - z_Enemy;

                    float hyp = (float)Math.Sqrt(difX * difX + difY * difY);

                    float x_NewAngle = (float)((float)Math.Atan2(difY, difX));
                    float y_NewAngle = -(float)Math.Asin(difZ / hyp);


                    //Console.WriteLine("PlayerID: " + helpers.convertIntToHex(mem.readInt(playerPointer)) + "Addr: " + playerPointer + " HP: " + mem.readFloat(playerPointer + ",0x540"));
                    //Console.WriteLine("X: " + x_NewAngle + " Y: " + y_NewAngle + " Ex: " + x_Enemy + " Mx: " + xMe + " MemID: " + playerPointer);

                    if (mem.readInt("0xB7347A") != 0) //left mouse key
                    {

                        mem.writeMemory(position_crosshair_x_y[0], "float", x_NewAngle.ToString());

                        if (y_NewAngle > -0.777f && y_NewAngle < 0.777f)
                        {
                            mem.writeMemory(position_crosshair_x_y[1], "float", y_NewAngle.ToString());
                        }
                    }

                }
                catch
                {

                }
            }
        }








        public void disable_fps_limiter(bool x)
        {
            if (x)
            {
                mem.writeMemory(frame_limiter_PTR, "byte", "0");
            }
            else
            {
                mem.writeMemory(frame_limiter_PTR, "byte", "1");
            }
        }


        //neds work doenst work
        public void change_Veh_Mass_Before_Collision()
        {
            float nearestCarX = mem.readFloat(nearestCar + ",14,30");
            float nearestCarY = mem.readFloat(nearestCar + ",14,34");
            float nearestCarZ = mem.readFloat(nearestCar + ",14,38");

            float myX = mem.readFloat(position_x_y_z[0]);
            float myY = mem.readFloat(position_x_y_z[1]);
            float myZ = mem.readFloat(position_x_y_z[2]);

            while (true)
            {
                Thread.Sleep(1000 / 60);

                nearestCarX = mem.readFloat(nearestCar + ",14,30");
                nearestCarY = mem.readFloat(nearestCar + ",14,34");
                nearestCarZ = mem.readFloat(nearestCar + ",14,38");

                myX = mem.readFloat(position_x_y_z[0]);
                myY = mem.readFloat(position_x_y_z[1]);
                myZ = mem.readFloat(position_x_y_z[2]);

                //calc distance

                double Distance = Math.Sqrt(Math.Pow(nearestCarX - myX, 2)) + Math.Sqrt(Math.Pow(nearestCarY - myY, 2)) + Math.Sqrt(Math.Pow(nearestCarZ - myZ, 2));


                Console.WriteLine(nearestCarX.ToString() + " <> " + nearestCarY.ToString() + " <> " + nearestCarZ.ToString() + " || " + myX.ToString() + " -- " + myY.ToString() + " -- " + myZ.ToString() + " ### " + Distance.ToString());


            }
        }
        #endregion

    }
}