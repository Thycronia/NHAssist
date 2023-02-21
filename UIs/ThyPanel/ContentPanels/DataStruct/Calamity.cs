using Cal = CalamityMod.NPCs;
using CalamityMod;
using NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel;
using System.Reflection;
namespace NHAssist.UIs.ThyPanel.ContentPanels.DataStruct
{
    public static partial class BossLib
    {
        [JITWhenModsEnabled("CalamityMod")]
        private static List<(int, float, RefMethod<bool, bool>, FieldInfo)> GetCalamityTypeStageList()
        {
            BindingFlags flag = BindingFlags.Static | BindingFlags.NonPublic;
            Type systemType = typeof(DownedBossSystem);
            FieldInfo GetField(string fieldText) => systemType.GetField(fieldText, flag);
            List<(int, float, RefMethod<bool, bool>, FieldInfo)> result = new List<(int, float, RefMethod<bool, bool>, FieldInfo)>
            {
                (CalType<Cal.DesertScourge.DesertScourgeHead>(), FloatStages.KingSlime, null,
                GetField("_downedDesertScourge")),
                (CalType<Cal.Crabulon.Crabulon>(), FloatStages.KingSlime + 0.2f, null,
                GetField("_downedCrabulon")),
                (CalType<Cal.HiveMind.HiveMind>(), FloatStages.Skeletron, null,
                GetField("_downedHiveMind")),////
                (CalType<Cal.Perforator.PerforatorHive>(), FloatStages.Skeletron, null,
                GetField("_downedPerforator")),
                (CalType<Cal.SlimeGod.SlimeGodCore>(), FloatStages.Skeletron + 0.2f, null,
                GetField("_downedSlimeGod")),
                (CalType<Cal.Cryogen.Cryogen>(), FloatStages.MechBoss, null,
                GetField("_downedCryogen")),
                (CalType<Cal.BrimstoneElemental.BrimstoneElemental>(), FloatStages.MechBoss, null,
                GetField("_downedBrimstoneElemental")),
                (CalType<Cal.AquaticScourge.AquaticScourgeHead>(), FloatStages.MechBoss, null,
                GetField("_downedAquaticScourge")),
                (CalType<Cal.CalClone.CalamitasClone>(), FloatStages.MechBoss + 0.2f, null,
                GetField("_downedCalamitas")),
                (CalType<Cal.Leviathan.Leviathan>(), FloatStages.Plantera + 0.2f, null,
                GetField("_downedLeviathan")),
                //(CalType<Cal.Leviathan.Anahita>(), FloatStages.Plantera + 0.2f),
                (CalType<Cal.AstrumAureus.AstrumAureus>(), FloatStages.Plantera + 0.2f, null,
                GetField("_downedAstrumAureus")),
                (CalType<Cal.PlaguebringerGoliath.PlaguebringerGoliath>(), FloatStages.Golem + 0.2f, null,
                GetField("_downedPlaguebringer")),
                (CalType<Cal.Ravager.RavagerBody>(), FloatStages.Golem + 0.2f, null,
                GetField("_downedRavager")),
                (CalType<Cal.AstrumDeus.AstrumDeusHead>(), FloatStages.Cultist + 0.2f, null,
                GetField("_downedAstrumDeus")),
                (CalType<Cal.ProfanedGuardians.ProfanedGuardianCommander>(), FloatStages.ProfGuard, null,
                GetField("_downedGuardians")),
                (CalType<Cal.Bumblebirb.Bumblefuck>(), FloatStages.ProfGuard, null,
                GetField("_downedDragonfolly")),
                (CalType<Cal.Providence.Providence>(), FloatStages.Providence, null,
                GetField("_downedProvidence")),
                (CalType<Cal.CeaselessVoid.CeaselessVoid>(), FloatStages.Sentinel, null,
                GetField("_downedCeaselessVoid")),
                (CalType<Cal.StormWeaver.StormWeaverHead>(), FloatStages.Sentinel, null,
                GetField("_downedStormWeaver")),
                (CalType<Cal.Signus.Signus>(), FloatStages.Sentinel, null,
                GetField("_downedSignus")),
                (CalType<Cal.Polterghast.Polterghast>(), FloatStages.Polterghast, null,
                GetField("_downedPolterghast")),
                (CalType<Cal.OldDuke.OldDuke>(), FloatStages.OldDuke, null,
                GetField("_downedBoomerDuke")),
                (CalType<Cal.DevourerofGods.DevourerofGodsHead>(), FloatStages.DOG, null,
                GetField("_downedDoG")),
                (CalType<Cal.Yharon.Yharon>(), FloatStages.Yharon, null,
                GetField("_downedYharon")),
                (CalType<Cal.ExoMechs.Ares.AresBody>(), FloatStages.Exo, null,
                GetField("_downedAres")),
                (CalType<Cal.ExoMechs.Thanatos.ThanatosHead>(), FloatStages.Exo, null,
                GetField("_downedThanatos")),
                (CalType<Cal.ExoMechs.Apollo.Apollo>(), FloatStages.Exo, null,
                GetField("_downedArtemisAndApollo")),
                (CalType<Cal.ExoMechs.Draedon>(), FloatStages.Exo, null,
                GetField("_downedExoMechs")),
                //Hypnos
                (CalType<Cal.SupremeCalamitas.SupremeCalamitas>(), FloatStages.SCal, null,
                GetField("_downedSCal")),
                (CalType<Cal.AdultEidolonWyrm.AdultEidolonWyrmHead>(), FloatStages.BR, null,
                GetField("_downedAdultEidolonWyrm")),
            };
            return result;
        }
        [JITWhenModsEnabled("CalamityMod")]
        public static void AddBossHeadSlots(Mod mod)
        {
            mod.AddBossHeadTexture("NHAssist/UIs/UITextures/Bases/Calamity/DraedonHead",
                ModContent.NPCType<Cal.ExoMechs.Draedon>());
        }
        [JITWhenModsEnabled("CalamityMod")]
        private static int CalType<T>() where T : ModNPC => ModContent.NPCType<T>();
    }
}
