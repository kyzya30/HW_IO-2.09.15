using System.IO;
using System.IO.Compression;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            CompressedCopy();
        }

        private static void CompressedCopy()
        {
            string sourceFile = File.ReadAllText("test.txt");

            string tempFileName = Path.GetTempFileName();
            File.WriteAllText(tempFileName, sourceFile);


            FileStream tempFileStream = new FileStream(tempFileName, FileMode.Open);
            byte[] byteBuffer = new byte[tempFileStream.Length];
            tempFileStream.Read(byteBuffer, 0, (int)tempFileStream.Length);

            FileStream createZipStream = new FileStream("File.Zipp", FileMode.Create);
            GZipStream gZipStream = new GZipStream(createZipStream, CompressionMode.Compress, false);
            gZipStream.Write(byteBuffer, 0, byteBuffer.Length);

            gZipStream.Close();
            createZipStream.Close();
            
        }
    }
}
