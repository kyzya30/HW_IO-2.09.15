using System;
using System.IO;

namespace HW_IO_2._09._15
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkWithFile();
        }

        private static void WorkWithFile()
        {
            FileStream byteStreamWriter = new FileStream(@".\test.txt", FileMode.OpenOrCreate, FileAccess.Write);

            for (int i = 0; i < 256; i++)
            {
                byteStreamWriter.WriteByte((byte)i);
            }
            byteStreamWriter.Close();

            FileStream byteStreamReader = new FileStream(@".\test.txt", FileMode.Open, FileAccess.Read);
            for (int i = 0; i < 256; i++)
            {
                Console.WriteLine(byteStreamReader.ReadByte());
            }
            byteStreamReader.Close();
        }
    }
}
