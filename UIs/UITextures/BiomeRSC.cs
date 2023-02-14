namespace NHAssist.UIs.UITextures
{
    public static partial class RSC
    {
        public static class Biome
        {
            public static Asset<Texture2D> Hallow;
            public static Asset<Texture2D> Dungeon;
            public static Asset<Texture2D> Corrupt;
            public static Asset<Texture2D> Meteor;
            public static Asset<Texture2D> Jungle;
            public static Asset<Texture2D> Snow;
            public static Asset<Texture2D> Crimson;
            public static Asset<Texture2D> GlowMushroom;
            public static Asset<Texture2D> UndergroundDesert;
            public static Asset<Texture2D> Granite;
            public static Asset<Texture2D> Marble;
            public static Asset<Texture2D> Graveyard;
            public static Asset<Texture2D> Desert;
            internal static void Load()
            {
                Hallow = GetTexture("Biome/Hallow");
                Dungeon = GetTexture("Biome/Dungeon");
                Corrupt = GetTexture("Biome/Corrupt");
                Meteor = GetTexture("Biome/Meteor");
                Jungle = GetTexture("Biome/Jungle");
                Snow = GetTexture("Biome/Snow");
                Crimson = GetTexture("Biome/Crimson");
                GlowMushroom = GetTexture("Biome/GlowMushroom");
                UndergroundDesert = GetTexture("Biome/UndergroundDesert");
                Granite = GetTexture("Biome/Granite");
                Marble = GetTexture("Biome/Marble");
                Graveyard = GetTexture("Biome/Graveyard");
                Desert = GetTexture("Biome/Desert");
            }
        }
        public static class CalBiome
        {
            public static Asset<Texture2D> SurfaceAstral;
            public static Asset<Texture2D> AbyssLayer1;
            public static Asset<Texture2D> AbyssLayer4;
            public static Asset<Texture2D> Brimstone;
            public static Asset<Texture2D> Sulphur;
            public static Asset<Texture2D> Sunken;
            [JITWhenModsEnabled("CalamityMod")]
            internal static void Load()
            {
                SurfaceAstral = GetTexture("Biome/Calamity/SurfaceAstral");
                AbyssLayer1 = GetTexture("Biome/Calamity/AbyssLayer1");
                AbyssLayer4 = GetTexture("Biome/Calamity/AbyssLayer4");
                Brimstone = GetTexture("Biome/Calamity/Brimstone");
                Sulphur = GetTexture("Biome/Calamity/Sulphur");
                Sunken = GetTexture("Biome/Calamity/Sunken");
            }
        }
    }
}

