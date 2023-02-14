using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Terraria.GameInput;
using Terraria.Audio;

namespace NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Config.ConfigPlayers
{
    public class BGTeleportSystem : ModSystem
    {
        public override void PostDrawFullscreenMap(ref string mouseText)
        {
            Player player = Main.LocalPlayer;
            if(player == null || !player.active || player.dead || DataPlayer.haveBoss)
            {
                base.PostDrawFullscreenMap(ref mouseText);
                return;
            }
            if(player.TryGetModPlayer<BGTeleportPlayer>(out BGTeleportPlayer plr))
            {
                if (plr.BGTeleport)
                {
                    TeleportCheck();
                }
            }
            base.PostDrawFullscreenMap(ref mouseText);
        }
        private static void TeleportCheck()
        {
            if (PlayerInput.Triggers.JustPressed.MouseRight && Main.keyState.IsKeyUp(Keys.LeftControl))
            {
                PlayerInput.SetZoom_Unscaled();

                int mapWidth = Main.maxTilesX * 16;
                int mapHeight = Main.maxTilesY * 16;
                Vector2 cursorPosition = new Vector2(Main.mouseX, Main.mouseY);

                cursorPosition.X -= Main.screenWidth / 2f;
                cursorPosition.Y -= Main.screenHeight / 2f;

                Vector2 mapPosition = Main.mapFullscreenPos;
                Vector2 cursorWorldPosition = mapPosition;

                cursorPosition /= 16;
                cursorPosition *= 16 / Main.mapFullscreenScale;
                cursorWorldPosition += cursorPosition;
                cursorWorldPosition *= 16;

                Player player = Main.player[Main.myPlayer];
                cursorWorldPosition.Y -= player.height;
                if (cursorWorldPosition.X < 0) cursorWorldPosition.X = 0;
                else if (cursorWorldPosition.X + player.width > mapWidth) cursorWorldPosition.X = mapWidth - player.width;
                if (cursorWorldPosition.Y < 0) cursorWorldPosition.Y = 0;
                else if (cursorWorldPosition.Y + player.height > mapHeight) cursorWorldPosition.Y = mapHeight - player.height;

                //if (Main.netMode == NetmodeID.SinglePlayer) // single
                //{
                player.Teleport(cursorWorldPosition, 1, 0);
                SoundEngine.PlaySound(SoundID.Item6);
                player.position = cursorWorldPosition;
                player.velocity = Vector2.Zero;
                player.fallStart = (int)(player.position.Y / 16f);
                //}
                PlayerInput.SetZoom_UI();
            }
        }
    }
}

