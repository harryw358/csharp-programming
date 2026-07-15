using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Records
{
    class Program
    {
        struct Tbook                                        //declare structure, must be before Main program
        {
            public string title, ISBN;                      //these are the fields that must be public to use
            public decimal price;
            public int yearOfPublication;
        }
        static void Main(string[] args)
        {
            Tbook book;                                     //variable of type 'TBook' declared, must be in the main program

            book.title = "A-level computing";               //assign values to field
            book.price = 20.49M;                            //M means decimal (money)

            Console.ReadKey();
        }
    }
}
