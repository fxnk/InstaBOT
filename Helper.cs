using System;
using System.Collections.Generic;
using System.Text;

namespace InstaBOT
{
    public static class Helper
    {
        public static void info(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("- " + message);
        }
        public static void fail(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[-] " + message);
        }
        public static void success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[+] " + message);
        }
        public static void menu(string message)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("# " + message);
        }
        public static void ErrorHandler(Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[--]" + e.Message);
        }
        public static string getbet(string input, string start, string end)
        {
            var temp = input.Split(new string[] { start }, StringSplitOptions.None);
            var result = temp[1].Split(new string[] { end }, StringSplitOptions.None);
            return result[0];
        }


    }
}
