using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTrees
{
    public class llnode
    {
        public int data { get; set; }
        public llnode next { get; set; }
        public llnode(int data) : this(data, null) { }
        public llnode(int data, llnode next)
        {
            this.data = data;
            this.next = next;
        }
    }
    
    public class LinkedListToBT
    {
        public llnode head { get; set; }

        public LinkedListToBT() : this(null) { }
        public LinkedListToBT(llnode head)
        {
            this.head = head;
        }      

        public llnode CreateList(int size)
        {
            llnode cur = null;
            
            for (int i = 0; i < size; i++)
            {
                cur = new llnode(i);
                cur.next = head;
                head = cur;
            }
            return head;
        }

        public LinkedList<int> createList(int size)
        {
            LinkedList<int> list = new LinkedList<int>();
            for (int i = 0; i < size; i++)
            {
                list.AddLast(i);
            }
            return list;
        }

        public Node<int> LLtoBT(LinkedList<int> list)
        {
            if (list == null)
                return null;
            Node<int> node = new Node<int>(list.First.Value);
            Node<int> root = node;
            Queue<Node<int>> queue = new Queue<Node<int>>();
            queue.Enqueue(node);
            LinkedListNode<int> head = list.First;
            head = head.Next;
            while (head != null)
            {
                node = queue.Dequeue();

                Node<int> left = null; Node<int> right = null;

                left = new Node<int>(head.Value);
                head = head.Next;
                queue.Enqueue(left);

                if (head != null)
                {
                    right = new Node<int>(head.Value);
                    head = head.Next;
                    queue.Enqueue(right);
                }

                node.left = left;
                node.right = right;
                
            }
            return root;
        }
    }
}
