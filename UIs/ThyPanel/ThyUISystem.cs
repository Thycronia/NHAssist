using Terraria.GameInput;
namespace NHAssist.UIs.ThyPanel
{
    public class ThyUISystem : ModSystem
    {
        private GameTime lastUpdateUITime;
        private bool lastInventory;
        private static UserInterface ThyInterface;
        public static ThyPanelState ThyPanelState;
        public static bool UIVisible
        {
            get { return ThyInterface?.CurrentState != null; }
            set { if (value) ShowUI(); else HideUI(); }
        }
        public static ModKeybind ThyPanelKey { get; private set; }
        public static ThyPanel Panel => ThyPanelState.ThyPanel;
        public override void Load()
        {
            //ThyPanelKey = KeybindLoader.RegisterKeybind(Mod, NHAssist.GetLocalText("KeyBind.ThyPanelKey"), "OemOpenBrackets");
            ThyPanelKey = KeybindLoader.RegisterKeybind(Mod, "Toggle Control Panel", "OemOpenBrackets");
            base.Load();
        }
        public override void PostSetupContent()
        {
            if (!Main.dedServ)
            {
                ThyInterface = new UserInterface();
                ThyPanelState = new ThyPanelState();
                //Activate could potentially be moved to other places
                //to run Initialize() after texture loading
                ThyPanelState.Activate();
            }
            base.PostSetupContent();
        }
        public override void OnWorldLoad()
        {
            if (!Main.dedServ)
            {
                Panel.OptionPanel.BiomeCategory.LoadData(new TagCompound());
                HideUI();
            }
            base.OnWorldLoad();
        }
        public override void Unload()
        {
            ThyPanelState = null;
            ThyInterface = null;
            ThyPanelKey = null;
            base.Unload();
        }
        public static void ShowUI(bool toMouse = true)
        {
            ThyInterface?.SetState(ThyPanelState);
            if (toMouse && ThyPanelState!=null && Panel!=null)
            {
                PlayerInput.SetZoom_UI();
                Vector2 Size = Panel.GetDimensions().ToRectangle().Size();
                float maxTop = Main.screenHeight - Panel.Height.Pixels;
                float maxLeft = Main.screenWidth - Panel.Width.Pixels;
                Panel.Top.Set(Math.Clamp((Main.mouseY - Size.Y / 2f), 0, maxTop),0);
                Panel.Left.Set(Math.Clamp((Main.mouseX - Size.X / 2f), 0, maxLeft), 0);
                ThyInterface.Recalculate();
                PlayerInput.SetZoom_Context();
            }
        }
        public static void HideUI()
        {
            ThyInterface?.SetState(null);
        }
        public override void UpdateUI(GameTime gameTime)
        {
            lastUpdateUITime = gameTime;
            if (lastInventory && !Main.playerInventory)
                UIVisible = false;
            lastInventory = Main.playerInventory;
            if (ThyPanelKey.JustPressed)
                UIVisible = !UIVisible;
            if (ThyInterface?.CurrentState != null)
            {
                ThyInterface.Update(gameTime);
            }
            base.UpdateUI(gameTime);
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "NHAssist: ThyInterface",
                    delegate
                    {
                        if (lastUpdateUITime != null && ThyInterface?.CurrentState != null)
                        {
                            //if (UserInterface.ActiveInstance == null) ;
                            UserInterface.ActiveInstance = ThyInterface;
                            ThyInterface.Draw(Main.spriteBatch, lastUpdateUITime);
                            //if (UserInterface.ActiveInstance == null) ;
                        }
                        return true;
                    },
                       InterfaceScaleType.UI));
            }
        }
    }
}
