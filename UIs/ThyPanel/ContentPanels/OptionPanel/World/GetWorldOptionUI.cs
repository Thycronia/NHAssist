using NHAssist.UIs.ThyPanel.ContentPanels.DataStruct;
namespace NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.World
{
    public partial class WorldOptionUI : OptionUI
    {
        public static List<OptionUI> GetWorldOptionUIList()
        {
            List<OptionUI> result = new List<OptionUI> ();
            result.AddRange(GetBossWorldOptionUI());
            return result;
        }
        private static List<OptionUI> GetBossWorldOptionUI()
        {
            List<OptionUI> result = new List<OptionUI>();
            foreach(Boss boss in BossLib.Bosses)
            {
                if (boss.NeedReflection)
                    result.Add(new BossWorldOptionUI(boss, boss.TargetFieldInfo, RSC.World.BossBack));
                else
                    result.Add(new BossWorldOptionUI(boss, boss.GetControlRef, RSC.World.BossBack));
            }
            result.AddRange(GetOtherWorldOptionUI());
            return result;
        }
        private static List<OptionUI> GetOtherWorldOptionUI()
        {
            List<OptionUI> result = new List<OptionUI>();
            result.Add(new WorldOptionUI(RSC.World.FTW, (bool x) => ref Main.getGoodWorld, "Terraria.World_FTW"));
            return result;
        }
    }
}
