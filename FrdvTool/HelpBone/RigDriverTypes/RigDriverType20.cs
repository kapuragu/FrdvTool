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
        public uint MaterialNameA { get; set; }
        [XmlElement]
        public uint MaterialNameC { get; set; }
        [XmlElement]
        public uint MaterialParamC { get; set; }
        [XmlElement]
        public uint MaterialNameB { get; set; }
        [XmlElement]
        public uint MaterialParamA { get; set; }
        [XmlElement]
        public uint MaterialParamB { get; set; }
        public override void ReadTypeParams(BinaryReader reader)
        {
            Weight = reader.ReadSingle();
            reader.ReadUInt32();
            LimitMin = reader.ReadSingle();
            LimitMax = reader.ReadSingle();
            MaterialNameA = reader.ReadUInt32();
            reader.ReadBytes(sizeof(uint) * 2);
            MaterialNameC = reader.ReadUInt32();
            MaterialParamC = reader.ReadUInt32();
            MaterialNameB = reader.ReadUInt32();
            MaterialParamA = reader.ReadUInt32();
            MaterialParamB = reader.ReadUInt32();
        }
        public override void WriteTypeParams(BinaryWriter writer)
        {
            writer.Write(Weight);
            writer.WriteZeroes(sizeof(uint));
            writer.Write(LimitMin);
            writer.Write(LimitMax);
            writer.Write(MaterialNameA);
            writer.WriteZeroes(sizeof(uint) * 2);
            writer.Write(MaterialNameC);
            writer.Write(MaterialParamC);
            writer.Write(MaterialNameB);
            writer.Write(MaterialParamA);
            writer.Write(MaterialParamB);
        }
    }
}
