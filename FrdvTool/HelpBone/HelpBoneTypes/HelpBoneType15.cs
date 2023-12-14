using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrdvTool.HelpBone
{
    public class HelpBoneType15 : HelpBoneTypeData
    {
        public Vector3 VecA { get; set; }
        public Vector3 VecB { get; set; }
        public Vector3 VecC { get; set; }
        public Vector3 VecD { get; set; }
        public void Read(BinaryReader reader)
        {
            reader.ReadInt32();
            reader.ReadUInt32();
            reader.ReadUInt64();
            reader.ReadBytes(0x4 * 8);
            VecA = new();
            VecA.Read(reader); reader.ReadUInt32();
            VecB = new();
            VecB.Read(reader); reader.ReadUInt32();
            VecC = new();
            VecC.Read(reader); reader.ReadUInt32();
            VecD = new();
            VecD.Read(reader);
        }
    }
}
