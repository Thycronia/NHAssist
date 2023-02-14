using Terraria.Audio;
namespace NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel
{
    public abstract class OptionUI : UIElement
    {
        public virtual string Tagkey => null;
        public bool isOn { get; protected set; }
        public bool isAvailable { get; protected set; }
        public UpdateMethod DoUpdate { get; protected set; }
        public ToggleMethod ToggleOn { get; protected set; }
        public ToggleMethod ToggleOff { get; protected set; }
        public virtual void UpdateAvailability(ThyPanel thyPanel) { isAvailable = true; }
        public virtual string HoverText => null;
        protected Asset<Texture2D> UITexture;
        public OptionUI(Asset<Texture2D> tex, UpdateMethod doUpdate = null, 
            ToggleMethod onMethod = null, ToggleMethod offMethod = null)
        {
            UITexture = tex;
            //if(UITexture.State == AssetState.NotLoaded)
            //{
            //    try { ModContent.Request<Texture2D>(UITexture.Name); }
            //    catch (Exception) {; }
            //}
            DoUpdate = doUpdate;
            ToggleOn = onMethod;
            ToggleOff = offMethod;
        }
        public override void OnInitialize()
        {
            Width.Set(UIDims.OptionSize, 0);
            Height = Width;
            base.OnInitialize();
        }
        public override void Click(UIMouseEvent evt)
        {
            if (evt.Target != this || !isAvailable)
                return;
            SoundEngine.PlaySound(SoundID.MenuTick);
            if (isOn)
            { // Turn off
                isOn = false;
                ToggleOff?.Invoke(Main.LocalPlayer);
            }
            else
            { // Turn on
                isOn = true;
                ToggleOn?.Invoke(Main.LocalPlayer);
            }
            base.Click(evt);
        }
        public override void Update(GameTime gameTime)
        {
            if(IsMouseHovering)
                SetMouseText();
            base.Update(gameTime);
        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            //if (IsMouseHovering)
            //    SetMouseText();
            Color drawColor;
            if (isAvailable)
                drawColor = Color.White;
            else
                drawColor = Color.Lerp(Color.White, Color.Black, 0.4f);
            DrawContent(spriteBatch, drawColor with { A = (byte)((isAvailable && IsMouseHovering) ? 128 : 255) });
            Texture2D outlineTex = (isOn ? RSC.Base.OptionOn : RSC.Base.OptionOff).Value;
            Rectangle rect = GetDimensions().ToRectangle();
            spriteBatch.Draw(outlineTex, rect, drawColor);
            base.DrawSelf(spriteBatch);
        }
        public virtual void DrawContent(SpriteBatch spriteBatch, Color color)
        {
            Rectangle rect = GetDimensions().ToRectangle();
            spriteBatch.Draw(UITexture?.Value, rect, color);
        }
        private void SetMouseText()
        {
            string hoverText = HoverText;
            if (isAvailable)
            {
                if (hoverText != null)
                    Main.instance.MouseText(hoverText);
            }
            else
            {
                if (hoverText == null)
                    hoverText = "";
                else
                    hoverText += "\n";
                hoverText += NHAssist.GetLocalText("Option.Base.NotAvailable");
                Main.instance.MouseText(hoverText);
            }
        }
        public void LoadData(TagCompound tag)
        {
            isOn = false;
            if (Tagkey == null)
                return;
            if(tag.TryGet(Tagkey, out bool shouldOn))
                if (shouldOn && !isOn)
                {
                    isOn = true;
                    ToggleOn?.Invoke(Main.LocalPlayer);
                }
        }
        public (string, bool)? SaveData()
        {
            if (Tagkey == null)
                return null;
            return (Tagkey, isOn);
        }
    }
}
