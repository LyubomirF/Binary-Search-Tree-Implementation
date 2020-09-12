using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST_Implementation
{
    public interface Iterator
    {
        void Restart();
        void Next();
        bool IsDone();
        int CurrentItem();
    }
}
