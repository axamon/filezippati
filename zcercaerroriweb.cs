using System;
using System.IO;
using System.Text;
using System.IO.Compression;
using System.Text.RegularExpressions;


class Test
{
    public static void Main()
    {
          String[] arguments = Environment.GetCommandLineArgs();
          //string filePath = @"./pippo.txt.gz";
          string filePath = arguments[1];
          string domain  = arguments[2];
          Regex rx = new Regex(@"^.*\b" + domain + @"\b.*[45]\d\d\s+.*$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);


using (FileStream reader = File.OpenRead(filePath))
    using (GZipStream zip = new GZipStream(reader, CompressionMode.Decompress, true))
        using (StreamReader unzip = new StreamReader(zip))
            while(!unzip.EndOfStream)
         {
                MatchCollection matches = rx.Matches(unzip.ReadLine());
                //Console.WriteLine(unzip.ReadLine());
                foreach (Match match in matches)
                        {
                                Console.WriteLine(match);

        }               }
   }
}
