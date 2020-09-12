using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST_Implementation
{
    public class PostorderIterator : Iterator
    {
        private Stack<TreeNode> stack;
        private HashSet<TreeNode> hashSet;
        private TreeNode root;
        public PostorderIterator(BinarySearchTree tree)
        {
            stack = new Stack<TreeNode>();
            hashSet = new HashSet<TreeNode>();
            PreorderTraversal(tree.GetRoot);
            root = tree.GetRoot;
        }

        public int CurrentItem() => stack.Peek().Value;

        public bool IsDone() => stack.Count <= 0;

        public void Next()
        {
            stack.Pop();
            if(stack.Count > 0)
            {
                TreeNode top = stack.Peek();
                if (top.RightChild != null 
                    && !hashSet.Contains(top.RightChild))
                    PreorderTraversal(top.RightChild);
            }

        }

        public void Restart()
        {
            stack.Clear();
            hashSet.Clear();
            PreorderTraversal(root);
        }

        private bool PreorderTraversal(TreeNode root)
        {
            if (root == null) return false;

            stack.Push(root);
            hashSet.Add(root);

            if (root.LeftChild == null && root.RightChild == null) return true;

            bool flag1 = PreorderTraversal(root.LeftChild);

            if (!flag1)
                flag1 = flag1 || PreorderTraversal(root.RightChild);

            return flag1;
        }
    }
}
