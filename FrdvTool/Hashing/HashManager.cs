namespace FrdvTool
{
    public class HashManager
    {
        public Dictionary<uint, string> StrCode32LookupTable = new();
        public Dictionary<uint, string> UsedHashes = new();

        public static uint StrCode32(string text)
        {
            if (text == null) throw new ArgumentNullException();
            const ulong seed0 = 0x9ae16a3b2f90404f;
            ulong seed1 = text.Length > 0 ? (uint)((text[0]) << 16) + (uint)text.Length : 0;
            return (uint)(CityHash.CityHash.CityHash64WithSeeds(text + "\0", seed0, seed1) & 0xFFFFFFFFFFFF);
        }
    }
}
