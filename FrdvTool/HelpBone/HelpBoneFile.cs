using System.Xml.Serialization;

namespace FrdvTool.HelpBone
{
    [XmlType]
    public class HelpBoneFile
    {
        private static readonly uint AzureX11WebColor = 1447318086;
        private static readonly uint PowderBlue = 201306280; //June 28th, 2013
        [XmlArray]
        public List<RigDriver> rigDrivers = new();
        public void Read(BinaryReader reader)
        {
            if (reader.ReadUInt32() != AzureX11WebColor)
                throw new Exception("Signature wrong, quitting");

            if (reader.ReadUInt32() != PowderBlue)
                throw new Exception("Version date wrong, quitting");

            uint driverCount = reader.ReadUInt32();

            reader.BaseStream.Position = 0x10;

            uint[] offsets = new uint[driverCount];
            for (int i = 0; i<driverCount; i++)
                offsets[i] = reader.ReadUInt32();

            for (int i = 0; i<driverCount; i++)
            {
                reader.BaseStream.Position = offsets[i];

                FRDV_ACTION_TYPE type = (FRDV_ACTION_TYPE)reader.ReadInt16();
                RigDriver rigDriver = new();
                switch (type)
                {
                    case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_1:
                        rigDriver = new RigDriverType1();
                        break;
                    case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_2:
                        rigDriver = new RigDriverType2();
                        break;
                    case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_3:
                        rigDriver = new RigDriverType3();
                        break;
                    case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_4:
                        rigDriver = new RigDriverType4();
                        break;
                    case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_5:
                        rigDriver = new RigDriverType5();
                        break;
                    case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_6:
                        rigDriver = new RigDriverType6();
                        break;
                    case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_7:
                        rigDriver = new RigDriverType7();
                        break;
                    case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_8:
                        rigDriver = new RigDriverType8();
                        break;
                    case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_9:
                        rigDriver = new RigDriverType9();
                        break;
                    case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_10:
                        rigDriver = new RigDriverType10();
                        break;
                    case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_11:
                        rigDriver = new RigDriverType11();
                        break;
                    case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_12:
                        rigDriver = new RigDriverType12();
                        break;
                    case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_13:
                        rigDriver = new RigDriverType13();
                        break;
                    case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_14:
                        rigDriver = new RigDriverType14();
                        break;
                    case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_15:
                        rigDriver = new RigDriverType15();
                        break;
                    case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_16:
                        rigDriver = new RigDriverType16();
                        break;
                    case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_17:
                        rigDriver = new RigDriverType17();
                        break;
                    case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_18:
                        rigDriver = new RigDriverType18();
                        break;
                    case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_19:
                        rigDriver = new RigDriverType19();
                        break;
                    case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_20:
                        rigDriver = new RigDriverType20();
                        break;
                    case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_21:
                        rigDriver = new RigDriverType21();
                        break;
                    case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_22:
                        rigDriver = new RigDriverType22();
                        break;
                    case FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_23:
                        rigDriver = new RigDriverType23();
                        break;
                }
                rigDriver.Read(reader);

                rigDrivers.Add(rigDriver);
            }
        }
        public void Write(BinaryWriter writer)
        {
            writer.Write(AzureX11WebColor);
            writer.Write(PowderBlue);
            writer.Write((uint)rigDrivers.Count);
            writer.WriteZeroes(sizeof(uint));

            uint offsetsPos = (uint)writer.BaseStream.Position;
            writer.WriteZeroes(sizeof(uint) * rigDrivers.Count-1);
            writer.AlignStream(16);

            var rigDriverArrayStart = writer.BaseStream.Position;
            for (int i = 0; i < rigDrivers.Count; i++)
            {
                var offset = rigDriverArrayStart + (0x80 * i);
                writer.BaseStream.Position = offsetsPos + (sizeof(uint) * i);
                writer.Write((uint)offset);
                writer.BaseStream.Position = offset;
                switch (rigDrivers[i])
                {
                    case RigDriverType1:
                        writer.Write((short)FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_1);
                        break;
                    case RigDriverType2:
                        writer.Write((short)FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_2);
                        break;
                    case RigDriverType3:
                        writer.Write((short)FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_3);
                        break;
                    case RigDriverType4:
                        writer.Write((short)FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_4);
                        break;
                    case RigDriverType5:
                        writer.Write((short)FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_5);
                        break;
                    case RigDriverType6:
                        writer.Write((short)FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_6);
                        break;
                    case RigDriverType7:
                        writer.Write((short)FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_7);
                        break;
                    case RigDriverType8:
                        writer.Write((short)FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_8);
                        break;
                    case RigDriverType9:
                        writer.Write((short)FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_9);
                        break;
                    case RigDriverType10:
                        writer.Write((short)FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_10);
                        break;
                    case RigDriverType11:
                        writer.Write((short)FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_11);
                        break;
                    case RigDriverType12:
                        writer.Write((short)FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_12);
                        break;
                    case RigDriverType13:
                        writer.Write((short)FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_13);
                        break;
                    case RigDriverType14:
                        writer.Write((short)FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_14);
                        break;
                    case RigDriverType15:
                        writer.Write((short)FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_15);
                        break;
                    case RigDriverType16:
                        writer.Write((short)FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_16);
                        break;
                    case RigDriverType17:
                        writer.Write((short)FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_17);
                        break;
                    case RigDriverType18:
                        writer.Write((short)FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_18);
                        break;
                    case RigDriverType19:
                        writer.Write((short)FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_19);
                        break;
                    case RigDriverType20:
                        writer.Write((short)FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_20);
                        break;
                    case RigDriverType21:
                        writer.Write((short)FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_21);
                        break;
                    case RigDriverType22:
                        writer.Write((short)FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_22);
                        break;
                    case RigDriverType23:
                        writer.Write((short)FRDV_ACTION_TYPE.FRDV_ACTION_TYPE_23);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"Unsupported type: {rigDrivers[i].GetType()}");
                }
                rigDrivers[i].Write(writer);
                writer.WriteZeroes((int)(offset - writer.BaseStream.Position + 0x80));
            }
        }
    }
}
