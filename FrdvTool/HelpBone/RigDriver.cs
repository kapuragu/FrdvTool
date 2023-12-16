using System.Xml.Linq;
using System.Xml.Serialization;

namespace FrdvTool.HelpBone
{
    public enum FRDV_ACTION_TYPE : short
    {
        FRDV_ACTION_TYPE_INVALID = -1,
        FRDV_ACTION_TYPE_1 = 1,
        FRDV_ACTION_TYPE_2 = 2,
        FRDV_ACTION_TYPE_3 = 3,
        FRDV_ACTION_TYPE_4 = 4,
        FRDV_ACTION_TYPE_5 = 5,
        FRDV_ACTION_TYPE_6 = 6,
        FRDV_ACTION_TYPE_7 = 7,
        FRDV_ACTION_TYPE_8 = 8,
        FRDV_ACTION_TYPE_9 = 9,
        FRDV_ACTION_TYPE_10 = 10,
        FRDV_ACTION_TYPE_11 = 11,
        FRDV_ACTION_TYPE_12 = 12,
        FRDV_ACTION_TYPE_13 = 13,
        FRDV_ACTION_TYPE_14 = 14,
        FRDV_ACTION_TYPE_15 = 15,
        FRDV_ACTION_TYPE_16 = 16,
        FRDV_ACTION_TYPE_17 = 17,
        FRDV_ACTION_TYPE_18 = 18,
        FRDV_ACTION_TYPE_19 = 19,
        FRDV_ACTION_TYPE_20 = 20,
        FRDV_ACTION_TYPE_21 = 21,
        FRDV_ACTION_TYPE_22 = 22,
        FRDV_ACTION_TYPE_23 = 23,
    }
    public enum FRDV_LIMIT_AXIS : uint
    {
        FRDV_LIMIT_AXIS_X = 0,
        FRDV_LIMIT_AXIS_Y = 1,
        FRDV_LIMIT_AXIS_Z = 2,
    }
    public enum FRDV_ACTION_TYPE_14_UNK_ENUM : uint
    {
        FRDV_ACTION_TYPE_14_UNK_ENUM_0 = 0,
        FRDV_ACTION_TYPE_14_UNK_ENUM_1 = 1,
        FRDV_ACTION_TYPE_14_UNK_ENUM_2 = 2,
        FRDV_ACTION_TYPE_14_UNK_ENUM_3 = 3,
        FRDV_ACTION_TYPE_14_UNK_ENUM_4 = 4,
        FRDV_ACTION_TYPE_14_UNK_ENUM_5 = 5,
    }
    [XmlInclude(typeof(RigDriverType1))]
    [XmlInclude(typeof(RigDriverType2))]
    [XmlInclude(typeof(RigDriverType3))]
    [XmlInclude(typeof(RigDriverType4))]
    [XmlInclude(typeof(RigDriverType5))]
    [XmlInclude(typeof(RigDriverType6))]
    [XmlInclude(typeof(RigDriverType7))]
    [XmlInclude(typeof(RigDriverType8))]
    [XmlInclude(typeof(RigDriverType9))]
    [XmlInclude(typeof(RigDriverType10))]
    [XmlInclude(typeof(RigDriverType11))]
    [XmlInclude(typeof(RigDriverType12))]
    [XmlInclude(typeof(RigDriverType13))]
    [XmlInclude(typeof(RigDriverType14))]
    [XmlInclude(typeof(RigDriverType15))]
    [XmlInclude(typeof(RigDriverType16))]
    [XmlInclude(typeof(RigDriverType17))]
    [XmlInclude(typeof(RigDriverType18))]
    [XmlInclude(typeof(RigDriverType19))]
    [XmlInclude(typeof(RigDriverType20))]
    [XmlInclude(typeof(RigDriverType21))]
    [XmlInclude(typeof(RigDriverType22))]
    [XmlInclude(typeof(RigDriverType23))]
    [XmlType]
    public class RigDriver
    {
        [XmlAttribute]
        public string Target { get; set; } = string.Empty;
        [XmlAttribute]
        public string Source { get; set; } = string.Empty;
        [XmlAttribute]
        public string Source2 { get; set; } = string.Empty;
        [XmlAttribute]
        public string TargetParent { get; set; } = string.Empty;
        [XmlAttribute]
        public string SourceParent { get; set; } = string.Empty;
        [XmlAttribute]
        public string SourceParent2 { get; set; } = string.Empty;

        public void Read(BinaryReader reader, HashManager hashManager, Dictionary<short, FoxHash> bones)
        {
            Target = ReadIndex(reader, bones);
            Source = ReadIndex(reader, bones);
            Source2 = ReadIndex(reader, bones);
            TargetParent = ReadIndex(reader, bones);
            SourceParent = ReadIndex(reader, bones);
            SourceParent2 = ReadIndex(reader, bones);
            reader.ReadUInt16();

            ReadTypeParams(reader, hashManager);
        }
        private static string ReadIndex(BinaryReader reader, Dictionary<short,FoxHash> bones)
        {
            var index = reader.ReadInt16();
            if (index >= 0)
            {
                return bones.ContainsKey(index) ? bones[index].Name : index.ToString();
            }
            return index.ToString();
        }
        public virtual void ReadTypeParams(BinaryReader reader, HashManager hashManager) => throw new ArgumentOutOfRangeException($"Rig type {this.GetType()} unsupported");
        public void Write(BinaryWriter writer, Dictionary<short, FoxHash> bones)
        {
            WriteIndex(Target, writer, bones);
            WriteIndex(Source, writer, bones);
            WriteIndex(Source2, writer, bones);
            WriteIndex(TargetParent, writer, bones);
            WriteIndex(SourceParent, writer, bones);
            WriteIndex(SourceParent2, writer, bones);
            writer.WriteZeroes(sizeof(ushort));
            WriteTypeParams(writer);
        }
        public void WriteIndex(string name, BinaryWriter writer, Dictionary<short, FoxHash> bones)
        {
            short index = short.TryParse(name, out short _index) ? _index : bones.FirstOrDefault(x => x.Value.Name.Equals(name)).Key;
            writer.Write(index);
        }
        public virtual void WriteTypeParams(BinaryWriter writer) => throw new ArgumentOutOfRangeException($"Rig type {this.GetType()} unsupported");
    }
}
