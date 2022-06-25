using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Kirali.Framework;

namespace SoliaQuestClassic.SoulForge
{
    public partial class SQCreatureTeam
    {
        protected SQCreature[] members = new SQCreature[0];
        public SQCreature[] Members { get { return members; } }

        protected string teamIdentID = "";
        public string TeamID { get { return teamIdentID; } }

        protected string displayName = "";
        public string DisplayName { get { return displayName; } }

        public bool GetMember(out SQCreature creature, string identifier = "")
        {
            if(members.Length > 0)
            {
                if(!String.IsNullOrEmpty(identifier))
                {
                    for(int i = 0; i < members.Length; i++)
                    {
                        if(members[i].GetUniqueID() == identifier)
                        {
                            creature = members[i];
                            return true;
                        }
                    }
                    //creature not found return false
                    creature = null; return false;
                }
                else
                {
                    if(members.Length == 1)
                    { creature = members[0]; return true; }
                    else { creature = null; return false; }
                }
            } 
            else { creature = null; return false; }
        }

        public bool MemberInTeam(string identifier)
        {
            if(members.Length > 0)
            {
                for(int i = 0; i < members.Length; i++)
                {
                    if(members[i].GetUniqueID() == identifier)
                    {
                        return true;
                    }
                }
                //creature not found return false
                return false;
            }
            else { return false; }
        }


        //Creature teams will be used as the container for characters related by team, or a single character.
        public SQCreatureTeam(string display, string identifier)
        {
            displayName = display;
            teamIdentID = identifier;
            
        }

        public int AddMember(SQCreature creature)
        {
            //some situ's
            //-1 - error, unknown cause
            // 0 - member added no error
            // 1 - member not added duplicate
            //
            if(members.Length == 0)
            {
                members = new SQCreature[] { creature };
                return 0;
            }
            else
            {
                if(!MemberInTeam(creature.GetUniqueID()))
                {
                    members = ArrayHandler.append(members, creature);
                    return 0;
                }
                else { return 1; }
            }
            return -1;
        }

        public int RemoveMember(string identifier)
        {
            //some situ's
            //-1 - error, unknown cause
            // 0 - member removed no error
            // 1 - member not removed, not found
            //
            if(members.Length <= 0)
            {
                return 1;
            }
            else if(!MemberInTeam(identifier))
            {
                return 1;
            }
            else if(members.Length == 1)
            {
                members = new SQCreature[0];
                return 0;
            }
            else
            {
                SQCreature[] NewMembers = new SQCreature[members.Length - 1];
                bool found = false;
                for(int m = 0; m < members.Length; m++)
                {
                    if(members[m].GetUniqueID() == identifier)
                    {
                        found = true;
                    }
                    if(found)
                    {
                        NewMembers[m - 1] = members[m];
                    }
                    else
                    {
                        NewMembers[m] = members[m];
                    }
                }
                members = NewMembers;
                return 0;
            }
        }
        

    }
}