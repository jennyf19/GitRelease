using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace GitReleaseLibrary
{
    public class TagNameFormatCheck : ITagNameFormatCheck
    {
        public string TagName { get; set; }

        public bool TagNameFormat(string TagName)
        {
            Regex TagNamePattern = new Regex(@"^v[1-9]\.([0-9][0-9]\.)([0-9][0-9])$");

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
