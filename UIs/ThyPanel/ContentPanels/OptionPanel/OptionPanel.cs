using NHAssist.UIs.UIBases;
using NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Buff;
using NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Biome;
using NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.World;
using NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Config;

namespace NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel
{
    public class OptionPanel : ScrollContent
    {
        public const string TagKey = "OptionPanel";
        public const string BuffTagkey = "BuffCategory";
        public const string BiomeTagKey = "BiomeCategory";
        public const string WorldTagkey = "WorldCategory";
        public const string ConfigTagkey = "ConfigCategory";
        public CategoryUI BuffCategory { get; private set; }
        public CategoryUI BiomeCategory { get; private set; }
        public CategoryUI WorldCategory { get; private set; }
        public CategoryUI ConfigCategory { get; private set; }
        public OptionPanel()
        {
            BuffCategory = new CategoryUI();
            BiomeCategory = new CategoryUI();
            WorldCategory = new CategoryUI();
            ConfigCategory = new CategoryUI();
        }
        public override void OnInitialize()
        {
            //base.OnInitialize();
            BuffCategory.Left = BiomeCategory.Left = WorldCategory.Left = ConfigCategory.Left = new StyleDimension(0, 0);
            BuffCategory.Width = BiomeCategory.Width = WorldCategory.Width = ConfigCategory.Width = Width;
            Append(BuffCategory);
            Append(BiomeCategory);
            Append(WorldCategory);
            Append(ConfigCategory);
            BuffCategory.RegisterOptions(BuffOptionUI.GetBuffOptionUIList());
            BiomeCategory.RegisterOptions(BiomeOptionUI.GetBiomeOptionUIList());
            WorldCategory.RegisterOptions(WorldOptionUI.GetWorldOptionUIList());
            ConfigCategory.RegisterOptions(ConfigOptionUI.GetConfigOptionUIList());
            Rearrange();
            base.OnInitialize();
        }
        public void UpdateAvailability()
        {
            ThyPanel thyPanel = ThyUISystem.Panel;
            if(thyPanel != null)
            {
                BuffCategory.UpdateAvailability(thyPanel);
                BiomeCategory.UpdateAvailability(thyPanel);
                WorldCategory.UpdateAvailability(thyPanel);
                ConfigCategory.UpdateAvailability(thyPanel);
            }
        }
        public override void Rearrange()
        { // Has category instead of icon in BossPanel, so call rearrangeoption of each category
            BuffCategory.Width = BiomeCategory.Width = WorldCategory.Width = ConfigCategory.Width = Width;
            BuffCategory.RearrangeOptions();
            BiomeCategory.RearrangeOptions();
            WorldCategory.RearrangeOptions();
            ConfigCategory.RearrangeOptions();
            float buffHeight = BuffCategory.Height.Pixels;
            float biomeHeight = BiomeCategory.Height.Pixels;
            float worldHeight = WorldCategory.Height.Pixels;
            float configHeight = ConfigCategory.Height.Pixels;
            BuffCategory.Top.Set(0, 0);
            BiomeCategory.Top.Set(buffHeight + UIDims.CategorySep, 0);
            WorldCategory.Top.Set(buffHeight + biomeHeight + 2 * UIDims.CategorySep, 0);
            ConfigCategory.Top.Set(buffHeight + biomeHeight + worldHeight + 3 * UIDims.CategorySep, 0);
            Height.Set(buffHeight + biomeHeight + worldHeight + configHeight + 3 * UIDims.CategorySep, 0);
            base.Rearrange();
        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            DrawBaseLine(spriteBatch, BuffCategory.GetDimensions());
            DrawBaseLine(spriteBatch, BiomeCategory.GetDimensions());
            DrawBaseLine(spriteBatch, WorldCategory.GetDimensions());
            base.DrawSelf(spriteBatch);
        }
        private void DrawBaseLine(SpriteBatch spriteBatch, CalculatedStyle dimension)
        {
            int XShrink = UIDims.OptionSep;
            dimension.X += XShrink;
            dimension.Y += dimension.Height;
            dimension.Width -= 2 * XShrink;
            dimension.Height = UIDims.CategorySep;
            Rectangle rect = dimension.ToRectangle();
            spriteBatch.Draw(TextureAssets.MagicPixel.Value, rect, Color.Black);
        }
        public void LoadData(TagCompound tag)
        {
            if (tag.TryGet(BuffTagkey, out TagCompound t1))
                if (t1.Count > 0)
                    BuffCategory.LoadData(t1);
            if (tag.TryGet(BiomeTagKey, out TagCompound t2))
                if(t2.Count > 0)
                    BiomeCategory.LoadData(t2);
            if (tag.TryGet(WorldTagkey, out TagCompound t3))
                if (t3.Count > 0)
                    WorldCategory.LoadData(t3);
            if (tag.TryGet(ConfigTagkey, out TagCompound t4))
                if (t4.Count > 0)
                    ConfigCategory.LoadData(t4);
        }
        public TagCompound SaveData()
        {
            TagCompound tag = new TagCompound();
            tag.Add(BuffTagkey, BuffCategory.SaveData());
            tag.Add(BiomeTagKey, BiomeCategory.SaveData());
            tag.Add(WorldTagkey, WorldCategory.SaveData());
            tag.Add(ConfigTagkey, ConfigCategory.SaveData());
            return tag;
        }
    }
}
