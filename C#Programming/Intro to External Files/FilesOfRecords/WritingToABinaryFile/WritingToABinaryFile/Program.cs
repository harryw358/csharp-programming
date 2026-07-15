using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WritingToABinaryFile
{
    class Program
    {
        struct TBook
        {
            public string Title, ISBN;
            public decimal Price;
            public int YearOfPublication;
        }
        static TBook book;
        static BinaryWriter currentFileWriter;
        static FileStream currentFile;
        static void Main(string[] args)
        {
            string fileName = "D:/CS/C#Y1Programming/Intro to External Files/FilesOfRecords/test1.bin", answer;
            currentFile = new FileStream(fileName, FileMode.Append);
            currentFileWriter = new BinaryWriter(currentFile);
            do
            {
                Console.Write("ISBN: "); book.ISBN = Console.ReadLine();
                Console.Write("Title: "); book.Title = Console.ReadLine();
                Console.Write("Price: "); book.Price = decimal.Parse(Console.ReadLine());
                Console.Write("Year of publication: "); book.YearOfPublication = int.Parse(Console.ReadLine());
                currentFileWriter.Write(book.ISBN);
                currentFileWriter.Write(book.Title);
                currentFileWriter.Write(book.Price);
                currentFileWriter.Write(book.YearOfPublication);
                Console.Write("Do you want to add another record? (y/n) ");
                answer = Console.ReadLine();
            }
            while (answer.ToUpper() == "Y");
            currentFileWriter.Close();
            currentFile.Close();
            Console.ReadKey();
        }
    }
}
