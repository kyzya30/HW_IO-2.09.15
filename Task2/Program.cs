using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Task2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Введите эталонное строковое значение:");
            string stringToFind = Console.ReadLine();
            List<string> listFilesWithFindedString = new List<string>();
            FindFilesWithString(ref stringToFind, ref listFilesWithFindedString);
            if (listFilesWithFindedString.Count == 0)
                {
                    Console.WriteLine("Таких файлов с этим текстом нет");
                }
            else
            {
                ReplaceTextInFiles(ref stringToFind, ref listFilesWithFindedString);
            } 
        }
        static void FindFilesWithString(ref string stringToFind, ref List<string> listFilesWithFindedString)
        {
            string Path = @"C:\Users\Admin\Documents\Visual Studio 2015\Projects\HW_IO 2.09.15\Task2\bin\Debug";
            string[] files = Directory.GetFiles(Path, "*.*", SearchOption.AllDirectories);
            string line;
            for (int i = 0; i < files.Length; i++)
            {
                bool duplicate = false;
                StreamReader fileReader = new StreamReader(files[i]);

                while ((line = fileReader.ReadLine()) != null)
                {
                    if (line == stringToFind)
                    {
                        if (duplicate == false)
                        {
                            listFilesWithFindedString.Add(files[i]);
                            duplicate = true;
                        }

                    }
                }
                fileReader.Close();
            }

        }
        static void ReplaceTextInFiles(ref string stringToFind, ref List<string> listFilesWithFindedString)
        {
            Console.WriteLine($"Искомое значение {stringToFind} было найдено в таких файлах:");
            foreach (var lst in listFilesWithFindedString)
            {
                Console.WriteLine(lst);
            }

            Console.WriteLine($"Введите текст на который Вы хотите заменить {stringToFind}:");
            string replaceText = Console.ReadLine();
            foreach (var fileList in listFilesWithFindedString)
            {
                StreamReader fileReader = new StreamReader(fileList);
                string content = fileReader.ReadToEnd();
                fileReader.Close();

                content = Regex.Replace(content, stringToFind, replaceText);

                StreamWriter writer = new StreamWriter(fileList);
                writer.Write(content);
                writer.Close();
                fileReader.Close();

            }

        }
    }
}
