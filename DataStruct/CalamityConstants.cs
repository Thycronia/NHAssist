using CalamityMod.Items.Accessories;
namespace NHAssist.DataStruct
{
    public static class CalamityConstants
    {
        public static List<int> LevelMeterTypes { get; private set; }
        [JITWhenModsEnabled("CalamityMod")]
        internal static void Load()
        {
            //LevelMeterTypes = new List<int>
            //{
            //    ModContent.ItemType<MeleeLevelMeter>(),
            //    ModContent.ItemType<RangedLevelMeter>(),
            //    ModContent.ItemType<MagicLevelMeter>(),
            //    ModContent.ItemType<SummonLevelMeter>(),
            //    ModContent.ItemType<RogueLevelMeter>(),
            //};
        }
        internal static void UnLoad()
        {
            LevelMeterTypes = null;
        }
    }
}

