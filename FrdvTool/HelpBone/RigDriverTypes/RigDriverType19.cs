using System.Xml.Serialization;

namespace FrdvTool.HelpBone
{
    [XmlType]
    public class RigDriverType19 : RigDriver
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
        public FoxHash MaterialNameB = new();
        [XmlElement]
        public FoxHash MaterialParamA = new();
        [XmlElement]
        public FoxHash MaterialParamB = new();
        [XmlElement]
        public Vector3 Up = new();
        [XmlElement]
        public Vector3 Forward = new();
        [XmlElement]
        public Vector3 VecA = new();
        [XmlElement]
        public Vector3 VecB = new();
        public override void ReadTypeParams(BinaryReader reader, HashManager hashManager)
        {
            Weight = reader.ReadSingle();
            reader.ReadUInt32();
            LimitMin = reader.ReadSingle();
            LimitMax = reader.ReadSingle();
            MaterialNameA.Read(reader, hashManager.StrCode32LookupTable);
            reader.ReadBytes(sizeof(uint) * 4);
            MaterialNameB.Read(reader, hashManager.StrCode32LookupTable);
            MaterialParamA.Read(reader, hashManager.StrCode32LookupTable);
            MaterialParamB.Read(reader, hashManager.StrCode32LookupTable);
            Up = new();
            Up.Read(reader); reader.ReadUInt32();
            Forward = new();
            Forward.Read(reader); reader.ReadUInt32();
            VecA = new();
            VecA.Read(reader); reader.ReadUInt32();
            VecB = new();
            VecB.Read(reader);
        }
        public override void WriteTypeParams(BinaryWriter writer)
        {
            writer.Write(Weight);
            writer.WriteZeroes(sizeof(uint));
            writer.Write(LimitMin);
            writer.Write(LimitMax);
            MaterialNameA.Write(writer);
            writer.WriteZeroes(sizeof(uint)*4);
            MaterialNameB.Write(writer);
            MaterialParamA.Write(writer);
            MaterialParamB.Write(writer);
            Up.Write(writer); writer.WriteZeroes(sizeof(uint));
            Forward.Write(writer); writer.WriteZeroes(sizeof(uint));
            VecA.Write(writer); writer.WriteZeroes(sizeof(uint));
            VecB.Write(writer);
        }
    }
}
