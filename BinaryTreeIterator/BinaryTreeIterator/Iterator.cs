using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTreeIterator
{
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
    
    class Iterator
    {
        public Node root { get; set; }
        private List<Node> inorder = new List<Node>();
        private Node curIter = null;

        public Node insert(Node node, int data)
        {
            if (node == null)
                return new Node(data);
            else {
                if (node.data < data)
                    node.right = insert(node.right, data);
                else
                    node.left = insert(node.left, data);
                return node;
            }
        }

        public void buildTree()
        {
            int[] arr = { 5, 2, 8, 1, 9, 6, 3, 7, 4, 10};

            foreach (int i in arr)
                root = insert(root, i);
        }

        //Morris
        public void inorder()
        {
            Node cur = root;
            Console.Write("Inorder: ");
            while (cur != null)
            {
                if (cur.left == null)
                {
                    Console.Write("{0} ", cur.data);
                    cur = cur.right;
                }
                else
                {
                    Node succ = cur.left;

                    while (succ.right != null && succ.right != cur)
                        succ = succ.right;

                    if (succ.right == null)
                    {
                        succ.right = cur;
                        cur = cur.left;
                    }
                    else if (succ.right == cur)
                    {
                        succ.right = null;
                        Console.Write("{0} ", cur.data);
                        cur = cur.right;
                    }
                }
            }
            Console.WriteLine();
        }

        

        private bool InorderIter(Node node)
        {
            if (node != null)
            { }
        }
        
        private void buildList()
        { 
        
        }

        public bool hasNext()
        { 
            
        }

        public static void driver()
        {
            Iterator tree = new Iterator();
            tree.buildTree();
        }

    }
}
