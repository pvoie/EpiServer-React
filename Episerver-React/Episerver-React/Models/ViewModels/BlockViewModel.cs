using Episerver_React.Models.Blocks;
using Episerver_React.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Episerver_React.Models.ViewModels
{
    public class BlockViewModel<T>: IBlockViewModel<T> where T : BaseBlockData
    {
        public T CurrentBlock { get; private set; }

        public BlockViewModel() { }

        public BlockViewModel(T currentBlock)
        {
            CurrentBlock = currentBlock;
        }      
        
    }

    public static class BlockViewModel
    {
        /// <summary>
        /// Returns a BlockViewModel of type <typeparam name="T"/>.
        /// </summary>
        /// <remarks>
        /// Convenience method for creating BlockViewModela without having to specify the type as methods can use type inference while constructors cannot.
        /// </remarks>
        public static BlockViewModel<T> Create<T>(T block) where T : BaseBlockData
        {
            return new BlockViewModel<T>(block);
        }
    }


}