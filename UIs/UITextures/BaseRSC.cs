namespace NHAssist.UIs.UITextures
{
    public static partial class RSC
    {
        public static class Base
        {
            public static Asset<Texture2D> OptionOn;
            public static Asset<Texture2D> OptionOff;
            public static Asset<Texture2D> PanelResize;
            public static Asset<Texture2D> NoBoss;
            public static Asset<Texture2D> NoHit;
            public static Asset<Texture2D> QueryButton;
            internal static void Load()
            {
                OptionOn = GetTexture("Bases/On");
                OptionOff = GetTexture("Bases/Off");
                PanelResize = GetTexture("Bases/Resize");
                NoBoss = GetTexture("Bases/NoBoss");
                NoHit = GetTexture("Bases/Nohit");
                QueryButton = GetTexture("Bases/Query");
            }
        }
        public static class CalBase
        {
            //public static Asset<Texture2D> DraedonHead;
            [JITWhenModsEnabled("CalamityMod")]
            internal static void Load()
            {

            }
        }
    }
}

