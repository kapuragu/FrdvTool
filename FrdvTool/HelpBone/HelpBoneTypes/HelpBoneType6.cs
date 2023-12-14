using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrdvTool.HelpBone
{
    public class HelpBoneType6 : HelpBoneTypeData
    {
        public float WeightDeg { get; set; }
        public float LimitMin { get; set; }
        public float LimitMax { get; set; }
        public FRDV_LIMIT_AXIS Axis { get; set; }
        public float WeightB { get; set; }
        public Vector3 VecA { get; set; }
        public void Read(BinaryReader reader)
        {
            WeightDeg = reader.ReadSingle();
            reader.ReadUInt32();
            LimitMin = reader.ReadSingle();
            LimitMax = reader.ReadSingle();
            Axis = (FRDV_LIMIT_AXIS)reader.ReadUInt32();
            WeightB = reader.ReadSingle();
            reader.ReadBytes(0x4 * 6);
            VecA = new();
            VecA.Read(reader);
        }
    }
}
