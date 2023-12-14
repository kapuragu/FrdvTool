using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
    public class HelpBone
    {
        public FRDV_ACTION_TYPE HelpBoneType { get; set; }

        public short TargetSkelIndex { get; set; }
        public short SourceSkelIndex { get; set; }
        public short SourceSkelIndex2 { get; set; }
        public short TargetParentIndex { get; set; }
        public short SourceParentSkelIndex { get; set; }
        public short SourceParentSkelIndex2 { get; set; }

        public HelpBoneTypeData helpBoneTypeData { get; set; }

        public void Read(BinaryReader reader)
        {
            HelpBoneType = (FRDV_ACTION_TYPE)reader.ReadInt16();

            TargetSkelIndex = reader.ReadInt16();
            SourceSkelIndex = reader.ReadInt16();
            SourceSkelIndex2 = reader.ReadInt16();
            TargetParentIndex = reader.ReadInt16();
            SourceParentSkelIndex = reader.ReadInt16();
            SourceParentSkelIndex2 = reader.ReadInt16();
            reader.ReadUInt16();

            switch(HelpBoneType)
            {
                case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_1:
                    helpBoneTypeData = new HelpBoneType1();
                    break;
                case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_2:
                    helpBoneTypeData = new HelpBoneType2();
                    break;
                case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_3:
                    helpBoneTypeData = new HelpBoneType3();
                    break;
                case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_4:
                    helpBoneTypeData = new HelpBoneType4();
                    break;
                case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_5:
                    helpBoneTypeData = new HelpBoneType5();
                    break;
                case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_6:
                    helpBoneTypeData = new HelpBoneType6();
                    break;
                case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_7:
                    helpBoneTypeData = new HelpBoneType7();
                    break;
                case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_8:
                    helpBoneTypeData = new HelpBoneType8();
                    break;
                case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_9:
                    helpBoneTypeData = new HelpBoneType9();
                    break;
                case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_10:
                    helpBoneTypeData = new HelpBoneType10();
                    break;
                case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_11:
                    helpBoneTypeData = new HelpBoneType11();
                    break;
                case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_12:
                    helpBoneTypeData = new HelpBoneType12();
                    break;
                case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_13:
                    helpBoneTypeData = new HelpBoneType13();
                    break;
                case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_14:
                    helpBoneTypeData = new HelpBoneType14();
                    break;
                case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_15:
                    helpBoneTypeData = new HelpBoneType15();
                    break;
                case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_16:
                    helpBoneTypeData = new HelpBoneType16();
                    break;
                case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_17:
                    helpBoneTypeData = new HelpBoneType17();
                    break;
                case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_18:
                    helpBoneTypeData = new HelpBoneType18();
                    break;
                case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_19:
                    helpBoneTypeData = new HelpBoneType19();
                    break;
                case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_20:
                    helpBoneTypeData = new HelpBoneType20();
                    break;
                case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_21:
                    helpBoneTypeData = new HelpBoneType21();
                    break;
                case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_22:
                    helpBoneTypeData = new HelpBoneType22();
                    break;
                case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_23:
                    helpBoneTypeData = new HelpBoneType23();
                    break;
            }
            helpBoneTypeData.Read(reader);
        }
    }
}
