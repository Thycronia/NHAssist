using System;
using NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Config.ConfigPlayers;

namespace NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Config
{
    public partial class ConfigOptionUI : OptionUI
    {
        private static List<OptionUI> CalamityConfigs()
        {
            List<OptionUI> result = new List<OptionUI>();
            result.Add(new ConfigOptionUI(RSC.CalConfig.FillRage,
                (Player player) => ref player.GetModPlayer<RagePlayer>().FillRage, "Calamity.FillRage"));
            result.Add(new ConfigOptionUI(RSC.CalConfig.CalamityDrawing,
                (Player player) => ref player.GetModPlayer<RagePlayer>().CalamityDrawing, "Calamity.CalamityDrawing"));
            return result;
        }
    }
}

