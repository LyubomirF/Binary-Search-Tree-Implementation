using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST_Implementation.Factory
{
    public class PreorderIteratorFactory : IteratorFactory
    {
        public Iterator CreateIterator(BinarySearchTree tree) => new PreorderIterator(tree);
    }
}
