using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace GitRelease
{
    class TagNameFormat
    {
        public static bool TagNameFormatCheck(string TagName)
        {
            Regex TagNamePattern = new Regex(@"^v[1-9]\.([0-9][0-9]\.)([0-9][0-9])$");

            Console.WriteLine("The tag name is " + TagName);
            Console.WriteLine("The tag name pattern is " + TagNamePattern);

            if (Regex.IsMatch(TagName, TagNamePattern.ToString()) && TagName != null)
            {
                return true;
            }

            else
            {
                return false;
            }
            
        }
    }
}
