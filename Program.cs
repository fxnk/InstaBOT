using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace InstaBOT
{
    class Program
    { 

        static void Main(string[] args)
        {
            if (Loader.loadsessionconf())
            {
                if (InstagramHelper.getacc())
                {
                    Menu.loadmenu();
                }
                else
                {
                    Helper.fail("Validation error!");

                }
            }
            else
            {
                Helper.fail("Error, session did not load successfully!");
            }
            Console.ReadKey();
        }
   }
 
}
