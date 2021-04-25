using System;
using FlaxEngine;
using System.Collections.Generic;

namespace INIParser
{
    /// <summary>
    /// Represents the contents of a single INIFile
    /// </summary>
    [HideInEditor]
    public class INIFile : List<INISection>
    {
        /// <summary>
        /// Initial values of an INI file, values that are not specified in a section at the start of a file.
        /// </summary>
        public INISection GlobalSection { get; } = new INISection("%Global%");

        /// <summary>
        /// Retrieves the section under a given name.
        /// </summary>
        /// <param name="name">The section to retrieve.</param>
        /// <returns>The first occurence of that section.</returns>
        public INISection GetSection(string name) => this.Find(x => x.Name == name);
    }
}
