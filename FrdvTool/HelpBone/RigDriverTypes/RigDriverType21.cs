using System.Xml.Serialization;

namespace FrdvTool.HelpBone
{
    [XmlType]
    public class RigDriverType21 : RigDriver
    {
        [XmlElement]
        public float LimitMin { get; set; }
        [XmlElement]
        public float LimitMax { get; set; }
        [XmlElement]
        public uint MaterialNameA { get; set; }
        [XmlElement]
        public uint MaterialParamA { get; set; }
        [XmlElement]
        public uint MaterialParamB { get; set; }
        [XmlElement]
        public Vector3 Up = new();
        [XmlElement]
        public Vector3 Forward = new();
        public override void ReadTypeParams(BinaryReader reader)
        {
            reader.ReadBytes(sizeof(uint) * 2);
            LimitMin = reader.ReadSingle();
            LimitMax = reader.ReadSingle();
            MaterialNameA = reader.ReadUInt32();
            reader.ReadBytes(sizeof(uint) * 5);
            MaterialParamA = reader.ReadUInt32();
            MaterialParamB = reader.ReadUInt32();
            reader.ReadUInt32();
            Up = new();
            Up.Read(reader); reader.ReadUInt32();
            Forward = new();
            Forward.Read(reader); reader.ReadUInt32();
        }
        public override void WriteTypeParams(BinaryWriter writer)
        {
            writer.WriteZeroes(sizeof(uint)*2);
            writer.Write(LimitMin);
            writer.Write(LimitMax);
            writer.Write(MaterialNameA);
            writer.WriteZeroes(sizeof(uint) * 5);
            writer.Write(MaterialParamA);
            writer.Write(MaterialParamB);
            writer.WriteZeroes(sizeof(uint));
            Up.Write(writer); writer.WriteZeroes(sizeof(uint));
            Forward.Write(writer);
        }
    }
}
