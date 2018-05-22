using System.Drawing;
using System.IO;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using GameNS;


namespace FilerNS
{
    public class Filer : IFiler
    {

        public string LevelName;
        public Filer()
        {
        }
        public void GetName(string levelName)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            foreach (var item in specialChar)
            {
                if (!levelName.Contains(item))
                {
                    LevelName = levelName;
                }
                else
                {
                    throw new NotImplementedException("incorrect level name format!");
                }
            }

        }
        public string Load(string fileName)
        {
            if (File.Exists(fileName))
            {
                string[] result = File.ReadAllLines(fileName);
                string myString = string.Join("", result);
                string text = myString.Replace("\"", "");
                return text;
            }
            else
            {
                throw (new Exception("The file don't exist!"));
            }

        }
        public string GetExtension(string fileName)
        {
            string extension;
            extension = System.IO.Path.GetExtension(fileName);
            if (extension == ".txt")
            {
                return extension;
            }
            else
            {
                throw new NotImplementedException("incorrect format!");
            }
        }
        public void IsBlockEqualGoal(string fileName)
        {
            Load(fileName);
            int i = Load(fileName).Split('$').Length;
            int j = Load(fileName).Split('.').Length;
            if (i != j)
            {
                throw new ArgumentException("the number of block and goal is not the same");
            }
        }

        public void IsOnePlayer(string fileName)
        {
            Load(fileName);
            int i = Load(fileName).Split('@').Length;
            if (i != 1)
            {
                throw new ArgumentException("the number of player is not valid");
            }
        }
        public void IsAtLeastOneGoal(string fileName)
        {
            Load(fileName);
            int i = Load(fileName).Split('.').Length;
            if (i != 1)
            {
                throw new ArgumentException("the number of goal is not valid");
            }
        }
        public void IsAtLeastOneBlock(string fileName)
        {
            Load(fileName);
            int i = Load(fileName).Split('$').Length;
            if (i != 1)
            {
                throw new ArgumentException("the number of block is not valid");
            }
        }

        public void IsNoWall(string fileName)
        {
            Load(fileName);
            int i = Load(fileName).Split('#').Length;
            if (i == 0)
            {
                throw new ArgumentException("the number of wall is not valid");
            }
        }
        public void Save(string filename, GameNS.Game callMeBackforDetails)
        {
            int rowMax = callMeBackforDetails.GetRowCount();
            int colMax = callMeBackforDetails.GetColumnCount();
            List<MapItem> CurrentGame = callMeBackforDetails.GetMap().Items;
            List<char> parts = new List<char>();
            foreach (MapItem item in CurrentGame)
            {
                parts.Add(item.Sign);
            }
            //List<Parts> stringParts = new List<Parts>();
            //for (int i = 0; i <= rowMax; i++)
            //{
            //    for (int j = 0; j < colMax; j++)
            //    {
            //        Parts part = callMeBackforDetails.WhatsAt(i, j);
            //        parts.Add(part);
            //    }
            //}
            char[] lines = parts.ToArray();
            //// string mydocpath = @"H:\";
            string result = "";


            if (!File.Exists(filename))
            {
                using (StreamWriter outputFile = new StreamWriter(filename))
                {
                    string str = "";
                    foreach (char line in lines)
                    {
                        result += line;
                    }
                    int chunkSize = colMax;
                    int resultLength = result.Length;
                    for (int i = 0; i < resultLength; i += chunkSize)
                    {

                        str += result.Substring(i, chunkSize) + ",";


                    }
                    outputFile.WriteLine(str.TrimEnd(','));

                }
            }

        }

        //public string NewestFileofDirectory()
        //{
        //    //    DirectoryInfo d = new DirectoryInfo(
        //    //    System.Environment.GetFolderPath(Environment.SpecialFolder.Recent)
        //    //);
        //    //string path = Environment.GetFolderPath(Environment.SpecialFolder.Recent);
        //    ////var files = Directory.EnumerateFiles(path);
        //    ////return files;
        //    //return path;

        //    //string directoryPath;
        //    //DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

        //    //Directory.GetFiles(path)
        //    //.Select(x => new FileInfo(x))
        //    //.OrderByDescending(x => x.LastWriteTime)
        //    //.Take(5)
        //    //.ToArray()
        //    DirectoryInfo DR = new DirectoryInfo(@"H:\");

        //    FileInfo FR = DR.GetFiles();

        //    foreach (FileInfo F in FR)
        //    {
        //        Console.WriteLine("Last Edit Time : {0}", F.LastWriteTime);
        //    }


        //}
        //public static FileInfo NewestFileofDirectory(DirectoryInfo directory)
        //{
        //    return directory.GetFiles()
        //        .Union(directory.GetDirectories().Select(d => NewestFileofDirectory(d)))
        //        .OrderByDescending(f => (f == null ? DateTime.MinValue : f.LastWriteTime))
        //        .FirstOrDefault();
        //}
        public List<FileInfo> NewestFileofDirectory(DirectoryInfo directoryInfo)
        {
            FileInfo[] files = directoryInfo.GetFiles();
            List<FileInfo> lastUpdatedFile = new List<FileInfo>();
            DateTime lastUpdate = DateTime.MinValue;
            foreach (FileInfo file in files)
            {
                if (file.LastAccessTime > lastUpdate)
                {
                    lastUpdatedFile.Add(file);
                    lastUpdate = file.LastAccessTime;
                }
            }

            return lastUpdatedFile;
        }

        public void DeleteFile(string fileName)
        {
            //string mydocpath = @"H:\";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            else
            {
                throw new Exception("file not exists");
            }
        }

        //public void getRecentFile()
        //{
        //    var directory = new DirectoryInfo("C:\\MyDirectory");
        //    var myFile = (from f in directory.GetFiles()
        //                  orderby f.LastWriteTime descending
        //                  select f).First();
        //}

        public List<FileInfo> GetLastUpdatedFileInDirectory(DirectoryInfo directoryInfo)
        {
            FileInfo[] files = directoryInfo.GetFiles();
            List<FileInfo> lastUpdatedFile = new List<FileInfo>();
            DateTime lastUpdate = DateTime.MinValue;
            foreach (FileInfo file in files)
            {
                if (file.LastAccessTime > lastUpdate)
                {
                    lastUpdatedFile.Add(file);
                    lastUpdate = file.LastAccessTime;
                }
            }

            return lastUpdatedFile;
        }
        public bool HasNotInvalidChar(string fileName)
        {
            Load(fileName);
            bool result = false;
            string allowableChars = "#@$.*+-,";
            foreach (char c in Load(fileName))
            {
                if (allowableChars.Contains(c.ToString()))
                {
                    result = true;
                }

                else
                {
                    throw new ArgumentException("there is invaild char");
                }
            }
            return result;
        }
        public bool? PreExpandingCheck(string input)
        {
            bool result = false;
            string[] lines = input.Split(',');
            foreach (var item in lines)
            {
                if (item.First() > 0)
                {
                    result = true;
                }
                else
                {
                    throw new NotImplementedException("this string is not able to be expanded");
                }
            }
            return result;
        }

        public bool? PreCompressingCheck(string input)
        {
            //bool result = false;
            //char[] lines = input.ToCharArray();
            //for (var i = 0; i < lines.Length; i++)
            //{
            //    if (lines[i] == lines[++i])
            //    {
            //        result = true;
            //    }
            //    else
            //    {
            //        throw new NotImplementedException("this string is not able to be compressed");
            //    }
            //}
            //return result;
            bool result = false;
            int length = input.Split(',').Length;
            string[] myString = input.Split(',');
            for (int i = 0; i < length; i++)
            {
                char[] lines = myString[i].ToCharArray();
                for (var j = 0; j < lines.Length; j++)
                {
                    if (lines[j] == lines[++j])
                    {
                        result = true;
                    }
                    else
                    {
                        throw new NotImplementedException("this string is not able to be compressed");
                    }
                }
            }
            return result;
        }

        //public string Expanded
        //{

        //    get
        //    {
        //        this.PreCompressingCheck(string input);
        //        return expanded;
        //    }
        //    set
        //    {
        //        this.expanded = 

        //    }
        //}
        //public string Compressed { get; }

        public string Compress(string uncompressedLevel)
        {
            /* string result;
             int length = uncompressedLevel.Split(',').Length;
             if (PreCompressingCheck(uncompressedLevel) == true)
             {

                 string[] myString = uncompressedLevel.Split(',');
                 for (int i = 0; i < length; i++)
                 {
                     char[] lines = myString[i].ToCharArray();
                     int j = lines.Length;
                     result = j.ToString() + lines[0].ToString();
                 }

                 //char[] lines = uncompressedLevel.ToCharArray();
                 //int i = lines.Length;
                 //result = i.ToString() + lines[0].ToString();           
             }
             else
             {
                 throw new NotImplementedException("the input can not compress");
             }
             return result;*/
            string result = "";
            //int count = 1;
            int length = uncompressedLevel.Split(',').Length;
            string[] myString = uncompressedLevel.Split(',');
            for (int i = 0; i < length; i++)
            {
                char[] lines = myString[i].ToCharArray();
                for (int j = 1; j < lines.Length; j++)
                {

                    if (lines.Length - 1 > j && lines[j] == lines[j++])
                    {
                        int k = j + 1;
                        result += k.ToString() + lines[j].ToString() + ',';
                    }
                    //else
                    //{
                    //    throw new NotImplementedException("this string is not able to be compressed");
                    //}
                    //return result;
                }
            }
            return result;
        }
        public string Expand(string compressedLevel)
        {
            string result = "";
            string str = "";
            string[] lines = compressedLevel.Split(',');
            foreach (var item in lines)
            {
                int i = int.Parse(item.First().ToString());
                for (int j = 0; j < i; j++)
                {
                    result += item[1].ToString();
                }
            }
            int chunkSize = compressedLevel.Split(',').Length + 1;
            int resultLength = result.Length;
            for (int k = 0; k < resultLength; k += chunkSize)
            {
                str += result.Substring(k, chunkSize) + ",";
            }
            return str;
        }
    }
}
