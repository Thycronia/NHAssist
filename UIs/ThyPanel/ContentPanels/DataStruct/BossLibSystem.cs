namespace NHAssist.UIs.ThyPanel.ContentPanels.DataStruct
{
    public class BossLibSystem : ModSystem
    {
        public override void SetupContent()
        {
            BossLib.LoadBosses();
            base.SetupContent();
        }
        public override void Unload()
        {
            BossLib.UnLoad();
            base.Unload();
        }
    }
}
