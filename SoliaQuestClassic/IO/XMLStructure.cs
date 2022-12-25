using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.IO
{
    public class XMLStructure
    {
        public string StructureTag;
        public string AddressString;
        public int[] AddressInt = new int[0];
        public string[] ParameterCalls = new string[0];
        public object[] ParameterValues = new object[0];
        public bool IsOpenClose; // Open Close: <meow cat="12"></meow> Not open close: <meow cat="12"/>
        public bool IsContainer; // Container has no contents, only children.

        public XMLStructure[] Children = new XMLStructure[0];
        public object Contents = new object[0];



        public int AddChild(XMLStructure structure)
        {
            int slot = 0;
            structure.AddressString = AddressString + "." + structure.StructureTag;
            structure.AddressInt = new int[AddressInt.Length + 1];
            structure.AddressInt[AddressInt.Length] = Children.Length; slot = Children.Length;
            for(int ix = 0; ix < AddressInt.Length; ix++) { structure.AddressInt[ix] = AddressInt[ix]; }
            if (Children.Length == 0) { Children = new XMLStructure[] { structure }; }
            else
            {
                XMLStructure[] temp = new XMLStructure[Children.Length + 1];
                for (int ix = 0; ix < Children.Length; ix++)
                {
                    temp[ix] = Children[ix];
                }
                temp[Children.Length] = structure;
                Children = temp;
            }
            
            return slot;
        }
        public bool GetParameter(string paramSearch, out object result)
        {
            for(int ix = 0; ix < ParameterCalls.Length; ix++)
            {
                if (ParameterCalls[ix] == paramSearch)
                {
                    result = ParameterValues[ix];
                    return true;
                }
            }
            result = null;
            return false;
        }
    }

    public enum XMLStructureContentType
    {
        UNKNOWN,
        STRING,
        INTEGER,
        DATETIME,
        ARRAY_UNKNOWN,
        ARRAY_STRING,
        ARRAY_INTEGER,
        ARRAY_DATETIME
    }
}
