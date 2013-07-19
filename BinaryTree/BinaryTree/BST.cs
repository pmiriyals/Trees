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
    }

    public class BSTDriver
    {
        public static void driver()
        {
            BST tree = new BST();
            tree.buildTree();
            Traversals.driver(tree);
        }
    }
}
