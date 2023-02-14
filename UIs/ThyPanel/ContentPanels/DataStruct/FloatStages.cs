using System.Reflection;
using NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel;
namespace NHAssist.UIs.ThyPanel.ContentPanels.DataStruct
{
    public static class FloatStages
    {
        internal static int Comparator((int, float, RefMethod<bool, bool>, FieldInfo) boss1, (int, float, RefMethod<bool, bool>, FieldInfo) boss2)
        {
            float diff = boss1.Item2 - boss2.Item2;
            if (Math.Abs(diff) < Epsilon)
                return 0;
            return diff > 0f ? 1 : -1;
        }

        public const float Epsilon = 0.0001f;

        internal const float KingSlime = 0f;
        internal const float EvilBoss = 1f;
        internal const float Skeletron = 2f;
        internal const float WOF = 3f;
        internal const float MechBoss = 4f;
        internal const float Plantera = 5f;
        internal const float Golem = 6f;
        internal const float Duke = 7f;
        internal const float Cultist = 8f;
        internal const float MoonLord = 9f;
        internal const float ProfGuard = 10f;
        internal const float Providence = 11f;
        internal const float Sentinel = 12f;
        internal const float Polterghast = 13f;
        internal const float OldDuke = 14f;
        internal const float DOG = 15f;
        internal const float Yharon = 16f;
        internal const float SCal = 17f;
        internal const float Exo = 17f;
        internal const float BR = 18f;
    }
}
