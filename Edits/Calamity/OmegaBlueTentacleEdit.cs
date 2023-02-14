using CalamityMod.Projectiles.Typeless;
using MonoMod.RuntimeDetour.HookGen;
using System.Reflection;
using NHAssist.UIs.ThyPanel.ContentPanels.OptionPanel.Config.ConfigPlayers;
namespace NHAssist.Edits.Calamity
{
    [JITWhenModsEnabled("CalamityMod")]
    public class OmegaBlueTentacleEdit : MethodEdit
    {
        private static Asset<Texture2D> ProjTex;
        private static Asset<Texture2D> SegTex;
        private static bool loaded;
        public static void UnLoad()
        {
            if (!loaded)
                return;
            ProjTex = null;
            SegTex = null;
        }

        public override bool ShouldApply => NHAssist.Calamity != null && !Main.dedServ;

        public override void Apply()
        {
            loaded = true;
            MethodInfo MethodOrig = typeof(OmegaBlueTentacle).GetMethod("PreDraw", (BindingFlags)60);
            HookEndpointManager.Add(MethodOrig, PreDraw);
        }

        private bool PreDraw(PreDrawOrigin orig, ModProjectile self, ref Color color)
        {
            if (!Main.LocalPlayer.GetModPlayer<RagePlayer>().CalamityDrawing)
                return orig(self, ref color);
            if (ProjTex == null)
                ProjTex = ModContent.Request<Texture2D>(self.Texture);
            if (SegTex == null)
                SegTex = ModContent.Request<Texture2D>("CalamityMod/Projectiles/Typeless/OmegaBlueTentacleSegment");
            if (ProjTex == null || SegTex == null)
                return false;
            OmegaBlueTentacle tentacle = self as OmegaBlueTentacle;
            self.Projectile.rotation = (self.Projectile.Center - tentacle.segment[5]).ToRotation();
            Texture2D texture2D13 = ProjTex.Value;
            Texture2D segmentSprite = SegTex.Value;
            for (int i = 0; i < 6; i++)
            {
                Main.spriteBatch.Draw(segmentSprite, tentacle.segment[i] - Main.screenPosition + new Vector2(0f, self.Projectile.gfxOffY), segmentSprite.Bounds, self.Projectile.GetAlpha(color), 0f, segmentSprite.Bounds.Size() / 2f, self.Projectile.scale, SpriteEffects.None, 0f);
            }
            Main.spriteBatch.Draw(texture2D13, self.Projectile.Center - Main.screenPosition + new Vector2(0f, self.Projectile.gfxOffY), texture2D13.Bounds, self.Projectile.GetAlpha(color), self.Projectile.rotation, texture2D13.Bounds.Size() / 2f, self.Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }
}

