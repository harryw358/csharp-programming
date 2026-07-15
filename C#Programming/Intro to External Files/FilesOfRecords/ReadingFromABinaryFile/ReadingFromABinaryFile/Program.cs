using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadingFromABinaryFile
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
        static BinaryReader currentFileReader;
        static FileStream currentFile;
        static void Main(string[] args)
        {
            string filename = "D:/CS/C#Y1Programming/Intro to External Files/FilesOfRecords/test1.bin";
            currentFile = new FileStream(filename, FileMode.Open);
            currentFileReader = new BinaryReader(currentFile);

            do
            {
                book.ISBN = currentFileReader.ReadString();
                book.Title = currentFileReader.ReadString();
                book.Price = currentFileReader.ReadDecimal();
                book.YearOfPublication = currentFileReader.ReadInt32();

                Console.WriteLine("ISBN: " + book.ISBN);
                Console.WriteLine("Title: " + book.Title);
                Console.WriteLine("Price: " + book.Price);
                Console.WriteLine("Year of Publication: " + book.YearOfPublication);
                Console.WriteLine();
            }
            while (currentFile.Position < currentFile.Length);

            currentFileReader.Close();
            currentFile.Close();
            Console.ReadKey();
        }
    }
}
