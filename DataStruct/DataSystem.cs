namespace NHAssist.DataStruct
{
    public class DataSystem : ModSystem
    {
        public override void OnModLoad()
        {
            if(NHAssist.Calamity != null)
            {
                CalamityConstants.Load();
            }
            base.OnModLoad();
        }
        public override void Unload()
        {
            if(NHAssist.Calamity != null)
            {
                CalamityConstants.UnLoad();
            }
            base.Unload();
        }
    }
}

