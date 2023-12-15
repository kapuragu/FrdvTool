using System.Xml.Serialization;

namespace FrdvTool.HelpBone
{
    [XmlType]
    public class RigDriverType3 : RigDriver
    {
        [XmlElement]
        public float WeightDeg { get; set; }
        [XmlElement]
        public float Offset { get; set; }
        [XmlElement]
        public float LimitMin { get; set; }
        [XmlElement]
        public float LimitMax { get; set; }
        [XmlElement]
        public FRDV_LIMIT_AXIS Axis { get; set; }
        [XmlElement]
        public float WeightB { get; set; }
        public override void ReadTypeParams(BinaryReader reader)
        {
            WeightDeg = reader.ReadSingle();
            Offset = reader.ReadSingle();
            LimitMin = reader.ReadSingle();
            LimitMax = reader.ReadSingle();
            Axis = (FRDV_LIMIT_AXIS)reader.ReadUInt32();
            WeightB = reader.ReadSingle();
        }
        public override void WriteTypeParams(BinaryWriter writer)
        {
            writer.Write(WeightDeg);
            writer.Write(Offset);
            writer.Write(LimitMin);
            writer.Write(LimitMax);
            writer.Write((uint)Axis);
            writer.Write(WeightB);
        }
    }
}
