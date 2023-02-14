global using System;
global using System.Collections.Generic;

global using Terraria.ModLoader;
global using Terraria;
global using Terraria.UI;
global using Terraria.GameContent.UI.Elements;
global using Terraria.GameContent;
global using Terraria.ID;
global using Terraria.ModLoader.IO;
global using ReLogic.Content;

global using Microsoft.Xna.Framework;
global using Microsoft.Xna.Framework.Graphics;

global using NHAssist.UIs.UITextures;

using Terraria.Localization;
using NHAssist.UIs.ThyPanel.ContentPanels.DataStruct;
using NHAssist.Configs;

namespace NHAssist
{
	public class NHAssist : Mod
	{
		public static NHAssist Instance;
        public static Mod Calamity;
        public override uint ExtraPlayerBuffSlots => GeneralConfigs.Instance.ExtraBuffSlots;
        public override void Load()
        {//6
            if (Main.netMode != NetmodeID.SinglePlayer)
                throw new Exception("NHAssist does not support multiplayer...yet");
            Instance = this;
            if(ModLoader.TryGetMod("CalamityMod", out Mod mod))
            {
                Calamity = mod;
            }
            RSC.Load();
            if(Calamity != null)
                BossLib.AddBossHeadSlots(Instance);
            base.Load();
        }
        public override void Unload()
        {
            RSC.Unload();
            Calamity = null;
            Instance = null;
            base.Unload();
        }
        public static string GetLocalText(string key)
        {
            return Language.GetTextValue($"Mods.{Instance?.Name}." + key);
        }
    }
}