using NHAssist.UIs.ThyPanel.ContentPanels.DataStruct;
namespace NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Buff
{
    public partial class BuffOptionUI : OptionUI
    {
        public static BuffOptionUI GetBuffOptionUI(int buffType, float stage = -1f)
        {
            if (buffType < 0)
                throw new ArgumentException("Buff must have a non-negative type.");
            Asset<Texture2D> buffTexture = TextureAssets.Buff[buffType];
            ModBuff modBuff = ModContent.GetModBuff(buffType);
            Mod mod = modBuff?.Mod;
            string buffName = modBuff?.Name ?? ("Buff_"+buffType.ToString());
            return new BuffOptionUI(buffTexture, buffType, buffName, stage, mod);
        }
        public static List<OptionUI> GetBuffOptionUIList()
        {
            List<(int, float)> TypeWithStage = Bufflib.GetVanillaBuffStage();
            if (NHAssist.Calamity != null)
                TypeWithStage.AddRange(Bufflib.GetCalamityBuffStage());
            //Add other mod's buff here
            TypeWithStage.Sort(Comparator);
            List<OptionUI> result = new List<OptionUI>();
            foreach((int type, float stage) in TypeWithStage)
                result.Add(GetBuffOptionUI(type, stage));
            return result;
        }
        private static int Comparator((int, float) buff1, (int, float) buff2)
        {
            float diff = buff1.Item2 - buff2.Item2;
            if (Math.Abs(diff) < FloatStages.Epsilon)
                return 0;
            return diff > 0f ? 1 : -1;
        }
    }
}
