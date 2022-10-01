using BinaryTreeProblems;
using System.Text;

namespace LeetCode
{
    public class Problems
    {
        #region Problem 19
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode node = new ListNode(-1,head);
            int counter = 0;
            ListNode temp = node.next;

            while (temp != null)
            {
                if(counter+1 == n)
                {
                    ListNode listNode = temp.next;

                }
                temp = temp.next;
                counter++;
            }


            return node.next;
        }
        #endregion

        #region Problem 42
        public int Trap(int[] height)
        {
            int[] previous = previousMaxElement(height);
            int[] next = nextMaxElement(height);
            int result = 0;
            for (int i = 0; i < height.Length; i++)
            {
                if (previous[i] == -1 || next[i] == -1) continue;

                int vol = Math.Min(height[previous[i]], height[next[i]]);

                result += vol - height[i];
            }
            return result;
        }

        private int[] nextMaxElement(int[] height)
        {
            int[] next = new int[height.Length];

            Stack<int> stack = new Stack<int>();
            stack.Push(height.Length - 1);
            for (int i = height.Length - 1; i >= 0; i--)
            {
                if (height[stack.Peek()] > height[i])
                {
                    next[i] = stack.Peek();
                }
                else
                {
                    stack.Push(i);
                    next[i] = -1;
                }
            }


            return next;
        }

        private int[] previousMaxElement(int[] height)
        {
            int[] previous = new int[height.Length];
            Stack<int> stack = new Stack<int>();
            previous[0] = -1;
            stack.Push(0);
            for (int i = 1; i < height.Length; i++)
            {
                if (height[stack.Peek()] > height[i])
                {
                    previous[i] = stack.Peek();
                }
                else
                {
                    stack.Push(i);
                    previous[i] = -1;
                }
            }
            return previous;
        }
        #endregion

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

        #region Problem 88
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            for (int i = nums1.Length-1; i >= 0; i--)
            {
                if (n == 0)
                {
                    nums1[i]=nums1[m-1];
                    m--;
                }
                else if (m == 0)
                {
                    nums1[i] = nums2[n - 1];
                    n--;

                }
                else if(nums1[m-1] > nums2[n - 1])
                {
                    nums1[i] = nums1[m-1];
                    m--;
                }
                else
                {
                    nums1[i] = nums2[n - 1];
                    n--;
                }
            }
        }
        #endregion

        #region Problem 108
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums.Length == 0) return null;

            if(nums.Length == 1) return new TreeNode(nums[0],null,null);

            int left = 0;
            int right = nums.Length - 1;
            int mid = (left + right)/2;

            TreeNode root = new TreeNode(nums[mid], null, null);

            root.Left = SortedArrayToBST(nums.Take(mid).ToArray());
            root.Right = SortedArrayToBST(nums.Skip(mid+1).ToArray());

            return root;
        }
        #endregion

        #region Problem 110
        public bool IsBalanced(TreeNode root)
        {
            if(root == null) return true;

            if (Math.Abs(IsBalancedHeight(root.Left) - IsBalancedHeight(root.Right)) > 1) return false;

            return IsBalanced(root.Left) && IsBalanced(root.Right);
        }

        private int IsBalancedHeight(TreeNode node)
        {
            return 1 + Math.Max(IsBalancedHeight(node.Left), IsBalancedHeight(node.Right));
        }
        #endregion

        #region Problem 118
        public IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> list = new List<IList<int>>();

            for (int i = 1; i <= numRows; i++)
            {
                var row = new int[i];
                row[0] = 1;
                row[i-1] = 1;
                var prev = list.LastOrDefault();
                for (int j = 1; j < i-1; j++)
                {
                    row[j] = prev[j] + prev[j-1];
                }
                list.Add(row);
            }

            return list;
        }
        #endregion

        #region Problem 119
        public IList<int> GetRow(int rowIndex)
        {
            IList<int> list = new List<int>();
            for (int i = 1; i <= rowIndex+1; i++)
            {
                var row = new int[i];
                row[0] = 1;
                row[i - 1] = 1;
               
                for (int j = 1; j < i - 1; j++)
                {
                    row[j] = list [j] + list[j - 1];
                }
                list = row;
            }

            return list;
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

        #region Problem 336
        public IList<IList<int>> PalindromePairs(string[] words)
        {
            IList<IList<int>> result = new List<IList<int>>();
            for (int i = 0; i < words.Length - 1; i++)
            {
                for (int j = i + 1; j < words.Length; j++)
                {
                    if (isPalindrome(words[i] + words[j]))
                    {
                        result.Add(new List<int>() { i, j });
                    }
                    if (isPalindrome(words[j] + words[i]))
                    {
                        result.Add(new List<int>() { j, i });
                    }
                }
            }
            return result;
        }

        private bool isPalindrome(string word)
        {
            int startIndex = 0, endIndex = word.Length - 1;

            while (startIndex < endIndex)
            {
                if (word[startIndex++] != word[endIndex--]) return false;
            }
            return true;

        }
        #endregion

        #region Problem 838
        public string PushDominoes(string dominoes)
        {
            char[] chs = dominoes.ToCharArray();

            int n = chs.Length;

            int[] forces = new int[n];
            int force = 0;
            for (int i = 0; i < n; i++)
            {
                if (chs[i] == 'R')
                {
                    force = n;
                }
                else if (chs[i] == 'L')
                {
                    force = 0;
                }
                else
                {
                    force = Math.Max(force - 1, 0);
                }
                forces[i] += force;
            }

            force = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                if (chs[i] == 'L')
                {
                    force = n;
                }
                else if (chs[i] == 'R')
                {
                    force = 0;
                }
                else
                {
                    force = Math.Max(force - 1, 0);
                }
                forces[i] -= force;
            }
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                if (forces[i] == 0) stringBuilder.Append('.');
                else if (forces[i] > 0) stringBuilder.Append('R');
                else if (forces[i] < 0) stringBuilder.Append('L');
            }
            return stringBuilder.ToString();
        }
        #endregion

        #region Problem 1647
        public int MinDeletions(string s)
        {
            int i = 0;
            Dictionary<char, int> map = new Dictionary<char, int>();
            while (i < s.Length)
            {
                if (!map.ContainsKey(s[i]))
                {
                    map.Add(s[i], 0);
                }

                map[s[i]]++;

                i++;
            }


            var lst = map.OrderByDescending(x => x.Value).Select(x => x.Value).ToArray();

            Stack<int> stack = new Stack<int>();
            stack.Push(lst[0]);
            int result = 0;
            for (int j = 1; j < lst.Count(); j++)
            {
                if (stack.Peek() == 1)
                { while (lst[j] > 0) { result++; lst[j]--; } }
                else
                {
                    if (lst[j] >= stack.Peek())
                    {
                        int diff = lst[j] - stack.Peek() + 1;
                        result += diff;
                        lst[j] = stack.Peek() - 1;
                    }
                    stack.Push(lst[j]);
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
