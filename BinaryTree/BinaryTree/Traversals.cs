using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTree
{
    class Traversals
    {
        //print per line: O(n)
        public static void levelorder(BST tree)
        {
            if (tree.root == null)
                return;
            Node node = tree.root;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(node);
            int nextlevel = 1;
            int numnodes;
            Console.WriteLine("Level order traversal (print per line)");
            while (queue.Count > 0)
            {
                numnodes = nextlevel;
                nextlevel = 0;
                for (int i = 0; i < numnodes; i++)
                {
                    node = queue.Dequeue();
                    Console.Write(" {0} ", node.data);
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                        nextlevel++;
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                        nextlevel++;
                    }
                }
                Console.WriteLine();
            }
        }

        //Time: O(n) & Space: O(1) (O(n) for recursion overhead)
        public static void inorderRecur(Node node)
        {
            if (node == null)
                return;

            inorderRecur(node.left);
            Console.Write(" {0} ", node.data);
            inorderRecur(node.right);
        }

        //Time: O(n) & Space: O(1)
        public static void inorderIter(BST tree)
        {
            Stack<Node> stk = new Stack<Node>();
            Node node = tree.root;
            bool done = false;
            Console.WriteLine("Inorder traversal Iterative Using Stack");
            while (!done)
            {
                if (node != null)
                {
                    stk.Push(node);
                    node = node.left;
                }
                else
                {
                    if (stk.Count > 0)
                    {
                        node = stk.Pop();
                        Console.Write(" {0} ", node.data);
                        node = node.right;
                    }
                    else
                        done = true;
                }
            }
            Console.WriteLine();
        }

        //Time: O(n) & Space: O(1) (modifies tree and reverts back)
        public static void inorderMorris(BST tree)
        {
            Console.WriteLine("Inorder Morris traversal (threaded binary tree): ");
            Node node = tree.root;
            while (node != null)
            {
                if (node.left == null)
                {
                    Console.Write(" {0} ", node.data);
                    node = node.right;
                }
                else
                {
                    Node succ = node.left;

                    while (succ.right != null && succ.right != node)
                        succ = succ.right;

                    if (succ.right == null)
                    {
                        succ.right = node;
                        node = node.left;
                    }
                    else if (succ.right == node)
                    {
                        succ.right = null;
                        Console.Write(" {0} ", node.data);
                        node = node.right;
                    }
                }
            }
            Console.WriteLine();
        }

        //Time: O(n) & Space: O(1) (O(n) recursion overhead)
        public static void preorderRecur(Node node)
        {
            if (node == null)
                return;

            Console.Write(" {0} ", node.data);
            preorderRecur(node.left);
            preorderRecur(node.right);
        }

        //Time: O(n) & Space: O(n)
        public static void preorderIter(BST tree)
        {
            Node node = tree.root;
            if (node == null)
                return;
            Console.WriteLine("Preorder Iterative traversal: ");
            Stack<Node> stk = new Stack<Node>();
            stk.Push(node);

            while(stk.Count > 0)
            {
                node = stk.Pop();
                Console.Write(" {0} ", node.data);

                if (node.right != null)
                    stk.Push(node.right);
                if (node.left != null)
                    stk.Push(node.left);
            }
            Console.WriteLine();
        }

        //Time: O(n) & Space: O(1)
        public static void preorderMorris(BST tree)
        {
            Node node = tree.root;

            while (node != null)
            {
                if (node.left == null)
                {
                    Console.Write(" {0} ", node.data);
                    node = node.right;
                }
                else
                {
                    Node succ = node.left;
                    while (succ.right != null && succ.right != node)
                        succ = succ.right;

                    if (succ.right == null)
                    {
                        succ.right = node;
                        Console.Write(" {0} ", node.data);
                        node = node.left;
                    }
                    else if (succ.right == node)
                    {
                        succ.right = null;
                        node = node.right;
                    }
                }
            }
            Console.WriteLine();
        }

        //Time: O(n) & Space: O(n) (recursion overhead)
        public static void postorderRecur(Node node)
        {
            if (node == null)
                return;

            postorderRecur(node.left);
            postorderRecur(node.right);
            Console.Write(" {0} ", node.data);
        }

        //Time: O(n) & Space: O(2n) (two stacks
        public static void postorderIter(BST tree)
        {
            Node node = tree.root;
            if (node == null)
                return;
            Console.WriteLine("Post order traversal Iter using two stacks: ");
            Stack<Node> stk = new Stack<Node>();
            Stack<Node> res = new Stack<Node>();

            stk.Push(node);
            while (stk.Count > 0)
            {
                node = stk.Pop();
                res.Push(node);
                if (node.left != null)
                    stk.Push(node.left);
                if (node.right != null)
                    stk.Push(node.right);
            }
            
            while (res.Count > 0)
            {
                node = res.Pop();
                Console.Write(" {0} ", node.data);
            }
            Console.WriteLine();
        }

        public static void driver(BST tree)
        {
            levelorder(tree);
            
            inorderIter(tree);
            Console.WriteLine("Inorder traversal recursive : ");
            inorderRecur(tree.root);
            Console.WriteLine();
            inorderMorris(tree);

            preorderIter(tree);
            Console.WriteLine("Inorder traversal recursive : ");
            preorderRecur(tree.root);
            Console.WriteLine();
            preorderMorris(tree);
            
            postorderIter(tree);
            Console.WriteLine("Inorder traversal recursive : ");
            postorderRecur(tree.root);
            Console.WriteLine();
        }
    }
}
