using static NHAssist.UIs.ThyPanel.UIDims;
namespace NHAssist.UIs.ThyPanel
{
    public class ThyPanelState : UIState
    {
        public ThyPanel ThyPanel;
        public override void OnInitialize()
        {
            ThyPanel = new ThyPanel();
            ThyPanel.Top.Set(100, 0);
            ThyPanel.Left.Set(100, 0);
            ThyPanel.Width.Set(PanelMinWidth, 0f);
            ThyPanel.Height.Set(PanelMinHeight, 0f);
            Append(ThyPanel);
            base.OnInitialize();
        }
    }
}
