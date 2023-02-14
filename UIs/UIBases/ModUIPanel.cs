using System;
namespace NHAssist.UIs.UIBases
{
    public class ModUIPanel : UIPanel
    {
        protected bool Resizeable;
        protected bool Resizing;
        private readonly int _minResizeWidth;
        private readonly int _minResizeHeight;

        protected bool Draggable;
        protected bool Dragging;

        internal Vector2 Offset;

        protected event ElementEvent OnRecalculate;
        protected event ElementEvent OnDrag;
        protected event ElementEvent OnResize;

        internal Asset<Texture2D> ResizeIndicator;

        public ModUIPanel(bool draggable = true, bool resizeable = false, int minResizeWidth = 160, int minResizeHeight = 90)
        {
            Draggable = draggable;
            Resizeable = resizeable;
            OnMouseDown += DragStart;
            OnMouseUp += DragEnd;
            _minResizeWidth = minResizeWidth;
            _minResizeHeight = minResizeHeight;
            ResizeIndicator = RSC.Base.PanelResize;
        }

        public override void Recalculate()
        {
            base.Recalculate();
            OnRecalculate?.Invoke(this);
        }

        public Rectangle ResizeRectangle
        {
            get
            {
                CalculatedStyle innerDimensions = GetInnerDimensions();
                return new Rectangle((int)(innerDimensions.X + innerDimensions.Width - 12), (int)(innerDimensions.Y + innerDimensions.Height - 12), 12 + (int)PaddingRight, 12 + (int)PaddingBottom);
            }
        }

        // 可拖动/调整大小界面
        private void DragStart(UIMouseEvent evt, UIElement listeningElement)
        {
            //CalculatedStyle innerDimensions = GetInnerDimensions();
            if (evt.Target != this)
                return;
            if (Resizeable && ResizeRectangle.Contains(evt.MousePosition.ToPoint()))
            {
                CalculatedStyle innerDimensions = GetInnerDimensions();
                Offset = new Vector2(evt.MousePosition.X - innerDimensions.X - innerDimensions.Width - 12, evt.MousePosition.Y - innerDimensions.Y - innerDimensions.Height - 12);
                Resizing = true;
            }
            else if (Draggable)
            {
                Offset = new Vector2(evt.MousePosition.X - Left.Pixels, evt.MousePosition.Y - Top.Pixels);
                Dragging = true;
            }
        }

        // 可拖动/调整大小界面
        private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Dragging = false;
            Resizing = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if (Resizeable)
            {
                var dimensions = GetInnerDimensions();
                var position = dimensions.ToRectangle().BottomRight() - new Vector2(4f);
                var texture = ResizeIndicator.Value;

                spriteBatch.Draw(texture, position, BorderColor);

                if (ResizeRectangle.Contains(Main.MouseScreen.ToPoint()) || Resizing)
                {
                    Main.cursorOverride = CursorOverrideID.GamepadDefaultCursor;
                    Main.cursorColor = Color.SkyBlue;
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (IsMouseHovering)
            {
                Main.LocalPlayer.mouseInterface = true;
            }

            CalculatedStyle dimensions = GetOuterDimensions();

            if (Dragging)
            {
                Left.Set(Main.mouseX - Offset.X, 0f);
                Top.Set(Main.mouseY - Offset.Y, 0f);
                Recalculate();
                OnDrag?.Invoke(this);
            }
            if (Resizing)
            {
                Width.Pixels = Main.MouseScreen.X - dimensions.X - Offset.X;
                Height.Pixels = Main.MouseScreen.Y - dimensions.Y - Offset.Y;
                // 限制
                if (Width.Pixels <= _minResizeWidth)
                {
                    Width.Pixels = _minResizeWidth;
                }
                if (Height.Pixels <= _minResizeHeight)
                {
                    Height.Pixels = _minResizeHeight;
                }
                OnResize?.Invoke(this);
                Recalculate();
            }
        }
    }

}

