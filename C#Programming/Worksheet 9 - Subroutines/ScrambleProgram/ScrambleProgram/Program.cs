using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrambleProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            //user enters message they want to encrypt
            Console.Write("Enter a message: ");
            string msg = Console.ReadLine();
            
            //scramble message and display on console
            char[] encryptedMsg = new char[msg.Length];
            encryptedMsg = Scramble(msg);
            for(int i = 0; i < encryptedMsg.Length; i++)
            {
                Console.Write(encryptedMsg[i]);
            }
            Console.ReadKey();
        }
        static char[] Scramble(string msg)
        {
            int i;
            char c;
            char[] plainText = new char[msg.Length], encryptedText = new char[msg.Length];

            if(msg.Length % 2 == 0)
            {
                for(i = 0; i < msg.Length; i++)
                {
                    plainText[i] = msg[i];
                }
                i = 0;
                for(i = 0; i < plainText.Length; i += 2)
                {
                    c = plainText[i];
                    encryptedText[i] = plainText[i + 1];
                    encryptedText[i + 1] = c;
                }
            }
            else if(msg.Length % 2 != 0)
            {
                for(i = 0; i < msg.Length - 1; i++)
                {
                    plainText[i] = msg[i];
                }
                i = 0;
                for(i = 0; i < plainText.Length - 1; i += 2)
                {
                    c = plainText[i];
                    encryptedText[i] = plainText[i + 1];
                    encryptedText[i + 1] = c;
                    encryptedText[msg.Length - 1] = msg[msg.Length - 1];
                }
            }
            return encryptedText;
        }
    }
}
