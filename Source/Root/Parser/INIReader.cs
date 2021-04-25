using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FlaxEngine;

namespace INIParser
{
    /// <summary>
    /// 
    /// </summary>
    [HideInEditor]
    public class INIReader : StreamReader
    {
        /// <summary>
        /// Initilizes a new instance of <see cref="INIReader"/> with a given <see cref="Stream"/>
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to use for reading.</param>
        public INIReader(Stream stream) : base(stream) 
        {
        }

        /// <summary>
        /// Reads the file from the stream and returns the contents
        /// </summary>
        /// <returns>The contents of the INI File.</returns>
        public virtual INIFile ReadFile()
        {
            var file = new INIFile();
            INISection currentSection = file.GlobalSection;

            string line;
            while ((line = this.ReadLine()) != null)
            {
                line = line.Trim();

                // Comment // TODO: Include comments? For now skip.
                if (line.Length == 0 || line[0] == ';')
                    continue;

                // Section
                if (line[0] == '[')
                {
                    currentSection = new INISection(GetName(line, ']', 1));
                    file.Add(currentSection);
                    continue; // Next line
                }
                else // Assume KVP
                {
                    string name = this.GetName(line, '=', 0);
                    var option = new INIOption()
                    {
                        Name = name,
                        Value = line.Substring(name.Length + 1) // +1 to ignore '='
                    };

                    currentSection.Add(option);
                }
            }

            return file;
        }

        /// <summary>
        /// Returns the name of the given entity like returning 'SettingA' from 'SettingA=3' or [SettingA]
        /// </summary>
        /// <param name="line">The line itself.</param>
        /// <param name="endChar">Terminal charachter, at this point we should stop retrieving the name.</param>
        /// <param name="charOffset">The start offset to exclude characters at the front.</param>
        /// <returns></returns>
        protected virtual string GetName(string line, char endChar, int charOffset) => line.Substring(charOffset, line.IndexOf(endChar)).Trim(endChar);
    }
}
