using NHAssist.UIs.UIBases;
using NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel;
using NHAssist.UIs.ThyPanel.ContentPanels.BossPanel;
using NHAssist.UIs.ThyPanel.ContentPanels.DataStruct;
using static NHAssist.UIs.ThyPanel.UIDims;

namespace NHAssist.UIs.ThyPanel
{
    public class ThyPanel : ModUIPanel
    {
        public const string TagKey = "ThyPanel";

        private bool lastResizing;
        private UIScrollbar ScrollBar;
        private UIText BossText;
        private BossSelectorButton BossSelector;
        private NoHitButton NoHitButton;
        private ScrollableUI Content;
        public OptionPanel OptionPanel;
        private BossPanel BossPanel;
        public Boss NHBoss { get; private set; }
        public ThyPanel() : base(true, true, PanelMinWidth, PanelMinHeight)
        {
            BackgroundColor = Color.Orange * 0.5f;
        }
        public override void OnInitialize()
        {
            #region Scroll Bar
            ScrollBar = new UIScrollbar();
            ScrollBar.Top.Set(0, 0);
            ScrollBar.Left.Set(-20 + PaddingRight - 6, 1);
            ResetScrollBar();
            Append(ScrollBar);
            #endregion
            #region Boss Selector
            BossText = new UIText("Boss: ", 0.6f, true);
            BossText.Top.Set(10, 0); // x,0
            BossText.Left.Set(0, 0);
            BossText.Height = BossText.MinHeight;
            BossText.Width = BossText.MinWidth;
            Append(BossText);
            BossSelector = new BossSelectorButton(RSC.Base.NoBoss);
            BossSelector.Left.Set(BossText.Width.Pixels, 0);
            BossSelector.Top.Set(0, 0);
            BossSelector.Height.Set(BossText.Height.Pixels + 20, 0);
            BossSelector.MaxWidth.Set(BossText.Width.Pixels, 0);
            Append(BossSelector);
            NoHitButton = new NoHitButton(RSC.Base.NoHit);
            NoHitButton.Top.Set(0, 0);
            NoHitButton.Height.Set(BossText.Height.Pixels + 20, 0);
            NoHitButton.Width = NoHitButton.Height;
            NoHitButton.Left.Set(-(26 + OptionSep - PaddingRight + NoHitButton.Width.Pixels), 1f);
            Append(NoHitButton);
            #endregion
            #region Query Button
            QueryButton QueryButton = new QueryButton(RSC.Base.QueryButton);
            QueryButton.Width = QueryButton.Height = NoHitButton.Width;
            QueryButton.Top = NoHitButton.Top;
            QueryButton.Left.Set(NoHitButton.Left.Pixels - QueryButton.Width.Pixels - 8, 1f);
            Append(QueryButton);
            #endregion
            #region Content Table
            Content = new ScrollableUI(ScrollBar);
            Content.Left.Set(0, 0);
            Content.Top.Set(BossSelector.Height.Pixels + PaddingTop - 4, 0); //-x
            FillContent();
            Append(Content);

            OptionPanel = new OptionPanel();
            OptionPanel.Left.Set(0, 0);
            OptionPanel.Top.Set(0, 0);
            OptionPanel.Width.Set(Content.Width.Pixels, 0);
            //OptionPanel.Height.Set(114.514f, 0);
            //Content.SetContent(OptionPanel);
            OptionPanel.Initialize();

            BossPanel = new BossPanel();
            BossPanel.Left.Set(0, 0);
            BossPanel.Top.Set(0, 0);
            BossPanel.Width.Set(Content.Width.Pixels, 0);
            //Content.SetContent(BossPanel);
            BossPanel.Activate();

            Content.SetContent(OptionPanel);
            //Also setup the other panel here (setcontent + activate)
            #endregion
            SetBoss(null);
            base.OnInitialize();
        }
        public override void Recalculate()
        {
            base.Recalculate();
            if (Resizing)
            {
                if (ScrollBar != null)
                    ResetScrollBar();
                if (Content != null)
                    FillContent();
            }
        }
        public override void MouseOver(UIMouseEvent evt)
        {
            if(evt.Target == this)
                Main.LocalPlayer.mouseInterface = true;
            base.MouseOver(evt);
        }
        public override void Update(GameTime gameTime)
        {
            if (!Resizing && lastResizing)
                Recalculate();
            lastResizing = Resizing;
            base.Update(gameTime);
        }
        public ScrollContent SwitchContentPanel()
        {
            if(Content.Content is OptionPanel)
            {
                Content.SetContent(BossPanel);
                return BossPanel;
            }
            if(Content.Content is BossPanel)
            {
                Content.SetContent(OptionPanel);
                return OptionPanel;
            }
            return null;
        }
        public void SetContentPanel(bool optionPanel)
        {
            if((optionPanel && Content.Content is BossPanel) ||
                (!optionPanel && Content.Content is OptionPanel))
                SwitchContentPanel();
        }
        public bool isOptionPanel => Content.Content is OptionPanel;
        public void SetBoss(Boss boss)
        { //Need to set boss selector button, change Boss property, and update availability
            NHBoss = boss;
            if(boss == null)
                BossSelector.SetImage(RSC.Base.NoBoss);
            else
                BossSelector.SetImage(boss.TryGetHeadTexture() ?? RSC.Base.NoBoss);
            OptionPanel.UpdateAvailability();
        }
        private void ResetScrollBar()
        {
            CalculatedStyle innerRect = GetInnerDimensions();
            float totalHeight = innerRect.Height;
            ScrollBar.Height.Set(totalHeight - 12, 0);
            //ScrollBar.SetView(totalHeight, 800);
        }
        private void FillContent()
        {
            CalculatedStyle innerDim = GetInnerDimensions();
            Content.Height.Set(innerDim.Height - Content.Top.Pixels, 0);
            float width = innerDim.Width - (26 + OptionSep - PaddingRight);
            Content.Width.Set(width, 0);
            width -= BossText.Width.Pixels;
            width = Math.Clamp(width, 0, BossSelector.MaxWidth.Pixels);
            BossSelector.Width.Set(width, 0);
            Content.RearrangeContent();
        }

        /// <returns>A tag compound containing all infomation of the panel. Its key would be <see cref="ThyPanel.TagKey"/></returns>
        public TagCompound SaveData()
        {
            TagCompound tag = new TagCompound();
            tag.Add(OptionPanel.TagKey, OptionPanel.SaveData());
            tag.Add(BossSelectorButton.TagKey, BossSelector.SaveData());
            tag.Add(NoHitButton.TagKey, NoHitButton.SaveData());
            return tag;
        }
        /// <param name="tag">A tag containing all infomation of the panel. Its key is <see cref="ThyPanel.TagKey"/></param>
        public void LoadData(TagCompound tag)
        {
            if (tag.TryGet(OptionPanel.TagKey, out TagCompound t1))
                if(t1.Count > 0)
                    OptionPanel.LoadData(t1);
            if (tag.TryGet(BossSelectorButton.TagKey, out string t2))
                if (t2 != null)
                    BossSelector.LoadData(t2);
            if (tag.TryGet(NoHitButton.TagKey, out bool t3))
                NoHitButton.LoadData(t3);
        }
    }
}
