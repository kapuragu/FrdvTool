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
        }

        public virtual void Write(BinaryWriter writer)
        {
            uint hash = uint.TryParse(Name, out uint _hash) ? _hash : HashManager.StrCode32(Name);
            writer.Write(hash);
        }
    }
}
