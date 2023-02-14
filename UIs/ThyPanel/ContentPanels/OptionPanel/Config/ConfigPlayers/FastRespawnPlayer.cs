using System.Linq;

namespace NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Config.ConfigPlayers
{
    public class FastRespawnPlayer : ModPlayer
    {
        public bool FastRespawn;
        public bool NoTomb;
        public bool Respawn10HP;

        public override void UpdateDead()
        {
            if (FastRespawn)
            {
                if (Player.respawnTimer > 1)
                    Player.respawnTimer = 1;
                ClearEnimy();
                ClearProj();
            }
            base.UpdateDead();
        }
        public override void OnRespawn(Player player)
        {
            if (Respawn10HP)
                player.statLife = Math.Min(player.statLife, 10);
            base.OnRespawn(player);
        }
        private void ClearProj()
        {
            foreach (Projectile projectile in from proj in Main.projectile where proj != null select proj)
            {
                if (projectile.active)
                {
                    if (projectile.hostile && projectile.damage > 0)
                        projectile.active = false;
                    else if (projectile.owner == Player.whoAmI)
                        projectile.active = false;
                }
            }
        }
        private void ClearEnimy()
        {
            foreach (NPC npc in Main.npc)
            {
                if (npc != null && npc.active)
                {
                    if (npc.boss)
                    {
                        npc.active = false;
                    }
                    else
                    if (!npc.friendly && npc.lifeMax > 1)
                    {
                        npc.active = false;
                    }
                }
            }
        }
    }
}

