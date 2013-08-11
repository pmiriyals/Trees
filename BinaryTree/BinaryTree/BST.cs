using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTree
{
    //default access modifier for class is internal
    class Node
    {
        public int data { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }

        public Node(int data) : this(data, null, null) { }
        public Node(int data, Node left, Node right)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }
    }

    class BST
    {
        public Node root { get; set; }

        public BST()
        {
            root = null;
        }

        private Node insert(Node node, int data)
        {
            if (node == null)
                return new Node(data);
            else
            {
                if (node.data >= data)
                    node.left = insert(node.left, data);
                else
                    node.right = insert(node.right, data);
                return node;
            }
        }

        public void buildTree()
        {
            int[] elements = { 5, 4, 6, 2, 3, 8, 1, 9, 10, 7 };
            foreach (int data in elements)
            {
                root = insert(root, data);
            }
        }

        public void ConvertToMirror(Node node)
        {
            if (node == null)
                return;

            ConvertToMirror(node.left);
            ConvertToMirror(node.right);

            Node temp = node.left;
            node.left = node.right;
            node.right = temp;
        }

        public bool IsMirror(Node a, Node b)
        {
            if (a == null && b == null)
                return true;
            if (a != null && b != null)
                return (a.data == b.data) && IsMirror(a.left, b.right) && IsMirror(a.right, b.left);
            else
                return false;
        }
    }

    public class BSTDriver
    {
        public static void driver()
        {
            BST tree = new BST();
            tree.buildTree();
            BST mirror = new BST();
            mirror.buildTree();
            mirror.ConvertToMirror(mirror.root);
            Traversals.levelorder(mirror);
            Traversals.levelorder(tree);
            Console.WriteLine("Ismirror = {0}", mirror.IsMirror(mirror.root, tree.root));
            //Traversals.driver(tree);
        }
    }
}
