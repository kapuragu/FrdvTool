using System.Xml;
using System.Xml.Serialization;

namespace FrdvTool
{
    [XmlType]
    public class FoxHash
    {
        [XmlText]
        public string Name = string.Empty;

        public virtual void Read(BinaryReader reader, Dictionary<uint, string> hashLookupTable)
        {
            uint hashValue = reader.ReadUInt32();

            if (hashLookupTable.ContainsKey(hashValue))
                Name = hashLookupTable[hashValue];
            else
                Name = hashValue.ToString("X");
        }

        public virtual void Write(BinaryWriter writer)
        {
            uint hash = uint.TryParse(Name, out uint _hash) ? _hash : HashManager.StrCode32(Name);
            writer.Write(hash);
        }

        public virtual void Read64(BinaryReader reader, Dictionary<uint, string> hashLookupTable)
        {
            ulong hashValue = reader.ReadUInt64();

            if (hashLookupTable.ContainsKey((uint)hashValue))
                Name = hashLookupTable[(uint)hashValue];
            else
                Name = "0x"+hashValue.ToString("X").ToLower();
        }
    }
}
