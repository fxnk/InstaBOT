using System;
using System.Collections.Generic;
using System.Text;

namespace InstaBOT
{
    class Menu
    {
        public static void loadmenu()
        {
            Console.Clear();
            Helper.menu("Instagram Bot 1.0 \n");
            Helper.menu("Manual 1:");
            Helper.menu("Auto 2 (notworking):");
            Console.Write("Choice:");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    loadmenuman();
                    break;
                    /*case "2":
                        loadmenuauto();
                        break;  */
            }
        }
        static void loadmenuman()
        {
            Console.Clear();
            Helper.menu("Instagram Bot 1.0 \n");
            Helper.menu("Follow 1:");
            Helper.menu("Like 2:");
            Helper.menu("Comment 3:");
            Helper.menu("Message 4:");
            Console.Write("Choice:");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    followmenu();
                    break;
                case "2":
                    likemenu();
                    break;
                case "3":
                    commentmenu();
                    break;
                    /*case "4":
                        messagemenu();
                        break;*/
            }
        }
        static void followmenu()
        {
            Console.Clear();
            Console.Write("Username: ");
            string username = Console.ReadLine();
            var id = InstagramHelper.getuser(username);
            if (id[0] != "FAIL" || id[0] != "")
            {


                if (InstagramHelper.follow(id[0]))
                {
                    Helper.success(username + " followed!");
                    return;
                }


                Helper.fail(username + "not followed!");
            }
        }
        static void likemenu()
        {
            Console.Clear();
            Console.Write("ImageId: ");
            string ImageId = Console.ReadLine();
            if (InstagramHelper.like(ImageId))
            {
                Helper.success(ImageId + " Liked!");
            }
            else
            {
                Helper.fail(ImageId + "not Liked!");
            }
        }
        static void commentmenu()
        {
            Console.Clear();
            Console.Write("ImageId: ");
            string ImageId = Console.ReadLine();
            Console.Write("Message: ");
            string message = Console.ReadLine();
            if (InstagramHelper.comment(ImageId, message))
            {
                Helper.success(ImageId + " Commented!");
            }
            else
            {
                Helper.fail(ImageId + " not commented!");
            }
        }
    }
}