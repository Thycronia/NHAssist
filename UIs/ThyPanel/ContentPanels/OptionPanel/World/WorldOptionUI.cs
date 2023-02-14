//using NHAssist.UIs.ThyPanel.ContentPanels.DataStruct;
using System.Reflection;
namespace NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.World
{
    public partial class WorldOptionUI : OptionUI
    {
        //public override string Tagkey => HoverTextKey;
        private RefMethod<bool, bool> GetControlRef;
        private FieldInfo TargetFieldInfo;
        private Asset<Texture2D> BackTexture;
        private string HoverTextKey;
        private bool needReflection => TargetFieldInfo != null && GetControlRef == null;
        public override string HoverText => NHAssist.GetLocalText("Option.World."+HoverTextKey);
        public WorldOptionUI(Asset<Texture2D> tex, RefMethod<bool, bool> getControlRef, string hoverTextKey, Asset<Texture2D> backTex = null) : base(tex)
        {
            GetControlRef = getControlRef;
            TargetFieldInfo = null;
            BackTexture = backTex;
            HoverTextKey = hoverTextKey;
            ToggleOn = (Player _) => Value(true);
            ToggleOff = (Player _) => Value(false);
        }
        public WorldOptionUI(Asset<Texture2D> tex, FieldInfo targetFieldInfo, string hoverTextKey, Asset<Texture2D> backTex = null) : base(tex)
        {
            if (!targetFieldInfo.IsStatic || targetFieldInfo.FieldType != typeof(bool))
                throw new ArgumentException("Target field must be a static bool");
            GetControlRef = null;
            TargetFieldInfo = targetFieldInfo;
            BackTexture = backTex;
            HoverTextKey = hoverTextKey;
            ToggleOn = (Player _) => ReflectValue(true);
            ToggleOff = (Player _) => ReflectValue(false);
        }
        private bool Value(bool? setTo = null)
        {
            ref bool controlRef = ref GetControlRef();
            if (setTo.HasValue)
                controlRef = setTo.Value;
            return controlRef;
        }
        private bool ReflectValue(bool? setTo = null)
        {
            if (setTo.HasValue)
            {
                TargetFieldInfo.SetValue(null, setTo.Value);
                return setTo.Value;
            }
            return (bool)TargetFieldInfo.GetValue(null);
        }
        public override void Update(GameTime gameTime)
        {
            isOn = needReflection ? ReflectValue() : Value();
            base.Update(gameTime);
        }
        public override void DrawContent(SpriteBatch spriteBatch, Color color)
        {
            CalculatedStyle dimension = GetDimensions();
            if(BackTexture != null)
                spriteBatch.Draw(BackTexture.Value, dimension.ToRectangle(), color);
            if(UITexture?.Value != null)
            {
                Texture2D texture = UITexture.Value;
                float scale = BossSelectorButton.GetLargestScale(texture, dimension);
                if(scale > 0f)
                {
                    spriteBatch.Draw(texture, dimension.Center(), null, color,
                        0f, texture.Size() / 2f, scale, SpriteEffects.None, 0f);
                }
            }
        }
    }
}
