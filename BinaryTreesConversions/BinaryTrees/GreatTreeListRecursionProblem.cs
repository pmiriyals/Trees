using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTrees
{
    public class lNode<T>
    {
        public T data { get; set; }
        public lNode<T> small { get; set; }
        public lNode<T> large { get; set; }
        public lNode(T data)
        {
            this.data = data;
            this.small = null;
            this.large = null;
        }
    }
    
    public class GreatTreeListRecursionProblem
    {
        private static void join(lNode<int> a, lNode<int> b)
        {
            a.large = b;    //last node list a from append function. Eg: 1<=>2<=>3, this is 3
            b.small = a;    //first node of list b from append function. Eg: 4<=>5<=>6, this is 4
            //Eg: 1<=>2<=>3 (large)<=>(small)4<=>5<=>6
        }

        private static lNode<int> append(lNode<int> a, lNode<int> b)
        {
            if (a == null)
                return b;
            if (b == null)
                return a;

            lNode<int> alast = a.small; //get the last node of the lists
            lNode<int> blast = b.small;

            join(alast, b);
            join(blast, a);

            return a;
        }
        
        public static lNode<int> treetoList(Node<int> root)
        {
            if (root == null)
                return null;

            lNode<int> aList = treetoList(root.left);   //1st time, aList and bList will be null, when we reach leaf node in the tree
            lNode<int> bList = treetoList(root.right);
            lNode<int> lRoot = new lNode<int>(root.data);       //1st time, root will be left most leaf node
            lRoot.large = lRoot;    //Convert left most leaf node to a single circular list
            lRoot.small = lRoot;    //At this point we have 3 lists (aList is null, bList is null and lRoot is the leaf node in the tree

            //Now append the lists in the right order (aList, lRoot, bList)

            aList = append(aList, lRoot);
            aList = append(aList, bList);

            return aList;
        }

        public static void printList(lNode<int> node)
        {
            lNode<int> head = node;
            Console.WriteLine("Doubly linked list = ");
            while (node != null)
            {
                Console.Write(" {0} ", node.data);
                node = node.large;
                if (node == head)
                    break;
            }
        }
    }
}
