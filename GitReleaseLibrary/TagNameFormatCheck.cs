using System.Text.RegularExpressions;


namespace GitReleaseLibrary
{
    public class TagNameFormatCheck : ITagNameFormatCheck
    {
        public string tagName { get; set; }

        public bool TagNameFormat(string tagName)
        {
            Regex tagNamePattern = new Regex(@"^v[1-9]\.([0-9][0-9]\.)([0-9][0-9])$");

            if (Regex.IsMatch(tagName, tagNamePattern.ToString()) && tagName != null)
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
