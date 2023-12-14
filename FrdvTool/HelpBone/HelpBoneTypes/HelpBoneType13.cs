﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrdvTool.HelpBone
{
    public class HelpBoneType13 : HelpBoneTypeData
    {
        public float Weight { get; set; }
        public float LimitMinDeg { get; set; }
        public float LimitMaxDeg { get; set; }
        public FRDV_LIMIT_AXIS Axis { get; set; }
        public float WeightB { get; set; }
        public float LimitMinB { get; set; }
        public float LimitMaxB { get; set; }
        public FRDV_LIMIT_AXIS AxisB { get; set; }
        public Vector3 VecA { get; set; }
        public Vector3 VecB { get; set; }
        public void Read(BinaryReader reader)
        {
            Weight = reader.ReadSingle();
            reader.ReadUInt32();
            LimitMinDeg = reader.ReadSingle();
            LimitMaxDeg = reader.ReadSingle();
            Axis = (FRDV_LIMIT_AXIS)reader.ReadUInt32();
            WeightB = reader.ReadSingle();
            reader.ReadBytes(0x4);
            LimitMinB = reader.ReadSingle();
            LimitMaxB = reader.ReadSingle();
            AxisB = (FRDV_LIMIT_AXIS)reader.ReadUInt32();
            reader.ReadBytes(0x4 * 2);
            VecA = new();
            VecA.Read(reader); reader.ReadUInt32();
            VecB = new();
            VecB.Read(reader);
        }
    }
}