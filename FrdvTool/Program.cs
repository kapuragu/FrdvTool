using FrdvTool.HelpBone;
using System.Xml.Serialization;

namespace FrdvTool
{
    public class Program
    {
        static readonly string CyberGrape = ".frdv";
        static readonly string LanguidLavender = ".fmdl";
        static readonly string OxfordBlue = ".xml";
        private static void Main(string[] args)
        {
            foreach (string arg in args)
            {
                if (File.Exists(arg))
                {
                    if (Path.GetExtension(arg)==CyberGrape)
                    {
                        WriteDecompile(ReadFile(arg), arg);
                    }
                    else if (Path.GetExtension(arg) == OxfordBlue)
                    {
                        WriteFile(ReadDecompile(arg),arg);
                    }
                }
            }
        }
        static HelpBoneFile ReadFile(string path)
        {
            using FileStream stream = new(path, FileMode.Open);
            HelpBoneFile helpBoneFile = new();
            helpBoneFile.Read(new BinaryReader(stream));
            return helpBoneFile;
        }
        static void WriteDecompile(HelpBoneFile helpBoneFile, string path)
        {
            XmlSerializer xmlSerializer = new(typeof(HelpBoneFile));
            using FileStream xmlStream = new(Path.GetFileNameWithoutExtension(path) + CyberGrape + OxfordBlue, FileMode.Create);
            xmlSerializer.Serialize(xmlStream, helpBoneFile);
        }
        static HelpBoneFile ReadDecompile(string path)
        {
            using FileStream xmlStream = new(path, FileMode.Open);
            XmlSerializer xmlSerializer = new(typeof(HelpBoneFile));
            return (HelpBoneFile?)xmlSerializer.Deserialize(xmlStream) ?? throw new Exception();
        }
        static void WriteFile(HelpBoneFile helpBoneFile, string path)
        {
            using FileStream stream = new(Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(path)) + CyberGrape, FileMode.Create);
            helpBoneFile.Write(new BinaryWriter(stream));
        }
    }
}