using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BST_Implementation.Factory;


namespace BST_Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree bst = new BinarySearchTree();

            //InsertTest
            int[] arr = new int[] { 5, 2, 8, 1, 3, 6, 10 };

            for (int i = 0; i < arr.Length; i++)
                bst.Insert(arr[i]);

            //InsertTest

            //SearchTest 
            TreeNode node = bst.Find(2);
            if (node != null)
                Console.WriteLine(node.Value);
            else
                Console.WriteLine("No such node found!");
            //SearchTest 

            //DeleteNodeTest

            int value = 1;
            bst.DeleteNode(value);
            Console.WriteLine($"Deleted node with value = {value}");

            //DeleteNodeTest
            Console.WriteLine($"BST's min value is {bst.TreeMinValue}");
            bst.Insert(-1);
            Console.WriteLine($"BST's min value is {bst.TreeMinValue}");

            TreeNode successorNode = bst.GetSuccessor(2);
            Console.WriteLine($"Successor of node 2 is node {successorNode.Value}");

            Iterator iterator1 = bst.GetIterator(new PostorderIteratorFactory());
            Iterator iterator2 = bst.GetIterator(new PreorderIteratorFactory());

            while (!iterator1.IsDone() && !iterator2.IsDone())
            {
                Console.WriteLine($"Postorder iterator:{iterator1.CurrentItem()}");
                Console.WriteLine($"Preorder iterator:{iterator2.CurrentItem()}");
                iterator1.Next();
                iterator2.Next();
            }

        }
    }
}
