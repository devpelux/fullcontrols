using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullControls
{
    public class ItemExpandedEventArgs : EventArgs
    {
        public int Index { get; set; }

        public bool IsExpanded { get; set; }


        public ItemExpandedEventArgs(int index, bool isExpanded)
        {
            Index = index;
            IsExpanded = isExpanded;
        }
    }
}
