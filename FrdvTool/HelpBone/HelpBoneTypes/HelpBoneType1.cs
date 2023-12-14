using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrdvTool.HelpBone
{
    public class HelpBoneType1 : HelpBoneTypeData
    {
        public float WeightDeg { get; set; }
        public float LimitMin { get; set; }
        public float LimitMax { get; set; }
        public FRDV_LIMIT_AXIS Axis { get; set; }
        public void Read(BinaryReader reader)
        {
            WeightDeg = reader.ReadSingle();
            reader.ReadUInt32();
            LimitMin = reader.ReadSingle();
            LimitMax = reader.ReadSingle();
            Axis = (FRDV_LIMIT_AXIS)reader.ReadUInt32();
        }
    }
}
