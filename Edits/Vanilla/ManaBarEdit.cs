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
    public class ManaBarEdit : MethodEdit
    {
        public override bool ShouldApply => true;

        public override void Apply()
        {
            IL.Terraria.GameContent.UI.ResourceSets.CommonResourceBarMethods.DrawManaMouseOver += CommonResourceBarMethods_DrawManaMouseOver; ;
        }

        private void CommonResourceBarMethods_DrawManaMouseOver(ILContext il)
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
                        return input + "\n" + NHAssist.GetLocalText("Edits.ManaBarEdit.NoPause");
                    if (!Main.dedServ)
                    {
                        Player player = Main.LocalPlayer;
                        if (player.statManaMax % 10 != 0 || player.statManaMax < 20)
                            return input + "\n" + NHAssist.GetLocalText("Edits.ManaBarEdit.InvalidMana");
                        //player.mouseInterface = true;
                        if (PlayerInput.Triggers.JustPressed.MouseRight)
                        {
                            SoundEngine.PlaySound(SoundID.Item29);
                            if (NHAssist.Calamity == null)
                                VanillaIncrease(player);
                            else
                                CalamityIncrease(player);
                        }
                    }
                    return input + "\n" + NHAssist.GetLocalText("Edits.ManaBarEdit.Tip");
                });
            }
        }

        public override bool ShouldReApply => true;
        public override void ReApply()
        {
            On.Terraria.GameContent.UI.ResourceSets.CommonResourceBarMethods.DrawManaMouseOver += DummyOn;
            On.Terraria.GameContent.UI.ResourceSets.CommonResourceBarMethods.DrawManaMouseOver -= DummyOn;
            base.ReApply();
        }

        private void DummyOn(On.Terraria.GameContent.UI.ResourceSets.CommonResourceBarMethods.orig_DrawManaMouseOver orig) => orig();

        private void VanillaIncrease(Player player)
        {
            if (player.statManaMax >= 200)
                player.statManaMax = 20;
            else if (player.statManaMax >= 20)
                player.statManaMax += 20;
        }
        private void CalamityIncrease(Player player)
        {
            CalamityPlayer calPlayer = player.GetModPlayer<CalamityPlayer>();
            if (player.statManaMax >= 200)
            {
                if (calPlayer.pHeart)
                {
                    calPlayer.cShard = calPlayer.eCore = calPlayer.pHeart = false;
                    player.statManaMax = 20;
                }
                else if (calPlayer.eCore) calPlayer.pHeart = true;
                else if (calPlayer.cShard) calPlayer.eCore = true;
                else calPlayer.cShard = true;
            }
            else
            { // <200, vanilla logic
                calPlayer.cShard = calPlayer.eCore = calPlayer.pHeart = false;
                VanillaIncrease(player);
            }
        }
    }
}

