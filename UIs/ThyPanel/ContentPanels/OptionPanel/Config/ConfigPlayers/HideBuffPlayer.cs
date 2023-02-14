using Terraria.GameInput;
namespace NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Config.ConfigPlayers
{
    public class HideBuffPlayer : ModPlayer
    {
        public bool HideBuff;
        public bool AutoFire;

        private bool shouldAutoFire;
        private bool lastMouseLeft;
        private bool mouseLeft;

        public override void SetControls()
        {
            if (Main.gameMenu || Main.gamePaused)
                return;
            lastMouseLeft = mouseLeft;
            mouseLeft = PlayerInput.Triggers.Current.MouseLeft;
            //Main.NewText(player.controlUseItem+"  " + PlayerInput.Triggers.Current.KeyStatus["MouseLeft"]);
            //player.controlUseItem = true;
            if (AutoFire)
            {
                if (Player.mouseInterface)
                {
                    shouldAutoFire = false;
                }
                else if (!lastMouseLeft && mouseLeft)
                {
                    if (shouldAutoFire)
                    {
                        shouldAutoFire = false;
                    }
                    else
                    {
                        if (AutoUseValid())
                        {
                            shouldAutoFire = true;
                        }
                    }
                }
                if (shouldAutoFire)
                {
                    Player.controlUseItem = true;
                }
            }
            base.SetControls();
        }

        public override void UpdateDead()
        {
            shouldAutoFire = false;
            base.UpdateDead();
        }
        public override void OnEnterWorld(Player player)
        {
            shouldAutoFire = false;
            base.OnEnterWorld(player);
        }

        private bool AutoUseValid()
        {
            Item item = Player.HeldItem;
            if (item == null || item.IsAir)
                return false;
            if (!item.autoReuse && !item.channel)
                return false;
            if (item.damage < 1)
                return false;
            if (!ItemLoader.CanUseItem(item, Player))
                return false;
            return true;
        }
    }
}

