//using NHAssist.DataStruct;
//using CalamityMod.CalPlayer;
//using Terraria.GameInput;
//using System.Collections.Generic;

//namespace NHAssist.Edits.Calamity
//{
//    [JITWhenModsEnabled("CalamityMod")]
//    public class LevelMeterEdit : GlobalItem
//    {
//        private static readonly int[] ExactLevelToLevel = new int[16]
//        {
//            0, 100, 300, 600, 1000, 1500, 2100, 2800, 3600, 4500, 5500, 6600, 7800, 9100, 10500, 12500,
//        };

//        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
//        {
//            if (NHAssist.Calamity == null)
//                return false;
//            return CalamityConstants.LevelMeterTypes.Contains(entity.type);
//        }
//        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
//        {
//            if (Main.dedServ)
//                return;
//            TooltipLine line = tooltips.Find((TooltipLine x) => x.Mod == "Terraria" && x.Name == "Tooltip0");
//            if(line != null)
//                tooltips.Add(new TooltipLine(Mod, "LevelMeterTip", NHAssist.GetLocalText("Edits.LevelMeter.ItemTip")) { OverrideColor = new Color(150, 150, 255) });
//            base.ModifyTooltips(item, tooltips);
//        }
//        public override bool CanRightClick(Item item) => true;
//        public override bool ConsumeItem(Item item, Player player) => false;
//        public override void RightClick(Item item, Player player)
//        {
//            CalamityPlayer calPlayer = Main.LocalPlayer.GetModPlayer<CalamityPlayer>();
//            if (item.type == CalamityConstants.LevelMeterTypes[0])
//            { // melee
//                int targetLevel = (calPlayer.exactMeleeLevel + 1) % 16;
//                SetLevel(0, targetLevel, calPlayer);
//            }
//            else if (item.type == CalamityConstants.LevelMeterTypes[1])
//            { // range
//                int targetLevel = (calPlayer.exactRangedLevel + 1) % 16;
//                SetLevel(1, targetLevel, calPlayer);
//            }
//            else if (item.type == CalamityConstants.LevelMeterTypes[2])
//            { // magic
//                int targetLevel = (calPlayer.exactMagicLevel + 1) % 16;
//                SetLevel(2, targetLevel, calPlayer);
//            }
//            else if (item.type == CalamityConstants.LevelMeterTypes[3])
//            { // summon
//                int targetLevel = (calPlayer.exactSummonLevel + 1) % 16;
//                SetLevel(3, targetLevel, calPlayer);
//            }
//            else if (item.type == CalamityConstants.LevelMeterTypes[4])
//            { // rogue
//                int targetLevel = (calPlayer.exactRogueLevel + 1) % 16;
//                SetLevel(4, targetLevel, calPlayer);
//            }
//            base.RightClick(item, player);
//        }
//        private void SetLevel(int type, int targetExactLevel, CalamityPlayer calPlayer)
//        {
//            if (targetExactLevel < 0 || targetExactLevel > 15)
//                return;
//            int targetLevel = ExactLevelToLevel[targetExactLevel];
//            switch (type)
//            {
//                case 0:
//                    calPlayer.meleeLevel = targetLevel;
//                    if (targetLevel == 0)
//                        calPlayer.exactMeleeLevel = 0;
//                    else
//                    {
//                        calPlayer.shootFireworksLevelUpMelee = true;
//                        CallGetExactLevelUp(calPlayer);
//                    }
//                    ++calPlayer.meleeLevel;
//                    break;
//                case 1:
//                    calPlayer.rangedLevel = targetLevel;
//                    if (targetLevel == 0)
//                        calPlayer.exactRangedLevel = 0;
//                    else
//                    {
//                        calPlayer.shootFireworksLevelUpRanged = true;
//                        CallGetExactLevelUp(calPlayer);
//                    }
//                    ++calPlayer.rangedLevel;
//                    break;
//                case 2:
//                    calPlayer.magicLevel = targetLevel;
//                    if (targetLevel == 0)
//                        calPlayer.exactMagicLevel = 0;
//                    else
//                    {
//                        calPlayer.shootFireworksLevelUpMagic = true;
//                        CallGetExactLevelUp(calPlayer);
//                    }
//                    ++calPlayer.magicLevel;
//                    break;
//                case 3:
//                    calPlayer.summonLevel = targetLevel;
//                    if (targetLevel == 0)
//                        calPlayer.exactSummonLevel = 0;
//                    else
//                    {
//                        calPlayer.shootFireworksLevelUpSummon = true;
//                        CallGetExactLevelUp(calPlayer);
//                    }
//                    ++calPlayer.summonLevel;
//                    break;
//                case 4:
//                    calPlayer.rogueLevel = targetLevel;
//                    if (targetLevel == 0)
//                        calPlayer.exactRogueLevel = 0;
//                    else
//                    {
//                        calPlayer.shootFireworksLevelUpRogue = true;
//                        CallGetExactLevelUp(calPlayer);
//                    }
//                    ++calPlayer.rogueLevel;
//                    break;
//                default:
//                    break;
//            }
//        }
//        private void CallGetExactLevelUp(CalamityPlayer calPlayer)
//        {
//            int gainLevelCooldown = calPlayer.gainLevelCooldown;
//            calPlayer.GetExactLevelUp();
//            calPlayer.gainLevelCooldown = gainLevelCooldown;
//        }
//    }
//}

