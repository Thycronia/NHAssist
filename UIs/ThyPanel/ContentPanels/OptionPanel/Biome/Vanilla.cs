using System.Reflection;
namespace NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Biome
{
    public static partial class BiomeLib
    {
        private static bool DummyBool;
        private static List<BiomeInfo> GetVanillaBiomeInfo(ref int index)
        {
            List<BiomeInfo> result = new List<BiomeInfo>
            {
                //new BiomeInfo(index++, RSC.Biome.Snow, typeof(Player).GetMethod("get_ZoneSnow", (BindingFlags)60), "Terraria.Snow"),
                //new BiomeInfo(index++, RSC.Biome.Desert, typeof(Player).GetMethod("get_ZoneDesert", (BindingFlags)60), "Terraria.Desert"),
                //new BiomeInfo(index++, RSC.Biome.UndergroundDesert, typeof(Player).GetMethod("get_ZoneUndergroundDesert", (BindingFlags)60), "Terraria.UndergroundDesert"),
                //new BiomeInfo(index++, RSC.Biome.Jungle, typeof(Player).GetMethod("get_ZoneJungle", (BindingFlags)60), "Terraria.Jungle"),
                //new BiomeInfo(index++, RSC.Biome.GlowMushroom, typeof(Player).GetMethod("get_ZoneGlowshroom", (BindingFlags)60), "Terraria.Glowshroom"),
                //new BiomeInfo(index++, RSC.Biome.Dungeon, typeof(Player).GetMethod("get_ZoneDungeon", (BindingFlags)60), "Terraria.Dungeon"),
                //new BiomeInfo(index++, RSC.Biome.Corrupt, typeof(Player).GetMethod("get_ZoneCorrupt", (BindingFlags)60), "Terraria.Corrupt"),
                //new BiomeInfo(index++, RSC.Biome.Crimson, typeof(Player).GetMethod("get_ZoneCrimson", (BindingFlags)60), "Terraria.Crimson"),
                //new BiomeInfo(index++, RSC.Biome.Hallow, typeof(Player).GetMethod("get_ZoneHallow",(BindingFlags)60), "Terraria.Hallow"),
                //new BiomeInfo(index++, RSC.Biome.Granite, typeof(Player).GetMethod("get_ZoneGranite", (BindingFlags)60), "Terraria.Granite"),
                //new BiomeInfo(index++, RSC.Biome.Marble, typeof(Player).GetMethod("get_ZoneMarble", (BindingFlags)60), "Terraria.Marble"),
                //new BiomeInfo(index++, RSC.Biome.Graveyard, typeof(Player).GetMethod("get_ZoneGraveyard", (BindingFlags)60), "Terraria.Graveyard"),
                //new BiomeInfo(index++, RSC.Biome.Meteor, typeof(Player).GetMethod("get_ZoneMeteor", (BindingFlags)60), "Terraria.Meteor"),

                new BiomeInfo(RSC.Biome.Snow, (Player p) => {p.ZoneSnow = true; return ref DummyBool;}, "Terraria.Snow"),
                new BiomeInfo(RSC.Biome.Desert, (Player p) => {p.ZoneDesert = true; return ref DummyBool;}, "Terraria.Desert"),
                new BiomeInfo(RSC.Biome.UndergroundDesert, (Player p) => {p.ZoneUndergroundDesert = true; return ref DummyBool;}, "Terraria.UndergroundDesert"),
                new BiomeInfo(RSC.Biome.Jungle, (Player p) => {p.ZoneJungle = true; return ref DummyBool;}, "Terraria.Jungle"),
                new BiomeInfo(RSC.Biome.GlowMushroom, (Player p) => {p.ZoneGlowshroom = true; return ref DummyBool;}, "Terraria.Glowshroom"),
                new BiomeInfo(RSC.Biome.Dungeon, (Player p) => {p.ZoneDungeon = true; return ref DummyBool;}, "Terraria.Dungeon"),
                new BiomeInfo(RSC.Biome.Corrupt, (Player p) => {p.ZoneCorrupt = true; return ref DummyBool;}, "Terraria.Corrupt"),
                new BiomeInfo(RSC.Biome.Crimson, (Player p) => {p.ZoneCrimson = true; return ref DummyBool;}, "Terraria.Crimson"),
                new BiomeInfo(RSC.Biome.Hallow, (Player p) => {p.ZoneHallow = true; return ref DummyBool;}, "Terraria.Hallow"),
                new BiomeInfo(RSC.Biome.Granite, (Player p) => {p.ZoneGranite = true; return ref DummyBool;}, "Terraria.Granite"),
                new BiomeInfo(RSC.Biome.Marble, (Player p) => {p.ZoneMarble = true; return ref DummyBool;}, "Terraria.Marble"),
                new BiomeInfo(RSC.Biome.Graveyard, (Player p) => {p.ZoneGraveyard = true; return ref DummyBool;}, "Terraria.Graveyard"),
                new BiomeInfo(RSC.Biome.Meteor, (Player p) => {p.ZoneMeteor = true; return ref DummyBool;}, "Terraria.Meteor"),

            };
            return result;
        }
    }
}
