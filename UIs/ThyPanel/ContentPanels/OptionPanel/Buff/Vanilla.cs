using NHAssist.UIs.ThyPanel.ContentPanels.DataStruct;
namespace NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Buff
{
    internal static partial class Bufflib
    {
        internal static List<(int, float)> GetVanillaBuffStage()
        {
            List<(int, float)> result = new List<(int, float)>
            {
                (BuffID.Regeneration, -1), (BuffID.Swiftness, -1),
                (BuffID.Ironskin, -1), (BuffID.WellFed3, -1),
                (BuffID.SugarRush, -1),(BuffID.Sunflower, -1),
                (BuffID.Campfire, -1), (BuffID.HeartLamp, -1),
                (BuffID.StarInBottle, -1),(BuffID.CatBast, -1),
                (BuffID.Dangersense, -1), (BuffID.Hunter, -1),
                (BuffID.Gills, -1), (BuffID.Flipper, -1),
                (BuffID.WaterWalking, -1),(BuffID.ObsidianSkin, -1),
                (BuffID.Warmth, -1),
                (BuffID.Shine, -1),(BuffID.NightOwl, -1), 
                (BuffID.Heartreach, -1),(BuffID.Inferno, -1),
                (BuffID.Featherfall, -1),(BuffID.Gravitation, -1),
                (BuffID.Endurance, -1),(BuffID.Tipsy, -1),
                (BuffID.Rage, -1),(BuffID.Wrath, -1),
                (BuffID.AmmoReservation, -1),(BuffID.AmmoBox, -1),
                (BuffID.Archery, -1),
                (BuffID.ManaRegeneration, -1),(BuffID.MagicPower, -1),
                (BuffID.Summoning, -1),(BuffID.Thorns, -1),
                (BuffID.Sharpened, -1),

                (BuffID.Bewitched, FloatStages.Skeletron),(BuffID.WeaponImbuePoison, FloatStages.Skeletron),
                (BuffID.WeaponImbueFire, FloatStages.Skeletron),(BuffID.Titan, FloatStages.Skeletron),

                (BuffID.Lifeforce, FloatStages.WOF), (BuffID.WeaponImbueCursedFlames, FloatStages.WOF),
                (BuffID.WeaponImbueIchor, FloatStages.WOF),(BuffID.Clairvoyance, FloatStages.WOF),

                (BuffID.WeaponImbueNanites, FloatStages.Plantera),(BuffID.WeaponImbueVenom, FloatStages.Plantera),
            };
            return result;
        }
    }
}
