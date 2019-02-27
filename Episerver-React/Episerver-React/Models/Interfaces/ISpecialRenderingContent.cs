using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Episerver_React.Models.Interfaces
{
    interface ISpecialRenderingContent
    {
        string[] SupportedDisplayOptions { get; }
    }
}
