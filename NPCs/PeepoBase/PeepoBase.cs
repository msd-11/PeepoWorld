using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using static Terraria.ModLoader.ModContent;


namespace FirstMod.NPCs
{
    public class Bob : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bob");
            Main.npcFrameCount[NPC.type] = 26;
            NPCID.Sets.AttackFrameCount[NPC.type] = 5;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 1;
            NPCID.Sets.AttackTime[NPC.type] = 45;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = -6;
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 50;
            NPC.lifeMax = 1000;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Steampunker;
        }

        public override List SetNPCNameList()
        {
            return new List() { "Matthias", "Richard" };
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (NPC.CountNPCS(NPCType()) >= 1)
            {
                return 0;
            }
            return SpawnCondition.OverworldDay.Chance * 1.0f;
        }

        public override string GetChat()
        {
            string[] chat = {
                "Hello there, reader!",
                "Have you come to purchase some wares?",
                "I've heard rumors of an amazing blog post on www.onlineblogzone.com"
            };
            return Main.rand.Next(chat);
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Shop";
            button2 = "Quote";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
            else
            {
                Main.npcChatText = "Always remember that you are absolutely unique. Just like everyone else. -Margaret Mead";
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(ItemID.PlatinumCoin);
            shop.item[nextSlot].shopCustomPrice = 100000;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.LaserRifle);
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.MagicMirror);
            nextSlot++;
        }
    }
}
