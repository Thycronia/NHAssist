using System;
using MonoMod.Cil;
using MonoMod.RuntimeDetour.HookGen;
using Mono.Cecil.Cil;
using Terraria.GameInput;
using Terraria.Audio;
using CalamityMod.CalPlayer;
namespace NHAssist.Edits.Vanilla
{
    [JITWhenModsEnabled("CalamityMod")]
    public class LifeBarEdit : MethodEdit
    {
        public override bool ShouldApply => true;

        public override void Apply()
        {
            IL.Terraria.GameContent.UI.ResourceSets.CommonResourceBarMethods.DrawLifeMouseOver += CommonResourceBarMethods_DrawLifeMouseOver;
        }
        public override bool ShouldReApply => true;
        public override void ReApply()
        {
            On.Terraria.GameContent.UI.ResourceSets.CommonResourceBarMethods.DrawLifeMouseOver += DummyOn;
            On.Terraria.GameContent.UI.ResourceSets.CommonResourceBarMethods.DrawLifeMouseOver -= DummyOn;
            base.ReApply();
        }

        private void DummyOn(On.Terraria.GameContent.UI.ResourceSets.CommonResourceBarMethods.orig_DrawLifeMouseOver orig) => orig();

        private void CommonResourceBarMethods_DrawLifeMouseOver(ILContext il)
        {
            ILCursor c = new ILCursor(il);
            if (c.TryGotoNext(MoveType.After,
                i => i.MatchLdstr("/"),
                i => i.Match(OpCodes.Ldloc_0),
                i => i.Match(OpCodes.Ldflda),
                i => i.MatchCall<Int32>("ToString"),
                i => i.MatchCall<string>("Concat")))
            {
                c.EmitDelegate<Func<string, string>>(delegate (string input)
                {
                    if (Main.gamePaused)
                        return input + "\n" + NHAssist.GetLocalText("Edits.LifeBarEdit.NoPause");
                    if (!Main.dedServ)
                    {
                        Player player = Main.LocalPlayer;
                        if (player.statLifeMax % 5 != 0 || player.statLifeMax < 100)
                            return input + "\n" + NHAssist.GetLocalText("Edits.LifeBarEdit.InvalidHealth");
                        //player.mouseInterface = true;
                        if (PlayerInput.Triggers.JustPressed.MouseRight)
                        {
                            SoundEngine.PlaySound(SoundID.Item4);
                            if (NHAssist.Calamity == null)
                                VanillaIncrease(player);
                            else
                                CalamityIncrease(player);
                        }
                    }
                    return input + "\n" + NHAssist.GetLocalText("Edits.LifeBarEdit.Tip");
                });
            }
        }
        private void VanillaIncrease(Player player)
        {
            if (player.statLifeMax >= 500)
                player.statLifeMax = 100;
            else if (player.statLifeMax >= 400)
                player.statLifeMax += 5;
            else if (player.statLifeMax >= 100)
                player.statLifeMax += 20;
        }
        private void CalamityIncrease(Player player)
        {
            CalamityPlayer calPlayer = player.GetModPlayer<CalamityPlayer>();
            if (player.statLifeMax >= 500)
            {
                if (calPlayer.dFruit)
                {
                    calPlayer.bOrange = calPlayer.mFruit = calPlayer.eBerry = calPlayer.dFruit = false;
                    player.statLifeMax = 100;
                }
                else if (calPlayer.eBerry) calPlayer.dFruit = true;
                else if (calPlayer.mFruit) calPlayer.eBerry = true;
                else if (calPlayer.bOrange) calPlayer.mFruit = true;
                else calPlayer.bOrange = true;
            }
            else
            { // <500, vanilla logic
                calPlayer.bOrange = calPlayer.mFruit = calPlayer.eBerry = calPlayer.dFruit = false;
                VanillaIncrease(player);
            }
        }
    }
}

