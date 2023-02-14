namespace NHAssist.Edits
{
    public class EditSystem : ModSystem
    {
        public override void OnModLoad()
        {
            EditLoader.Load();
            base.OnModLoad();
        }
        public override void Unload()
        {
            EditLoader.UnLoad();
            base.Unload();
        }
    }
}

