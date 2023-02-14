using System.Reflection;
using NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel;
using NHAssist.UIs.ThyPanel.ContentPanels.DataStruct;
namespace NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.World
{
    public class BossWorldOptionUI : WorldOptionUI
    {
        public Boss Boss { get; private set; }
        public BossWorldOptionUI(Boss boss, FieldInfo fieldInfo, Asset<Texture2D> backTex = null) : base(null, fieldInfo, boss.UniqueIdentifier, backTex)
        {
            Boss = boss;
        }
        public BossWorldOptionUI(Boss boss, RefMethod<bool, bool> GetRef, Asset<Texture2D> backTex = null) : base(null, GetRef, boss.UniqueIdentifier,backTex)
        {
            Boss = boss;
        }
        public override string HoverText =>
            NHAssist.GetLocalText($"Option.World.Boss.{(isOn ? "Downed" : "NotDowned")}")
            + Boss.DisplayName;
        public override void Update(GameTime gameTime)
        {
            if (UITexture == null)
                UITexture = Boss.TryGetHeadTexture();
            base.Update(gameTime);
        }
        public override void UpdateAvailability(ThyPanel thyPanel)
        {
            if (thyPanel.NHBoss == null)
            {
                isAvailable = true;
                return;
            }
            isAvailable = Boss.Stage - thyPanel.NHBoss.Stage < - FloatStages.Epsilon;
        }
    }
}
