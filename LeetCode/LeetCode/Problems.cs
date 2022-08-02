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
                    while (lowIndex < highIndex && nums[lowIndex + 1] == nums[lowIndex])
                    {
                        lowIndex++;
                    }
                    lowIndex++;
                }
                else if (target < nums[highIndex])
                {
                    while (highIndex > lowIndex && nums[highIndex - 1] == nums[highIndex])
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
            ListNode firstNode = new ListNode(-101, head);
            ListNode temp = firstNode;

            while (head != null)
            {
                temp.next = head;

                while (head.next != null && head.val == head.next.val)
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

        #region Problem 315
        public IList<int> CountSmaller(int[] nums)
        {
            IList<int> result = new List<int>();

            int[][] matrix = new int[nums.Length][];
            for (int i = 0; i < nums.Length; i++)
            {
                matrix[i] = new int[nums.Length];
            }

            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = matrix[i - 1][j];
                    if (nums[j] > nums[i])
                    {
                        matrix[i][j] = matrix[i][j] + 1;
                    }
                }
            }

            return result;
        }
        #endregion

        #region July 24 2022
        public char RepeatedCharacter(string s)
        {
            List<char> result = new List<char>();
            int i = 0;
            while (i < s.Length && !result.Contains(s[i]))
            {
                result.Add(s[i]);
                i++;
            }
            return s[i];
        }

        public int EqualPairs(int[][] grid)
        {
            int result = 0;
            int[][] rows = new int[grid.Length][];
            int[][] cols = new int[grid.Length][];

            for (int i = 0; i < grid.Length; i++)
            {
                rows[i] = new int[grid[i].Length];
                for (int j = 0; j < grid.Length; j++)
                {
                    rows[i][j] = grid[i][j];
                }
            }

            for (int i = 0; i < grid.Length; i++)
            {
                cols[i] = new int[rows[i].Length];
                for (int j = 0; j < grid.Length; j++)
                {
                    cols[i][j] = grid[j][i];
                }
            }

            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < cols.Length; j++)
                {
                    bool match = true;
                    for (int k = 0; k < cols[i].Length; k++)
                    {
                        if (rows[i][k] != cols[j][k])
                        {
                            match = false; break;
                        }
                    }
                    if (match) result++;
                }
            }

            return result;
        }

        #endregion
    }
}
