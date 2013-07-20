using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTree
{
    class Construction
    {
        //Construct tree from given Inorder and Preorder traversal
        //Time: O(n2)
        private static int preIndex = 0;
        public static Node InorderAndPreorderToTree(int[] pre, int[] inorder, int instrt, int inend)
        {
            if (instrt > inend)
                return null;

            Node node = new Node(pre[preIndex++]);

            if (instrt == inend)
                return node;

            int inIndex;
            for (inIndex = instrt; inIndex <= inend; inIndex++)
            {
                if (inorder[inIndex] == node.data)
                    break;
            }

            node.left = InorderAndPreorderToTree(pre, inorder, instrt, inIndex - 1);
            node.right = InorderAndPreorderToTree(pre, inorder, inIndex + 1, inend);
            return node;
        }

        public static void driver()
        {
            int[] inorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] preorder = { 5, 4, 2, 1, 3, 6, 8, 7, 9, 10 };

            Node root = InorderAndPreorderToTree(preorder, inorder, 0, inorder.Length - 1);
            BST tree = new BST();
            tree.root = root;
            Traversals.levelorder(tree);
            Traversals.inorderIter(tree);
            Traversals.preorderIter(tree);
        }
    }
}
