using NHAssist.UIs.UIBases;
namespace NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel
{
    public class CategoryUI : UIElement
    {
        protected List<OptionUI> GetOptions => Elements.FindAll(x => x is OptionUI).ConvertAll<OptionUI>(x => (OptionUI)x);
        protected List<OptionUI> Options;
        public CategoryUI()
        {
            Options = new List<OptionUI>();
        }
        public override void OnInitialize()
        {
            if(Parent != null)
                Width.Set(Parent.Width.Pixels, 0);
            //Height.Set(2 * UIDims.OptionSep, 0);
            base.OnInitialize();
        }
        public void DoUpdate()
        {
            foreach(OptionUI option in Options)
                option.DoUpdate?.Invoke(Main.LocalPlayer);
        }
        public void UpdateAvailability(ThyPanel thyPanel)
        {
            foreach (OptionUI optionUI in Options)
                optionUI.UpdateAvailability(thyPanel);
        }
        public void RegisterOptions(OptionUI option, bool needActivation = false)
        {
            RegisterOptions(new List<OptionUI> { option }, needActivation);
        }
        public void RegisterOptions(List<OptionUI> options, bool needActivation = false)
        {
            foreach(OptionUI option in options)
                Append(option);
            Options = GetOptions;
            RearrangeOptions();
        }
        public void RearrangeOptions()
        {
            int numPerRow = UIDims.MaxOptionsPerRow(Width.Pixels);
            for(int i = 0; i < Options.Count; i++)
            {
                OptionUI option = Options[i];
                int row = i / numPerRow + 1;
                int col = i % numPerRow + 1;
                option.Top.Set(row * UIDims.OptionSep + (row - 1) * UIDims.OptionSize, 0);
                option.Left.Set(col * UIDims.OptionSep + (col - 1) * UIDims.OptionSize, 0);
            }
            int numRow = Options.Count > 0 ? (Options.Count - 1) / numPerRow + 1 : 0;
            Height.Set(numRow * UIDims.OptionSize + (numRow + 1) * UIDims.OptionSep, 0);
        }
        public void LoadData(TagCompound tag)
        {
            foreach(OptionUI option in Options)
                option.LoadData(tag);
        }
        public TagCompound SaveData()
        {
            TagCompound tag = new TagCompound();
            foreach(OptionUI option in Options)
            {
                (string, bool)? KeyValuePair = option.SaveData();
                if (KeyValuePair.HasValue)
                    tag.Add(KeyValuePair.Value.Item1, KeyValuePair.Value.Item2);
            }
            return tag;
        }
    }
}
