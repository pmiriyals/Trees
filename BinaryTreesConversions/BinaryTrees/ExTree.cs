using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpressionTrees
{
    public class TreeNode
    {
        public char op { get; set; }
        public double val { get; set; }
        public bool isleaf { get; set; }
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }

        public TreeNode(bool isleaf, char op, double val)
        {
            this.isleaf = isleaf;
            this.op = op;
            this.val = val;
            this.left = null;
            this.right = null;
        }

        public string toString()
        {
            return this.isleaf ? this.val.ToString() : this.op.ToString();
        }
    }

    public class ExTree
    {
        public TreeNode root = null;

        public void ExpressionTree(string prefixNot)
        {
            string[] tokens = prefixNot.Split(' ');
            int start = 0;
            root = build(tokens, ref start);
        }

        private TreeNode build(string[] tokens, ref int start)
        {
            if(start >= tokens.Length)
                return null;
            
            bool leaf;
            double val;
            TreeNode node = null;
            
            leaf = double.TryParse(tokens[start], out val);
            if(leaf)
            {
                node = new TreeNode(leaf, '\0', val);
                start++;
            }
            else
            {
                node = new TreeNode(leaf, char.Parse(tokens[start]), 0.0);
                start++;
                node.left = build(tokens, ref start);
                node.right = build(tokens, ref start);
            }
            return node;
        }

        public double Evaluate()
        {
            return root == null ? 0.0 : Evaluate(root);
        }

        private double Evaluate(TreeNode node)
        {
            double result = 0.0;
            if (node.isleaf)
                result = node.val;
            else
            {
                char op = node.op;
                double left, right;

                left = Evaluate(node.left);
                right = Evaluate(node.right);

                switch (op)
                {
                    case '+': result = left + right;
                        break;
                    case '*': result = left * right;
                        break;
                    case '-': result = left - right;
                        break;
                    case '/':
                        if (right != 0)
                            result = left / right;
                        else
                            throw new Exception("division by zero");
                        break;
                    default: Console.WriteLine("unrecognized character: " + op);
                        break;
                }
            }
            return result;
        }

        public void levelorderBFS()
        {
            TreeNode node = root;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            int numnodes;
            int nextlevel = 1;
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                numnodes = nextlevel;
                nextlevel = 0;

                for (int i = 0; i < numnodes; i++)
                {
                    node = queue.Dequeue();
                    Console.Write(" {0} ", node.toString());

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

        public void inorder(TreeNode node)
        {
            if (node == null)
                return;

            inorder(node.left);
            Console.Write(" {0} ", node.toString());
            inorder(node.right);
        }
    }
}
