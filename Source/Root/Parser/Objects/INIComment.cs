using System;
using FlaxEngine;

namespace INIParser
{
    /// <summary>
    /// An INI Comment
    /// </summary>
    [HideInEditor]
    public class INIComment : IINIObject
    {
        /// <summary>
        /// Inits a new <see cref="INIComment"/>
        /// </summary>
        /// <param name="comment"></param>
        public INIComment(string comment) => Name = comment;

        /// <summary>
        /// Represents the comment value itself.
        /// </summary>
        public string Name { get; set; }

    }
}
