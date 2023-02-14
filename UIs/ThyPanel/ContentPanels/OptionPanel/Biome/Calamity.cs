using Cal = CalamityMod.BiomeManagers;
namespace NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Biome
{
    public static partial class BiomeLib
    {
        [JITWhenModsEnabled("CalamityMod")]
        private static List<BiomeInfo> GetCalamityBiomeInfo(ref int index)
        {
            List<BiomeInfo> result = new List<BiomeInfo>
            {
                new BiomeInfo(index++, RSC.CalBiome.Sulphur, ModContent.GetInstance<Cal.SulphurousSeaBiome>(),"Calamity.Sulphur"),
                new BiomeInfo(index++, RSC.CalBiome.Sunken, ModContent.GetInstance<Cal.SunkenSeaBiome>(),"Calamity.Sunken"),
                new BiomeInfo(index++, RSC.CalBiome.Brimstone, ModContent.GetInstance<Cal.BrimstoneCragsBiome>(),"Calamity.Brimstone"),
                new BiomeInfo(index++, RSC.CalBiome.SurfaceAstral, ModContent.GetInstance<Cal.AbovegroundAstralBiome>(),"Calamity.SurfaceAstral"),
                new BiomeInfo(index++, RSC.CalBiome.AbyssLayer1, ModContent.GetInstance<Cal.AbyssLayer1Biome>(),"Calamity.AbyssLayer1"),
                new BiomeInfo(index++, RSC.CalBiome.AbyssLayer4, ModContent.GetInstance<Cal.AbyssLayer4Biome>(),"Calamity.AbyssLayer4"),
            };
            return result;
        }
    }
}
