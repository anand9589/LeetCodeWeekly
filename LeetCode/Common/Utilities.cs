namespace Common
{
    public static class Utilities
    {
        public static ListNode BuildListNode(int[] arr)
        {
            ListNode dummyNode = new ListNode(0, null);
            ListNode temp = dummyNode;
            for (int i = 0; i < arr.Length; i++)
            {
                temp.next = new ListNode(arr[i]);
                temp = temp.next;
            }

            return dummyNode.next;
        }
    }
}
