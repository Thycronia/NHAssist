using System.Reflection;
using MonoMod.RuntimeDetour.HookGen;

namespace NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Biome
{
    public partial class BiomeOptionPlayer : ModPlayer
    {
        public ref bool BiomeOverrides(int index)
        {
            return ref biomeOverrides[index];
        }
        private bool[] biomeOverrides;
        public BiomeOptionPlayer()
        {
            biomeOverrides = new bool[BiomeLib.BiomeCount];
        }
        public override void Load()
        {
            base.Load();//5
        }
        public override void SetStaticDefaults()
        {
            BiomeLib.LoadBiomes();
            biomeOverrides = new bool[BiomeLib.BiomeCount];
            foreach (BiomeInfo biome in BiomeLib.Biomes)
                AddOnHook(biome);
            On.Terraria.Player.UpdateBiomes += Player_UpdateBiomes;
        }
        private void Player_UpdateBiomes(On.Terraria.Player.orig_UpdateBiomes orig, Player self)
        {
            orig(self);
            if(self.whoAmI == Main.myPlayer)
                ThyUISystem.Panel.OptionPanel.BiomeCategory.DoUpdate();
        }
        public static void AddOnHook(BiomeInfo biome)
        {
            if (biome.Type == InfoType.DirectControl)
                return;
            bool PlayerGetProperty(PlayerPropertyGetOrigin orig, Player player)
            {
                //Main.NewText("executed " + biome.GetControlBool(player));
                return (!Main.gameMenu && biome.GetControlBool(player)) || orig(player);
            }
            bool IsModBiomeActive(IsBiomeActiveOrigin orig, ModBiome self, Player player)
            {
                return (!Main.gameMenu && biome.GetControlBool(player)) || orig(self, player);
            }
            switch (biome.Type)
            {
                case InfoType.PlayerProperty:
                    MethodInfo PropertyGetMethod = biome.PropertyGetMethod;
                    Delegate ModifiedGetMethod = new PlayerPropertyGetDelegate(PlayerGetProperty);
                    HookEndpointManager.Add(PropertyGetMethod, ModifiedGetMethod);
                    break;

                case InfoType.ModBiome:
                    MethodInfo IsBiomeActiveInfo = biome.ModBiomeInstance.GetType().GetMethod("IsBiomeActive", (BindingFlags)60);
                    Delegate ModifiedIsActive = new IsBiomeActiveDelegate(IsModBiomeActive);
                    HookEndpointManager.Add(IsBiomeActiveInfo, ModifiedIsActive);
                    break;

                default:
                    break;
            }
        }
        public override void Unload()
        {
            BiomeLib.UnLoad();
            biomeOverrides = new bool[0];
            base.Unload();
        }
    }
}
