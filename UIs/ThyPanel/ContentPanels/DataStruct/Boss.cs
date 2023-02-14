using NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel;
using System.Reflection;
namespace NHAssist.UIs.ThyPanel.ContentPanels.DataStruct
{
    public class Boss : IComparable<Boss>
    {
        public float Stage { get; internal set; }
        public NPC Instance { get; internal set; }
        public RefMethod<bool, bool> GetControlRef;
        public FieldInfo TargetFieldInfo;
        /// <summary>
        /// Attempt to get the boss head texture
        /// </summary>
        /// <returns>If not in a game, <c>null</c>; else, the correct texture</returns>
        public Asset<Texture2D> TryGetHeadTexture()
        {
            //if (Main.gameMenu)
            //    return null;
            //int ind = Instance.GetBossHeadTextureIndex();
            //return TextureAssets.NpcHeadBoss[ind];
            return Main.gameMenu ? null : TextureAssets.NpcHeadBoss[Instance.GetBossHeadTextureIndex()];
        }
        public int Type => Instance.type;
        public bool NeedReflection => GetControlRef == null && TargetFieldInfo != null;
        public Mod mod => Instance.ModNPC?.Mod;
        public string UniqueIdentifier { get
            {
                if (mod == null)
                    return $"Terraria:NPC_{Instance.type}";
                else
                    return $"{mod.Name}:{InternalName}";
            } }
        public string DisplayName => Instance.GivenOrTypeName;
        private string InternalName => Instance.ModNPC?.Name;
        public Boss(float stage, int type, RefMethod<bool, bool> getControlRef)
        {
            Stage = stage;
            NPC instance = new NPC();
            instance.SetDefaults(type);
            Instance = instance;
            GetControlRef = getControlRef;
            TargetFieldInfo = null;
        }
        public Boss(float stage, int type, FieldInfo targetField)
        {
            Stage = stage;
            NPC instance = new NPC();
            instance.SetDefaults(type);
            Instance = instance;
            GetControlRef = null;
            TargetFieldInfo = targetField;
        }
        public int CompareTo(Boss other)
        {
            if (Math.Abs(Stage - other.Stage) < FloatStages.Epsilon)
                return 0;
            return Stage > other.Stage ? 1 : -1;
        }
    }
}
