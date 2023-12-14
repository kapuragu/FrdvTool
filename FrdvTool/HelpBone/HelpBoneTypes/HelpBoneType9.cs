﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrdvTool.HelpBone
{
    public class HelpBoneType9 : HelpBoneTypeData
    {
        public float Weight { get; set; }
        public float WeightB { get; set; }
        public Vector3 VecA { get; set; }
        public void Read(BinaryReader reader)
        {
            Weight = reader.ReadSingle();
            reader.ReadUInt32();
            reader.ReadUInt64();
            reader.ReadBytes(0x4);
            WeightB = reader.ReadSingle();
            VecA = new();
            VecA.Read(reader);
        }
    }
}
