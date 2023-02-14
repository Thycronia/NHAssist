namespace NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Biome
{
    public partial class BiomeOptionUI : OptionUI
    {
        private RefMethod<bool, Player> GetControlRef;
        private string HoverTextKey;
        public BiomeOptionUI(Asset<Texture2D> tex, RefMethod<bool, Player> getControlRef, string hoverTextKey, bool needUpdate = false) : base(tex)
        {
            GetControlRef = getControlRef;
            HoverTextKey = hoverTextKey;
            if (needUpdate)
            {
                DoUpdate = delegate (Player player)
                {
                    if (!isAvailable || !isOn) return;
                    GetControlRef(player); //Only call if on
                };
            }
            else
            {
                ToggleOn = (Player player) => InBiome(player, true);
                ToggleOff = (Player player) => InBiome(player, false);
            }
        }
        private bool InBiome(Player player ,bool? setTo = null)
        {
            ref bool controlRef = ref GetControlRef(player);
            if(setTo.HasValue)
                controlRef = setTo.Value;
            return controlRef;
        }
        public override string HoverText => NHAssist.GetLocalText("Option.Biome."+HoverTextKey);
        //public override void UpdateAvailability(ThyPanel thyPanel)
        //{
        //    base.UpdateAvailability(thyPanel);
        //}
    }
}
