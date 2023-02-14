namespace NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Biome
{
    public partial class BiomeOptionUI
    {
        public static List<OptionUI> GetBiomeOptionUIList()
        {
            List<OptionUI> result = new List<OptionUI>();
            foreach(BiomeInfo biome in BiomeLib.Biomes)
            {
                BiomeOptionUI option = new BiomeOptionUI(biome.UITexture,
                    biome.GetControlBool, biome.HoverTextKey, biome.Type == InfoType.DirectControl);
                result.Add(option);
            }
            return result;
        }
    }
}
