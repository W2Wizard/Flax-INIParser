using System;
using System.Collections.Generic;
using System.IO;
using FlaxEngine;

namespace INIParser
{

    [HideInEditor]
    public class INIWriter : StreamWriter
    {
        /// <summary>
        /// Initilizes a new instance of <see cref="INIWriter"/> with a given <see cref="Stream"/>
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to use for writing.</param>
        public INIWriter(Stream stream) : base(stream)
        {
            
        }

        /// <summary>
        /// Writes a given <see cref="INISection"/> 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="IsGlobal"></param>
        public virtual void WriteSection(INISection section, bool IsGlobal = false)
        {
            if (section == null)
                return;

            if (!IsGlobal)
                this.WriteLine($"[{section.Name}]");

            for (int i = 0; i < section.Count; i++)
            {
                var iniObject = section[i];

                if (iniObject is INIOption option)
                {
                    WriteOption(option);
                    continue;
                }

                if (iniObject is INIComment comment)
                {
                    WriteComment(comment);
                    continue;
                }

            }

            // Empty line for padding between sections
            this.WriteLine();
        }

        /// <summary>
        /// Writes an <see cref="INIOption"/> onto the stream.
        /// </summary>
        /// <param name="option"></param>
        public virtual void WriteOption(INIOption option)
        {
            if (option is null)
                throw new ArgumentNullException("Option cannot be null!");

            if (option.Name is null)
                throw new NullReferenceException("The name for INIOption cannot be null!");

            if (option.Value is null)
                throw new NullReferenceException($"The value of {option.Name} cannot be null!");

            this.WriteLine($"{option.Name}={option.Value}");
        }

        /// <summary>
        /// Writes an <see cref="INIComment"/> onto the stream.
        /// </summary>
        /// <param name="comment"></param>
        public virtual void WriteComment(INIComment comment) 
        { 
            this.WriteLine($";{comment.Name}"); 
        }

        public virtual void Space(int num = 0)
        {
            for (int i = 0; i < num; i++)
                this.WriteLine();
        }
    }
}
