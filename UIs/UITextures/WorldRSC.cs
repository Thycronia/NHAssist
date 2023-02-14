namespace NHAssist.UIs.UITextures
{
    public static partial class RSC
    {
        public static class World
        {
            public static Asset<Texture2D> BossBack;
            public static Asset<Texture2D> FTW;
            internal static void Load()
            {
                BossBack = GetTexture("World/BossBack");
                FTW = GetTexture("World/FTW");
            }
        }
        public static class CalWorld
        {
            [JITWhenModsEnabled("CalamityMod")]
            internal static void Load()
            {

            }
        }
    }
}

