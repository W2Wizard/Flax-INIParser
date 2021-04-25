using FlaxEditor;
using FlaxEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INIParser.Root
{
    /// <summary>
    /// The sample editor plugin using <see cref="INIPlugin"/>.
    /// </summary>
    /// <seealso cref="FlaxEditor.EditorPlugin" />
    public class INIPluginEditor : EditorPlugin
    {
        /// <inheritdoc />
        public override PluginDescription Description => new PluginDescription
        {
            Name = "INIPlugin",
            Category = "Other",
            Author = "W2.Wizard",
            AuthorUrl = null,
            HomepageUrl = null,
            RepositoryUrl = "https://github.com/W2Wizard/Flax-INIParser",
            Description = "Lets your read and write ini files.",
            Version = new Version(1, 0),
            IsAlpha = false,
            IsBeta = false,
        };

        /// <inheritdoc />
        public override Type GamePluginType => typeof(INIPlugin);

        /// <inheritdoc />
        public override void InitializeEditor() => base.InitializeEditor();

        /// <inheritdoc />
        public override void Deinitialize() => base.Deinitialize();
    }
}
