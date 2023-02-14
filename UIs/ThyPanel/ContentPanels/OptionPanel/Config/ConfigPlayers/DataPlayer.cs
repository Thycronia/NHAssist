namespace NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Config.ConfigPlayers
{
    public class DataPlayer : ModPlayer
    {
        public static bool haveBoss;
        public static bool lastHaveBoss;
        public override void PreUpdate()
        {
            lastHaveBoss = haveBoss;
            haveBoss = Array.Find<NPC>(Main.npc, x => x != null && x.active && x.boss) != null;
            base.PreUpdate();
        }
    }
}

