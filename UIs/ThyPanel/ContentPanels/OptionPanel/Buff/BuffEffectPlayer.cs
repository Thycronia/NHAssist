namespace NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Buff
{
    public class BuffEffectPlayer : ModPlayer
    {
        public override void PostUpdateMiscEffects()
        {
            if(Player.whoAmI == Main.myPlayer)
            {
                if (Player.HasBuff(BuffID.Campfire))
                    Main.SceneMetrics.HasCampfire = true;
                if (Player.HasBuff(BuffID.HeartLamp))
                    Main.SceneMetrics.HasHeartLantern = true;
            }
            base.PostUpdateMiscEffects();
        }
    }
}

