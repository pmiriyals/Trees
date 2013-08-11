using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTrees
{
    public class Node<T>
    {
        public T data { get; set; }
        public Node<T> left { get; set; }
        public Node<T> right { get; set; }

        public Node(T data) : this(data, null, null) { }
        public Node(T data, Node<T> l, Node<T> r) 
        {
            this.data = data;
            this.left = l;
            this.right = r;
        }
    }

    public class Tree<T>
    {
        public Node<T> root { get; set; }

        public Tree() : this(null) { }
        public Tree(Node<T> root)
        {
            this.root = root;
        }

        private Node<T> insert(Node<T> node, T val)
        {
            if (node == null)
                return new Node<T>(val);
            else
            {
                if (int.Parse(node.data.ToString()) < int.Parse(val.ToString()))
                    node.right = insert(node.right, val);
                else
                    node.left = insert(node.left, val);
                return node;
            }
        }

        public void insert(T val)
        {
            root = insert(root, val);    
        }

        private int Count(Node<T> node)
        {
            if (node == null)
                return 0;
            return Count(node.left) + 1 + Count(node.right);
        }

        public int Count()
        {
            int cnt = Count(root);
            Console.WriteLine("Total nodes = {0}", cnt);
            return cnt;
        }

        private int height(Node<T> node)
        {
            if (node == null)
                return 0;

            int ldepth = height(node.left);
            int rdepth = height(node.right);

            if (ldepth > rdepth)
                return ldepth + 1;
            else
                return rdepth + 1;
        }

        public int height()
        {
            int h = height(root);
            Console.WriteLine("Height of tree = {0}", h);            
            return h;
        }

        private void InorderMorris(Node<T> node)
        {
            Node<T> cur = node;

            while (cur != null)
            {
                if (cur.left == null)
                { 
                    Console.Write(" {0} ", cur.data.ToString());
                    cur = cur.right;
                }
                else
                {
                    Node<T> pred = cur.left;
                    while (pred.right != null && pred.right != cur)
                        pred = pred.right;

                    if (pred.right == null)
                    {
                        pred.right = cur;
                        cur = cur.left;
                    }
                    else if (pred.right == cur)
                    {
                        pred.right = null;
                        Console.Write(" {0} ", cur.data.ToString());
                        cur = cur.right;
                    }
                }
            }
        }

        public void InorderMorris()
        {
            Console.WriteLine("Inorder Morris traversal = ");
            InorderMorris(root);
            Console.WriteLine();
        }

        private void InorderIter(Node<T> node)
        {
            Stack<Node<T>> stk = new Stack<Node<T>>();
            Node<T> cur = node;

            bool done = false;
            while (!done)
            {
                if (cur != null)
                {
                    stk.Push(cur);
                    cur = cur.left;
                }
                else
                {   
                    if (stk.Count > 0)
                    {
                        cur = stk.Pop();
                        Console.Write(" {0} ", cur.data.ToString());                    
                        cur = cur.right;
                    }
                    else
                        done = true;
                }
            }
        }

        public void InorderIter()
        {
            Console.WriteLine("Inorder Iterative = ");
            InorderIter(root);
            Console.WriteLine();
        }

        private void InorderRecur(Node<T> node)
        {
            if (node == null)
                return;

            InorderRecur(node.left);
            Console.Write(" {0} ", node.data);
            InorderRecur(node.right);
        }

        public void InorderRecur()
        {
            Console.WriteLine("Inorder Recursive Traversal = ");
            InorderRecur(root);
            Console.WriteLine();
        }

        private void PostorderIter(Node<T> node)
        {
            Stack<Node<T>> stk = new Stack<Node<T>>();
            Stack<Node<T>> res = new Stack<Node<T>>();

            Node<T> cur = node;
            stk.Push(cur);
            while (stk.Count > 0)
            {
                cur = stk.Pop();
                res.Push(cur);
                if (cur.left != null)
                    stk.Push(cur.left);
                if (cur.right != null)
                    stk.Push(cur.right);
            }

            
            while (res.Count > 0)
            {
                Console.Write(" {0} ", res.Pop().data.ToString());
            }
        }

        public void PostorderIter()
        {
            Console.WriteLine("Postorder iterative traversal = ");
            PostorderIter(root);
            Console.WriteLine();
        }

        private void PostorderRecur(Node<T> node)
        {
            if (node == null)
                return;

            PostorderRecur(node.left);
            PostorderRecur(node.left);
            Console.Write(" {0} ", node.data);
        }

        public void PostOrderRecur()
        {
            Console.WriteLine("PostOrder Recursive Traversal = ");
            PostorderRecur(root);
            Console.WriteLine();
        }

        private void PreorderMorris(Node<T> node)
        {
            Node<T> cur = node;
            while (cur != null)
            {
                if (cur.left == null)
                {
                    Console.Write(" {0} ", cur.data.ToString());
                }
                else
                {
                    Node<T> pred = cur.left;

                    while (pred.right != null && pred.right != cur)
                    {
                        pred = pred.right;
                    }

                    if (pred.right == null)
                    {
                        pred.right = cur;
                        Console.Write(" {0} ", cur.data.ToString());
                        cur = cur.left;
                    }
                    else if (pred.right == cur)
                    {
                        pred.right = null;
                        cur = cur.right;
                    }
                }
            }
        }

        public void PreOrderMorris()
        {
            Console.WriteLine("PreOrder Morris traversal = ");
            PreorderMorris(root);
            Console.WriteLine();
        }

        private void PreorderIter(Node<T> node)
        {
            if (node == null)
                return;

            Stack<Node<T>> stk = new Stack<Node<T>>();
            Node<T> cur = node;
            stk.Push(cur);
            while (stk.Count > 0)
            {
                cur = stk.Pop();
                Console.Write(" {0} ", cur.data.ToString());
                if(cur.right != null)
                    stk.Push(cur.right);
                if (cur.left != null)
                    stk.Push(cur.left);
            }
        }

        public void PreorderIter()
        {
            Console.WriteLine("Preorder Iterative traversal = ");
            PreorderIter(root);
            Console.WriteLine();
        }

        private void PreorderRecur(Node<T> node)
        {
            if (node == null)
                return;
            Console.Write(" {0} ", node.data);

            PreorderRecur(node.left);
            PreorderRecur(node.right);
        }

        public void PreOrderRecur()
        {
            Console.WriteLine("Preorder recursive traversal = ");
            PreorderRecur(root);
            Console.WriteLine();
        }

        private void printPath(T[] pathArr, int pathlen)
        {
            for (int i = 0; i < pathlen; i++)
            {
                Console.Write(" {0} ", pathArr[i].ToString());
            }
        }

        private void printPaths(Node<T> node, T[] pathArr, int pathlen)
        {
            if (node == null)
                return;

            pathArr[pathlen++] = node.data;

            if (node.left == null && node.right == null)
            {
                printPath(pathArr, pathlen);
                Console.WriteLine();
            }
            else
            {
                printPaths(node.left, pathArr, pathlen);
                printPaths(node.right, pathArr, pathlen);
            }
        }

        public void printPaths()
        {
            int h = height();
            T[] pathArr = new T[(int)Math.Pow(2, h-1) + 1];
            Console.WriteLine("Printing paths of the tree = ");
            printPaths(root, pathArr, 0);
        }

        private void printlevel(Node<T> node, int level)
        {
            if (level == 1)
            {
                Console.Write(" {0} ", node.data);
                return;
            }
            else
            {
                if(node.left != null)
                    printlevel(node.left, level - 1);
                if (node.right != null)
                    printlevel(node.right, level - 1);
            }
        }

        public void levelorder()
        {
            int h = height();
            for (int i = 1; i <= h; i++)
            {
                printlevel(root, i);
                Console.WriteLine();
            }
        }

        public void levelorderBFS()
        {
            Node<T> cur = root;
            Queue<Node<T>> queue = new Queue<Node<T>>();
            Console.WriteLine("level order BFS traversal = ");
            queue.Enqueue(cur);
            while (queue.Count > 0)
            {
                cur = queue.Dequeue();
                Console.Write(" {0} ", cur.data.ToString());

                if (cur.left != null)
                    queue.Enqueue(cur);
                if (cur.right != null)
                    queue.Enqueue(cur);
            }
        }

        public void levelorderBFSperline()
        {
            Node<T> cur = root;
            Queue<Node<T>> queue = new Queue<Node<T>>();
            Node<T> dummy;
            int nextlevel = 1, numnodes;
            Console.WriteLine("level order BFS per line traversal = ");
            Console.Write(" {0} ", cur.data.ToString());
            queue.Enqueue(cur);
            while (queue.Count > 0)
            {                
                dummy = cur;
                numnodes = nextlevel;
                nextlevel = 0;
                Console.WriteLine();
                for(int i = 0; i < numnodes; i++)
                {
                    if (cur.left != null)
                    {
                        Console.Write(" {0} ", cur.left.data.ToString());
                        queue.Enqueue(cur.left);
                        nextlevel++;
                    }
                    if (cur.right != null)
                    {
                        Console.Write(" {0} ", cur.right.data.ToString());
                        queue.Enqueue(cur.right);
                        nextlevel++;
                    }
                    cur = queue.Dequeue();
                }

                if (cur == dummy && queue.Count > 0)
                    cur = queue.Dequeue();
            }
        }

        private void doubleTree(Node<T> node)
        {
            if (node == null)
                return;

            doubleTree(node.left);
            doubleTree(node.right);

            Node<T> oldLeft = node.left;
            node.left = new Node<T>(node.data);
            node.left.left = oldLeft;
        }

        public void doubleTree()
        {
            doubleTree(root);
        }

        private void mirror(Node<T> node)
        {
            if (node == null)
                return;

            mirror(node.left);
            mirror(node.right);
            Node<T> left = node.left;
            node.left = node.right;
            node.right = left;
        }

        public void mirrorTree()
        {
            mirror(root);
        }

        public bool isIdentical(Node<T> n1, Node<T> n2)
        {
            if (n1 == null && n2 == null)
                return true;
            else if (n1 != null && n2 != null)
            {
                return (n1.data.ToString() == n2.data.ToString()) && isIdentical(n1.left, n2.left) && isIdentical(n1.right, n2.right);
            }
            else return false;
        }

        private bool isBST(Node<T> node, int min, int max)
        {
            if (node == null)
                return true;

            if (int.Parse(node.data.ToString()) > max || int.Parse(node.data.ToString()) < min)
                return false;

            return isBST(node.left, min, int.Parse(node.data.ToString())) && isBST(node.right, int.Parse(node.data.ToString())+1, max);
        }

        public bool isBST()
        {
            return isBST(root, Int32.MinValue, Int32.MaxValue);
        }

        public T minValue()
        {
            Node<T> cur = root;
            while (cur.left != null)
                cur = cur.left;
            Console.WriteLine("Min value = " + cur.data.ToString());
            return cur.data;
        }
        public T maxValue()
        {
            Node<T> cur = root;
            while (cur.right != null)
                cur = cur.right;
            Console.WriteLine("Max value = " + cur.data.ToString());
            return cur.data;
        }

        private bool hasPathSum(Node<T> node, int sum)
        {
            if(node == null)
                return sum == 0;
            else
            {
                int subSum = sum - int.Parse(node.data.ToString());
                return hasPathSum(node.left, subSum) || hasPathSum(node.right, subSum);
            }
        }

        public bool hasPathSum(int sum)
        {
            bool hassum = false;
            hassum = hasPathSum(root, sum);
            Console.WriteLine("HasPathSum({0}) = {1}", sum, hassum);
            return hassum;
        }

        public int countTrees(int numKeys)
        {
            if (numKeys <= 1)
                return 1;
            else
            {
                int root, left, right;
                int sum = 0;
                for (root = 1; root <= numKeys; root++)
                {
                    left = countTrees(root - 1);
                    right = countTrees(numKeys - root);
                    sum += left * right;
                }
                return sum;
            }
        }

        private class IntRef
        {
            public int val { get; set; }
            public IntRef(int val)
            {
                this.val = val;
            }
        }

        //Cracking the coding interview 4.1
        private bool isTreeBalanced(Node<T> node, IntRef height)
        {
            if (node == null)
            {
                height.val = 0;
                return true;
            }

            bool l, r;
            IntRef lh = new IntRef(0);
            IntRef rh = new IntRef(0);

            l = isTreeBalanced(node.left, lh);
            r = isTreeBalanced(node.right, rh);

            height.val = (lh.val > rh.val) ? lh.val + 1 : rh.val + 1;

            return Math.Abs(lh.val - rh.val) < 2 && l && r;
        }

        public bool isTreeBalanced()
        {
            IntRef h = new IntRef(0);
            bool isbalanced = isTreeBalanced(root, h);
            Console.WriteLine("IsTreeBalanced = {0}\nHeight calculated from TreeBalance function = {1}", isbalanced, h.val);
            return isbalanced;
        }

        private int covers(Node<T> root, Node<T> p, Node<T> q)
        {
            if (root == null)
                return 0;

            int ret = 0;
            if (root == p || root == q)
                ret += 1;

            ret += covers(root.left, p, q);
            if (ret == 2)
                return ret;
            return ret + covers(root.right, p, q);
        }
        
        private Node<T> LCAForNonBST(Node<T> root, Node<T> p, Node<T> q)
        {
            if (root == null || root == p || root == q)
                return null;

            int num_left = covers(root.left, p, q);

            if (num_left == 2)
            {
                if (root.left == p || root.left == q)
                    return root;
                else return LCAForNonBST(root.left, p, q);
            }
            else if (num_left == 1)
            {
                if (root == p)
                    return p;
                else if (root == q)
                    return q;
            }
            int num_right = covers(root.right, p, q);
            if (num_right == 2)
            {
                if (root.right == p || root.right == q)
                    return root;
                else return LCAForNonBST(root.right, p, q);
            }
            else if (num_right == 1)
            {
                if (root == p)
                    return p;
                if (root == q)
                    return q;
            }

            if (num_left == 1 && num_right == 1)
                return root;
            else return null;
        }
        
        public Node<T> LCAForNonBST(Node<T> p, Node<T> q)
        {
            return LCAForNonBST(root, p, q);
        }

        private void printSumPath(int[] a, int si, int ei)
        {
            Console.WriteLine("path = ");
            for(int i = si; i<= ei; i++)
                Console.Write(" {0} ", a[i]);
        }

        private void printSumPath(List<int> buf, int si, int ei)
        {
            Console.WriteLine("path = ");            
            for (int i = si; i <= ei; i++)
            {
                Console.Write(" {0} ", buf[i]);
            }
        }

        public void findSum(Node<int> node, List<int> buf, int sum, int level)
        {
            if (node == null)
                return;

            int tmp = sum;
            buf.Add(node.data);
            for (int i = level; i >= 0; i--)
            {
                tmp -= buf[i];
                if (tmp == 0)
                    printSumPath(buf, i, level);
            }
            List<int> c1 = new List<int>(buf);
            List<int> c2 = new List<int>(buf);
            findSum(node.left, c1, sum, level+1);
            findSum(node.right, c2, sum, level+1);
        }

        public bool printAncestorsRecur(Node<T> node, int data)
        {
            if (node == null)
                return false;
            
            if (int.Parse(node.data.ToString()) == data)
                return true;

            if (printAncestorsRecur(node.left, data) || printAncestorsRecur(node.right, data))
            {
                Console.Write(" {0} ", node.data.ToString());
                return true;
            }
            return false;
        }

        public void printAncestorsIter(Node<T> node, int data)
        {
            Stack<Node<T>> stk = new Stack<Node<T>>();
            while (true)
            {
                if(node == null)
                    return;
                
                while (node != null && int.Parse(node.data.ToString()) != data)
                {
                    stk.Push(node);
                    node = node.left;
                }

                if (node != null && int.Parse(node.data.ToString()) == data)
                    break;

                if (stk.Count > 0 && stk.Peek().right == null)
                {
                    node = stk.Pop();

                    while (stk.Count > 0 && stk.Peek().right == node)
                        node = stk.Pop();
                }

                node = (stk.Count > 0) ? stk.Peek().right : null;
            }

            while (stk.Count > 0)
                Console.Write(" {0} ", stk.Pop().data.ToString());
        }

        public Node<T> RemoveKeysInRange(Node<T> node, int min, int max)
        {
            if (node == null)
                return null;

            node.left = RemoveKeysInRange(node.left, min, max);
            node.right = RemoveKeysInRange(node.right, min, max);

            if (int.Parse(node.data.ToString()) < min)
            {
                Node<T> rchild = node.right;
                node = null;
                return rchild;
            }
            if (int.Parse(node.data.ToString()) > max)
                return node.left;

            return node;
        }
        
    }
    
    class Program
    {
        //cracking the coding interview 4.4
        static List<LinkedList<Node<int>>> CreateLinkedListOfNodesAtEachDepth(Tree<int> tree)
        {
            List<LinkedList<Node<int>>> lst = new List<LinkedList<Node<int>>>();
            Node<int> cur = tree.root;
            LinkedList<Node<int>> ll = new LinkedList<Node<int>>();
            ll.AddLast(cur);
            lst.Add(ll);

            while(true)
            {
	            ll = new LinkedList<Node<int>>();	

	            for(int i = 0; i< lst[lst.Count-1].Count; i++)
	            {
                    cur = lst[lst.Count - 1].ElementAt(i);
                    if(cur.left != null)
		            {
			            ll.AddLast(cur.left);
		            }
		            if(cur.right != null)
		            {
			            ll.AddLast(cur.right);
		            }
	             }

                if (ll.Count > 0)
                    lst.Add(ll);
                else
                    break;
            }
            return lst;
        }
        public static int sav;
        static void Main(string[] args)
        {
            Tree<int> tree = ConstrutTreeRandom();
            //tree.InorderRecur();

            LinkedListToBT llbt = new LinkedListToBT();
            LinkedList<int> list = llbt.createList(10);
            Node<int> root = llbt.LLtoBT(list);
            tree.root = root;
            tree.levelorder();
            
            //Node<int> node = tree.RemoveKeysInRange(tree.root, 20, 80);
            //lNode<int> node = GreatTreeListRecursionProblem.treetoList(tree.root);
            //GreatTreeListRecursionProblem.printList(node);
            //Console.Write("\nAncestors Recur = ");
            //tree.printAncestorsRecur(tree.root, sav);
            //Console.Write("\nAncestors Iter = ");
            //tree.printAncestorsIter(tree.root, sav);
            //tree = findSumAnyPath(tree);
            //CreateLinkedListOfNodesAtEachDepth(tree);
            //SortedArrtoMinimalBSTDriver();
            //PropertiesMisc(tree);
            //Traversal(tree);            
            //FunctionsModifyingTree(tree);
            
            Console.ReadLine();
        }

        private static Tree<int> findSumAnyPath(Tree<int> tree)
        {
            Tree<int> Sumtree = new Tree<int>();
            Node<int> n1 = new Node<int>(2);
            Node<int> n2 = new Node<int>(3);
            Node<int> n3 = new Node<int>(-4);
            Node<int> n4 = new Node<int>(3);
            Node<int> n5 = new Node<int>(2);
            Node<int> n6 = new Node<int>(-1);
            n1.left = n2; n2.left = n3; n3.left = n4; n4.left = n5; n5.left = n6; n6.left = null;
            Sumtree.findSum(n1, new List<int>(), 5, 0);
            return Sumtree;
        }

        private static void SortedArrtoMinimalBSTDriver()
        {
            int[] a = { 1, 2, 3, 4 };
            Tree<int> tree = SortedArrToTreeMinHeight(a);

            tree.levelorder();
        }

        //cracking the coding interview 4.3
        static Node<int> SortedArrToTree(int[] a, int start, int end)
        {
            if (start > end)
                return null;

            int mid = start + (end - start) / 2;
            Node<int> node = new Node<int>(a[mid]);
            node.left = SortedArrToTree(a, start, mid - 1);
            node.right = SortedArrToTree(a, mid + 1, end);
            return node;
        }

        static Tree<int> SortedArrToTreeMinHeight(int[] a)
        {
            Tree<int> tree = new Tree<int>();
            tree.root = SortedArrToTree(a, 0, a.Length - 1);
            return tree;
        }
        

        private static Tree<int> ConstrutTreeRandom()
        {
            Random r = new Random();
            Console.WriteLine("Inserting elements = ");
            int val;

            Tree<int> tree = new Tree<int>();

            for (int i = 1; i <= 10; i++)
            {
                val = r.Next(0, 100);
                Console.Write(" {0} ", val);
                tree.insert(val);
                sav = val;
            }
            return tree;
        }

        private static void PropertiesMisc(Tree<int> tree)
        {
            tree.Count();
            tree.height();
            tree.minValue();
            tree.maxValue();
            Console.WriteLine("Is identical = {0}", tree.isIdentical(tree.root, tree.root));
            tree.isTreeBalanced();
        }

        private static void Traversal(Tree<int> tree)
        {
            tree.InorderRecur();
            tree.InorderIter();
            //tree.InorderMorris();

            tree.PreOrderRecur();
            tree.PreorderIter();
            //tree.PreOrderMorris();

            tree.PostOrderRecur();
            tree.PostorderIter();

            tree.levelorder();
            //tree.levelorderBFS();
            //tree.levelorderBFSperline();

            tree.printPaths();
        }

        private static void FunctionsModifyingTree(Tree<int> tree)
        {
            tree.mirrorTree();
            Console.WriteLine("After mirroring the tree: ");
            tree.levelorder();
            Console.WriteLine("After mirroring back the tree: ");
            tree.mirrorTree();
            tree.levelorder();
            Console.WriteLine("After doubling the tree: ");
            tree.doubleTree();
            tree.levelorder();
        }
    }
}
