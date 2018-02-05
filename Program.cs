/*
*
*	Title: IndigoVersion
*	Authors: Imposter
*	Date: 8/22/2015
*
*	Copyright (C) 2018 Imposter. All Rights Reserved.
*
*/

using System;
using System.IO;
using System.Text.RegularExpressions;

namespace IndigoVersion
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // Check args
            if (args.Length != 3)
            {
                Console.WriteLine("USAGE: IndigoVersion.exe <directory> <product_name> <command>");
                return;
            }

            var dataDirectory = Path.GetFullPath(args[0]);
            var productName = Regex.Replace(args[1], "[^a-zA-Z0-9_]+", "", RegexOptions.Compiled);

            Console.WriteLine("Version directory: {0}", dataDirectory);

            // Open version config
            var version = new ProductVersion();
            var versionNull = true;
            var versionString = $"{productName.ToUpper()}_VERSION";
            var versionInfo = $"{versionString.ToLower()}.xml";
            if (File.Exists(Path.Combine(dataDirectory, versionInfo)))
            {
                using (var fileStream = File.OpenRead(Path.Combine(dataDirectory, versionInfo)))
                {
                    if (!Xml.Deserialize(fileStream, ref version))
                    {
                        Console.WriteLine("ERROR: Version configuration is corrupt.");
                        return;
                    }
                    versionNull = false;
                }
            }

            // Parse command
            var command = args[2];
            var newVersion = version;
            switch (command)
            {
                case "Increase":
                    newVersion = new ProductVersion(version.Major, version.Minor, version.Build + 1);
                    break;
                case "Decrease":
                    newVersion = new ProductVersion(version.Major, version.Minor, version.Build - 1);
                    break;
                case "Reset":
                    newVersion = new ProductVersion();
                    break;
            }

            if (versionNull || newVersion != version)
            {
                if (!Directory.Exists(dataDirectory))
                {
                    Directory.CreateDirectory(dataDirectory);
                }

                using (var fileStream = File.OpenWrite(Path.Combine(dataDirectory, versionInfo)))
                {
                    Xml.Serialize(fileStream, newVersion);
                }

                var versionFile = new StreamWriter(Path.Combine(dataDirectory, $"{versionString.ToLower()}.h"));

                versionFile.WriteLine("#ifndef {0}_VERSION_H", productName.ToUpper());
                versionFile.WriteLine("#define {0}_VERSION_H", productName.ToUpper());
                versionFile.WriteLine();
                versionFile.WriteLine("#define {0}_VERSION_MAJOR {1}", productName.ToUpper(), newVersion.Major);
                versionFile.WriteLine("#define {0}_VERSION_MAJOR_STRING \"{1}\"", productName.ToUpper(), newVersion.Major);
                versionFile.WriteLine("#define {0}_VERSION_MINOR {1}", productName.ToUpper(), newVersion.Minor);
                versionFile.WriteLine("#define {0}_VERSION_MINOR_STRING \"{1}\"", productName.ToUpper(), newVersion.Minor);
                versionFile.WriteLine("#define {0}_VERSION_BUILD {1}", productName.ToUpper(), newVersion.Build);
                versionFile.WriteLine("#define {0}_VERSION_BUILD_STRING \"{1}\"", productName.ToUpper(), newVersion.Build);
                versionFile.WriteLine();
                versionFile.WriteLine("#define {0}_VERSION_STRING {0}_VERSION_MAJOR_STRING \".\" {0}_VERSION_MINOR_STRING \".\" {0}_VERSION_BUILD_STRING", productName.ToUpper());
                versionFile.WriteLine("#define {0}_VERSION_BUILD_DATE \"{1} {2}\"", productName.ToUpper(), DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());
                versionFile.WriteLine("#endif // {0}_VERSION_H", productName.ToUpper());

                versionFile.Close();
            }

            Console.WriteLine("Successfully finished operations!");
            Console.WriteLine("Current version: {0}.{1}.{2}", newVersion.Major, newVersion.Minor, newVersion.Build);
        }
    }
}
