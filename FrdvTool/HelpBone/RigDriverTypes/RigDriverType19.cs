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
        public uint MaterialNameA { get; set; }
        [XmlElement]
        public uint MaterialNameB { get; set; }
        [XmlElement]
        public uint MaterialParamA { get; set; }
        [XmlElement]
        public uint MaterialParamB { get; set; }
        [XmlElement]
        public Vector3 Up = new();
        [XmlElement]
        public Vector3 Forward = new();
        [XmlElement]
        public Vector3 VecA = new();
        [XmlElement]
        public Vector3 VecB = new();
        public override void ReadTypeParams(BinaryReader reader)
        {
            Weight = reader.ReadSingle();
            reader.ReadUInt32();
            LimitMin = reader.ReadSingle();
            LimitMax = reader.ReadSingle();
            MaterialNameA = reader.ReadUInt32();
            reader.ReadBytes(sizeof(uint) * 4);
            MaterialNameB = reader.ReadUInt32();
            MaterialParamA = reader.ReadUInt32();
            MaterialParamB = reader.ReadUInt32();
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
            writer.Write(MaterialNameA);
            writer.WriteZeroes(sizeof(uint)*4);
            writer.Write(MaterialNameB);
            writer.Write(MaterialParamA);
            writer.Write(MaterialParamB);
            Up.Write(writer); writer.WriteZeroes(sizeof(uint));
            Forward.Write(writer); writer.WriteZeroes(sizeof(uint));
            VecA.Write(writer); writer.WriteZeroes(sizeof(uint));
            VecB.Write(writer);
        }
    }
}
