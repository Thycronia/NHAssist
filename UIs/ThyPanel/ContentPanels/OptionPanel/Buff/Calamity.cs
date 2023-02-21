using Cal = CalamityMod.Buffs;
using CalNPC = CalamityMod.NPCs;
using NHAssist.UIs.ThyPanel.ContentPanels.DataStruct;
namespace NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Buff
{
    internal static partial class Bufflib
    {
        [JITWhenModsEnabled("CalamityMod")]
        internal static List<(int, float)> GetCalamityBuffStage()
        {
            List<(int, float)> result = new List<(int, float)>
            {
                (ModContent.BuffType<Cal.StatBuffs.BossEffects>(), -1),
                (ModContent.BuffType<Cal.Potions.BoundingBuff>(), -1),
                (ModContent.BuffType<Cal.Potions.CalciumBuff>(), -1),
                (BuffID.Invisibility, -1),
                (ModContent.BuffType<Cal.Potions.SulphurskinBuff>(), -1),
                (ModContent.BuffType<Cal.Placeables.CorruptionEffigyBuff>(), -1),
                (ModContent.BuffType<Cal.Placeables.CrimsonEffigyBuff>(), -1),
                (ModContent.BuffType<Cal.Placeables.EffigyOfDecayBuff>(), FloatStages.KingSlime),
                //(ModContent.BuffType<Cal.Potions.TriumphBuff>(), BossLib.PostBossStage(ModContent.NPCType<CalNPC.DesertScourge.DesertScourgeHead>())),

                //(ModContent.BuffType<Cal.Potions.YharimPower>(), FloatStages.Skeletron),
                (ModContent.BuffType<Cal.Potions.TeslaBuff>(), BossLib.PostBossStage(ModContent.NPCType<CalNPC.HiveMind.HiveMind>())),
                (ModContent.BuffType<Cal.Potions.Omniscience>(), FloatStages.Skeletron),
                 (ModContent.BuffType<Cal.Potions.ShadowBuff>(), FloatStages.Skeletron),

                //(ModContent.BuffType<Cal.Potions.CadancesGrace>(), FloatStages.WOF),
                (ModContent.BuffType<Cal.Potions.PhotosynthesisBuff>(), FloatStages.WOF),
                //(ModContent.BuffType<Cal.Potions.Revivify>(), FloatStages.WOF),
                (ModContent.BuffType<Cal.Potions.Soaring>(), FloatStages.WOF),
                (ModContent.BuffType<Cal.Potions.WeaponImbueCrumbling>(), FloatStages.WOF),

                (ModContent.BuffType<Cal.Alcohol.WhiskeyBuff>(), FloatStages.WOF),
                (ModContent.BuffType<Cal.Alcohol.RumBuff>(), FloatStages.WOF),
                (ModContent.BuffType<Cal.Alcohol.TequilaBuff>(), FloatStages.WOF),
                (ModContent.BuffType<Cal.Alcohol.FireballBuff>(), FloatStages.WOF),
                (ModContent.BuffType<Cal.Alcohol.FabsolVodkaBuff>(), FloatStages.WOF),

                (ModContent.BuffType<Cal.Placeables.CirrusPinkCandleBuff>(), FloatStages.WOF),
                (ModContent.BuffType<Cal.Placeables.CirrusPurpleCandleBuff>(), FloatStages.WOF),
                (ModContent.BuffType<Cal.Placeables.CirrusYellowCandleBuff>(), FloatStages.WOF),
                (ModContent.BuffType<Cal.Placeables.CirrusBlueCandleBuff>(), FloatStages.WOF),
                (ModContent.BuffType<Cal.Alcohol.Trippy>(), FloatStages.WOF),

                (ModContent.BuffType<Cal.Alcohol.VodkaBuff>(), FloatStages.MechBoss),
                (ModContent.BuffType<Cal.Alcohol.ScrewdriverBuff>(), FloatStages.MechBoss),
                (ModContent.BuffType<Cal.Alcohol.WhiteWineBuff>(), FloatStages.MechBoss),

                (ModContent.BuffType<Cal.Potions.WeaponImbueBrimstone>(), BossLib.PostBossStage(ModContent.NPCType<CalNPC.CalClone.CalamitasClone>())),

                //(ModContent.BuffType<Cal.Potions.PenumbraBuff>(), FloatStages.Plantera),
                (ModContent.BuffType<Cal.Alcohol.MargaritaBuff>(), FloatStages.Plantera),
                (ModContent.BuffType<Cal.Alcohol.EvergreenGinBuff>(), FloatStages.Plantera),
                (ModContent.BuffType<Cal.Alcohol.CaribbeanRumBuff>(), FloatStages.Plantera),

                (ModContent.BuffType<Cal.Potions.GravityNormalizerBuff>(), BossLib.PostBossStage(ModContent.NPCType<CalNPC.AstrumAureus.AstrumAureus>())),
                (ModContent.BuffType<Cal.Alcohol.EverclearBuff>(), BossLib.PostBossStage(ModContent.NPCType<CalNPC.AstrumAureus.AstrumAureus>())),
                (ModContent.BuffType<Cal.Alcohol.BloodyMaryBuff>(), BossLib.PostBossStage(ModContent.NPCType<CalNPC.AstrumAureus.AstrumAureus>())),
                (ModContent.BuffType<Cal.Alcohol.StarBeamRyeBuff>(), BossLib.PostBossStage(ModContent.NPCType<CalNPC.AstrumAureus.AstrumAureus>())),

                //(ModContent.BuffType<Cal.Potions.ArmorCrumbling>(), FloatStages.Golem),
                //(ModContent.BuffType<Cal.Potions.TitanScale>(), FloatStages.Golem),
                (ModContent.BuffType<Cal.Alcohol.MoonshineBuff>(), FloatStages.Golem),
                (ModContent.BuffType<Cal.Alcohol.MoscowMuleBuff>(), FloatStages.Golem),
                (ModContent.BuffType<Cal.Alcohol.CinnamonRollBuff>(), FloatStages.Golem),
                (ModContent.BuffType<Cal.Alcohol.TequilaSunriseBuff>(), FloatStages.Golem),

                //(ModContent.BuffType<Cal.Potions.ProfanedRageBuff>(), FloatStages.MoonLord),
                (ModContent.BuffType<Cal.Potions.WeaponImbueHolyFlames>(), FloatStages.MoonLord),

                (ModContent.BuffType<Cal.Potions.CeaselessHunger>(), FloatStages.Sentinel),

                //(ModContent.BuffType<Cal.Potions.DraconicSurgeBuff>(), FloatStages.Yharon),
            };
            return result;
        }
    }
}
