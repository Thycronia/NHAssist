using NHAssist.UIs.ThyPanel.ContentPanels.DataStruct;
namespace NHAssist.UIs.ThyPanel.ContentPanels.BossPanel
{
    public partial class BossIcon : UIElement
    {
        public static List<UIElement> GetBossIconList()
        {
            List<UIElement> result = new List<UIElement>();
            foreach (Boss boss in BossLib.Bosses)
            {
                result.Add(new BossIcon(boss));
            }
            return result;
        }
    }
}
