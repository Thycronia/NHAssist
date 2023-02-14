using NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel;
using System.Reflection;
namespace NHAssist.UIs.ThyPanel.ContentPanels.DataStruct
{
    public static partial class BossLib
    {
        public static List<Boss> Bosses { get; private set; }
        public static void LoadBosses()
        {
            Bosses = new List<Boss>();
            List<(int, float, RefMethod<bool, bool>, FieldInfo)> TypeToFloatStage = new List<(int, float, RefMethod<bool, bool>, FieldInfo)>();
            TypeToFloatStage.AddRange(GetVanillaTypeStageList());
            if (NHAssist.Calamity != null)
                TypeToFloatStage.AddRange(GetCalamityTypeStageList());
            TypeToFloatStage.Sort(FloatStages.Comparator);
            foreach((int i, float j, RefMethod<bool, bool> GetRef, FieldInfo fieldInfo) in TypeToFloatStage)
            {
                Boss boss = null;
                if (GetRef != null)
                    boss = new Boss(j, i, GetRef);
                else if (fieldInfo != null)
                    boss = new Boss(j, i, fieldInfo);
                if(boss != null)
                    Bosses.Add(boss);
            }
        }
        public static float PostBossStage(int bossType)
        {
            foreach (Boss boss in Bosses)
                if (boss.Type == bossType)
                    return boss.Stage;
            return -1f;
        }
        public static void UnLoad()
        {
            Bosses = null;
        }
    }
}
