using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;
using System.Text;
using System.IO;

namespace SoliaQuestClassic.IO
{
    public class XMLFile
    {
        public string version  = "1.0";
        public string encoding = "utf-8";

        public XMLStructure[] Contents = new XMLStructure[0];

        protected XMLFile() { }

        public static XMLFile FromResource(string resourcePath)
        {
            //  OPENING INFO
            //  <?xml version="1.0" encoding="utf-8"?>
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
            using (StreamReader reader = new StreamReader(stream))
            {
                string data = reader.ReadToEnd();
                XMLFile xml = new XMLFile();
                string remaining = data;
                string line;

                // first read info / version and encoding
                ReadBtwnCarrots(remaining, true, out line, out remaining);
                if (IsInfoLine(line))
                {
                    object v; TryGetHeaderParameter(line, "version", out v);
                    object e; TryGetHeaderParameter(line, "encoding", out e);
                    xml.version = (string)v; xml.encoding = (string)e;
                }



                //Run through all the remaining structures
                bool isStructureOpen = false;
                XMLStructure CurrentStructure = new XMLStructure();

                bool lineErrorBreak = false;

                while (ReadBtwnCarrots(remaining, true, out line, out remaining, true) && !lineErrorBreak)
                {
                    // get next line


                    // is line start, end, or info?
                    if (IsInfoLine(line))
                    {
                        //idk man whatever to do here yet
                    }
                    else
                    {
                        string ident;
                        string[] parameters;
                        string[] parameterValues;
                        XML_LineType lineType = GetLineTypeInfo(line, out ident, out parameters, out parameterValues);

                        switch (lineType)
                        {
                            case XML_LineType.OPEN_TAG:
                                // create new structure...
                                XMLStructure newStructure = new XMLStructure();
                                newStructure.StructureTag = ident;
                                newStructure.ParameterCalls = parameters;
                                newStructure.ParameterValues = new object[parameterValues.Length];
                                if (parameterValues.Length > 0)
                                    for (int ix = 0; ix < parameterValues.Length; ix++) { newStructure.ParameterValues[ix] = parameterValues[ix]; }
                                newStructure.IsOpenClose = true;
                                if (isStructureOpen)
                                {
                                    // Add structure to currently open structure, open new structure.
                                    CurrentStructure.IsContainer = true;
                                    int place = CurrentStructure.AddChild(newStructure);
                                    CurrentStructure = CurrentStructure.Children[place];
                                    isStructureOpen = true;
                                }
                                else
                                {
                                    // Add structure to the xml and open
                                    newStructure.AddressString = newStructure.StructureTag;
                                    int slot = xml.AddStructure(newStructure);
                                    CurrentStructure = xml.Contents[slot];
                                    isStructureOpen = true;
                                }
                                // Get content of the section, if any exists.
                                string content_ofNew = ReadUntil(RemoveLeadingSpace(remaining), '<');
                                CurrentStructure.Contents = content_ofNew;

                                break;
                            case XML_LineType.CLOSE_TAG:
                                // no params here :)
                                // need to bring back structure to parent!!!
                                if (CurrentStructure.AddressInt.Length > 1)
                                {
                                    xml.GetStructure(ShortenToParent(CurrentStructure.AddressInt), out CurrentStructure);
                                }
                                else
                                {
                                    //probably the end of file?
                                    isStructureOpen = false;
                                }


                                break;
                            case XML_LineType.SINGLE:
                                // create new structure...
                                XMLStructure newSingle = new XMLStructure();
                                newSingle.StructureTag = ident;
                                newSingle.ParameterCalls = parameters;
                                newSingle.ParameterValues = new object[parameterValues.Length];
                                if (parameterValues.Length > 0)
                                    for (int ix = 0; ix < parameterValues.Length; ix++) { newSingle.ParameterValues[ix] = parameterValues[ix]; }
                                newSingle.IsOpenClose = false;
                                // isContainer??
                                // Children??
                                if (isStructureOpen)
                                {
                                    // Add structure to currently open structure, open new structure.
                                    newSingle.AddressString = CurrentStructure.AddressString + "." + newSingle.StructureTag;
                                    int place = CurrentStructure.AddChild(newSingle);
                                    isStructureOpen = true;
                                }
                                else
                                {
                                    // Add structure to the xml
                                    newSingle.AddressString = newSingle.StructureTag;
                                    int slot = xml.AddStructure(newSingle);
                                    isStructureOpen = true;
                                }

                                break;
                            case XML_LineType.ERROR:
                                lineErrorBreak = true;
                                break;
                        }
                    }
                }

                return xml;
            }


            //file parse failed.
            return new XMLFile();
        }
        public static XMLFile FromFile(string filepath)
        {
            //  OPENING INFO
            //  <?xml version="1.0" encoding="utf-8"?>

            if (File.Exists(filepath))
            {
                string data = File.ReadAllText(filepath);
                XMLFile xml = new XMLFile();
                string remaining = data;
                string line;

                // first read info / version and encoding
                ReadBtwnCarrots(remaining, true, out line, out remaining);
                if (IsInfoLine(line))
                {
                    object v; TryGetHeaderParameter(line, "version", out v);
                    object e; TryGetHeaderParameter(line, "encoding", out e);
                    xml.version = (string)v; xml.encoding = (string)e;
                }


                
                //Run through all the remaining structures
                bool isStructureOpen = false;
                XMLStructure CurrentStructure = new XMLStructure();

                bool lineErrorBreak = false;

                while(ReadBtwnCarrots(remaining, true, out line, out remaining, true) && !lineErrorBreak)
                {
                    // get next line


                    // is line start, end, or info?
                    if (IsInfoLine(line))
                    {
                        //idk man whatever to do here yet
                    }
                    else
                    {
                        string ident;
                        string[] parameters;
                        string[] parameterValues;
                        XML_LineType lineType = GetLineTypeInfo(line, out ident, out parameters, out parameterValues);

                        switch (lineType)
                        {
                            case XML_LineType.OPEN_TAG:
                                // create new structure...
                                XMLStructure newStructure = new XMLStructure();
                                newStructure.StructureTag = ident;
                                newStructure.ParameterCalls = parameters;
                                newStructure.ParameterValues = new object[parameterValues.Length];
                                if (parameterValues.Length > 0)
                                    for (int ix = 0; ix < parameterValues.Length; ix++) { newStructure.ParameterValues[ix] = parameterValues[ix]; }
                                newStructure.IsOpenClose = true;
                                if (isStructureOpen)
                                {
                                    // Add structure to currently open structure, open new structure.
                                    CurrentStructure.IsContainer = true;
                                    int place = CurrentStructure.AddChild(newStructure);
                                    CurrentStructure = CurrentStructure.Children[place];
                                    isStructureOpen = true;
                                }
                                else
                                {
                                    // Add structure to the xml and open
                                    newStructure.AddressString = newStructure.StructureTag;
                                    int slot = xml.AddStructure(newStructure);
                                    CurrentStructure = xml.Contents[slot];
                                    isStructureOpen = true;
                                }
                                // Get content of the section, if any exists.
                                string content_ofNew = ReadUntil(RemoveLeadingSpace(remaining), '<');
                                CurrentStructure.Contents = content_ofNew;

                                break;
                            case XML_LineType.CLOSE_TAG:
                                // no params here :)
                                // need to bring back structure to parent!!!
                                if (CurrentStructure.AddressInt.Length > 1)
                                {
                                    xml.GetStructure(ShortenToParent(CurrentStructure.AddressInt), out CurrentStructure);
                                }
                                else
                                {
                                    //probably the end of file?
                                    isStructureOpen = false;
                                }
                                

                                break;
                            case XML_LineType.SINGLE:
                                // create new structure...
                                XMLStructure newSingle = new XMLStructure();
                                newSingle.StructureTag = ident;
                                newSingle.ParameterCalls = parameters;
                                newSingle.ParameterValues = new object[parameterValues.Length];
                                if (parameterValues.Length > 0)
                                    for (int ix = 0; ix < parameterValues.Length; ix++) { newSingle.ParameterValues[ix] = parameterValues[ix]; }
                                newSingle.IsOpenClose = false;
                                // isContainer??
                                // Children??
                                if (isStructureOpen)
                                {
                                    // Add structure to currently open structure, open new structure.
                                    newSingle.AddressString = CurrentStructure.AddressString + "." + newSingle.StructureTag;
                                    int place = CurrentStructure.AddChild(newSingle);
                                    isStructureOpen = true;
                                }
                                else
                                {
                                    // Add structure to the xml
                                    newSingle.AddressString = newSingle.StructureTag;
                                    int slot = xml.AddStructure(newSingle);
                                    isStructureOpen = true;
                                }

                                break;
                            case XML_LineType.ERROR:
                                lineErrorBreak = true;
                                break;
                        }
                    }
                }

                return xml;

            }

            //file parse failed.
            return new XMLFile();
        }

        /// <summary>
        /// <tooltip>Returns a match (hopefully) for the address entered within the XML file</tooltip>
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public bool Search(string tag, out XMLStructure result, int skip = 0)
        {
            //
            XMLStructure loop = new XMLStructure(); bool begin = false;
            string[] broken = tag.Split('.');
            if (!String.IsNullOrEmpty(tag))
            {
                for (int ix= 0; ix< Contents.Length; ix++)
                {
                    if(broken[0] == Contents[ix].StructureTag) { loop = Contents[ix]; begin = true; }
                }
                if (begin)
                {
                    if(broken.Length == 1) { result = loop; return true; } // found in xml content
                    else
                    {
                        for (int ix = 1; ix < broken.Length; ix++)
                        {
                            bool found = false;
                            for(int children = 0; children < loop.Children.Length; children++)
                            {
                                if (broken[ix] == loop.Children[children].StructureTag)
                                {
                                    loop = loop.Children[children];
                                    found = true; break; // implement skip counts later :/
                                }
                            }
                            if(!found) { result = loop; return false; }
                        }
                        result = loop;
                        return true;
                    }
                }
                else { result = loop; return false; }
            }
            else
            {
                result = loop;
                return false;
            }
            result = loop;
            return false;
        }



        protected int AddStructure(XMLStructure structure)
        {
            structure.AddressInt = new int[] { Contents.Length };
            if (Contents.Length == 0) { Contents = new XMLStructure[] { structure }; return 0; }
            else
            {
                XMLStructure[] temp = new XMLStructure[Contents.Length + 1];
                for(int ix = 0; ix < Contents.Length; ix++)
                {
                    temp[ix] = Contents[ix];
                }
                temp[Contents.Length] = structure;
                Contents = temp; return Contents.Length - 1;
            }
        }
        private static string RemoveLeadingSpace(string line)
        {
            char[] charArray = line.ToCharArray();
            int removeCount = 0;
            for(int ix = 0; ix<charArray.Length; ix++)
            {
                // count spaces until char not match
                if(IsEqualAny(charArray[ix], new char[] 
                { ' ', '\n', '\t', '\r' }
                )) { removeCount++; } else { break; }
            }
            if(removeCount > 0) { return line.Remove(0, removeCount); } else { return line; }
        }
        private static string ReadUntil(string line, char stop)
        {
            string build = "";
            char[] array = line.ToCharArray();
            if(line.Length == 0) { return ""; }
            else
            {
                for(int ix = 0; ix < array.Length; ix++)
                {
                    if (array[ix] == stop) { break; }
                    else { build += array[ix]; }
                }
                return build;
            }
        }
        public bool GetStructure(int[] address, out XMLStructure structure)
        {
            XMLStructure loop = new XMLStructure();
            for (int ix = 0; ix < Contents.Length; ix++)
            {
                if (Contents[ix].AddressInt[0] == address[0])
                {
                    if (address.Length == 0) { structure = Contents[ix]; return true; }
                    else { loop = Contents[ix]; }
                }
            }
            for (int ix = 1; ix < address.Length; ix++)
            {
                if(address[ix] < 0 || address[ix] >= loop.Children.Length) { structure = loop; return false; } //outside bounds
                else
                {
                    // in bounds, continue search
                    loop = loop.Children[address[ix]];
                    if(ix == address.Length - 1) { structure = loop; return true; }
                }
            }
            structure = loop;
            return false;
        }
        private static int[] ShortenToParent(int[] address)
        {
            int[] parentPath = new int[address.Length - 1];
            for(int ix=0; ix < parentPath.Length; ix++)
            {
                parentPath[ix] = address[ix];
            }
            return parentPath;
        }
        public XMLStructure GetStructure(string address)
        {
            string[] broken = address.Split('.');
            XMLStructure loop;
            for(int lev = 0; lev < Contents.Length; lev++)
            {
                if(broken[0] == Contents[lev].StructureTag)
                {
                    loop = Contents[lev];
                    if (broken.Length == 1) { return loop; }
                }
            }
            
            for (int ix = 0; ix < broken.Length; ix++)
            {

            }
            return null;
        }
        private static bool ReadBtwnCarrots(string contents, bool includeCarrots, out string line, out string remainder, bool cutPreceeding = false)
        {
            if (!String.IsNullOrEmpty(contents))
            {
                char[] charArray = contents.ToCharArray();

                string stack = "";
                bool isReading = false;
                int begin = 0; int end = 0;
                
                for(int ix = 0; ix < charArray.Length; ix++)
                {
                    if (charArray[ix] == '<')
                    {
                        isReading = true;
                        begin = ix;
                    }
                    if(charArray[ix] == '<' || charArray[ix] == '>' && isReading && includeCarrots)
                    {
                        stack += charArray[ix];
                    }
                    else if(isReading && !(charArray[ix] == '<' || charArray[ix] == '>'))
                    {
                        stack += charArray[ix];
                    }
                    if (charArray[ix] == '>' && isReading)
                    {
                        isReading = false;
                        end = ix;
                        break;
                    }
                }
                line = stack;
                line = line.Replace("\n", "");

                // cut to remainder
                if (!cutPreceeding) { remainder = contents.Remove(begin, 1 + end - begin); }
                else
                {
                    remainder = contents.Remove(0, 1 + end);
                }

                return true;
            }
            else { line = ""; remainder = ""; return false; }
        }
        private static bool TryGetHeaderParameter(string line, string parameter, out object value)
        {
            if (line.Contains(parameter))
            {
                char[] charArray = line.ToCharArray();
                char[] charParam = parameter.ToCharArray();
                string val_build = "";

                int posOfMatcher = 0;
                bool matches = false;
                bool foundParam = false;
                bool isReading = false;
                bool readComplete = false;

                for(int ix = 0; ix < charArray.Length; ix++)
                {
                    //first find the parameter location in the line:
                    //cycle through both line and parameter checking for a continuous match
                    if(posOfMatcher >= 0 && !foundParam)
                    {
                        if (posOfMatcher < charParam.Length)
                        {
                            if (charArray[ix] == charParam[posOfMatcher])
                            {
                                matches = true;
                                posOfMatcher++;
                            }
                        }
                        //reach end of param, if it doesnt match this then reset, otherwise declare the param found and wait for "
                        else if(posOfMatcher == charParam.Length && matches)
                        {
                            if (charArray[ix] == '=' || charArray[ix] == ' ')
                            {
                                //correct param, declare found!
                                foundParam = true;

                            } else { matches = false; posOfMatcher = 0; } //not correct param, reset please :)
                        }
                    }
                    else { matches = false; posOfMatcher = 0; }
                    if(foundParam && !isReading)
                    {
                        if(charArray[ix] == '\"') { isReading = true; }
                    }
                    if(isReading && charArray[ix] != '\"')
                    {
                        val_build += charArray[ix];
                    }
                    if(isReading && charArray[ix+1] == '\"')
                    {
                        readComplete = true;
                        break;
                    }
                }
                if (readComplete)
                    value = val_build;
                else
                {
                    value = null;
                    return false;
                }
                return true;
            }
            else
            {
                value = null;
                return false;
            }
        }
        private static bool IsInfoLine(string line, bool includeCarrots = true)
        {
            if (line.Contains('?'))
            {
                if (line.Contains("<?") && line.Contains("?>")) { return true; }
                else if (!includeCarrots && line.ToCharArray()[0] == '?' && line.ToCharArray()[line.Length - 1] == '?')
                {
                    return true; //probably right?
                }
                else return false;
            }
            else { return false; }
        }
        private static XML_LineType GetLineTypeInfo(string line, out string lineIdent, out string[] parameters, out string[] paramValues, bool includeCarrots = true)
        {
            char[] charArray = line.ToCharArray();
            XML_LineType lineType;
            try
            {
                if (includeCarrots || true)
                {
                    if (charArray[0] == '<' && charArray[1] != '/' && charArray[charArray.Length - 2] != '/' && charArray[charArray.Length - 1] == '>')
                    {
                        // This is an OPENING line
                        lineType = XML_LineType.OPEN_TAG;
                    }
                    else if (charArray[0] == '<' && charArray[1] == '/' && charArray[charArray.Length - 2] != '/' && charArray[charArray.Length - 1] == '>')
                    {
                        // This is a CLOSING line
                        lineType = XML_LineType.CLOSE_TAG;
                    }
                    else if (charArray[0] == '<' && charArray[1] != '/' && charArray[charArray.Length - 2] == '/' && charArray[charArray.Length - 1] == '>')
                    {
                        // This is a SINGLE line
                        lineType = XML_LineType.SINGLE;
                    }
                    else { lineType = XML_LineType.ERROR; }
                }
                else
                {
                    // copy later

                }

                // NOW we know the line type (hopefully)
                // now find the identifier!
                // <effect id="Cube_Material-effect">
                //  ^ here!
                // read after the '<' and break at the space

                ReadAfterUntil(charArray, new char[] { '<' }, new char[] { ' ', '>' }, out lineIdent, 0);

                // How many params???
                int paramCounter = 0;
                while (ReadAfterUntil(charArray, new char[] { ' ' }, new char[] { '=' }, out _, paramCounter))
                { paramCounter++; }

                if (paramCounter > 0)
                {
                    // Create param arrays...
                    parameters = new string[paramCounter];
                    paramValues = new string[paramCounter];

                    // reset counter, this time we read!
                    for (paramCounter = 0; paramCounter < parameters.Length; paramCounter++)
                    {
                        // read param identifier
                        ReadAfterUntil(charArray, new char[] { ' ' }, new char[] { '=' }, out parameters[paramCounter], paramCounter);

                        // read param data
                        ReadAfterUntil(charArray, '\"', '\"', out paramValues[paramCounter], paramCounter);
                    }
                }
                else
                {
                    parameters = new string[0];
                    paramValues = new string[0];
                }
            }
            catch
            {
                lineIdent = "";
                parameters = new string[0];
                paramValues = new string[0];
                lineType = XML_LineType.ERROR;
            }
            

            return lineType;
        }
        private static bool ReadAfterUntil(char[] line, char begin, char end, out string result, int encounter = 0)
        {
            // here I will not add in the start/end
            string build = "";
            bool isReading = false;
            bool doneReading = false;
            int en_counter = 0; // how many times to start/end seach before reading...
            bool in_Encounter = false;

            bool roundPerformAction = false;

            for (int ix = 0; ix < line.Length; ix++)
            {
                roundPerformAction = false; // rpa makes sure that we don't open a new encounter on the same character as we close one, without making an ioobe

                if ((in_Encounter || isReading) && !doneReading && line[ix] == end)
                {
                    // end reading or encounter.
                    if(encounter == en_counter)
                    {
                        isReading = false; in_Encounter = false; doneReading = true;
                        break;
                    }
                    else
                    {
                        en_counter++;
                    }
                    in_Encounter = false;
                    roundPerformAction = true;
                }
                if (isReading && !doneReading)
                {
                    // read.
                    build += line[ix];
                }
                if (!isReading && !doneReading && line[ix] == begin && !roundPerformAction)
                {
                    // start reading, or only increase en_counter.
                    if(encounter == en_counter)
                    {
                        isReading = true;
                    }
                    in_Encounter = true;
                    roundPerformAction = true;
                }
            }

            if (doneReading)
            {
                result = build;
                return true;
            }

            result = "";
            return false;
        }
        private static bool ReadAfterUntil(char[] line, char[] begin, char[] end, out string result, int encounter = 0)
        {
            // here I will not add in the start/end
            string build = "";
            bool isReading = false;
            bool doneReading = false;
            int en_counter = 0; // how many times to start/end seach before reading...
            bool in_Encounter = false;

            for (int ix = 0; ix < line.Length; ix++)
            {
                if ((in_Encounter || isReading) && !doneReading && IsEqualAny(line[ix], end))
                {
                    // end reading or encounter.
                    if (encounter == en_counter)
                    {
                        isReading = false; in_Encounter = false; doneReading = true;
                        break;
                    }
                    else
                    {
                        en_counter++;
                    }
                    in_Encounter = false;
                }
                if (isReading && !doneReading)
                {
                    // read.
                    build += line[ix];
                }
                if (!isReading && !doneReading && IsEqualAny(line[ix], begin))
                {
                    // start reading, or only increase en_counter.
                    if (encounter == en_counter)
                    {
                        isReading = true;
                    }
                    in_Encounter = true;
                }
            }

            if (doneReading)
            {
                result = build;
                return true;
            }

            result = "";
            return false;
        }
        private static bool IsEqualAny(char compare, char[] set)
        {
            for(int ix = 0; ix < set.Length; ix++)
            {
                if(set[ix] == compare) { return true; }
            }
            return false;
        }
    }

    public enum XML_LineType
    {
        OPEN_TAG,
        CLOSE_TAG,
        SINGLE,
        ERROR
    }
}
