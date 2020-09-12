using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST_Implementation.Factory
{
    public interface IteratorFactory
    {
        Iterator CreateIterator(BinarySearchTree tree);
    }
}
