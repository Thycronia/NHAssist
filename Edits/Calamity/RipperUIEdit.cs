using CalamityMod.UI.Rippers;
using MonoMod.Cil;
using Mono.Cecil.Cil;
using System.Reflection;
using CalamityMod;
using CalamityMod.CalPlayer;
using Terraria.GameInput;
using Terraria.Audio;
namespace NHAssist.Edits.Calamity
{
    [JITWhenModsEnabled("CalamityMod")]
    //[NoJIT]
    public class RipperUIEdit : MethodEdit
    {
        public override bool ShouldApply => NHAssist.Calamity != null;
        public override void Apply()
        {
            MethodInfo MethodOrig = typeof(RipperUI).GetMethod("Draw", BindingFlags.Public | BindingFlags.Static);
            MonoModHooks.Modify(MethodOrig, RipperUI_Draw);
        }
        private void RipperUI_Draw(ILContext il)
        {
            ILCursor c = new ILCursor(il);
            if (c.TryGotoNext(MoveType.After,
                i => i.Match(OpCodes.Ldstr, "UI.Rage"),
                [JITWhenModsEnabled("CalamityMod")] (i) => i.MatchCall(typeof(CalamityUtils), nameof(CalamityUtils.GetTextValue)),
                i => i.Match(OpCodes.Ldstr, ": "),
                i => i.Match(OpCodes.Ldloc_S),
                i => i.MatchCall<string>("Concat")
                ))
            {
                c.EmitDelegate<Func<string, string>>(MakeRageString);
                NHAssist.Instance.Logger.Info("Rage bar edit successfully hooked.");
            }
            if (c.TryGotoNext(MoveType.After,
                [JITWhenModsEnabled("CalamityMod")] (i) => i.MatchCall(typeof(RipperUI), "MakeRipperPercentString"),
                i => i.Match(OpCodes.Stloc_S),
                i => i.MatchLdsfld<Main>("instance"),
                i => i.Match(OpCodes.Ldloc_S),
                i => i.MatchLdstr(": "),
                i => i.Match(OpCodes.Ldloc_S),
                i => i.MatchCall<string>("Concat")
                ))
            {
                c.EmitDelegate<Func<string, string>>(MakeAdrenalineString);
                NHAssist.Instance.Logger.Info("Adrenaline bar edit successfully hooked.");
            }
        }

        private string MakeRageString(string input)
        {
            if (CalamityConfig.Instance.MeterPosLock)
            {
                if (PlayerInput.Triggers.JustPressed.MouseRight)
                {
                    ChangeRageLevel();
                    SoundEngine.PlaySound(SoundID.Item122);
                }
                return input + "\n" + NHAssist.GetLocalText("Edits.RipperUIEdit.RageTip");
            }
            return input + "\n" + NHAssist.GetLocalText("Edits.RipperUIEdit.LockWarning");
        }

        private string MakeAdrenalineString(string input)
        {
            if (CalamityConfig.Instance.MeterPosLock)
            {
                if (PlayerInput.Triggers.JustPressed.MouseRight)
                {
                    ChangeAdrenalineLevel();
                    SoundEngine.PlaySound(SoundID.Item122);
                }
                return input + "\n" + NHAssist.GetLocalText("Edits.RipperUIEdit.AdrenalineTip");
            }
            return input + "\n" + NHAssist.GetLocalText("Edits.RipperUIEdit.LockWarning");
        }

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

