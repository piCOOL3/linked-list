/*
https://leetcode.com/problems/reverse-linked-list/submissions/
Reverse a singly linked list.

Example:

Input: 1->2->3->4->5->NULL
Output: 5->4->3->2->1->NULL
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_206_Reverse_Linked_ListCS
{
      public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

    class Program
    {
       public static ListNode  build_singlylinkedlist_allocatememory(int[] build_singlylinkedlist, int first_element , int last_element)
        {
            // helper function to allocate memory to the node 

            ListNode head = null;

            if ((build_singlylinkedlist.Count() != 0) && (first_element <= last_element))
            {
                // create a new node to store value 
                head = new ListNode(build_singlylinkedlist[first_element]);
                head.next = build_singlylinkedlist_allocatememory(build_singlylinkedlist, first_element + 1, last_element);
                return head;
            }
            return head;
        }
        public static ListNode build_singlylinkedlist (int[] build_singlylinkedlist)
            {
            // build the linked-list recursively 

                ListNode head = null;
                // declare a ListNode referance to store the start  to the node 
                int first_element = build_singlylinkedlist.GetLowerBound(0);
                int last_element  = build_singlylinkedlist.GetUpperBound(0);
                // calculate the start and end index of the array 

                head = build_singlylinkedlist_allocatememory(build_singlylinkedlist, first_element, last_element);
                // call the helper function to allocate memory to the linked node .
            
                return head; 
            }

        public static void traverse_linkedlist(ListNode head)
        {
            ListNode temp_head = head; 
            // declare a referance to the head node for manipulation 
            while(temp_head != null)
            {
                // print the data if the node is not null 
                Console.Write(temp_head.val + " ");
                temp_head = temp_head.next;
            }
        }

        public static  ListNode ReverseList(ListNode head)
        {

            // 1(head)->2->3->4->5->NULL
            ListNode current, previous, next;
            current = head;
            previous = null;
            next = null;
           // null(previous) --->1(head)(current)--->2(next)--->3---->4---->5---->NULL

            while (current != null)
            {
                // before we break the link , we should move the next pointer 
                next = current.next;
                // 1(head)--->2(next)--->3->4---->5---->NULL

               
                current.next = previous;
                // null(previous) <------1(head)(current)   2(next)--->3---->4---->5---->NULL

                //move the pointers forward 
                previous = current;
                // null <------1(head)(current)(previous)   2(next)--->3---->4---->5---->NULL

                current = next;
                // null <------1(head)(previous)   2(next)(current)--->3---->4---->5---->NULL
            }
            // set the head pointer to previous after all the nodes have been reversed
            head = previous;
            return head;
        }

        static void Main(string[] args)
        {
            // 1. build the list 
            // 2. traverse the list to check if properly created 
            // 3. reverse the list using a function 
            // 4. traverse the list to check the reversed list 

            int[] linked_arr_collection = new int[] { 1 ,2 ,3 ,4 ,5 };
            // given array containing the data 

            //int[] linked_arr_collection = new int[] { 1, 2 };

            ListNode head = build_singlylinkedlist(linked_arr_collection);
            // call to the function to build the singly linked list in memory

            Console.WriteLine("the nodes in the linked list : ");
            traverse_linkedlist(head);
            // traverse the list 
            Console.WriteLine();

            head = ReverseList(head);
            // reverse the list iteratively.

           
            Console.WriteLine("the nodes in the linked list : ");
            // traverse the linked list after the reverse operation 
            traverse_linkedlist(head);
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
