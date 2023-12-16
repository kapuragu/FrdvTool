﻿using System.Xml.Serialization;

namespace FrdvTool.HelpBone
{
    [XmlType]
    public class RigDriverType11 : RigDriver
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
        public Vector3 VecA = new();
        [XmlElement]
        public Vector3 VecB = new();
        public override void ReadTypeParams(BinaryReader reader, HashManager hashManager)
        {
            Weight = reader.ReadSingle();
            reader.ReadUInt32();
            LimitMinDeg = reader.ReadSingle();
            LimitMaxDeg = reader.ReadSingle();
            Axis = (FRDV_LIMIT_AXIS)reader.ReadUInt32();
            reader.ReadBytes(sizeof(uint) * 7);
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
            writer.WriteZeroes(sizeof(uint) * 7);
            VecA.Write(writer); writer.WriteZeroes(sizeof(uint));
            VecB.Write(writer);
        }
    }
}
