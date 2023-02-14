using Terraria.DataStructures;

namespace NHAssist.UIs.ThyPanel
{
    public class PanelUIPlayer : ModPlayer
    {
        private ThyPanel Panel => ThyUISystem.Panel;
        public bool Nohit;
        public override void PostUpdateBuffs()
        {
            Panel.OptionPanel.BuffCategory.DoUpdate();
            base.PostUpdateBuffs();
        }
        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit, int cooldownCounter)
        {
            if (Nohit && damage > 0)
                if(Array.Exists<NPC>(Main.npc, x=>x!=null&&x.active&&x.boss))
                    Player.KillMe(PlayerDeathReason.ByCustomReason(NHAssist.GetLocalText("PanelUIPlayer.DeathMessage")), damage, hitDirection);
            base.Hurt(pvp, quiet, damage, hitDirection, crit, cooldownCounter);
        }
    }
}
