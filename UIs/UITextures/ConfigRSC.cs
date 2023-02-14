namespace NHAssist.UIs.UITextures
{
    public static partial class RSC
    {
        public static class Config
        {
            public static Asset<Texture2D> FastRespawn;
            public static Asset<Texture2D> NoTomb;
            public static Asset<Texture2D> Respawn10HP;
            public static Asset<Texture2D> HideBuff;
            public static Asset<Texture2D> AutoFire;
            public static Asset<Texture2D> BGTeleport;
            public static Asset<Texture2D> QuickReforge;
            internal static void Load()
            {
                FastRespawn = GetTexture("Config/FastRespawn");
                NoTomb = GetTexture("Config/NoTomb");
                Respawn10HP = GetTexture("Config/Respawn10HP");
                HideBuff = GetTexture("Config/HideBuff");
                AutoFire = GetTexture("Config/AutoFire");
                BGTeleport = GetTexture("Config/BGTeleport");
                QuickReforge = GetTexture("Config/QuickReforge");
            }
        }
        public static class CalConfig
        {
            public static Asset<Texture2D> FillRage;
            public static Asset<Texture2D> CalamityDrawing;
            [JITWhenModsEnabled("CalamityMod")]
            internal static void Load()
            {
                FillRage = GetTexture("Config/Calamity/FillRage");
                CalamityDrawing = GetTexture("Config/Calamity/CalamityDrawing");
            }
        }
    }
}

