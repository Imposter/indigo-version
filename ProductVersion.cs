/*
*
*	Title: IndigoVersion
*	Authors: Imposter
*	Date: 8/22/2015
*
*	Copyright (C) 2018 Imposter. All Rights Reserved.
*
*/

namespace IndigoVersion
{
    public class ProductVersion
    {
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Build { get; set; }
        public int Revision { get; set; }

        public ProductVersion()
        {

        }

        public ProductVersion(int major = 0, int minor = 0, int build = 0, int revision = 0)
        {
            Major = major;
            Minor = minor;
            Build = build;
            Revision = revision;
        }

        public new string ToString()
        {
            return string.Format("{0}.{1}.{2}.{3}", Major, Minor, Build, Revision);
        }
    }
}
