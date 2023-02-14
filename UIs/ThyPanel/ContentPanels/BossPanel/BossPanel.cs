using NHAssist.UIs.UIBases;
namespace NHAssist.UIs.ThyPanel.ContentPanels.BossPanel
{
    public class BossPanel : ScrollContent
    {
        private List<UIElement> BossIcons;
        public BossPanel()
        {
            BossIcons = new List<UIElement>();
        }
        public override void OnInitialize()
        {
            BossIcons = BossIcon.GetBossIconList();
            Rearrange();
            foreach (UIElement boss in BossIcons)
                Append(boss);
            base.OnInitialize();
        }
        public override void Rearrange()
        {
            int numPerRow = UIDims.MaxOptionsPerRow(Width.Pixels);
            for (int i = 0; i < BossIcons.Count; i++)
            {
                UIElement option = BossIcons[i];
                int row = i / numPerRow + 1;
                int col = i % numPerRow + 1;
                option.Top.Set(row * UIDims.OptionSep + (row - 1) * UIDims.OptionSize, 0);
                option.Left.Set(col * UIDims.OptionSep + (col - 1) * UIDims.OptionSize, 0);
            }
            int numRow = BossIcons.Count > 0 ? (BossIcons.Count - 1) / numPerRow + 1 : 0;
            Height.Set(numRow * UIDims.OptionSize + (numRow + 1) * UIDims.OptionSep, 0);
            base.Rearrange();
        }
    }
}
