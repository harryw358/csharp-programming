using System;

namespace WarriorWars
{
    internal class Tools
    {
        public static void ColourfulWriteLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
