using System.Reflection;
namespace NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Biome
{
    public static partial class BiomeLib
    {
        internal static List<BiomeInfo> Biomes { get; private set; }
        public static int BiomeCount
        {
            get
            {
                if (Biomes == null) return 0;
                int count = 0;
                foreach (BiomeInfo biome in Biomes)
                    if (biome.Type != InfoType.DirectControl) ++count;
                return count;
            }
        }
        public static void LoadBiomes()
        {
            Biomes = new List<BiomeInfo>();
            int index = 0;
            Biomes.AddRange(GetVanillaBiomeInfo(ref index));
            if(NHAssist.Calamity != null)
                Biomes.AddRange(GetCalamityBiomeInfo(ref index));
        }
        public static void UnLoad()
        {
            Biomes = null;
        }
    }
}
