using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrdvTool.HelpBone
{
    public class HelpBoneType20 : HelpBoneTypeData
    {
        public float Weight { get; set; }
        public float LimitMin { get; set; }
        public float LimitMax { get; set; }
        public uint MaterialNameA { get; set; }
        public uint MaterialNameC { get; set; }
        public uint MaterialParamC { get; set; }
        public uint MaterialNameB { get; set; }
        public uint MaterialParamA { get; set; }
        public uint MaterialParamB { get; set; }
        public void Read(BinaryReader reader)
        {
            Weight = reader.ReadSingle();
            reader.ReadUInt32();
            LimitMin = reader.ReadSingle();
            LimitMax = reader.ReadSingle();
            MaterialNameA = reader.ReadUInt32();
            reader.ReadBytes(0x4 * 2);
            MaterialNameC = reader.ReadUInt32();
            MaterialParamC = reader.ReadUInt32();
            MaterialNameB = reader.ReadUInt32();
            MaterialParamA = reader.ReadUInt32();
            MaterialParamB = reader.ReadUInt32();
        }
    }
}
