/* 
 * https://leetcode.com/problems/reverse-linked-list-ii/
Reverse a linked list from position m to n. Do it in one-pass.

Note: 1 ≤ m ≤ n ≤ length of list.

Example:

Input: 1->2->3->4->5->NULL, m = 2, n = 4
Output: 1->4->3->2->5->NULL

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_92_Reverse_Linked_List_II_CS
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    class Program
    {
        public static ListNode build_singlylinkedlist_allocatememory(int[] build_singlylinkedlist, int first_element, int last_element)
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
        public static ListNode build_singlylinkedlist(int[] build_singlylinkedlist)
        {
            // build the linked-list recursively 

            ListNode head = null;
            // declare a ListNode referance to store the start  to the node 
            int first_element = build_singlylinkedlist.GetLowerBound(0);
            int last_element = build_singlylinkedlist.GetUpperBound(0);
            // calculate the start and end index of the array 

            head = build_singlylinkedlist_allocatememory(build_singlylinkedlist, first_element, last_element);
            // call the helper function to allocate memory to the linked node .

            return head;
        }

        public static void traverse_linkedlist(ListNode head)
        {
            ListNode temp_head = head;
            // declare a referance to the head node for manipulation 
            while (temp_head != null)
            {
                // print the data if the node is not null 
                Console.Write(temp_head.val + " ");
                temp_head = temp_head.next;
            }
        }

        public static ListNode ReverseBetween(ListNode head, int m, int n)
        

        static void Main(string[] args)
        {
            int[] linked_arr_collection = new int[] { 1, 2, 3, 4, 5 };
            // given array containing the data 

            ListNode head = build_singlylinkedlist(linked_arr_collection);
            // call to the function to build the singly linked list in memory

            Console.WriteLine("the nodes in the linked list : ");
            traverse_linkedlist(head);
            // traverse the list 
            Console.WriteLine();
            

            Console.Write("enter the start index of the nodes to be reversed:");
            int start_index = Convert.ToInt32(Console.ReadLine());
            Console.Write("enter the  end index of the nodes to be reversed:");
            int end_index = Convert.ToInt32(Console.ReadLine());

            head = ReverseBetween(head, start_index, end_index);

            traverse_linkedlist(head);
            // traverse the list 
            Console.WriteLine();

            Console.ReadLine();
        }

    }
}


