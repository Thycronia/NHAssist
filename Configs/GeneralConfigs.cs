using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace NHAssist.Configs
{
    [Label("$Mods.NHAssist.Configs.GeneralConfigs.Name")]
    public class GeneralConfigs : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;
        public static GeneralConfigs Instance;

        [Label("$Mods.NHAssist.Configs.GeneralConfigs.MoreBuffSlots.Label")]
        [DefaultValue(64)]
        [Range(0, 64)]
        [Slider]
        [Increment(8)]
        [ReloadRequired]
        public uint ExtraBuffSlots;

        [Label("$Mods.NHAssist.Configs.GeneralConfigs.ScrollSens.Label")]
        [DefaultValue(1f)]
        [Range(0.2f, 4f)]
        [Slider]
        [Increment(0.2f)]
        [Tooltip("$Mods.NHAssist.Configs.GeneralConfigs.ScrollSens.Tip")]
        public float ScrollSensMultiplier;
    }
}

