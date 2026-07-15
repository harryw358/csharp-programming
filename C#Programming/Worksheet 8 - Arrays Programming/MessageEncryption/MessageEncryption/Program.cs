using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageEncryption
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message;
            int count = 0;

            char[,] str = new char[6, 6];
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 6; col++)
                {
                    str[row, col] = ' ';
                }
            }
            do
            {
                Console.Write("Enter the message, up to 36 characters: ");
                message = Console.ReadLine();
                if(message.Length > 36)
                {
                    Console.WriteLine("Only up to 36 characters please.");
                }
            }
            while (message.Length > 36);
            for(int row = 0; row < 6; row++)
            {
                for(int col = 0; col < 6; col++)
                {
                    if (count < message.Length)
                    {
                        str[row, col] = message[count];
                    }
                    count++;
                }
            }
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 6; col++)
                {
                    Console.Write(str[col, row]);   
                }
            }
            Console.ReadKey();
        }
    }
}
