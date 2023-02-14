using System.Reflection;
using Microsoft.Xna.Framework.Graphics;
using NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Config.ConfigPlayers;

namespace NHAssist.Edits.Vanilla
{
    public class QuickReforge : MethodEdit
    {
        public override bool ShouldApply => true;
        public override bool ShouldReApply => true;
        private static PropertyInfo talkNPCProperty;
        public static void UnLoad() { talkNPCProperty = null; }
        public override void Apply()
        {
            talkNPCProperty = typeof(Player).GetProperty("talkNPC", typeof(int));
            On.Terraria.Main.DrawInventory += Main_DrawInventory;
        }

        private void Main_DrawInventory(On.Terraria.Main.orig_DrawInventory orig, Main self)
        {
            Player player = Main.LocalPlayer;
            if (!player.GetModPlayer<BGTeleportPlayer>().QuickReforge || talkNPCProperty == null)
            {
                orig(self);
                return;
            }
            if (Main.playerInventory && player.chest == -1 && Main.npcShop == 0 && !Main.InGuideCraftMenu && player.talkNPC == -1 && !Main.CreativeMenu.Enabled)
            {
                Main.InReforgeMenu = true;
                talkNPCProperty.SetValue(player, -2);
                player.currentShoppingSettings = new ShoppingSettings() { HappinessReport = "", PriceAdjustment = 0.000001 };
            }
            orig(self);
            if (player.talkNPC == -2)
                player.SetTalkNPC(-1);
        }

        public override void ReApply()
        {
            On.Terraria.Main.DrawInventory += DummyOn;
        }

        private void DummyOn(On.Terraria.Main.orig_DrawInventory orig, Main self) => orig(self);
    }
}

