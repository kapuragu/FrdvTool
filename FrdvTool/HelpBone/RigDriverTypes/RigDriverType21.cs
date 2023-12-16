using System.Xml.Serialization;

namespace FrdvTool.HelpBone
{
    [XmlType]
    public class RigDriverType21 : RigDriver
    {
        [XmlElement]
        public float LimitMin { get; set; }
        [XmlElement]
        public float LimitMax { get; set; }
        [XmlElement]
        public FoxHash MaterialNameA = new();
        [XmlElement]
        public FoxHash MaterialParamA = new();
        [XmlElement]
        public FoxHash MaterialParamB = new();
        [XmlElement]
        public Vector3 Up = new();
        [XmlElement]
        public Vector3 Forward = new();
        public override void ReadTypeParams(BinaryReader reader, HashManager hashManager)
        {
            reader.ReadBytes(sizeof(uint) * 2);
            LimitMin = reader.ReadSingle();
            LimitMax = reader.ReadSingle();
            MaterialNameA.Read(reader, hashManager.StrCode32LookupTable);
            reader.ReadBytes(sizeof(uint) * 5);
            MaterialParamA.Read(reader, hashManager.StrCode32LookupTable);
            MaterialParamB.Read(reader, hashManager.StrCode32LookupTable);
            reader.ReadUInt32();
            Up = new();
            Up.Read(reader); reader.ReadUInt32();
            Forward = new();
            Forward.Read(reader); reader.ReadUInt32();
        }
        public override void WriteTypeParams(BinaryWriter writer)
        {
            writer.WriteZeroes(sizeof(uint)*2);
            writer.Write(LimitMin);
            writer.Write(LimitMax);
            MaterialNameA.Write(writer);
            writer.WriteZeroes(sizeof(uint) * 5);
            MaterialParamA.Write(writer);
            MaterialParamB.Write(writer);
            writer.WriteZeroes(sizeof(uint));
            Up.Write(writer); writer.WriteZeroes(sizeof(uint));
            Forward.Write(writer);
        }
    }
}
