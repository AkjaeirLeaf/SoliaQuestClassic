using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.ItemFamilies
{
    public class Unitemized : SQItemFamily
    {
        public Unitemized() : base(0, "unitemized")
        {
            //add images
            AddItemImage(0, "SoliaQuestClassic.Resources.Families.r000unitemized.00nothing.png");
            AddItemImage(1, "SoliaQuestClassic.Resources.Families.r000unitemized.01unknown.png");
            AddItemImage(2, "SoliaQuestClassic.Resources.Families.r000unitemized.02experience.png");
            AddItemImage(3, "SoliaQuestClassic.Resources.Families.r000unitemized.03skillpoint.png");
            AddItemImage(4, "SoliaQuestClassic.Resources.Families.r000unitemized.04statpointbox.png");
            AddItemImage(5, "SoliaQuestClassic.Resources.Families.r000unitemized.05statRankUp.png");

            AddItemImage(6, "SoliaQuestClassic.Resources.Families.r000unitemized.06learnAbility.png");
            AddItemImage(7, "SoliaQuestClassic.Resources.Families.r000unitemized.07learnAbility.png");
            AddItemImage(8, "SoliaQuestClassic.Resources.Families.r000unitemized.08airdisk.png");
            AddItemImage(9, "SoliaQuestClassic.Resources.Families.r000unitemized.09crystaldisk.png");
            AddItemImage(10, "SoliaQuestClassic.Resources.Families.r000unitemized.10darkdisk.png");

            //add items
            LinkItemTo(new Items.Nothing());
            LinkItemTo(new Items.Unitemized.StatPointBox(0));
            LinkItemTo(new Items.Unitemized.RankUpgrade());
            LinkItemTo(new Items.Unitemized.DefaultAbilityScript());

            LoadImages();
        }

        public static int Register()
        {
            SQWorld.Register(new Unitemized());
            return 0;
        }
    }
}
