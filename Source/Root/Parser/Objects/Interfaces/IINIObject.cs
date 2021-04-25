using FlaxEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INIParser
{
    /// <summary>
    /// Base INI Object
    /// </summary>
    public interface IINIObject
    {
        /// <summary>
        /// Name of the object, can be used as key or comment value
        /// </summary>
        string Name { get; set; }
    }
}
