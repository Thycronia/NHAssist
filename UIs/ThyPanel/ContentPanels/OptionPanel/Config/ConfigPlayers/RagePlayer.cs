using CalamityMod.CalPlayer;
namespace NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Config.ConfigPlayers
{
    [JITWhenModsEnabled("CalamityMod")]
    public class RagePlayer : ModPlayer
    {
        public bool FillRage;
        private bool UsedForThisLife;

        public bool CalamityDrawing;
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModLoader.TryGetMod("CalamityMod", out Mod _);
        }

        //[JITWhenModsEnabled("CalamityMod")]
        public override void PostUpdateMiscEffects()
        {
            if (!UsedForThisLife && NHAssist.Calamity != null)
            {
                if (FillRage && !DataPlayer.lastHaveBoss && DataPlayer.haveBoss)
                {
                    CalamityPlayer calPlayer = Player.GetModPlayer<CalamityPlayer>();
                    if (calPlayer.RageEnabled)
                    {
                        calPlayer.rage = calPlayer.rageMax;
                        UsedForThisLife = true;
                    }
                }
            }
            base.PostUpdateMiscEffects();
        }

        public override void OnRespawn(Player player)
        {
            UsedForThisLife = false;
            base.OnRespawn(player);
        }
    }
}

