using Terraria.ModLoader;
using Terraria;
using System.IO;
using Terraria.IO;
using System.Collections.Generic;

namespace NPCGodmode
{
    class ConfigToucher
    {


        static string ConfigPath = Path.Combine(Main.SavePath, "Mod Configs", "NPC Control" + ".json");
        static Preferences Configuration = new Preferences(ConfigPath);
        public static bool standardKillable = false;
        private Dictionary<int, bool> npcInvincible = new Dictionary<int, bool>();


        public Dictionary<int, bool> LoadConfig()
        {

            if (Configuration.Load())
            {
                Configuration.Get("StandardKillable", ref standardKillable);

                for (int i = 0; i < NPCLoader.NPCCount; i++)
                {
                    NPC npc = new NPC();
                    
                    npc.SetDefaults(i);
                    

                    if (npc.townNPC)
                    {
                        string a = npc.TypeName + "Killable";
                        a = a.Replace(" ", "_");
                        bool temp = false;
                        try
                        {
                            if (!Configuration.Contains(a))
                            {
                                string temp2 = "Killable";
                                string temp3 = npc.TypeName + temp2;
                                Configuration.Put(temp3, standardKillable);
                                Configuration.Save();
                            }
                            
                            Configuration.Get(a, ref temp);
                            npcInvincible[npc.netID] = temp;
                        }
                        catch
                        {
                            //CreateConfig();

                            string temp2 = "Killable";
                            string temp3 = npc.TypeName + temp2;
                            Configuration.Put(temp3, standardKillable);
                            Configuration.Save();

                            Configuration.Get(a, ref temp);
                            npcInvincible[npc.netID] = temp;
                        }
                    }
                }
            }
            else
            {
                CreateConfig();
                npcInvincible = LoadConfig();
            }


            return npcInvincible;
        }

        public void CheckConfig()
        {
            if (Configuration.Load())
            {

            }
            else
            {
                CreateConfig();
            }
        }

        static void CreateConfig()
        {
            Configuration.Clear();
            Configuration.Put("StandardKillable", standardKillable);


            //loop through Main.npc
            //if you just need if one is alive, use NPC.AnyNPCs(type)
            //Thx Direwolf420

            string alpha = "Killable";

            for (int i = 0; i < NPCLoader.NPCCount; i++)
            {
                NPC npc = new NPC();
                npc.SetDefaults(i);

                if (npc.townNPC)
                {
                    string beta = npc.TypeName + alpha;
                    beta = beta.Replace(" ", "_");
                    Configuration.Put(beta, standardKillable);
                }
            }
            /*
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                if (Main.npc[i].townNPC)
                {
                    string beta = Main.npc[i].TypeName + alpha;
                    Configuration.Put(beta, standardKillable);
                }

                
            }
            */
            Configuration.Save();
            
        }

    }
}
