using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoliaQuestClassic.SoulForge
{
    public partial class StatDetailsWindow : Form
    {
        private int statPointsAvailable = 0;
        private int statPointsTotal = 0;
        private int maxSizeBar;
        private int maxHbar;

        private SQCreature modifyCreature;
        private SQCreatureStat m_selectedStat;

        public StatDetailsWindow(SQCreatureStat statSelected, SQCreature modifyTarget)
        {
            InitializeComponent();
            Color baseBarColor = Color.Black;
            switch (statSelected)
            {
                case SQCreatureStat.Health:
                    baseBarColor = Color.OrangeRed;
                    statUpgradeLabel.Text += ": Health";
                    break;
                case SQCreatureStat.Defense:
                    baseBarColor = Color.Orange;
                    statUpgradeLabel.Text += ": Defense";
                    break;
                case SQCreatureStat.Attack:
                    baseBarColor = Color.Yellow;
                    statUpgradeLabel.Text += ": Attack";
                    break;
                case SQCreatureStat.Stamina:
                    baseBarColor = Color.YellowGreen;
                    statUpgradeLabel.Text += ": Stamina";
                    break;
                case SQCreatureStat.Evade:
                    baseBarColor = Color.LightSkyBlue;
                    statUpgradeLabel.Text += ": Evade";
                    break;
                case SQCreatureStat.Control:
                    baseBarColor = Color.Violet;
                    statUpgradeLabel.Text += ": Control";
                    break;
                default:

                    break;
            }

            m_selectedStat = statSelected;

            unimpressiveFillBar.BackColor  = baseBarColor;
            ordinaryFillBar.BackColor      = baseBarColor;
            extraordinaryFillBar.BackColor = baseBarColor;
            deadlyFillBar.BackColor        = baseBarColor;
            arcaneFillBar.BackColor        = baseBarColor;
            mythicalFillBar.BackColor      = baseBarColor;
            celestialFillBar.BackColor     = baseBarColor;

            modifyCreature = modifyTarget;
            statPointsTotal = modifyTarget.StatPointsTotal;
            statPointsAvailable = modifyTarget.StatPointsAvailable;

            maxSizeBar = unimpressiveBGpanel.Width;
            maxHbar = unimpressiveBGpanel.Height;

            UpdateFormMeters();
        }

        private int UpdateFormMeters()
        {
            StatPointsInfoLabel.Text = "Stat Points: " + statPointsAvailable + " of " + statPointsTotal;

            double min;
            double max;
            double sizeFactor;

            min = modifyCreature.StatCalcMinMax(new StatMods.Unimpressive(), m_selectedStat, false);
            max = modifyCreature.StatCalcMinMax(new StatMods.Unimpressive(), m_selectedStat, true);
            sizeFactor = (modifyCreature.GetStatValue(m_selectedStat) - min) / (max - min);
            if (sizeFactor < 0) { sizeFactor = 0; } else if (sizeFactor > 1) { sizeFactor = 1; }
            unimpressiveFillBar.Size = new Size((int)(maxSizeBar * sizeFactor), maxHbar);

            min = modifyCreature.StatCalcMinMax(new StatMods.Ordinary(), m_selectedStat, false);
            max = modifyCreature.StatCalcMinMax(new StatMods.Ordinary(), m_selectedStat, true);
            sizeFactor = (modifyCreature.GetStatValue(m_selectedStat) - min) / (max - min);
            if (sizeFactor < 0) { sizeFactor = 0; } else if (sizeFactor > 1) { sizeFactor = 1; }
            ordinaryFillBar.Size = new Size((int)(maxSizeBar * sizeFactor), maxHbar);

            min = modifyCreature.StatCalcMinMax(new StatMods.Extraordinary(), m_selectedStat, false);
            max = modifyCreature.StatCalcMinMax(new StatMods.Extraordinary(), m_selectedStat, true);
            sizeFactor = (modifyCreature.GetStatValue(m_selectedStat) - min) / (max - min);
            if (sizeFactor < 0) { sizeFactor = 0; } else if (sizeFactor > 1) { sizeFactor = 1; }
            extraordinaryFillBar.Size = new Size((int)(maxSizeBar * sizeFactor), maxHbar);

            min = modifyCreature.StatCalcMinMax(new StatMods.Deadly(), m_selectedStat, false);
            max = modifyCreature.StatCalcMinMax(new StatMods.Deadly(), m_selectedStat, true);
            sizeFactor = (modifyCreature.GetStatValue(m_selectedStat) - min) / (max - min);
            if (sizeFactor < 0) { sizeFactor = 0; } else if (sizeFactor > 1) { sizeFactor = 1; }
            deadlyFillBar.Size = new Size((int)(maxSizeBar * sizeFactor), maxHbar);

            min = modifyCreature.StatCalcMinMax(new StatMods.Arcane(), m_selectedStat, false);
            max = modifyCreature.StatCalcMinMax(new StatMods.Arcane(), m_selectedStat, true);
            sizeFactor = (modifyCreature.GetStatValue(m_selectedStat) - min) / (max - min);
            if (sizeFactor < 0) { sizeFactor = 0; } else if (sizeFactor > 1) { sizeFactor = 1; }
            arcaneFillBar.Size = new Size((int)(maxSizeBar * sizeFactor), maxHbar);

            min = modifyCreature.StatCalcMinMax(new StatMods.Mythical(), m_selectedStat, false);
            max = modifyCreature.StatCalcMinMax(new StatMods.Mythical(), m_selectedStat, true);
            sizeFactor = (modifyCreature.GetStatValue(m_selectedStat) - min) / (max - min);
            if (sizeFactor < 0) { sizeFactor = 0; } else if (sizeFactor > 1) { sizeFactor = 1; }
            mythicalFillBar.Size = new Size((int)(maxSizeBar * sizeFactor), maxHbar);

            min = modifyCreature.StatCalcMinMax(new StatMods.Celestial(), m_selectedStat, false);
            max = modifyCreature.StatCalcMinMax(new StatMods.Celestial(), m_selectedStat, true);
            sizeFactor = (modifyCreature.GetStatValue(m_selectedStat) - min) / (max - min);
            if (sizeFactor < 0) { sizeFactor = 0; } else if (sizeFactor > 1) { sizeFactor = 1; }
            celestialFillBar.Size = new Size((int)(maxSizeBar * sizeFactor), maxHbar);

            if (statPointsAvailable > 0) { upgradeStatButton.Enabled = true; }
            else { upgradeStatButton.Enabled = false; }
            return 1;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void upgradeStatButton_Click(object sender, EventArgs e)
        {
            modifyCreature.TryUpgradeStat(m_selectedStat);
            statPointsTotal = modifyCreature.StatPointsTotal;
            statPointsAvailable = modifyCreature.StatPointsAvailable;
            UpdateFormMeters();
        }
    }
}
