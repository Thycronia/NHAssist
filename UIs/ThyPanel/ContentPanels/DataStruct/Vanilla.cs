using NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel;
using System.Reflection;
namespace NHAssist.UIs.ThyPanel.ContentPanels.DataStruct
{
    public static partial class BossLib
    {
        private static List<(int, float, RefMethod<bool, bool>, FieldInfo)> GetVanillaTypeStageList()
        {
            var result = new List<(int, float, RefMethod<bool, bool>, FieldInfo)>
            {
                (NPCID.KingSlime, FloatStages.KingSlime, (bool _) => ref NPC.downedSlimeKing, null),
                (NPCID.EyeofCthulhu, FloatStages.KingSlime, (bool _) => ref NPC.downedBoss1, null),
                (NPCID.EaterofWorldsHead, FloatStages.EvilBoss, (bool _) => ref NPC.downedBoss2, null),
                (NPCID.BrainofCthulhu, FloatStages.EvilBoss, (bool _) => ref NPC.downedBoss2, null),
                (NPCID.QueenBee, FloatStages.Skeletron, (bool _) => ref NPC.downedQueenBee, null),
                (NPCID.SkeletronHead, FloatStages.Skeletron, (bool _) => ref NPC.downedBoss3, null),
                (NPCID.Deerclops, FloatStages.Skeletron, (bool _) => ref NPC.downedDeerclops, null),
                (NPCID.WallofFlesh, FloatStages.WOF, (bool _) => ref Main.hardMode, null),
                (NPCID.QueenSlimeBoss, FloatStages.MechBoss, (bool _) => ref NPC.downedQueenSlime, null),
                (NPCID.Retinazer, FloatStages.MechBoss, (bool _) => ref NPC.downedMechBoss2, null),
                (NPCID.SkeletronPrime, FloatStages.MechBoss, (bool _) => ref NPC.downedMechBoss3, null),
                (NPCID.TheDestroyer, FloatStages.MechBoss, (bool _) => ref NPC.downedMechBoss1, null),
                (NPCID.Plantera, FloatStages.Plantera, (bool _) => ref NPC.downedPlantBoss, null),
                (NPCID.GolemHead, FloatStages.Golem, (bool _) => ref NPC.downedGolemBoss, null),
                (NPCID.HallowBoss, FloatStages.Golem, (bool _) => ref NPC.downedEmpressOfLight, null),
                (NPCID.DukeFishron, FloatStages.Duke, (bool _) => ref NPC.downedFishron, null),
                (NPCID.CultistBoss, FloatStages.Cultist, (bool _) => ref NPC.downedAncientCultist, null),
                (NPCID.MoonLordHead, FloatStages.MoonLord, (bool _) => ref NPC.downedMoonlord, null),
            };
            return result;
        }
    }
}
