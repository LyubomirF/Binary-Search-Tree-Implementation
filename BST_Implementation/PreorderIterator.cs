using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST_Implementation
{
    public class PreorderIterator : Iterator
    {
        private Stack<TreeNode> stack;
        private TreeNode root;

        public PreorderIterator(BinarySearchTree tree)
        {
            root = tree.GetRoot;
            stack = new Stack<TreeNode>();
            stack.Push(tree.GetRoot);
        }

        public int CurrentItem() => stack.Peek().Value;
      
        public bool IsDone() => stack.Count <= 0;
        
        public void Next()
        {
            TreeNode top = stack.Pop();

            if(top.RightChild != null) stack.Push(top.RightChild);
            if(top.LeftChild != null) stack.Push(top.LeftChild);
        }

        public void Restart()
        {
            stack.Clear();
            stack.Push(root);
        }
    }
}
