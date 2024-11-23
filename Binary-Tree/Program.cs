using System;

namespace Binary_Tree
{
    class Program
    {
        public static int Main()
        {
            BinaryTree root = BinaryTree.NodeCreate(10);
            for (int i = 0; i < 10; i++)
            {
                BinaryTree.Insert(ref root, i);
            }
            Console.WriteLine("Tree:");
            BinaryTree.InorderTraversal(root);
            Console.WriteLine();
            BinaryTree.Delete(root, 5);
            Console.WriteLine("Tree after deleting 5:");
            BinaryTree.InorderTraversal(root);
            Console.WriteLine();
            
            
            return 0;
        }
    }
}