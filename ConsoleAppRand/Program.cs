using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppRand
{
    class Program
    {
        // globale variablen 
        // ordner aufbau
        private static string pathGlob = @"C:\temp\";
        // dateiname
        // private static string fileGlob = @"test.csv";
        private static string fileGlob = @"people.csv";

        static void Main(string[] args)
        {
            // lokale variablen
            // lokale variable folder (directory)
            string pathLoc = pathGlob; 
            // lokale variable folder + filename
            string fileLoc = pathGlob + fileGlob; 

            // check directory and file
            if (CheckDirectory(pathLoc) && CheckFile(fileLoc))
            {
                // open file on location
                OpenFile(fileLoc);
            }           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static bool CheckDirectory(string fileName)
        {
            return Directory.Exists(fileName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static bool CheckFile(string fileName)
        {
            bool retValue = false;

            if(File.Exists(fileName))
            {
                retValue = true;
            }
            else
            {
                retValue = false;
            }
            return retValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        private static void OpenFile(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path)) //neuer Streamreader mit übergebenem Pfad
                {
                    string line = "";
                    string[] tempArray;
                    while ((line = sr.ReadLine()) != null) //solange eine Zeile vorhanden ist
                    {
                        Console.WriteLine($"Inhalt der Zeile: {line}");
                        tempArray = line.Split(';'); //Zeile teilen bei jedem ; oder ,
                        // ausgabe der Infos
                        ExportLineInfos(tempArray);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Es ist ein Fehler ausgetreten {ex.StackTrace}");
                throw;
            }
        }

        private static void ExportLineInfos(string[] infoArray)
        {
            for (int i = 0; i < infoArray.Length; i++)
            {
                Console.WriteLine($"An der Position {i} ist der Inhalt {infoArray[i].ToString()}");
            }
        }
    }
}

//Random rnd = new Random();

//int retRNDValue = default;

//for (int i = 0; i < 10; i++)
//{
//    retRNDValue = rnd.Next(0, 12 + 1);
//    Console.WriteLine($"Der Wert aus RND {retRNDValue}");

//}
