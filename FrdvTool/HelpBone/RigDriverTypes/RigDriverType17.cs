using System.Xml.Serialization;

namespace FrdvTool.HelpBone
{
    [XmlType]
    public class RigDriverType17 : RigDriver
    {
        [XmlElement]
        public float Weight { get; set; }
        [XmlElement]
        public Vector3 VecA = new();
        [XmlElement]
        public Vector3 VecB = new();
        public override void ReadTypeParams(BinaryReader reader)
        {
            Weight = reader.ReadSingle();
            reader.ReadBytes(sizeof(uint) * 11);
            VecA = new();
            VecA.Read(reader); reader.ReadUInt32();
            VecB = new();
            VecB.Read(reader);
        }
        public override void WriteTypeParams(BinaryWriter writer)
        {
            writer.Write(Weight);
            writer.WriteZeroes(sizeof(uint) * 11);
            VecA.Write(writer); writer.WriteZeroes(sizeof(uint));
            VecB.Write(writer);
        }
    }
}
