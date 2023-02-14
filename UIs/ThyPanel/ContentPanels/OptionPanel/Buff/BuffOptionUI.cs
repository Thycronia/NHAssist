using NHAssist.UIs.ThyPanel.ContentPanels.DataStruct;
namespace NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Buff
{
    public partial class BuffOptionUI : OptionUI
    {
        public override string Tagkey => BuffFullName;
        public int buffType { get; private set; }
        /// <summary>
        /// The buff is a post-[boss at buff stage] buff.
        /// </summary>
        public float buffStage { get; private set; }
        public string buffName { get; private set; }
        public Mod buffMod { get; private set; }
        public BuffOptionUI(Asset<Texture2D> tex, int buffType, string buffName, float stage, Mod mod = null) : base(tex)
        {
            this.buffType = buffType;
            this.buffName = buffName;
            this.buffStage = stage;
            this.buffMod = mod;
            DoUpdate = (Player player) => { if (isOn && isAvailable) player.AddBuff(buffType, 5); };
            ToggleOn = (Player _) => Main.buffNoTimeDisplay[buffType] = true;
            ToggleOff = (Player _) => Main.buffNoTimeDisplay[buffType] = false;
        }
        public override string HoverText => BuffDisplayName + "\n" + BuffDescription;
        public override void UpdateAvailability(ThyPanel thyPanel)
        {
            if (thyPanel.NHBoss == null)
            {
                isAvailable = true;
                return;
            }
            isAvailable = buffStage - thyPanel.NHBoss.Stage < - FloatStages.Epsilon;
        }
        private string BuffDisplayName => Lang.GetBuffName(buffType);
        private string BuffFullName => (buffMod?.Name ?? "Terraria") + ":" + buffName;
        private string BuffDescription => Main.GetBuffTooltip(Main.LocalPlayer, buffType);

    }
}
