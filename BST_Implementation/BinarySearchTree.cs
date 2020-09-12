using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BST_Implementation.Factory;


namespace BST_Implementation
{
    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }

        public TreeNode(int value = 0, TreeNode left = null, TreeNode right = null)
        {
            Value = value;
            LeftChild = left;
            RightChild = right;
        }
    }

    public class BinarySearchTree
    {
        private TreeNode root;
        public TreeNode GetRoot => root;
        public int TreeMaxValue
        {
            get
            {
                TreeNode r = root;
                return FindMaxValue(r);
            }
        }

        public int TreeMinValue
        {
            get
            {
                TreeNode r = root;
                return FindMinValue(r);
            }
        }

        public BinarySearchTree(TreeNode root = null)
        {
            this.root = root;
        }

        public TreeNode Insert(int value)
        {
            if (root == null)
            {
                root = new TreeNode(value);
                return root;
            }

            TreeNode node = new TreeNode(value);
            root = InsertNode(root, node);
            return node;
        }
        
        public TreeNode Find(int value)
        {
            TreeNode r = root;
            return SearchNode(r, value);
        }

        public TreeNode GetSuccessor(int value)
        {
            TreeNode r = root;
            return GetSuccessor(r, value);
        }

        public void DeleteNode(int value)
        {
            root = DeleteNode(root, value);
        }

        public Iterator GetIterator(IteratorFactory factory)
        {
            return factory.CreateIterator(this);
        }

        private TreeNode SearchNode(TreeNode root, int value)
        {
            if (root == null) return null;

            if (root.Value == value)
                return root;

            TreeNode node = null;

            if (value < root.Value)
                node = SearchNode(root.LeftChild, value);

            if (value > root.Value)
                node = SearchNode(root.RightChild, value);

            return node;
        }

        private TreeNode InsertNode(TreeNode root, TreeNode node)
        {
            if (root == null) return node;

            if (node.Value < root.Value)
                root.LeftChild = InsertNode(root.LeftChild, node);

            if (node.Value > root.Value)
                root.RightChild = InsertNode(root.RightChild, node);

            return root;
        }

        private TreeNode DeleteNode(TreeNode root, int value)
        {
            if (root == null) return null;

            if (value < root.Value)
                root.LeftChild = DeleteNode(root.LeftChild, value);
            else if (value > root.Value)
                root.RightChild = DeleteNode(root.RightChild, value);
            else
            {
                if (root.LeftChild == null)
                    return root.RightChild;

                if (root.RightChild == null)
                    return root.LeftChild;

                root.Value = FindMinValue(root.RightChild);

                root.RightChild = DeleteNode(root.RightChild, root.Value);
            }

            return root;
        }

        private TreeNode GetSuccessor(TreeNode root, int value)
        {
            TreeNode current = SearchNode(root,value);
            if (current == null) return null;

            if(current.RightChild != null)
                return FindMinNode(current.RightChild);
            else
            {
                TreeNode successor = null;
                TreeNode ancestor = root;

                while(current.Value != ancestor.Value)
                {
                    if (current.Value < ancestor.Value)
                    {
                        successor = ancestor;
                        ancestor = ancestor.LeftChild;
                    }
                    else
                        ancestor = ancestor.RightChild;
                }

                return successor;
            }
            
        }

        private TreeNode FindMinNode(TreeNode node)
        {
            if (node == null) return null;

            while (node.LeftChild != null)
                node = node.LeftChild;

            return node;
        }

        private int FindMinValue(TreeNode root)
        {
            int minVal = root.Value;

            while(root != null)
            {
                minVal = root.Value;
                root = root.LeftChild;
            }

            return minVal;
        }

        private int FindMaxValue(TreeNode root)
        {
            int maxVal = root.Value;

            while(root != null)
            {
                maxVal = root.Value;
                root = root.RightChild;
            }

            return maxVal;
        }
    }
}
