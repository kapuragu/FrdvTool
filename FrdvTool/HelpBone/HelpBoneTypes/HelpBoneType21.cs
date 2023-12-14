using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrdvTool.HelpBone
{
    public class HelpBoneType21 : HelpBoneTypeData
    {
        public float LimitMin { get; set; }
        public float LimitMax { get; set; }
        public uint MaterialNameA { get; set; }
        public uint MaterialParamA { get; set; }
        public uint MaterialParamB { get; set; }
        public Vector3 Up { get; set; }
        public Vector3 Forward { get; set; }
        public void Read(BinaryReader reader)
        {
            reader.ReadUInt32();
            reader.ReadUInt32();
            LimitMin = reader.ReadSingle();
            LimitMax = reader.ReadSingle();
            MaterialNameA = reader.ReadUInt32();
            reader.ReadBytes(0x4 * 5);
            MaterialParamA = reader.ReadUInt32();
            MaterialParamB = reader.ReadUInt32();
            reader.ReadBytes(0x4);
            Up = new();
            Up.Read(reader); reader.ReadUInt32();
            Forward = new();
            Forward.Read(reader); reader.ReadUInt32();
        }
    }
}
