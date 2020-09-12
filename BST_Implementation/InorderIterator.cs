using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST_Implementation
{
    public class InorderIterator : Iterator
    {
        private Stack<TreeNode> stack;
        private TreeNode root;
        public InorderIterator(BinarySearchTree binarySearchTree)
        {
            root = binarySearchTree.GetRoot;
            stack = new Stack<TreeNode>();
            InorderLeft(binarySearchTree.GetRoot);
        }

        private void InorderLeft(TreeNode node)
        {
            while(node != null)
            {
                stack.Push(node);
                node = node.LeftChild;
            }
        }
        public int CurrentItem()
        {
            TreeNode currentItem = stack.Peek();
            return currentItem.Value;
        }

        public bool IsDone()
        {
            return stack.Count <= 0;
        }

        public void Next()
        {
            TreeNode topItem = stack.Pop();

            if (topItem.RightChild != null)
                InorderLeft(topItem.RightChild);
        }

        public void Restart()
        {
            stack.Clear();
            InorderLeft(root);
        }
    }
}
