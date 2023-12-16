using FrdvTool.HelpBone;
using System.Collections.Concurrent;
using System.Reflection;
using System.Xml.Serialization;

namespace FrdvTool
{
    public class Program
    {
        private const string CyberGrape = ".frdv";
        private const string LanguidLavender = ".fmdl";
        private const string OxfordBlue = ".xml";
        private const string fileName = "fmdl_dictionary.txt";
        private static void Main(string[] args)
        {
            var dictionaries = new List<string>() { Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/" + fileName };
            HashManager hashManager = new() { 
                StrCode32LookupTable = MakeStrCode32HashLookupTableFromFiles(dictionaries) 
            };
            foreach (string arg in args)
            {
                if (File.Exists(arg))
                {
                    if (Path.GetExtension(arg)==CyberGrape)
                    {
                        WriteDecompile(ReadFile(arg, hashManager), arg);
                    }
                    else if (Path.GetExtension(arg) == OxfordBlue)
                    {
                        WriteFile(ReadDecompile(arg),arg,hashManager);
                    }
                }
            }
        }
        static HelpBoneFile ReadFile(string path, HashManager hashManager)
        {
            using FileStream stream = new(path, FileMode.Open);
            HelpBoneFile helpBoneFile = new();
            Dictionary<short, FoxHash> bones = new();
            var fmdlPath = Path.GetFileNameWithoutExtension(path) + LanguidLavender;
            if (File.Exists(fmdlPath))
                bones = ReadFmdl(fmdlPath, hashManager);
            helpBoneFile.Read(new BinaryReader(stream),hashManager,bones);
            return helpBoneFile;
        }
        static Dictionary<short, FoxHash> ReadFmdl(string path, HashManager hashManager)
        {
            Dictionary<short, FoxHash> bones = new();
            using FileStream stream = new(path, FileMode.Open);
            using BinaryReader reader = new(stream);

            reader.ReadBytes(sizeof(uint) * 2);
            uint fileDescOffset = reader.ReadUInt32();
            reader.ReadBytes(sizeof(uint) * 5);
            uint featureCount = reader.ReadUInt32();
            uint bufferCount = reader.ReadUInt32();
            uint featureDataOffset = reader.ReadUInt32();
            reader.ReadBytes(sizeof(uint));
            uint buffersDataOffset = reader.ReadUInt32();

            uint boneCount = 0;
            uint boneDefOffset = 0;
            uint stringCount = 0;
            uint stringOffset = 0;
            uint hashCount = 0;
            uint hashOffset = 0;

            for (int i = 0; i<featureCount; i++)
            {
                reader.BaseStream.Position = fileDescOffset + (i * sizeof(ulong));
                byte featureType=reader.ReadByte();
                reader.ReadByte();
                ushort entryCount = reader.ReadUInt16();
                uint dataOffset = reader.ReadUInt32();
                switch(featureType)
                {
                    case (byte)0:
                        boneCount = entryCount;
                        boneDefOffset = dataOffset;
                        break;
                    case (byte)12:
                        stringCount = entryCount;
                        stringOffset = dataOffset;
                        break;
                    case (byte)22:
                        hashCount = entryCount;
                        hashOffset = dataOffset;
                        break;
                }
            }
            uint stringBufferOffset = 0;
            for (int i = 0; i < bufferCount; i++)
            {
                uint bufferType = reader.ReadUInt32();
                uint bufferOffset = reader.ReadUInt32();
                if (bufferType==3)
                    stringBufferOffset = bufferOffset;
                reader.ReadUInt32();
            }

            for (int i = 0; i < boneCount; i++)
            {
                reader.BaseStream.Position = featureDataOffset + boneDefOffset + (i * sizeof(uint) * 12);
                short boneIndex = reader.ReadInt16();
                if (stringCount>0)
                {
                    reader.BaseStream.Position = featureDataOffset + stringOffset + (boneIndex * sizeof(ulong));
                    short bufferType = reader.ReadInt16();
                    ushort length = reader.ReadUInt16();
                    uint offset = reader.ReadUInt32();
                    if (length>1)
                    {
                        reader.BaseStream.Position = buffersDataOffset + stringBufferOffset + offset;
                        string boneNameString = reader.ReadCString();
                        bones.Add((short)(boneIndex - 1), new FoxHash() { Name = boneNameString });
                    }
                }
                else if (hashCount>0)
                {
                    reader.BaseStream.Position = featureDataOffset + hashOffset + boneIndex * sizeof(ulong);
                    FoxHash boneNameHash = new();
                    boneNameHash.Read64(reader, hashManager.StrCode32LookupTable);
                    bones.Add((short)(boneIndex - 1), boneNameHash);
                }
            }

            return bones;
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
        static void WriteFile(HelpBoneFile helpBoneFile, string path, HashManager hashManager)
        {
            using FileStream stream = new(Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(path)) + CyberGrape, FileMode.Create);
            Dictionary<short, FoxHash> bones = new();
            var fmdlPath = Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(path)) + LanguidLavender;
            if (File.Exists(fmdlPath))
                bones = ReadFmdl(fmdlPath, hashManager);
            helpBoneFile.Write(new BinaryWriter(stream), bones);
        }
        private static Dictionary<uint, string> MakeStrCode32HashLookupTableFromFiles(List<string> paths)
        {
            ConcurrentDictionary<uint, string> table = new();

            // Read file
            List<string> stringLiterals = new();
            foreach (var dictionary in paths)
            {
                using StreamReader file = new(dictionary);
                // TODO multi-thread
                string? line;
                while ((line = file.ReadLine()) != null)
                {
                    stringLiterals.Add(line);
                }
            }

            // Hash entries
            Parallel.ForEach(stringLiterals, (string entry) =>
            {
                uint hash = HashManager.StrCode32(entry);
                table.TryAdd(hash, entry);
            });

            return new Dictionary<uint, string>(table);
        }
    }
}