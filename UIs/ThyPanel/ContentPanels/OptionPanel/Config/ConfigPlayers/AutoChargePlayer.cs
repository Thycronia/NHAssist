using CalamityMod.Items;

namespace NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Config.ConfigPlayers
{
    [JITWhenModsEnabled("CalamityMod")]
    public class AutoChargePlayer : ModPlayer
    {
        public bool AutoCharge;
        private bool UsedForThisLife;

        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModLoader.TryGetMod("CalamityMod", out Mod _);
        }

        //[JITWhenModsEnabled("CalamityMod")]
        public override void PostUpdateMiscEffects()
        {
            if (!UsedForThisLife && NHAssist.Calamity != null)
            {
                if (AutoCharge && !DataPlayer.lastHaveBoss && DataPlayer.haveBoss)
                {
                    //Charge all
                    foreach(Item item in Player.inventory)
                    {
                        if (item is null || item.IsAir)
                            continue;
                        if (item.TryGetGlobalItem<CalamityGlobalItem>(out CalamityGlobalItem calItem))
                        {
                            if (calItem.UsesCharge)
                            {
                                calItem.Charge = calItem.MaxCharge;
                            }
                        }
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

