namespace LeetCode
{
    public class Problems
    {
        #region Problem 80
        public int RemoveDuplicates(int[] nums)
        {
            int i = 0;
            int count = 0;
            int lastNumber = int.MaxValue;
            for (int j = 0; j < nums.Length; j++)
            {
                if (lastNumber != nums[j]) count = 0;
                if (count < 2)
                {
                    nums[i] = nums[j];
                    i++;
                    lastNumber = nums[j];
                }
            }

            return i;
        }
        #endregion

        #region Problem 81
        public bool Search(int[] nums, int target)
        {
            int lowIndex = 0;
            int highIndex = nums.Length - 1;

            while (lowIndex <= highIndex)
            {

                if (nums[lowIndex] == target) return true;
                if (nums[highIndex] == target) return true;

                if (target > nums[lowIndex])
                {
                    while (lowIndex<highIndex && nums[lowIndex+1] == nums[lowIndex])
                    {
                        lowIndex++;
                    }
                    lowIndex++;
                }
                else if(target < nums[highIndex])
                {
                    while (highIndex>lowIndex && nums[highIndex-1]==nums[highIndex])
                    {
                        highIndex--;
                    }
                    highIndex--;
                }
                else
                {
                    break;
                }
            }
            return false;
        }
        #endregion

        #region Problem 82
        public ListNode DeleteDuplicates_82(ListNode head)
        {
            ListNode firstNode = new ListNode(-101, head);
            ListNode temp = firstNode;
            while (head != null)
            {
                bool skip = false;
                if (head.next != null && head.val == head.next.val)
                {
                    while (head.next != null && head.val == head.next.val)
                    {
                        head = head.next;
                    }
                    temp.next = head.next;
                }
                else
                {
                    temp = temp.next;
                }
                head = head.next;

            }

            return firstNode.next;
        }
        #endregion

        #region Problem 83
        public ListNode DeleteDuplicates(ListNode head)
        {
            ListNode firstNode = new ListNode(-101,head);
            ListNode temp = firstNode;

            while (head!=null)
            {
                temp.next = head;

                while (head.next!=null && head.val == head.next.val)
                {
                    head = head.next;
                }

                head = head.next;
                temp = temp.next;
            }

            return firstNode.next;
        }
        #endregion

        #region Problem 86
        public ListNode Partition(ListNode head, int x)
        {
            ListNode smallNode = new ListNode(0);
            ListNode higherNode = new ListNode(0);

            ListNode smallHead = smallNode;
            ListNode higherHead = higherNode;

            while (head != null)
            {
                if (head.val < x)
                {
                    smallHead.next = head;
                    smallHead = smallHead.next;
                }
                else
                {
                    higherHead.next = head;
                    higherHead = higherHead.next;
                }
                head = head.next;
            }

            higherHead.next = null;
            smallHead.next = higherNode.next;

            return smallHead.next;
        }
        #endregion


    }
}
