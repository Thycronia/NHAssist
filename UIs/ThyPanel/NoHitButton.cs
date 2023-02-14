using Terraria.Audio;
namespace NHAssist.UIs.ThyPanel
{
    public class NoHitButton : UIElement
    {
        public const string TagKey = "IsNohit";

        private const float activeOpacity = 1f;
        private const float inactiveOpacity = 0.6f;
        private const int BorderWidth = 2;
        private Color backColor;
        private bool On;
        private Asset<Texture2D> UITexture;
        public NoHitButton(Asset<Texture2D> tex)
        {
            On = false;
            UITexture = tex;
            backColor = new Color(63, 82, 151) * 0.7f;
        }
        public override void MouseOver(UIMouseEvent evt)
        {
            base.MouseOver(evt);
            SoundEngine.PlaySound(SoundID.MenuTick);
        }
        public override void Click(UIMouseEvent evt)
        {
            if (evt.Target != this)
                return;
            PanelUIPlayer plr = Main.LocalPlayer.GetModPlayer<PanelUIPlayer>();
            plr.Nohit = !plr.Nohit;
            On = plr.Nohit;
            base.Click(evt);
        }
        public override void Update(GameTime gameTime)
        {
            if (IsMouseHovering)
            {
                string text = On ? NHAssist.GetLocalText("NoHitButton.IsOn") : NHAssist.GetLocalText("NoHitButton.IsOff");
                Main.instance.MouseText(text);
            }
            base.Update(gameTime);
        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            CalculatedStyle dimension = GetDimensions();
            //Draw Back
            float opacity = IsMouseHovering ? activeOpacity : inactiveOpacity;
            Color drawColor = backColor * opacity;
            spriteBatch.Draw(TextureAssets.MagicPixel.Value, dimension.ToRectangle(), drawColor);
            //Draw Border
            drawColor = Color.Black * opacity;
            Rectangle rect = new Rectangle((int)dimension.X, (int)dimension.Y, (int)dimension.Width, BorderWidth);
            spriteBatch.Draw(TextureAssets.MagicPixel.Value, rect, drawColor);
            rect = new Rectangle((int)dimension.X, (int)(dimension.Y + dimension.Height) - BorderWidth, (int)dimension.Width, BorderWidth);
            spriteBatch.Draw(TextureAssets.MagicPixel.Value, rect, drawColor);
            rect = new Rectangle((int)dimension.X, (int)(dimension.Y), BorderWidth, (int)dimension.Height);
            spriteBatch.Draw(TextureAssets.MagicPixel.Value, rect, drawColor);
            rect = new Rectangle((int)(dimension.X + dimension.Width) - BorderWidth, (int)dimension.Y, BorderWidth, (int)dimension.Height);
            spriteBatch.Draw(TextureAssets.MagicPixel.Value, rect, drawColor);
            if (UITexture?.Value != null)
            { //Draw texture
                Texture2D tex = UITexture.Value;
                float scale = BossSelectorButton.GetLargestScale(tex, dimension);
                if (scale > 0f)
                {
                    opacity = On ? activeOpacity : inactiveOpacity;
                    spriteBatch.Draw(tex, dimension.Center(), null, Color.White * opacity,
                        0f, tex.Size() / 2f, scale, SpriteEffects.None, 0f);
                }
            }
        }
        public void LoadData(bool shouldOn)
        {
            PanelUIPlayer plr = Main.LocalPlayer.GetModPlayer<PanelUIPlayer>();
            plr.Nohit = shouldOn;
            On = shouldOn;
        }
        public bool SaveData()
        {
            return On;
        }
    }
}
