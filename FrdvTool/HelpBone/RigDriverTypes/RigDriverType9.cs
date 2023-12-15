using System.Xml.Serialization;

namespace FrdvTool.HelpBone
{
    [XmlType]
    public class RigDriverType9 : RigDriver
    {
        [XmlElement]
        public float Weight { get; set; }
        [XmlElement]
        public float WeightB { get; set; }
        [XmlElement]
        public Vector3 VecA = new();
        public override void ReadTypeParams(BinaryReader reader)
        {
            Weight = reader.ReadSingle();
            reader.ReadBytes(sizeof(uint) * 4);
            WeightB = reader.ReadSingle();
            reader.ReadBytes(sizeof(uint) * 6);
            VecA = new();
            VecA.Read(reader);
        }
        public override void WriteTypeParams(BinaryWriter writer)
        {
            writer.Write(Weight);
            writer.WriteZeroes(sizeof(uint) * 4);
            writer.Write(WeightB);
            writer.WriteZeroes(sizeof(uint) * 6);
            VecA.Write(writer);
        }
    }
}
