using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrdvTool.HelpBone
{
    public class HelpBoneType23 : HelpBoneTypeData
    {
        public float Weight { get; set; }
        public float Offset { get; set; }
        public float LimitMin { get; set; }
        public float LimitMax { get; set; }
        public Vector3 Up { get; set; }
        public Vector3 Forward { get; set; }
        public void Read(BinaryReader reader)
        {
            Weight = reader.ReadSingle();
            Offset = reader.ReadSingle();
            LimitMin = reader.ReadSingle();
            LimitMax = reader.ReadSingle();
            reader.ReadBytes(0x4 * 8);
            Up = new();
            Up.Read(reader); reader.ReadUInt32();
            Forward = new();
            Forward.Read(reader);
        }
    }
}
