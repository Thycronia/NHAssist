using System.Reflection;
namespace NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Biome
{
    public delegate bool PlayerPropertyGetOrigin(Player player);
    public delegate bool PlayerPropertyGetDelegate(PlayerPropertyGetOrigin orig, Player player);
    //public delegate bool ModPlayerPropertyGetOrigin(ModPlayer modPlayer);
    //public delegate bool ModPlayerPropertyGetDelegate(ModPlayerPropertyGetOrigin orig, ModPlayer modPlayer);
    public delegate bool IsBiomeActiveOrigin(ModBiome self , Player player);
    public delegate bool IsBiomeActiveDelegate(IsBiomeActiveOrigin orig, ModBiome self, Player player);
    public enum InfoType
    {
        DirectControl, PlayerProperty, ModBiome,
    }
    public struct BiomeInfo
    {
        public InfoType Type { get; private set; }
        public int ID;
        public MethodInfo PropertyGetMethod;
        public RefMethod<bool, Player> GetControlBool;
        public ModBiome ModBiomeInstance;
        public Asset<Texture2D> UITexture;
        public string HoverTextKey;
        public BiomeInfo(int IDSlot, Asset<Texture2D> UITexture, MethodInfo PropertyGetMethod, string HoverTextKey)
        {
            if (IDSlot < 0) throw new ArgumentException("IDSlot should be non-negative");
            Type = InfoType.PlayerProperty;
            this.ID = IDSlot;
            this.UITexture = UITexture;
            this.HoverTextKey = HoverTextKey;
            this.PropertyGetMethod = PropertyGetMethod;
            this.ModBiomeInstance = null;
            GetControlBool = delegate (Player player)
            {
                BiomeOptionPlayer modPlayer = player.GetModPlayer<BiomeOptionPlayer>();
                return ref modPlayer.BiomeOverrides(IDSlot);
            };
        }
        public BiomeInfo(Asset<Texture2D> UITexture, RefMethod<bool, Player> GetControlRef, string HoverTextKey)
        {
            Type = InfoType.DirectControl;
            this.ID = -1;
            this.UITexture = UITexture;
            this.HoverTextKey = HoverTextKey;
            this.PropertyGetMethod = null;
            this.ModBiomeInstance = null;
            this.GetControlBool = GetControlRef;
        }
        public BiomeInfo(int IDSlot, Asset<Texture2D> UITexture, ModBiome biomeInstance, string HoverTextKey)
        {
            if (IDSlot < 0) throw new ArgumentException("IDSlot should be non-negative");
            Type = InfoType.ModBiome;
            this.ID = IDSlot;
            this.UITexture = UITexture;
            this.HoverTextKey = HoverTextKey;
            this.ModBiomeInstance = biomeInstance;
            this.PropertyGetMethod= null;
            GetControlBool = delegate (Player player)
            {
                BiomeOptionPlayer modPlayer = player.GetModPlayer<BiomeOptionPlayer>();
                return ref modPlayer.BiomeOverrides(IDSlot);
            };
        }
        public bool PropertyBelongsToModPlayer => PropertyGetMethod.DeclaringType.IsSubclassOf(typeof(ModPlayer));
    }
}
