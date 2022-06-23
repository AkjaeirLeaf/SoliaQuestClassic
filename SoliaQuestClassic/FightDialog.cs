using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Kirali.MathR;

using SoliaQuestClassic.SoulForge;
using SoliaQuestClassic.SoulForge.Items;
using SoliaQuestClassic.SoulForge.Items.Unitemized;
using SoliaQuestClassic.SoulForge.Items.HealingItems;
using SoliaQuestClassic.SoulForge.Items.FoodItems;

namespace SoliaQuestClassic
{
    public partial class FightDialog : Form
    {
        public SQOpponentCreature enemyCreature;

        private bool playerWon = false;
        public bool PlayerWins { get { return playerWon; } }

        public FightDialog()
        {
            InitializeComponent();
            //enemyCreature = new SQOpponentCreature(new SoulForge.Species.Acyltri());
            enemyCreature = new SQOpponentCreature(); //trainer dummy
            enemyCreature.AddTag("tag_isActiveUser", false);
            MainWindow.player.AddEffect(new SoulForge.Effects.TrainingRoomEffect());
            //enemyCreature.TeachAbility(new SoulForge.Abilities.Opalium("X"));

            CreateLootInventory();
            UpdateTextGeneral();
        }

        public void CreateLootInventory()
        {
            enemyCreature.CreateCreatureMainInventory(8);
            /*
            int count0 = Kirali.Framework.Random.Int(2, 5);
            int count1 = Kirali.Framework.Random.Int(4, 12);
            enemyCreature.QuickGiveItem(new HealingPotion0(), count0);
            enemyCreature.QuickGiveItem(new Carrot(), count1);
            count0 = Kirali.Framework.Random.Int(2, 5);
            enemyCreature.QuickGiveItem(new BakedPotato(), count0);

            int rareitem0 = Kirali.Framework.Random.Int(0, 500);
            if (rareitem0 < 3)
            {
                count0 = Kirali.Framework.Random.Int(1, 5);
                enemyCreature.QuickGiveItem(new StatPointBox(count0), 1);
            }
            rareitem0 = Kirali.Framework.Random.Int(0, 500);
            if (rareitem0 < 30)
            {
                enemyCreature.QuickGiveItem(new RankUpgrade(), 1);
            }
            rareitem0 = Kirali.Framework.Random.Int(0, 500);
            if (rareitem0 < 25)
            {
                //enemyCreature.QuickGiveItem(new DefaultAbilityScript(new SoulForge.Abilities.Opalium("X"), 3), 1);
            }
            */
        }

        private void UpdateTextGeneral()
        {
            creatureStats.Text = MainWindow.player.DisplayAs() + "\n"
                + "Health: " + Math.Round(MainWindow.player.DynamicHealth, 2) + " / " + Math.Round(MainWindow.player.Health, 2) + "\n"
                + "Defense: " + Math.Round(MainWindow.player.DynamicDefense, 2) + " / " + Math.Round(MainWindow.player.Defense, 2) + "\n"
                + "Attack: " + Math.Round(MainWindow.player.DynamicAttack, 2) + " / " + Math.Round(MainWindow.player.Attack, 2) + "\n"
                + "Stamina: " + Math.Round(MainWindow.player.DynamicStamina, 2) + " / " + Math.Round(MainWindow.player.Stamina, 2) + "\n"
                + "Evade: " + Math.Round(MainWindow.player.DynamicEvade, 2) + " / " + Math.Round(MainWindow.player.Evade, 2) + "\n"
                + "Control: " + Math.Round(MainWindow.player.DynamicControl, 2) + " / " + Math.Round(MainWindow.player.Control, 2) + "\n\n"
                + "Level: " + MainWindow.player.Level + "  (" + MainWindow.player.Experience + "/" + SQCreature.GetRequiredExp(MainWindow.player.Level + 1);

            creatureEnemy.Text = enemyCreature.DisplayAs() + "\n"
                + "Health: " + Math.Round(enemyCreature.DynamicHealth, 2) + " / " + Math.Round(enemyCreature.Health, 2) + "\n"
                + "Defense: " + Math.Round(enemyCreature.DynamicDefense, 2) + " / " + Math.Round(enemyCreature.Defense, 2) + "\n"
                + "Attack: " + Math.Round(enemyCreature.DynamicAttack, 2) + " / " + Math.Round(enemyCreature.Attack, 2) + "\n"
                + "Stamina: " + Math.Round(enemyCreature.DynamicStamina, 2) + " / " + Math.Round(enemyCreature.Stamina, 2) + "\n"
                + "Evade: " + Math.Round(enemyCreature.DynamicEvade, 2) + " / " + Math.Round(enemyCreature.Evade, 2) + "\n"
                + "Control: " + Math.Round(enemyCreature.DynamicControl, 2) + " / " + Math.Round(enemyCreature.Control, 2) + "\n\n"
                + "Level: " + enemyCreature.Level + "  (" + enemyCreature.Experience + "/" + SQCreature.GetRequiredExp(enemyCreature.Level + 1);

            UpdateAbilitiesDisplay();
        }

        private string abilityLogDisplayString = "";

        private bool doPlayerAttacks(string abilityID)
        {
            bool ended = false;
            //clear log
            abilityLogDisplayString = "";

            //update effects on all creatures
            for (int u = 0; u < MainWindow.player.ActiveEffects.Length; u++)
            { MainWindow.player.ActiveEffects[u].EffectEvent_DoTick(MainWindow.player); }
            for (int u = 0; u < enemyCreature.ActiveEffects.Length; u++)
            { enemyCreature.ActiveEffects[u].EffectEvent_DoTick(enemyCreature); }

            //do ability use
            switch (creatureUseAbility(abilityID, MainWindow.player, enemyCreature))
            {
                case useAbilityEnum.used:
                    break;
                case useAbilityEnum.failedUnconcious:
                    doPlayerLost(); ended = true;
                    break;
                default:
                    break;
            }

            ended = doEnemyAttacks(ended);

            creatureAttackInfo.Text = abilityLogDisplayString;
            if (!ended)
            {
                if (MainWindow.player.State == SQCreatureState.Blackout) { doPlayerLost(); }
                if (enemyCreature.State == SQCreatureState.Blackout) { doPlayerWon(); }
            }
            UpdateTextGeneral();
            return ended;
        }

        private bool doEnemyAttacks(bool ended)
        {
            string enemyAbilityUse = "";
            int r = Kirali.Framework.Random.Int(0, 100);

            enemyAbilityUse = enemyCreature.GetAbilityUse(MainWindow.player);

            if (!ended)
            {
                switch (creatureUseAbility(enemyAbilityUse, enemyCreature, MainWindow.player))
                {
                    case useAbilityEnum.used:
                        return false;
                    case useAbilityEnum.failedUnconcious:
                        doPlayerWon();
                        return true;
                    default:
                        return false;
                }
            }
            else { return true; }
        }

        private useAbilityEnum creatureUseAbility(string internalID, SQCreature sender, SQCreature target)
        {
            SQCreatureState creatureStateSender = sender.State;
            bool targetDodged = false;

            if (creatureStateSender == SQCreatureState.Nominal) //TODO Work on this!
            {
                //Get the info about the attack, specific to the player's creature
                SQAbilityInfo abilityUsedInfo = sender.GetAbilityInfo(internalID, target);
                string doCreatureDisplay;
                string doTargetDisplay;
                if (!String.IsNullOrEmpty(sender.CreatureName)) { doCreatureDisplay = sender.CreatureName; }
                else { doCreatureDisplay = sender.CreatureSpecies.SpeciesName; }
                if (!String.IsNullOrEmpty(target.CreatureName)) { doTargetDisplay = target.CreatureName; }
                else { doTargetDisplay = target.CreatureSpecies.SpeciesName; }

                if (abilityUsedInfo.ErrorCode == SQAbilityError.noError)
                {
                    SQDamageInfo damageToSelf = sender.DoDamage(abilityUsedInfo, false);
                    SQHealInfo healingToSelf = sender.DoHeal(abilityUsedInfo, false);
                    SQDamageInfo damageToTarget = target.DoDamage(abilityUsedInfo, true);
                    SQHealInfo healingToTarget = target.DoHeal(abilityUsedInfo, true);

                    if (sender == target)
                    {
                        for (int u = 0; u < sender.ActiveEffects.Length; u++)
                        { sender.ActiveEffects[u].EffectEvent_DoAbilityUsedSelf(sender.GetAbility(internalID), sender); }
                    }
                    else
                    {
                        for (int u = 0; u < target.ActiveEffects.Length; u++)
                        { target.ActiveEffects[u].EffectEvent_DoAbilityUsedOn(sender.GetAbility(internalID), target, sender); }
                    }

                    for (int u = 0; u < sender.ActiveEffects.Length; u++)
                    {
                        sender.ActiveEffects[u].EffectEvent_PostUseAbility(sender.GetAbility(internalID), sender);
                    }

                    //grant experience to player for using ability:
                    sender.GiveExperience(abilityUsedInfo.experienceForUse);
                    if (!String.IsNullOrEmpty(abilityUsedInfo.flavorText))
                    {
                        abilityLogDisplayString += abilityUsedInfo.flavorText + ".\n";
                        
                    }
                    else
                    {
                        abilityLogDisplayString += doCreatureDisplay + " used " + abilityUsedInfo.abilityDisplay + ".\n";
                        
                    }
                    targetDodged = damageToTarget.evade;
                    if (targetDodged) { abilityLogDisplayString += doTargetDisplay + " dodged.\n"; }

                    return useAbilityEnum.used;
                }
                else
                {
                    abilityLogDisplayString += doCreatureDisplay + " attempted to use " + abilityUsedInfo.abilityDisplay + ", but was too tired.\n";
                    return useAbilityEnum.failedStamina;
                }
            }
            else if (creatureStateSender == SQCreatureState.Blackout)
            {
                abilityLogDisplayString += sender.CreatureName + " cannot act. They are unconcious.\n";
                return useAbilityEnum.failedUnconcious;
            }

            return useAbilityEnum.failedUnknown;
        }

        private void doPlayerLost()
        {
            MessageBox.Show("All your team has passed out! Oh NO!", "Battle Lost!");
            MainWindow.player.GiveExperience(25);
            playerWon = false;
            this.Close();
        }

        private void doPlayerWon()
        {
            MessageBox.Show("You have defeated " + enemyCreature.CreatureSpecies.SpeciesName + "!", "Your Team Won!");
            MainWindow.player.GiveExperience(enemyCreature.GetDefeatExperience());
            playerWon = true;
            this.Close();
        }

        private int SelectedAbilityIndex = 0;
        private int UpdateAbilitiesDisplay()
        {
            if (MainWindow.player.Abilities.Length > 0)
            {
                if (SelectedAbilityIndex >= 0 && SelectedAbilityIndex < MainWindow.player.Abilities.Length)
                {
                    string typeslist = "";
                    for (int t = 0; t < MainWindow.player.Abilities[SelectedAbilityIndex].AbilityType.Length; t++)
                    {
                        SQType type;
                        if (SQWorld.SQWorldTypeList.TryGetValue(MainWindow.player.Abilities[SelectedAbilityIndex].AbilityType[t], out type)) ;
                        {
                            typeslist += type.Title;
                            if (t != MainWindow.player.Abilities[SelectedAbilityIndex].AbilityType.Length - 1)
                            {
                                typeslist += ", ";
                            }
                        }
                    }

                    selectAbilityName.Text = MainWindow.player.Abilities[SelectedAbilityIndex].DisplayName;
                    selectAbilityTypes.Text = typeslist + "\n" +
                        MainWindow.player.Abilities[SelectedAbilityIndex].Description
                        + "\nDamage: " + MainWindow.player.Abilities[SelectedAbilityIndex].GetDealDamageTarget(MainWindow.player)
                        + "\nHealing: " + MainWindow.player.Abilities[SelectedAbilityIndex].GetHealValueSelf(MainWindow.player);


                    abilityTypeImg0.Image = null;
                    abilityTypeImg1.Image = null;
                    abilityTypeImg2.Image = null;

                    //type images
                    for (int t = 0; t < MainWindow.player.Abilities[SelectedAbilityIndex].AbilityType.Length; t++)
                    {
                        SQType type;
                        if (SQWorld.SQWorldTypeList.TryGetValue(MainWindow.player.Abilities[SelectedAbilityIndex].AbilityType[t], out type))
                        {
                            Bitmap bmpI = type.Image();
                            if (bmpI != null)
                            {
                                switch (t)
                                {
                                    case 0:
                                        abilityTypeImg0.Image = bmpI;
                                        break;
                                    case 1:
                                        abilityTypeImg1.Image = bmpI;
                                        break;
                                    case 2:
                                        abilityTypeImg2.Image = bmpI;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }

                    int displace = selectAbilityName.Size.Width;
                    int buff = 4;
                    int x = 24;
                    int y = 10;
                    abilityTypeImg0.Location = new Point(buff + displace, y);
                    abilityTypeImg1.Location = new Point(buff + displace + x, y);
                    abilityTypeImg2.Location = new Point(buff + displace + x + x, y);
                    return 1;

                }
            }

            selectAbilityName.Text = "";
            selectAbilityTypes.Text = "";

            return 0;
        }

        private void selectAbilityLast_Click(object sender, EventArgs e)
        {
            if (SelectedAbilityIndex == 0)
            {
                SelectedAbilityIndex = MainWindow.player.Abilities.Length - 1;
            }
            else { SelectedAbilityIndex--; }
            UpdateAbilitiesDisplay();
        }
        private void selectAbilityNext_Click(object sender, EventArgs e)
        {
            if (SelectedAbilityIndex == MainWindow.player.Abilities.Length - 1)
            {
                SelectedAbilityIndex = 0;
            }
            else { SelectedAbilityIndex++; }
            UpdateAbilitiesDisplay();
        }
        
        private void useSelectedAbility_Click(object sender, EventArgs e)
        {
            if (MainWindow.player.State == SQCreatureState.Blackout)
            {
                playerWon = false;
                doPlayerLost();
            }
            else if (MainWindow.player.DynamicStamina == 0)
            {
                playerWon = false;
                doPlayerLost();
            }
            else
            {
                doPlayerAttacks(MainWindow.player.Abilities[SelectedAbilityIndex].InternalName);
                if(enemyCreature.State != SQCreatureState.Blackout)
                {
                    doEnemyAttacks(false);
                }
                else
                {
                    playerWon = true;
                    doPlayerWon();
                }
                if(MainWindow.player.State == SQCreatureState.Blackout) { playerWon = false; doPlayerLost(); }
            }
            UpdateTextGeneral();
        }
    }

    public enum useAbilityEnum
    {
        failedUnconcious = -2,
        failedStamina = -1,
        failedUnknown = 0,
        used = 1
    }
}
