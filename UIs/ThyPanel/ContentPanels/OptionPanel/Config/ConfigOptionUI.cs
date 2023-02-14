namespace NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Config
{
    public partial class ConfigOptionUI : OptionUI
    {
        public override string Tagkey => HoverTextKey;
        private RefMethod<bool, Player> GetControlRef;
        private string HoverTextKey;
        public override string HoverText => NHAssist.GetLocalText("Option.Config."+HoverTextKey);
        public ConfigOptionUI(Asset<Texture2D> tex, RefMethod<bool, Player> getControlRef, string hoverTextKey) : base(tex)
        {
            this.GetControlRef = getControlRef;
            this.HoverTextKey = hoverTextKey;
            ToggleOn = (Player player) => Value(player, true);
            ToggleOff = (Player player) => Value(player, false);
        }
        private bool Value(Player player, bool? setTo = null)
        {
            ref bool controlRef = ref GetControlRef(player);
            if (setTo.HasValue)
                controlRef = setTo.Value;
            return controlRef;
        }
    }
}
