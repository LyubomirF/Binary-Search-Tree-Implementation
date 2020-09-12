using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST_Implementation.Factory
{
    class PostorderIteratorFactory : IteratorFactory
    {
        public Iterator CreateIterator(BinarySearchTree tree) => new PostorderIterator(tree);
    }
}
