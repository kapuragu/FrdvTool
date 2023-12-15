using System.Xml.Serialization;

namespace FrdvTool.HelpBone
{
    [XmlType]
    public class RigDriverType12 : RigDriver
    {
        [XmlElement]
        public float Weight { get; set; }
        [XmlElement]
        public float WeightB { get; set; }
        [XmlElement]
        public float LimitMinB { get; set; }
        [XmlElement]
        public float LimitMaxB { get; set; }
        [XmlElement]
        public FRDV_LIMIT_AXIS AxisB { get; set; }
        [XmlElement]
        public Vector3 VecA = new();
        [XmlElement]
        public Vector3 VecB = new();
        public override void ReadTypeParams(BinaryReader reader)
        {
            Weight = reader.ReadSingle();
            reader.ReadUInt32();
            reader.ReadUInt64();
            reader.ReadUInt32();
            WeightB = reader.ReadSingle();
            reader.ReadUInt32();
            LimitMinB = reader.ReadSingle();
            LimitMaxB = reader.ReadSingle();
            AxisB = (FRDV_LIMIT_AXIS)reader.ReadUInt32();
            reader.ReadBytes(sizeof(uint) * 2);
            VecA = new();
            VecA.Read(reader); reader.ReadUInt32();
            VecB = new();
            VecB.Read(reader);
        }
        public override void WriteTypeParams(BinaryWriter writer)
        {
            writer.Write(Weight);
            writer.WriteZeroes(sizeof(uint)*4);
            writer.Write(WeightB);
            writer.WriteZeroes(sizeof(uint));
            writer.Write(LimitMinB);
            writer.Write(LimitMaxB);
            writer.Write((uint)AxisB);
            writer.WriteZeroes(sizeof(uint) * 2);
            VecA.Write(writer); writer.WriteZeroes(sizeof(uint));
            VecB.Write(writer);
        }
    }
}
