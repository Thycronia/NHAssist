using NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Config.ConfigPlayers;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using MonoMod.RuntimeDetour;
namespace NHAssist.Edits.Vanilla
{
    public class TombDropEdit : MethodEdit
    {
        public override bool ShouldApply => true;
        public override bool ShouldReApply => true;

        public override void Apply()
        {
            On.Terraria.Player.DropTombstone += Player_DropTombstone;
        }
        public override void ReApply()
        {
            On.Terraria.Player.DropTombstone += DummyOn;
            On.Terraria.Player.DropTombstone -= DummyOn;
        }

        private void DummyOn(On.Terraria.Player.orig_DropTombstone orig, Player self, int coinsOwned, Terraria.Localization.NetworkText deathText, int hitDirection) => orig(self, coinsOwned, deathText, hitDirection);

        private void Player_DropTombstone(On.Terraria.Player.orig_DropTombstone orig, Player self, int coinsOwned, Terraria.Localization.NetworkText deathText, int hitDirection)
        {
            if (!self.GetModPlayer<FastRespawnPlayer>().NoTomb)
                orig(self, coinsOwned, deathText, hitDirection);
        }
    }
}

