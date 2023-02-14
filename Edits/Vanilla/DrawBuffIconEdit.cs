using NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Config.ConfigPlayers;
namespace NHAssist.Edits.Vanilla
{
    public class DrawBuffIconEdit : MethodEdit
    {
        public override bool ShouldApply => true;
        public override bool ShouldReApply => true;

        public override void Apply()
        {
            On.Terraria.Main.DrawBuffIcon += Main_DrawBuffIcon;
        }

        private int Main_DrawBuffIcon(On.Terraria.Main.orig_DrawBuffIcon orig, int drawBuffText, int buffSlotOnPlayer, int x, int y)
        {
            if (Main.EquipPage != 2 && Main.LocalPlayer.GetModPlayer<HideBuffPlayer>().HideBuff)
                return -1;
            return orig(drawBuffText, buffSlotOnPlayer, x, y);
        }

        public override void ReApply()
        {
            On.Terraria.Main.DrawBuffIcon += DummyOn;
            On.Terraria.Main.DrawBuffIcon -= DummyOn;
        }

        private int DummyOn(On.Terraria.Main.orig_DrawBuffIcon orig, int drawBuffText, int buffSlotOnPlayer, int x, int y)
            => orig(drawBuffText, buffSlotOnPlayer, x, y);
    }
}

