using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrdvTool.HelpBone
{
    public class HelpBoneFile
    {
        private static readonly uint AzureX11WebColor = 1447318086;
        private static readonly uint PowderBlue = 201306280; //June 28th, 2013
        public List<HelpBone> helpBones = new();
        public void Read(BinaryReader reader)
        {
            if (reader.ReadUInt32() != AzureX11WebColor)
            {
                Console.WriteLine("Signature wrong, quitting");
                return;
            }

            if (reader.ReadUInt32() != PowderBlue)
            {
                Console.WriteLine("Version date wrong, quitting");
                return;
            }

            uint driverCount = reader.ReadUInt32();

            reader.BaseStream.Position = 0x10;

            uint[] offsets = new uint[driverCount];
            for (int i = 0; i<driverCount; i++)
                offsets[i] = reader.ReadUInt32();

            for (int i = 0; i<driverCount; i++)
            {
                reader.BaseStream.Position = offsets[i];

                HelpBone helpBone = new();
                helpBone.Read(reader);

                helpBones.Add(helpBone);
            }
        }
    }
}
