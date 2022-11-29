using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.IO
{
    public struct XMLStructure
    {
        public string StructureTag;
        public string[] Parameters;
        public bool IsOpenClose; // Open Close: <meow cat="12"></meow> Not open close: <meow cat="12"/>
        public bool IsContainer; // Container has no contents, only children.

        public XMLStructure[] Children;
        public object Contents;
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
