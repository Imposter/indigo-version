/*
*
*	Title: IndigoVersion
*	Authors: Imposter (Eyaz Rehman) [http://www.igonline.eu]
*	Date: 8/22/2015
*
*	Copyright (C) 2015 Indigo Games. All Rights Reserved.
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
            return $"{Major}.{Minor}.{Build}.{Revision}";
        }
    }
}
