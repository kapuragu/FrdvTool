using System.Xml.Serialization;

namespace FrdvTool.HelpBone
{
    [XmlType]
    public class RigDriverType23 : RigDriver
    {
        [XmlElement]
        public float Weight { get; set; }
        [XmlElement]
        public float Offset { get; set; }
        [XmlElement]
        public float LimitMin { get; set; }
        [XmlElement]
        public float LimitMax { get; set; }
        [XmlElement]
        public Vector3 Up = new();
        [XmlElement]
        public Vector3 Forward = new();
        public override void ReadTypeParams(BinaryReader reader, HashManager hashManager)
        {
            Weight = reader.ReadSingle();
            Offset = reader.ReadSingle();
            LimitMin = reader.ReadSingle();
            LimitMax = reader.ReadSingle();
            reader.ReadBytes(sizeof(uint) * 8);
            Up = new();
            Up.Read(reader); reader.ReadUInt32();
            Forward = new();
            Forward.Read(reader);
        }
        public override void WriteTypeParams(BinaryWriter writer)
        {
            writer.Write(Weight);
            writer.Write(Offset);
            writer.Write(LimitMin);
            writer.Write(LimitMax);
            writer.WriteZeroes(sizeof(uint) * 8);
            Up.Write(writer); writer.WriteZeroes(sizeof(uint));
            Forward.Write(writer);
        }
    }
}
