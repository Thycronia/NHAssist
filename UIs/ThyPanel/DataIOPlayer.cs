namespace NHAssist.UIs.ThyPanel
{
    public class DataIOPlayer : ModPlayer
    {
        private ThyPanel panel => ThyUISystem.Panel;
        private TagCompound tempTag;
        public DataIOPlayer()
        {
            tempTag = new TagCompound();
        }
        public override void LoadData(TagCompound tag)
        {
            tempTag = new TagCompound();
            if (tag.TryGet(ThyPanel.TagKey, out TagCompound temp))
                tempTag = temp;
            base.LoadData(tag);
        }
        public override void OnEnterWorld(Player player)
        {
            panel.LoadData(tempTag);
            if (ThyUISystem.ThyPanelKey.GetAssignedKeys().Count == 0)
                Main.NewText(NHAssist.GetLocalText("General.WorldEnterWarning"));
            base.OnEnterWorld(player);
        }
        public override void SaveData(TagCompound tag)
        {
            tag.Add(ThyPanel.TagKey, panel.SaveData());
            base.SaveData(tag);
        }
        public override void Unload()
        {
            tempTag = null;
            base.Unload();
        }
    }
}
