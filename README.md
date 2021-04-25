# Flax-INIParser
INI file parser as a plugin for the Flax Engine.
As of now its only C#, in the future if I have time I might include C++.

## How to install?
Add the following to your project's `.flaxproj` under references:
```
"Name": "$(ProjectPath)/Plugins/INIParser/INIParser.flaxproj"
```

Upnext go to `<YourProject>.Build.cs` and add the following under the `Setup` method.
```cs
options.PrivateDependencies.Add("INIParser");
```
