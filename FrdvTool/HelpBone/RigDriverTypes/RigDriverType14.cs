using System.Xml.Serialization;

namespace FrdvTool.HelpBone
{
    [XmlType]
    public class RigDriverType14 : RigDriver
    {
        [XmlElement]
        public float Weight { get; set; }
        [XmlElement]
        public float LimitMinDeg { get; set; }
        [XmlElement]
        public float LimitMaxDeg { get; set; }
        [XmlElement]
        public FRDV_LIMIT_AXIS Axis { get; set; }
        [XmlElement]
        public float WeightB { get; set; }
        [XmlElement]
        public float LimitMinBDegrees { get; set; }
        [XmlElement]
        public float LimitMaxBDegrees { get; set; }
        [XmlElement]
        public bool UnknownBool { get; set; }
        [XmlElement]
        public FRDV_ACTION_TYPE_14_UNK_ENUM UnknownEnum { get; set; }
        [XmlElement]
        public Vector3 VecA = new();
        [XmlElement]
        public Vector3 VecB = new();
        public override void ReadTypeParams(BinaryReader reader)
        {
            Weight = reader.ReadSingle();
            reader.ReadUInt32();
            LimitMinDeg = reader.ReadSingle();
            LimitMaxDeg = reader.ReadSingle();
            Axis = (FRDV_LIMIT_AXIS)reader.ReadUInt32();
            WeightB = reader.ReadSingle();
            reader.ReadBytes(0x4);
            LimitMinBDegrees = reader.ReadSingle();
            LimitMaxBDegrees = reader.ReadSingle();
            UnknownBool = (reader.ReadByte() > 0); reader.ReadBytes(0x3);
            UnknownEnum = (FRDV_ACTION_TYPE_14_UNK_ENUM)reader.ReadUInt32();
            VecA = new();
            VecA.Read(reader); reader.ReadUInt32();
            VecB = new();
            VecB.Read(reader);
        }
        public override void WriteTypeParams(BinaryWriter writer)
        {
            writer.Write(Weight);
            writer.WriteZeroes(sizeof(uint));
            writer.Write(LimitMinDeg);
            writer.Write(LimitMaxDeg);
            writer.Write((uint)Axis);
            writer.Write(WeightB);
            writer.WriteZeroes(sizeof(uint));
            writer.Write(LimitMinBDegrees);
            writer.Write(LimitMaxBDegrees);
            writer.Write(UnknownBool); writer.AlignStream(sizeof(uint));
            writer.Write((uint)UnknownEnum);
            VecA.Write(writer); writer.WriteZeroes(sizeof(uint));
            VecB.Write(writer);
        }
    }
}
