using System.Xml.Serialization;

namespace FrdvTool.HelpBone
{
    [XmlType]
    public class RigDriverType2 : RigDriver
    {
        [XmlElement]
        public float Weight { get; set; }
        public override void ReadTypeParams(BinaryReader reader, HashManager hashManager)
        {
            Weight = reader.ReadSingle();
        }
        public override void WriteTypeParams(BinaryWriter writer)
        {
            writer.Write(Weight);
        }
    }
}
