using Terraria.GameInput;
using NHAssist.Configs;
namespace NHAssist.UIs.UIBases
{
    public class ScrollableUI : UIElement
    {
        public UIScrollbar ScrollBar { get; private set; }
        public ScrollContent Content { get; private set; }
        private float sensitivity;
        private Color backColor;
        public ScrollableUI(UIScrollbar scrollBar, float sensitivity = 0.2f)
        {
            SetScrollBar(scrollBar);
            this.sensitivity = sensitivity;
            OverflowHidden = true;
            Content = new ScrollContent();
            backColor = new Color(63, 82, 151) * 0.6f;
        }
        public override void OnInitialize()
        {
            //SetContent(Content);
            base.OnInitialize();
        }
        public void SetScrollBar(UIScrollbar scrollBar)
        {
            ScrollBar = scrollBar;
        }
        /// <summary>
        /// Set the height of the content before calling
        /// </summary>
        /// <param name="content">Not <see cref="null"/></param>
        public void SetContent(ScrollContent content)
        {
            if (content == null || HasChild(content))
                return;
            Content?.OnSetInvisible();
            RemoveChild(Content);
            Content = content;
            Content.Left.Set(0, 0);
            Content.Width = Width;
            if (ScrollBar != null)
            {
                ScrollBar.SetView(Height.Pixels, Content.Height.Pixels);
                Content.Top.Set(-ScrollBar.ViewPosition, 0);
            }
            else
                Content.Top.Set(0, 0);
            Append(Content);
            RearrangeContent();
            Content.Recalculate();
            Content.OnSetVisible();
        }
        public override void Update(GameTime gameTime)
        {
            if (IsMouseHovering)
                PlayerInput.LockVanillaMouseScroll("NHAssist: ThyPanel");
            if (Content != null && ScrollBar != null)
            {
                if(Content.Top.Pixels != -ScrollBar.ViewPosition)
                {
                    Content.Top.Set(-ScrollBar.ViewPosition, 0);
                    Content.Recalculate();
                }
            }
            base.Update(gameTime);
        }
        public override void ScrollWheel(UIScrollWheelEvent evt)
        {
            base.ScrollWheel(evt);
            if (ScrollBar != null)
                ScrollBar.ViewPosition -= sensitivity * evt.ScrollWheelValue * GeneralConfigs.Instance.ScrollSensMultiplier;
        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            //Color drawColor = new Color(63, 82, 151) * 0.7f;
            Rectangle rect = GetDimensions().ToRectangle();
            spriteBatch.Draw(TextureAssets.MagicPixel.Value, rect, backColor);
            base.DrawSelf(spriteBatch);
        }
        public void RearrangeContent()
        {
            if(Content != null)
            {
                Content.Width = Width;
                Content.Rearrange();
                if (ScrollBar != null)
                    ScrollBar.SetView(Height.Pixels, Content.Height.Pixels);
            }
        }
    }
}
