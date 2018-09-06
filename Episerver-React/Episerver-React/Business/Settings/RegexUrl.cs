using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Episerver_React.Business.Settings
{
    public class RegexUrl
    {
        public const string Url = @"^((http|ftp|https):\/\/)?[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?";
    }
}