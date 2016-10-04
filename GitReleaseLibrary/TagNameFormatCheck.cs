using System.Text.RegularExpressions;


namespace GitReleaseLibrary
{
    public class TagNameFormatCheck : ITagNameFormatCheck
    {
        public string tagName { get; set; }

        public bool TagNameFormat(string tagName)
        {
            if (tagName == null)
            {
                return false;
            }
            Regex tagNamePattern = new Regex(@"^v[1-9]\.([0-9]{0,2}\.)([0-9]{0,3})$");

            if (Regex.IsMatch(tagName, tagNamePattern.ToString()))
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
