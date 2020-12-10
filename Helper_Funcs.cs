using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;
namespace SAMP_CHEAT_KRANE
{
    class Helper_Funcs
    {
        
        public string convertIntToHex(int number)
        {
            return number.ToString("X");
        }

        public int convertHexToInt(string hexNumber)
        {
            return Convert.ToInt32(hexNumber, 16);
        }

        public float getDistanceBetween2Points(float x1, float x2, float y1, float y2)
        {

            return (float)(Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)));
        }        

        
        
    }
}
