using System;
using System.IO;
using System.Text;

namespace lab02_csv
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            //sciezka do pliku csv
            var path = @"C:\Users\Karol\Desktop\example.csv";
            //nazwa pliku wyjsciowego
            var newFileName = @"C:\Users\Karol\Desktop\outputTableTest.html";
        
            
            string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            using (var outfs = File.AppendText(newFileName))
            {
                outfs.Write("<html><head><style>#bold{font-weight: bold; background-color:bisque;}#white{background-color: white;}#black{background-color: bisque;}</style></head><body><table>");
                foreach (var line in lines)
                {
                    switch (i)
                    {
                        case 0:
                            outfs.Write("<tr id=\"bold\"><td>" + string.Join("</td><td>", line.Split(',')) + "</td></tr></b>");
                            i++;
                            break;
                        case 1:
                            outfs.Write("<tr id=\"white\"><td>" + string.Join("</td><td>", line.Split(',')) + "</td></tr>");
                            i++;
                            break;
                        case 2 :
                            outfs.Write("<tr id=\"black\"><td>" + string.Join("</td><td>", line.Split(',')) + "</td></tr>");
                            i = 1;
                            break;
                    }
                }

                outfs.Write("</table></body></html>");
            }
            
        }
    }
}