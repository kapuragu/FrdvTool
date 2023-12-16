using System.Xml.Serialization;

namespace FrdvTool.HelpBone
{
    [XmlType]
    public class RigDriverType20 : RigDriver
    {
        [XmlElement]
        public float Weight { get; set; }
        [XmlElement]    
        public float LimitMin { get; set; }
        [XmlElement]
        public float LimitMax { get; set; }
        [XmlElement]
        public FoxHash MaterialNameA = new();
        [XmlElement]
        public FoxHash MaterialNameC = new();
        [XmlElement]
        public FoxHash MaterialParamC = new();
        [XmlElement]
        public FoxHash MaterialNameB = new();
        [XmlElement]
        public FoxHash MaterialParamA = new();
        [XmlElement]
        public FoxHash MaterialParamB = new();
        public override void ReadTypeParams(BinaryReader reader, HashManager hashManager)
        {
            Weight = reader.ReadSingle();
            reader.ReadUInt32();
            LimitMin = reader.ReadSingle();
            LimitMax = reader.ReadSingle();
            MaterialNameA.Read(reader, hashManager.StrCode32LookupTable);
            reader.ReadBytes(sizeof(uint) * 2);
            MaterialNameC.Read(reader, hashManager.StrCode32LookupTable);
            MaterialParamC.Read(reader, hashManager.StrCode32LookupTable);
            MaterialNameB.Read(reader, hashManager.StrCode32LookupTable);
            MaterialParamA.Read(reader, hashManager.StrCode32LookupTable);
            MaterialParamB.Read(reader, hashManager.StrCode32LookupTable);
        }
        public override void WriteTypeParams(BinaryWriter writer)
        {
            writer.Write(Weight);
            writer.WriteZeroes(sizeof(uint));
            writer.Write(LimitMin);
            writer.Write(LimitMax);
            MaterialNameA.Write(writer);
            writer.WriteZeroes(sizeof(uint) * 2);
            MaterialNameC.Write(writer);
            MaterialParamC.Write(writer);
            MaterialNameB.Write(writer);
            MaterialParamA.Write(writer);
            MaterialParamB.Write(writer);
        }
    }
}
