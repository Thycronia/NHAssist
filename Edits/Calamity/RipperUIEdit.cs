using CalamityMod.UI.Rippers;
using MonoMod.Cil;
using Mono.Cecil.Cil;
using MonoMod.RuntimeDetour.HookGen;
using System.Reflection;
using CalamityMod;
using CalamityMod.CalPlayer;
using Terraria.GameInput;
using Terraria.Audio;
namespace NHAssist.Edits.Calamity
{
    [JITWhenModsEnabled("CalamityMod")]
    public class RipperUIEdit : MethodEdit
    {
        public override bool ShouldApply => NHAssist.Calamity != null;
        //[JITWhenModsEnabled("CalamityMod")]
        public override void Apply()
        {
            MethodInfo MethodOrig = typeof(RipperUI).GetMethod("Draw", BindingFlags.Public | BindingFlags.Static);
            HookEndpointManager.Modify(MethodOrig, RipperUI_Draw);
        }
        //[JITWhenModsEnabled("CalamityMod")]
        private void RipperUI_Draw(ILContext il)
        {
            ILCursor c = new ILCursor(il);
            //Rage
            //if (c.TryGotoNext(MoveType.After,
            //    i => i.MatchLdsfld<Main>("instance"),
            //    i => i.MatchLdstr("Rage: "),
            //    i => i.Match(OpCodes.Ldloc_S),
            //    i => i.MatchCall<string>("Concat")))
            if (c.TryGotoNext(MoveType.Before,
                i => i.Match(OpCodes.Ldloc_S),
                i => i.MatchCall<string>("Concat"),
                i => i.Match(OpCodes.Ldc_I4_0),
                i => i.Match(OpCodes.Ldc_I4_0),
                i => i.Match(OpCodes.Ldc_I4_M1),
                i => i.Match(OpCodes.Ldc_I4_M1)))
            {
                ++c.Index; ++c.Index;
                c.EmitDelegate<Func<string, string>>(delegate (string input)
                {
                    if (CalamityConfig.Instance.MeterPosLock)
                    {
                        if (PlayerInput.Triggers.JustPressed.MouseRight)
                        {
                            ChangeRageLevel();
                            SoundEngine.PlaySound(SoundID.MenuTick);
                        }
                        return input + "\n" + NHAssist.GetLocalText("Edits.RipperUIEdit.RageTip");
                    }
                    return input + "\n" + NHAssist.GetLocalText("Edits.RipperUIEdit.LockWarning");
                });
            }
            //Adrenaline
            if (c.TryGotoNext(MoveType.After,
                i => i.MatchLdsfld<Main>("instance"),
                i => i.Match(OpCodes.Ldloc_S),
                i => i.MatchLdstr(": "),
                i => i.Match(OpCodes.Ldloc_S),
                i => i.MatchCall<string>("Concat")))
            {
                c.EmitDelegate<Func<string, string>>(delegate (string input)
                {
                    if (CalamityConfig.Instance.MeterPosLock)
                    {
                        if (PlayerInput.Triggers.JustPressed.MouseRight)
                        {
                            ChangeAdrenalineLevel();
                            SoundEngine.PlaySound(SoundID.MenuTick);
                        }
                        return input + "\n" + NHAssist.GetLocalText("Edits.RipperUIEdit.AdrenalineTip");
                    }
                    return input + "\n" + NHAssist.GetLocalText("Edits.RipperUIEdit.LockWarning");
                });
            }
        }
        //[JITWhenModsEnabled("CalamityMod")]
        private void ChangeRageLevel()
        {
            if (Main.dedServ || Main.gameMenu)
                return;
            CalamityPlayer calPlayer = Main.LocalPlayer.GetModPlayer<CalamityPlayer>();
            if (calPlayer.rageBoostThree)
            {
                calPlayer.rageBoostOne = calPlayer.rageBoostTwo = calPlayer.rageBoostThree = false;
            }
            else if (calPlayer.rageBoostTwo)
            {
                calPlayer.rageBoostThree = true;
            }
            else if (calPlayer.rageBoostOne)
            {
                calPlayer.rageBoostTwo = true;
            }
            else
            {
                calPlayer.rageBoostOne = true;
            }
        }

        //[JITWhenModsEnabled("CalamityMod")]
        private void ChangeAdrenalineLevel()
        {
            if (Main.dedServ || Main.gameMenu)
                return;
            CalamityPlayer calPlayer = Main.LocalPlayer.GetModPlayer<CalamityPlayer>();
            if (calPlayer.adrenalineBoostThree)
            {
                calPlayer.adrenalineBoostOne = calPlayer.adrenalineBoostTwo = calPlayer.adrenalineBoostThree = false;
            }
            else if (calPlayer.adrenalineBoostTwo)
            {
                calPlayer.adrenalineBoostThree = true;
            }
            else if (calPlayer.adrenalineBoostOne)
            {
                calPlayer.adrenalineBoostTwo = true;
            }
            else
            {
                calPlayer.adrenalineBoostOne = true;
            }
        }
    }
}

