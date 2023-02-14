using System;
using NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Config.ConfigPlayers;

namespace NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Config
{
    public partial class ConfigOptionUI : OptionUI
    {
        private static List<OptionUI> VanillaConfigs()
        {
            List<OptionUI> result = new List<OptionUI>();
            result.Add(new ConfigOptionUI(RSC.Config.FastRespawn,
                (Player player) => ref player.GetModPlayer<FastRespawnPlayer>().FastRespawn, "FastRespawn"));
            result.Add(new ConfigOptionUI(RSC.Config.NoTomb,
                (Player player) => ref player.GetModPlayer<FastRespawnPlayer>().NoTomb, "NoTomb"));
            result.Add(new ConfigOptionUI(RSC.Config.Respawn10HP,
                (Player player) => ref player.GetModPlayer<FastRespawnPlayer>().Respawn10HP, "Respawn10HP"));
            result.Add(new ConfigOptionUI(RSC.Config.HideBuff,
                (Player player) => ref player.GetModPlayer<HideBuffPlayer>().HideBuff, "HideBuff"));
            result.Add(new ConfigOptionUI(RSC.Config.AutoFire,
                (Player player) => ref player.GetModPlayer<HideBuffPlayer>().AutoFire, "AutoFire"));
            result.Add(new ConfigOptionUI(RSC.Config.BGTeleport,
                (Player player) => ref player.GetModPlayer<BGTeleportPlayer>().BGTeleport, "BGTeleport"));
            result.Add(new ConfigOptionUI(RSC.Config.QuickReforge,
                (Player player) => ref player.GetModPlayer<BGTeleportPlayer>().QuickReforge, "QuickReforge"));

            return result;
        }
    }
}

