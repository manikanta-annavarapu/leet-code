/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public ListNode MiddleNode(ListNode head)
    {
        ListNode curr = head;
        List<ListNode> nodesList = new List<ListNode>();
        int count = 0;

        while (curr != null)
        {
            nodesList.Add(curr);
            count++;
            curr = curr.next;
        }

        return nodesList.ElementAt(count / 2);

    }
}