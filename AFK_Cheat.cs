using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memory;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace SAMP_CHEAT_KRANE
{
    class AFK_Cheat
    {
        Mem mem;
        string[] WASD = { "00B72D76", "00B72D4A", "00B72D6E", "00B72D50" };
        string chatlogLocation = @"C:\Users\" + Environment.UserName +  @"\Documents\GTA San Andreas User Files\SAMP\chatlog.txt";
        public string TextLog = "";

        int process_ID_San_Andreeas;
        public void init()
        {
            System.IO.File.Delete(this.chatlogLocation);
            mem = new Mem();
            process_ID_San_Andreeas = Process.GetProcessesByName("gta_sa")[0].Id;

            mem.OpenProcess(process_ID_San_Andreeas);
/*
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\";
            ofd.Title = "SAMP -> chatlog.txt";
            ofd.ShowDialog();
            this.chatlogLocation = ofd.FileName;
  */
        }

        public void SendKey(char key)
        {
            switch (key)
            {
                case 'W':
                    {
                        mem.writeMemory(WASD[0], "int", "255");
                        mem.writeMemory(WASD[1], "int", "0");
                        mem.writeMemory(WASD[2], "int", "0");
                        mem.writeMemory(WASD[3], "int", "0");
                        break;
                    }
                case 'A':
                    {
                        mem.writeMemory(WASD[1], "int", "255");
                        mem.writeMemory(WASD[0], "int", "0");
                        mem.writeMemory(WASD[2], "int", "0");
                        mem.writeMemory(WASD[3], "int", "0");

                        break;
                    }
                case 'S':
                    {
                        mem.writeMemory(WASD[2], "int", "255");
                        mem.writeMemory(WASD[1], "int", "0");
                        mem.writeMemory(WASD[0], "int", "0");
                        mem.writeMemory(WASD[3], "int", "0");

                        break;
                    }
                case 'D':
                    {
                        mem.writeMemory(WASD[3], "int", "255");
                        mem.writeMemory(WASD[1], "int", "0");
                        mem.writeMemory(WASD[2], "int", "0");
                        mem.writeMemory(WASD[0], "int", "0");

                        break;
                    }

            }
        }


       


        public void chatLog()
        {
            while(true)
            {//daca dezactivezi toate togurile nu o sa ai treaba
                Thread.Sleep(1000);

                string[] text;
                try
                {

                    text = System.IO.File.ReadAllText(this.chatlogLocation).Split('\n'); 
                    System.IO.File.Delete(this.chatlogLocation);
                    foreach(string s in text)
                    {
                        this.TextLog += s + "\n";

                        if (s.Contains("PC") || s.Contains("esti") || s.Contains("Esti") || s.Contains("pc") || s.Contains("cf") || s.Contains("ce faci"))
                        {
                            //trigger the save
                            Process.GetProcessById(process_ID_San_Andreeas).Kill();
                        }
                    }
                }
                catch
                {
                    
                }
                
                
            }
        }
    
        

        public void moveAround()
        {
            int endTime = DateTime.Now.Second + 2;
            bool TriggerChange = false;

            char CurrentKey = 'W';
            Random random = new Random();
            int randomNr = 0;
            while (true)
            {
                Thread.Sleep(1000 / 60);


                //get random nr
                
                
                //get current time + 4 seconds to mvoe for 4 seconds 1 direction
                int currentTime = DateTime.Now.Second;

                //Console.WriteLine("End: " + endTime.ToString() + " C: " + currentTime);

                if (endTime > 59)
                {
                    endTime = 1;
                }

                if (currentTime == endTime)
                {
                    endTime = currentTime + 2;
                    TriggerChange = true;
                    randomNr = random.Next(1, 5);

                    //Console.Write("CHANGED");


                }



                if (TriggerChange)
                {
                    if (randomNr == 0)
                    {
                        randomNr = 1;
                    }
                    switch(randomNr)
                    {
                        case 1:
                            CurrentKey = 'S';
                            break;
                        case 2:
                            CurrentKey = 'W';
                            break;

                        case 3:
                            CurrentKey = 'D';
                            break;
                        case 4:
                            CurrentKey = 'A';
                            break;
                    }
                    TriggerChange = false;
                }



                SendKey(CurrentKey);

                //Console.WriteLine("Current Key: " + CurrentKey + " TriggerChange: " + TriggerChange + " TimeC: " + currentTime + "EndTime: " + endTime);
            }
        }
    
    }
}
