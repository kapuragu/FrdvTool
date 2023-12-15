using System.Xml.Serialization;

namespace FrdvTool.HelpBone
{
    [XmlType]
    public class RigDriverType1 : RigDriver
    {
        [XmlElement]
        public float WeightDeg { get; set; }
        [XmlElement]
        public float LimitMin { get; set; }
        [XmlElement]
        public float LimitMax { get; set; }
        [XmlElement]
        public FRDV_LIMIT_AXIS Axis { get; set; }
        public override void ReadTypeParams(BinaryReader reader)
        {
            WeightDeg = reader.ReadSingle();
            reader.ReadUInt32();
            LimitMin = reader.ReadSingle();
            LimitMax = reader.ReadSingle();
            Axis = (FRDV_LIMIT_AXIS)reader.ReadUInt32();
        }
        public override void WriteTypeParams(BinaryWriter writer)
        {
            writer.Write(WeightDeg);
            writer.WriteZeroes(sizeof(uint));
            writer.Write(LimitMin);
            writer.Write(LimitMax);
            writer.Write((uint)Axis);
        }
    }
}
