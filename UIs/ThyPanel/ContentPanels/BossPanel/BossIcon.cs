using NHAssist.UIs.ThyPanel.ContentPanels.DataStruct;
using NHAssist.UIs.ThyPanel;
namespace NHAssist.UIs.ThyPanel.ContentPanels.BossPanel
{
    public partial class BossIcon : UIElement
    {
        private Boss Boss;
        private ThyPanel Panel => ThyUISystem.Panel;
        private Asset<Texture2D> UITexture;
        private bool IsPanelBoss => Panel.NHBoss != null && Panel.NHBoss.Type == Boss.Type;
        public BossIcon(Boss boss)
        {
            this.Boss = boss;
        }
        public override void OnInitialize()
        {
            Width.Set(UIDims.OptionSize, 0);
            Height = Width;
            base.OnInitialize();
        }
        public override void Update(GameTime gameTime)
        {
            if(UITexture == null)
                UITexture = Boss.TryGetHeadTexture();
            if (IsMouseHovering)
                Main.instance.MouseText(Boss.DisplayName);
            base.Update(gameTime);
        }
        public override void Click(UIMouseEvent evt)
        {
            if (evt.Target != this || Panel == null)
                return;
            if (!IsPanelBoss)
            {
                Panel.SetBoss(Boss);
            }
            Panel.SwitchContentPanel();
            base.Click(evt);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (UITexture?.Value != null)
            {
                Texture2D texture = UITexture.Value;
                CalculatedStyle dimension = GetDimensions();
                float scale = BossSelectorButton.GetLargestScale(texture, dimension);
                Color drawColor = Color.White with { A = (byte)(IsMouseHovering || IsPanelBoss ? 128 : 255) };
                spriteBatch.Draw(texture, dimension.Center(), null, drawColor, 0f,
                    texture.Size() / 2f, scale, SpriteEffects.None, 0f);
            }
            base.Draw(spriteBatch);
        }
    }
}
