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
        public int Major { get; }
        public int Minor { get; }
        public int Build { get; }
        public int Revision { get; }

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
            return $"{Major}.{Minor}.{Build}.{Revision}";
        }
    }
}
