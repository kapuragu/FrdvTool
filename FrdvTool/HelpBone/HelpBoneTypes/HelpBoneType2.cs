using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrdvTool.HelpBone
{
    public class HelpBoneType2 : HelpBoneTypeData
    {
        public float Weight { get; set; }
        public void Read(BinaryReader reader)
        {
            Weight = reader.ReadSingle();
        }
    }
}
