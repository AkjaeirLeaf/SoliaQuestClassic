using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kirali;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class Brush : SQAbility
    {
        public Brush()
        {
            ModifyAbilityReference("Brush", "brush");
            addTypeOf("spirit", 1.0);
            description = "A basic spirit attack with a chance to apply a random stat reduction to your opponent.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.ENERGY;
            abilityPurpose = SQAbilityPurpose.DAMAGE_ONLY;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 18.0;
            m_doBaseDamageSelf   =  0.0;
            m_doBaseHealTarget   =  0.0;
            m_doBaseHealSelf     =  4.0;

            //id like to add another bonus tho

            //how possible is evading this attack?
            m_dodgeCompdChance = 0.03;
            m_controlMod       = 0.80;

            //stamina usage
            m_doBaseStaminaCost = 6.0;

            //I will use the base ability damage info here :)
        }

        public override string GetFlavorText(SQCreature sender)
        {
            string ident = sender.CreatureName;
            if (String.IsNullOrEmpty(ident)) { ident = sender.CreatureSpecies.SpeciesName; }
            int response = Kirali.Framework.Random.Int(0, 100);
            if(response < 5)
            {
                return ident + " appears behind their opponent, gotcha!";
            }
            else
            {
                return ident + " swiftly dashes towards their opponent.";
            }
        }

        public override void OnAbilityUsedOn(SQCreature target)
        {
            int doStatReduct = Kirali.Framework.Random.Int(0,20);
            if(doStatReduct > 13)
            {
                //reduces a random stat:
                //0.88*defense
                //0.86*attack
                //0.82*evade
                //0.91*control
                double newV = 0;
                int r = Kirali.Framework.Random.Int(0, 100);
                if(r < 25)
                {
                    newV = target.DynamicDefense * 0.88;
                    target.DoModifyDefense(newV);
                }
                else if(r < 50)
                {
                    newV = target.DynamicAttack * 0.86;
                    target.DoModifyAttack(newV);
                }
                else if(r < 75)
                {
                    newV = target.DynamicEvade * 0.82;
                    target.DoModifyEvade(newV);
                }
                else
                {
                    newV = target.DynamicControl * 0.91;
                    target.DoModifyControl(newV);
                }
            }
            
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new Brush());
            return 1;
        }
    }
}
