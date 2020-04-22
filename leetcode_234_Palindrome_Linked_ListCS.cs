/* 
https://leetcode.com/problems/palindrome-linked-list
Given a singly linked list, determine if it is a palindrome.

Example 1:

Input: 1->2
Output: false
Example 2:

Input: 1->2->2->1
Output: true

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_234_Palindrome_Linked_ListCS
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

        /*
         * algorithm : 
          
            base case: 
                1. null node or single node -----> true [palindrome]

            recursive case 
                visit the list recursively till the very end 
                compare the last node and firt node and return the response  to the calling statement.
         */

        public static ListNode root;
        // referance to the  head to make the comparisions 

        public  static bool IsPalindrome(ListNode head)
        {
            root = head;
            if (head == null)
            {
                return true;
            }
            else
            {
                bool flag =  _isPalindrome(head);
                return flag;
            }
        }


        public static Boolean _isPalindrome(ListNode head)
        {
            Boolean flag = true;
            if (head.next != null)
            {
                flag = _isPalindrome(head.next);
            }
            if (flag && root.val == head.val)
            {
                root = root.next;
                return true;
            }
            return false;
        }


        static void Main(string[] args)
        {
            int[] linked_arr_collection = new int[] { 1, 2, 3, 2, 1 };
            // given array containing the data for the linked list 

            ListNode head = build_singlylinkedlist(linked_arr_collection);
            // call to the function to build the singly linked list in memory

            Console.WriteLine("the nodes in the linked list : ");
            traverse_linkedlist(head);
            // traverse the list 
            Console.WriteLine();

           bool flag = IsPalindrome(head);
            // call the function to check weather the given linked linked is a valid pallindrome or not a pallindrome 

            if (flag == true)
            {
                Console.WriteLine("linked list a valid pallindrome");
            }
            else
            {
                Console.WriteLine("linked list not a valid pallindrome");
            }
            Console.ReadLine();
        }
    }
}




