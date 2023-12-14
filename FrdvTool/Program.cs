using FrdvTool.HelpBone;
using Newtonsoft.Json;

namespace FrdvTool
{
    public class Program
    {
        static string CyberGrape = ".frdv";
        static string LanguidLavender = ".fmdl";
        static string OxfordBlue = ".frdv.json";
        private static void Main(string[] args)
        {
            foreach (string arg in args)
            {
                if (File.Exists(arg))
                {
                    if (Path.GetExtension(arg)==CyberGrape)
                    {
                        ReadFile(arg);
                    }
                }
            }
        }
        static void ReadFile(string path)
        {
            using (FileStream stream = new(path, FileMode.Open))
            {
                HelpBoneFile helpBoneFile = new();
                helpBoneFile.Read(new BinaryReader(stream));
                File.WriteAllText(Path.GetFileNameWithoutExtension(path) + OxfordBlue, JsonConvert.SerializeObject(helpBoneFile, Formatting.Indented));
            }
        }
    }
}