using System;
using System.Collections.Generic;
using System.Text;

namespace InstaBOT
{
    public static class Loader
    {
        public static Boolean loadsessionconf()
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"config.txt");
                foreach (string conf in lines)
                {
                    var whichconf = conf.Split("=");
                    if (whichconf[1] != "")
                    {
                        switch (whichconf[0])
                        {
                            case "xcrstoken":
                                Globals.XCSRFToken = whichconf[1];
                                break;
                            case "xinstagramajax":
                                Globals.XInstagramAJAX = whichconf[1];
                                break;
                            case "xigappid":
                                Globals.XIGAppID = whichconf[1];
                                break;
                            case "sessionid":
                                Globals.sessionid = whichconf[1];
                                break;
                        }
                    }
                    else
                    {
                        Helper.fail(whichconf[0] + "Error");
                        return false;
                    }
                }
                Helper.info(Globals.sessionid);
                Helper.info(Globals.XIGAppID);
                Helper.info(Globals.XInstagramAJAX);
                Helper.info(Globals.XCSRFToken);
                Helper.success("Session loaded!");
                return true;

            }
            catch (Exception e)
            {
               
                Helper.ErrorHandler(e);
            }
            return false;
        }
    }
}
