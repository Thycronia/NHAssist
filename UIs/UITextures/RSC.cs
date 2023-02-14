using System.Reflection;
namespace NHAssist.UIs.UITextures
{
    public static partial class RSC
    {
        public static Asset<Texture2D> PlaceHolder;
        public static void Load()
        {
            Biome.Load();
            World.Load();
            Config.Load();
            Base.Load();
            if(NHAssist.Calamity != null)
            {
                CalBiome.Load();
                CalWorld.Load();
                CalConfig.Load();
                CalBase.Load();
            }
            PlaceHolder = World.BossBack;
        }
        public static void Unload()
        {
            if(NHAssist.Calamity != null)
            {
                UnLoadType(typeof(CalBiome));
                UnLoadType(typeof(CalWorld));
                UnLoadType(typeof(CalConfig));
                UnLoadType(typeof(CalBase));
            }
            UnLoadType(typeof(Biome));
            UnLoadType(typeof(World));
            UnLoadType(typeof(Config));
            UnLoadType(typeof(Base));
            PlaceHolder = null;
        }
        internal static Asset<Texture2D> GetTexture(string path)
        {
            return ModContent.Request<Texture2D>(NHAssist.Instance.Name + "/UIs/UITextures/" + path);
        }
        internal static void UnLoadType(Type type)
        {
            FieldInfo[] fields = type.GetFields(BindingFlags.Static | BindingFlags.Public);
            foreach (FieldInfo field in fields)
            {
                if(field.IsStatic)
                    if (field.GetValue(null) is Asset<Texture2D>)
                        field.SetValue(null, null);
            }
        }
    }
}
