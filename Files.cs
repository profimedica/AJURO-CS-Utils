using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJURO_CS_Utils
{
    // All files heplers
    public class Files
    {
        public List<string> RecursiveProcess(string rootDirectory, List<string> acceptedExtensions, bool searchRecursively, Func<string, int> fileProcessor)
        {
            List<string> paths = new List<string>();
            try
            {
                foreach (string f in Directory.GetFiles(rootDirectory))
                {
                    if (acceptedExtensions.Count > 0)
                    {
                        if (f.IndexOf('.') > 0 && f.LastIndexOf('.') + 1 < f.Length - 1 && f.LastIndexOf('.') > f.LastIndexOf('\\') && acceptedExtensions.Contains(f.Substring(f.LastIndexOf('.') + 1)))
                        {
                            fileProcessor(f);
                        }
                    }
                    else
                    {
                        fileProcessor(f);
                    }
                }
                if (searchRecursively)
                    foreach (string d in Directory.GetDirectories(rootDirectory))
                    {
                        RecursiveProcess(d, acceptedExtensions, searchRecursively, fileProcessor);
                    }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
            return paths;
        }
    }
}
