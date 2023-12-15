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
        public short TargetSkelIndex { get; set; }
        [XmlAttribute]
        public short SourceSkelIndex { get; set; }
        [XmlAttribute]
        public short SourceSkelIndex2 { get; set; }
        [XmlAttribute]
        public short TargetParentIndex { get; set; }
        [XmlAttribute]
        public short SourceParentSkelIndex { get; set; }
        [XmlAttribute]
        public short SourceParentSkelIndex2 { get; set; }

        public void Read(BinaryReader reader)
        {
            TargetSkelIndex = reader.ReadInt16();
            SourceSkelIndex = reader.ReadInt16();
            SourceSkelIndex2 = reader.ReadInt16();
            TargetParentIndex = reader.ReadInt16();
            SourceParentSkelIndex = reader.ReadInt16();
            SourceParentSkelIndex2 = reader.ReadInt16();
            reader.ReadUInt16();

            ReadTypeParams(reader);
        }
        public virtual void ReadTypeParams(BinaryReader reader) => throw new ArgumentOutOfRangeException($"Rig type {this.GetType()} unsupported");
        public void Write(BinaryWriter writer)
        {
            writer.Write(TargetSkelIndex);
            writer.Write(SourceSkelIndex);
            writer.Write(SourceSkelIndex2);
            writer.Write(TargetParentIndex);
            writer.Write(SourceParentSkelIndex);
            writer.Write(SourceParentSkelIndex2);
            writer.WriteZeroes(sizeof(ushort));
            WriteTypeParams(writer);
        }
        public virtual void WriteTypeParams(BinaryWriter writer) => throw new ArgumentOutOfRangeException($"Rig type {this.GetType()} unsupported");
    }
}
