namespace NHAssist.UIs.ThyPanel
{
    public class QueryButton : UIImageButton
    {
        public QueryButton(Asset<Texture2D> tex) : base(tex)
        {
            SetVisibility(1f, 0.7f);
        }
        public override void Update(GameTime gameTime)
        {
            if (IsMouseHovering)
            {
                Main.instance.MouseText(NHAssist.GetLocalText("QueryButton.Tip"));
            }
            base.Update(gameTime);
        }
        public override void Click(UIMouseEvent evt)
        {
            if (evt.Target != this)
                return;
            string output = NHAssist.GetLocalText("QueryButton.Description");
            string[] outputs = output.Split('\n');
            foreach(string s in outputs)
                Main.NewText(s);
            base.Click(evt);
        }
    }
}

