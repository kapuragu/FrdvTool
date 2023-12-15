using System.Xml.Serialization;

namespace FrdvTool.HelpBone
{
    [XmlType]
    public class RigDriverType6 : RigDriver
    {
        [XmlElement]
        public float WeightDeg { get; set; }
        [XmlElement]
        public float LimitMin { get; set; }
        [XmlElement]
        public float LimitMax { get; set; }
        [XmlElement]
        public FRDV_LIMIT_AXIS Axis { get; set; }
        [XmlElement]
        public float WeightB { get; set; }
        [XmlElement]
        public Vector3 VecA = new();
        public override void ReadTypeParams(BinaryReader reader)
        {
            WeightDeg = reader.ReadSingle();
            reader.ReadUInt32();
            LimitMin = reader.ReadSingle();
            LimitMax = reader.ReadSingle();
            Axis = (FRDV_LIMIT_AXIS)reader.ReadUInt32();
            WeightB = reader.ReadSingle();
            reader.ReadBytes(sizeof(uint) * 6);
            VecA = new();
            VecA.Read(reader);
        }
        public override void WriteTypeParams(BinaryWriter writer)
        {
            writer.Write(WeightDeg);
            writer.WriteZeroes(sizeof(uint));
            writer.Write(LimitMin);
            writer.Write(LimitMax);
            writer.Write((uint)Axis);
            writer.Write(WeightB);
            writer.WriteZeroes(sizeof(uint)*6);
            VecA.Write(writer);
        }
    }
}
