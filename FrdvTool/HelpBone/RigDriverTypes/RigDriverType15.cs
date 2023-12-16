using System.Xml.Serialization;

namespace FrdvTool.HelpBone
{
    [XmlType]
    public class RigDriverType15 : RigDriver
    {
        [XmlElement]
        public Vector3 VecA = new();
        [XmlElement]
        public Vector3 VecB = new();
        [XmlElement]
        public Vector3 VecC = new();
        [XmlElement]
        public Vector3 VecD = new();
        public override void ReadTypeParams(BinaryReader reader, HashManager hashManager)
        {
            reader.ReadBytes(sizeof(uint) * 12);
            VecA = new();
            VecA.Read(reader); reader.ReadUInt32();
            VecB = new();
            VecB.Read(reader); reader.ReadUInt32();
            VecC = new();
            VecC.Read(reader); reader.ReadUInt32();
            VecD = new();
            VecD.Read(reader);
        }
        public override void WriteTypeParams(BinaryWriter writer)
        {
            writer.WriteZeroes(sizeof(uint)*12);
            VecA.Write(writer); writer.WriteZeroes(sizeof(uint));
            VecB.Write(writer); writer.WriteZeroes(sizeof(uint));
            VecC.Write(writer); writer.WriteZeroes(sizeof(uint));
            VecD.Write(writer);
        }
    }
}
