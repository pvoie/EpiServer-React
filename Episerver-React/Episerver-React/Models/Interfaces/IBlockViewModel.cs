using Episerver_React.Models.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Episerver_React.Models.Interfaces
{
    interface IBlockViewModel< out T> where T : BaseBlockData
    {
        T CurrentBlock { get; }
    }
}
