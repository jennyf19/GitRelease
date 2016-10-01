using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitReleaseLibrary
{
    interface ITagNameFormatCheck
    {
        string tagName { get; set; }

        bool TagNameFormat(string tagName);
    }
}
