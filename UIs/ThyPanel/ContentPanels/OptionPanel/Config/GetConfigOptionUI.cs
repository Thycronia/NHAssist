using NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Config.ConfigPlayers;
namespace NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Config
{
    public partial class ConfigOptionUI : OptionUI
    {
        public static List<OptionUI> GetConfigOptionUIList()
        {
            List<OptionUI> result = new List<OptionUI>();
            result.AddRange(VanillaConfigs());
            if (NHAssist.Calamity != null)
                result.AddRange(CalamityConfigs());
            return result;
        }
    }
}
