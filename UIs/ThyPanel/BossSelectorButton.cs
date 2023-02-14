using Terraria.Audio;
using NHAssist.UIs.ThyPanel.ContentPanels.DataStruct;
namespace NHAssist.UIs.ThyPanel
{
    public class BossSelectorButton : UIElement
    {
        public const string TagKey = "NohitBoss";

        private const float activeOpacity = 1f;
        private const float inactiveOpacity = 0.6f;
        private const int BorderWidth = 2;
        private Color backColor;
        private Asset<Texture2D> texture;
        public BossSelectorButton(Asset<Texture2D> tex)
        {
            SetImage(tex);
            backColor = new Color(63, 82, 151) * 0.7f;
        }
        public void SetImage(Asset<Texture2D> tex)
        {
            texture = tex;
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
            ThyPanel panel = (ThyPanel)Parent;
            if(panel != null)
            {
                panel.SwitchContentPanel();
            }
            base.Click(evt);
        }
        public override void RightClick(UIMouseEvent evt)
        {
            if (evt.Target != this)
                return;
            ThyPanel panel = (ThyPanel)Parent;
            if (panel != null)
            {
                panel.SetBoss(null);
                panel.SetContentPanel(true);
            }
            base.RightClick(evt);
        }
        public override void Update(GameTime gameTime)
        {
            if (IsMouseHovering)
            {
                ThyPanel panel = (ThyPanel)Parent;
                if(panel != null)
                {
                    string text = "";
                    Boss boss = panel.NHBoss;
                    if (boss != null)
                        text += NHAssist.GetLocalText("BossSelectorButton.CurrentBoss") + $" {boss.DisplayName}\n";
                    if (panel.isOptionPanel)
                        text += NHAssist.GetLocalText("BossSelectorButton.Select");
                    else
                        text += NHAssist.GetLocalText("BossSelectorButton.Return");
                    text += "\n" + NHAssist.GetLocalText("BossSelectorButton.Clear");
                    Main.instance.MouseText(text);
                }
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
            rect = new Rectangle((int)(dimension.X+dimension.Width)-BorderWidth, (int)dimension.Y, BorderWidth, (int)dimension.Height);
            spriteBatch.Draw(TextureAssets.MagicPixel.Value, rect, drawColor);
            if (texture?.Value != null)
            { //Draw texture
                Texture2D tex = texture.Value;
                float scale = GetLargestScale(tex, dimension);
                if (scale > 0f)
                {
                    spriteBatch.Draw(tex, dimension.Center(), null, Color.White,
                        0f, tex.Size() / 2f, scale, SpriteEffects.None, 0f);
                }
            }
        }
        public static float GetLargestScale(Texture2D tex, CalculatedStyle dimension)
        {
            if (tex.Width == 0 || tex.Height == 0)
                return 0f;
            if (dimension.Width <= 0f || dimension.Height <= 0f)
                return -1f;
            float xScale = dimension.Width / tex.Width;
            float yScale = dimension.Height / tex.Height;
            return Math.Min(xScale, yScale);
        }
        public void LoadData(string str)
        {
            Boss b = null;
            foreach(Boss boss in BossLib.Bosses)
                if(boss.UniqueIdentifier == str)
                {
                    b = boss;
                    break;
                }
            ThyPanel panel = (ThyPanel)Parent;
            if (panel != null)
                panel.SetBoss(b);
        }
        public string SaveData()
        {
            ThyPanel panel = (ThyPanel)Parent;
            if (panel != null)
                if (panel.NHBoss != null)
                    return panel.NHBoss.UniqueIdentifier;
            return "";
        }
    }
}
