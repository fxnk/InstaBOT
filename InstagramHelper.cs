using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace InstaBOT
{
    public static class InstagramHelper
    {
        public static Boolean getacc()
        {
            var resultget = instagramget("/accounts/edit/?__a=");

            if (resultget[0] == "OK")
            {
                try
                {
                    Helper.info("Username: " + Helper.getbet(resultget[1], "\"username\":\"", "\""));
                    Helper.info("Email: " + Helper.getbet(resultget[1], "\"email\":\"", "\""));
                    Helper.info("FirstName: " + Helper.getbet(resultget[1], "\"first_name\":\"", "\""));
                    Helper.info("LastName: " + Helper.getbet(resultget[1], "\"last_name\":\"", "\""));
                    Helper.info("EmailConfirmed: " + Helper.getbet(resultget[1], "\"is_email_confirmed\":", ","));
                    Helper.info("PhoneConfirmed: " + Helper.getbet(resultget[1], "\"is_phone_confirmed\":", ","));
                    Helper.info("PhoneNumber: " + Helper.getbet(resultget[1], "\"phone_number\":\"", "\""));
                    Helper.info("Bio: " + Helper.getbet(resultget[1], "\"biography\":\"", "\""));
                }
                catch (Exception e)
                {
                    Helper.ErrorHandler(e);
                    return false;
                }

            }
            return true;
        }
        static public Boolean like(string imageid)
        {
            var resultget = instagrampost("","/web/likes/" + imageid + "/like/");
            if (resultget[0] == "OK")
            {
                return true;
            }
            return false;
        }
        static public Boolean comment(string imageid, string message)
        {
            var resultget = instagrampost(message, "/web/comments/" + imageid + "/add/");
            if (resultget[0] == "OK")
            {
                return true;
            }
            return false;
        }
        static public Boolean follow(string userid)
        {
            var resultget = instagrampost("", "/web/friendships/" + userid + "/follow/");
            if(resultget[0] == "OK")
            {
                return true;
            }
            return false;
        }

        public static List<String> getuser(string username)
        {
            List<String> userresult = new List<String>();
            var resultget = instagramget("/" + username + "/");
            if (resultget[0] == "OK")
            {
                try
                {
                    userresult.Add(Helper.getbet(resultget[1], "id\":\"profilePage_", "\""));
                    return userresult;
                }
                catch(Exception e)
                {
                    Helper.ErrorHandler(e);
                }
            }
            userresult.Clear();
            userresult.Add("FAIL");
            return userresult;
        }

        static List<String> instagrampost(string post, string command)
        {
            List<String> responselist = new List<String>();
            try
            {
                HttpWebRequest request = WebRequest.Create("https://www.instagram.com" + command) as HttpWebRequest;

                var data = Encoding.UTF8.GetBytes(post);
                
                request.Method = "POST";
                request.Host = "www.instagram.com";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88 Safari/537.36 OPR/73.0.3856.284";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers["Accept-Language"] = "en-GB,en-US;q=0.9,en;q=0.8";
                request.Headers["Accept-Encoding"] = "utf-8";
                request.Headers["X-IG-App-ID"] = Globals.XIGAppID;
                request.Headers["X-Instagram-AJAX"] = Globals.XInstagramAJAX;
                request.Headers["X-CSRFToken"] = Globals.XCSRFToken;
                request.Headers["X-Requested-With"] = "XMLHttpRequest";
                request.Headers["Cookie"] = "sessionid=" + Globals.sessionid + ";";

                request.Timeout = 5000;
                
                using(var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
               
                var response = (HttpWebResponse)request.GetResponse();
                responselist.Add(response.StatusCode.ToString());
                var resp = new StreamReader(response.GetResponseStream()).ReadToEnd();
                responselist.Add(resp);
            }
            catch (Exception e)
            {
                Helper.ErrorHandler(e);
                responselist.Clear();
                responselist.Add("Fail");
                return responselist;
            }
            return responselist;
        }
    
    static List<String> instagramget(string command)
        {
            List<String> responselist = new List<String>();
            try
            {
                HttpWebRequest request = WebRequest.Create("https://www.instagram.com" + command) as HttpWebRequest;
                request.Method = "GET";
                request.Host = "www.instagram.com";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88 Safari/537.36 OPR/73.0.3856.284";
                request.Headers["Accept-Language"] = "en-GB,en-US;q=0.9,en;q=0.8";
                request.Headers["Accept-Encoding"] = "utf-8";
                request.Headers["X-IG-App-ID"] = Globals.XIGAppID;
                request.Headers["X-Requested-With"] = "XMLHttpRequest";
                request.Headers["Cookie"] = "csrftoken=" + Globals.XCSRFToken + "; sessionid=" + Globals.sessionid + ";";

                request.Timeout = 5000;

                string responsestring;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    responselist.Add(response.StatusCode.ToString());
                    responsestring = reader.ReadToEnd();
                }
                responselist.Add(responsestring);
            }
            catch (Exception e)
            {
                Helper.ErrorHandler(e);
                responselist.Clear();
                responselist.Add("Fail");
                return responselist;
            }
            return responselist;
        }
    }
}
