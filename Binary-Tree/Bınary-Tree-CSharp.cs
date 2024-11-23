using System;
using System.Data;
using System.Resources;

namespace Binary_Tree
{
    public class BinaryTree
    {
        public BinaryTree node;
    public int Data;
    public BinaryTree Left;
    public BinaryTree Right;

    public static BinaryTree NodeCreate(int data)
    {
        BinaryTree node = new BinaryTree();
        node.Data = data;
        node.Left = null;
        node.Right = null;
        return node;
    }

    public static void Insert(ref BinaryTree root, int key)
    {
        if (root == null)
        {
            root = NodeCreate(key);
            return;
        }

        if (key < root.Data)
        {
            Insert(ref root.Left, key);
        }
        else if (key > root.Data)
        {
            Insert(ref root.Right, key);
        }
    }

    public static BinaryTree GetDeepestRightmostNode(BinaryTree root)
    {
        BinaryTree temp = null;
        Queue<BinaryTree> queue = new Queue<BinaryTree>();

        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            temp = queue.Dequeue();

            if (temp.Left != null)
            {
                queue.Enqueue(temp.Left);
            }

            if (temp.Right != null)
            {
                queue.Enqueue(temp.Right);
            }
        }

        return temp;
    }

    public static void DeleteDeepestRightmostNode(BinaryTree root, BinaryTree dnode)
    {
        BinaryTree temp = null;
        Queue<BinaryTree> queue = new Queue<BinaryTree>();

        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            temp = queue.Dequeue();

            if (temp == dnode)
            {
                temp.Data = 0;
                return;
            }

            if (temp.Left == dnode)
            {
                temp.Left = null;
                return;
            }
            else if (temp.Left != null)
            {
                queue.Enqueue(temp.Left);
            }

            if (temp.Right == dnode)
            {
                temp.Right = null;
                return;
            }
            else if (temp.Right != null)
            {
                queue.Enqueue(temp.Right);
            }
        }
    }

    public static void Delete(BinaryTree root, int data)
    {
        if (root == null)
        {
            Console.Write("Tree is empty \n");
            return;
        }

        if (root.Left == null && root.Right == null)
        {
            if (root.Data == data)
            {
                //root.Data = 0;
                root = null;
                return;
            }
            else
            {
                Console.Write("Node not found \n");
                return;
            }
        }

        BinaryTree temp;
        BinaryTree keyNode = null;
        Queue<BinaryTree> queue = new Queue<BinaryTree>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {

            temp = queue.Dequeue();

            if (temp.Data == data)
            {
                keyNode = temp;

            }

            if (temp.Left != null)
            {
                queue.Enqueue(temp.Left);
            }

            if (temp.Right != null)
            {
                queue.Enqueue(temp.Right);
            }

        }

        if (keyNode != null)
        {
            BinaryTree deepestNode = GetDeepestRightmostNode(root);
            keyNode.Data = deepestNode.Data;
            DeleteDeepestRightmostNode(root, deepestNode);

        }

        else
        {
            Console.Write("Node not found \n");
        }
    }

    public static BinaryTree Search(BinaryTree root, int data)
    {
        if (root == null)
        {
            return null;
        }

        BinaryTree temp;
        Queue<BinaryTree> queue = new Queue<BinaryTree>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            temp = queue.Dequeue();
            if (temp.Data == data)
            {
                return temp;
            }

            if (temp.Left != null)
            {
                queue.Enqueue(temp.Left);
            }

            if (temp.Right != null)
            {
                queue.Enqueue(temp.Right);
            }
        }

        return null;
    }

    public static void InorderTraversal(BinaryTree root)
    {
        if (root == null)
        {
            return;
        }

        InorderTraversal(root.Left);
        Console.Write(root.Data + " ");
        InorderTraversal(root.Right);
    }
}
}

