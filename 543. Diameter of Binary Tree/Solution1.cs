/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    int max = 0;
    public int DiameterOfBinaryTree(TreeNode root)
    {
        LengthOfNode(root);
        return max;
    }

    private int LengthOfNode(TreeNode node)
    {
        if (node == null) return -1;
        int left = LengthOfNode(node.left);
        int right = LengthOfNode(node.right);
        max = Math.Max(max, left + right + 2);
        return Math.Max(left, right) + 1;
    }
}
