using FlaxEngine;
using System.Collections.Generic;

namespace INIParser
{
    /// <summary>
    /// Defines a single INISection.
    /// </summary>
    [HideInEditor]
    public class INISection : List<IINIObject>
    {
        /// <summary>
        /// Initilizes a new instance of <see cref="INISection"/>
        /// </summary>
        public INISection() => Name = string.Empty;

        /// <summary>
        /// Initilizes a new instance of <see cref="INISection"/>
        /// </summary>
        /// <param name="name">The name of the section.</param>
        public INISection(string name) => Name = name;

        /// <summary>
        /// The Name of the section.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Searches and returns the given option.
        /// </summary>
        /// <param name="optionName">The option to retrieve.</param>
        /// <returns>The specified option that was meant to be retrieved.</returns>
        public INIOption GetOption(string optionName) => this.Find(x => x.Name == optionName) as INIOption;
    }
}
