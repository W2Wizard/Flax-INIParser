using System;
using FlaxEngine;

namespace INIParser 
{
    /// <summary>
    /// A single INIOption
    /// </summary>
    [HideInEditor]
    public class INIOption : IINIObject
    {
        /// <summary>
        /// Initilizes a new instance of <see cref="INIOption"/>.
        /// </summary>
        public INIOption()
        {
        }

        /// <summary>
        /// Initilizes a new instance of <see cref="INIOption"/> with a given name and value.
        /// </summary>
        /// <param name="name">The key of the option.</param>
        /// <param name="value">The value of the option.</param>
        public INIOption(string name, object value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Key of the option
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Value of the option
        /// </summary>
        public object Value { get; set; } = null;

        /// <summary>
        /// Retrieves the value of the option as <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to get the value as.</typeparam>
        /// <param name="defaultValue">If invalid type, returns default value of <typeparamref name="T"/>, can be used as fallback.</param>
        /// <returns>The value of the option as <typeparamref name="T"/>.</returns>
        public T GetValue<T>(T defaultValue = default)
        {
            // Check if object is already T, else attempt to convert.
            if (this.Value is T type)
                return type;

            if (this.Value is IConvertible obj)
                return (T)obj.ToType(typeof(T), null);

            return defaultValue;
        }

    }
}
