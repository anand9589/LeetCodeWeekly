using Common;
using System.Text;

namespace LeetCode
{
    public class Problems
    {
        #region Problem 19
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode node = new ListNode(-1, head);
            int counter = 0;
            ListNode temp = node.next;

            while (temp != null)
            {
                if (counter + 1 == n)
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

        #region Problem 79
        bool[][] visited_WordExists;
        public bool Exist(char[][] board, string word)
        {
            visited_WordExists = new bool[board.Length][];
            for (int i = 0; i < board.Length; i++)
            {
                visited_WordExists[i] = new bool[board[i].Length];
            }
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == word[0] && searchWord(i, j, 0, word, board))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool searchWord(int i, int j, int index, string word, char[][] board)
        {
            if (index == word.Length) return true;


            if (i < 0 || i >= board.Length || j < 0 || j >= board[i].Length || word[index] != board[i][j] || visited_WordExists[i][j]) return false;

            visited_WordExists[i][j] = true;

            if (
                searchWord(i, j + 1, index + 1, word, board) ||
                searchWord(i, j - 1, index + 1, word, board) ||
                searchWord(i + 1, j, index + 1, word, board) ||
                searchWord(i - 1, j, index + 1, word, board)
                )
            {
                return true;
            }

            visited_WordExists[i][j] = false;
            return false;

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
            for (int i = nums1.Length - 1; i >= 0; i--)
            {
                if (n == 0)
                {
                    nums1[i] = nums1[m - 1];
                    m--;
                }
                else if (m == 0)
                {
                    nums1[i] = nums2[n - 1];
                    n--;

                }
                else if (nums1[m - 1] > nums2[n - 1])
                {
                    nums1[i] = nums1[m - 1];
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

        #region Problem 92. Reverse Linked List II
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            if (left == right) return head;

            ListNode dummy = new ListNode(-1, head);
            int counter = 0;
            ListNode temp = dummy;
            while (counter < left - 1)
            {
                temp = temp.next;
                counter++;
            }
            Stack<ListNode> stack = new Stack<ListNode>();
            ListNode n1 = temp.next;
            while (counter < right)
            {
                stack.Push(n1);
                n1 = n1.next;
                counter++;
            }

            while (stack.Count() > 0)
            {
                temp.next = stack.Pop();
                temp = temp.next;
            }

            temp.next = n1;
            return dummy.next;
        }
        #endregion

        #region Problem 93. Restore IP Addresses
        public IList<string> RestoreIpAddresses(string s)
        {
            IList<string> ipAddresses = new List<string>();
            if (s.Length < 4) return ipAddresses;
            int n = s.Length;

            for (int i = 1; i <= 3; i++)
            {
                string[] ipAddrPart = new string[4];

                ipAddrPart[0] = s.Substring(0, i);

                if (!validAddressRange(ipAddrPart[0])) continue;

                for (int j = 1; j <= 3; j++)
                {
                    if (i + j >= n) break;
                    ipAddrPart[1] = s.Substring(i, j);

                    if (!validAddressRange(ipAddrPart[1])) continue;

                    for (int k = 1; k <= 3; k++)
                    {
                        if (i + j + k >= n) break;
                        ipAddrPart[2] = s.Substring(i + j, k);
                        ipAddrPart[3] = s.Substring(i + j + k);

                        if (validAddressRange(ipAddrPart[2]) && validAddressRange(ipAddrPart[3]))
                        {
                            ipAddresses.Add(string.Join('.', ipAddrPart));
                        }

                    }
                }
            }


            return ipAddresses;
        }

        private bool validAddressRange(string s)
        {
            return !(s.Length < 1 || s.Length > 3 || int.Parse(s) > 255 || (s.Length > 1 && s.StartsWith('0')));
        }
        #endregion

        #region Problem 95. Unique Binary Search Trees II
        public IList<TreeNode> GenerateTrees(int n)
        {
            return generateTree_helper(1, n);
        }

        private IList<TreeNode> generateTree_helper(int left, int right)
        {
            IList<TreeNode> treeNodes = new List<TreeNode>();
            if (left >= right)
            {
                if (left == right)
                {
                    TreeNode treeNode = new TreeNode(left, null, null);
                    treeNodes.Add(treeNode);
                }
                else
                {
                    treeNodes.Add(null);
                }
                return treeNodes;
            }

            for (int i = left; i <= right; i++)
            {
                IList<TreeNode> leftNodes = generateTree_helper(left, i - 1);
                IList<TreeNode> rightNodes = generateTree_helper(i + 1, right);

                foreach (TreeNode leftNode in leftNodes)
                {
                    foreach (TreeNode rightNode in rightNodes)
                    {
                        TreeNode node = new TreeNode(i, leftNode, rightNode);
                        treeNodes.Add(node);
                    }
                }
            }


            return treeNodes;
        }
        #endregion

        #region Problem 96. Unique Binary Search Trees
        public int NumTrees(int n)
        {
            int[] nums = new int[n + 1];

            nums[0] = 1;
            nums[1] = 1;

            for (int i = 2; i <= n; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    nums[i] += nums[j] * nums[i - j - 1];
                }
            }

            return nums[n];
        }

        //private int NumTrees_Helper(int left, int right)
        //{
        //    if (n)
        //        int count = 0;
        //    if (left >= right)
        //    {
        //        if (left == right)
        //        {
        //            count++;
        //        }
        //        return count;
        //    }

        //    for (int i = left; i <= right; i++)
        //    {
        //        int leftNodeCount = NumTrees_Helper(left, i - 1);
        //        int rightNodeCount = NumTrees_Helper(i + 1, right);

        //        count = leftNodeCount + rightNodeCount;
        //    }
        //    return count;
        //}
        #endregion

        #region Problem 97. Interleaving String
        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length) return false;
            return checkInterleaving(s1, s2, s3, 0, 0, 0);
        }

        private bool checkInterleaving(string s1, string s2, string s3, int p1, int p2, int p3)
        {
            if (s3.Length == p3 && s1.Length == p1 && s2.Length == p2) return true;

            bool first = false, second = false;

            if (p1 == s1.Length) return s2[p2] == s3[p3] ? checkInterleaving(s1, s2, s3, p1, p2 + 1, p3 + 1) : false;
            if (p2 == s2.Length) return s1[p1] == s3[p3] ? checkInterleaving(s1, s2, s3, p1 + 1, p2, p3 + 1) : false;

            if (s1[p1] == s3[p3])
            {
                first = checkInterleaving(s1, s2, s3, p1 + 1, p2, p3 + 1);
            }

            if (s2[p2] == s3[p3])
            {
                second = checkInterleaving(s1, s2, s3, p1, p2 + 1, p3 + 1);
            }

            return first || second;
        }
        #endregion

        #region Problem 98. Validate Binary Search Tree
        public bool IsValidBST(TreeNode root)
        {
            long minval = int.MinValue;
            minval--;

            long maxval = int.MaxValue;
            maxval++;
            return isValidBST_Helper(root, minval, maxval);
        }


        private bool isValidBST_Helper(TreeNode root, long minval, long maxval)
        {
            if (root == null) return true;


            return root.val < maxval
                && root.val > minval
                && isValidBST_Helper(root.left, minval, root.val)
                && isValidBST_Helper(root.right, root.val, maxval);
        }

        #endregion

        #region Problem 106. Construct Binary Tree from Inorder and Postorder Traversal
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (inorder.Length == 0 && postorder.Length == 0) return null;

            int rootVal = postorder[postorder.Length - 1];
            TreeNode root = new TreeNode(rootVal, null, null);
            if (inorder.Length == 1 && postorder.Length == 1) return root;

            int[] inorder1, postorder1, inorder2, postorder2;

            int indexRootVal1 = Array.IndexOf(inorder, rootVal);

            inorder1 = inorder.Take(indexRootVal1).ToArray();
            postorder1 = postorder.Take(indexRootVal1).ToArray();

            inorder2 = inorder.Skip(indexRootVal1 + 1).ToArray();
            postorder2 = postorder.Skip(indexRootVal1).Take(inorder2.Length).ToArray();


            root.left = BuildTree(inorder1, postorder1);
            root.right = BuildTree(inorder2, postorder2);

            return root;
        }
        #endregion

        #region Problem 108
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums.Length == 0) return null;

            if (nums.Length == 1) return new TreeNode(nums[0], null, null);

            int left = 0;
            int right = nums.Length - 1;
            int mid = (left + right) / 2;

            TreeNode root = new TreeNode(nums[mid], null, null);

            root.left = SortedArrayToBST(nums.Take(mid).ToArray());
            root.right = SortedArrayToBST(nums.Skip(mid + 1).ToArray());

            return root;
        }
        #endregion

        #region Problem 109. Convert Sorted List to Binary Search Tree
        public TreeNode SortedListToBST(ListNode head)
        {

            if (head == null) return null;

            ListNode mid = getMidNode(head);
            TreeNode root = new TreeNode(mid.val, null, null);

            if (mid != head)
            {

                root.left = SortedListToBST(head);
                root.right = SortedListToBST(mid.next);
            }

            return root;
        }

        private ListNode getMidNode(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;
            ListNode prev = head;

            while (fast != null && fast.next != null)
            {
                prev = slow;
                slow = slow.next;
                fast = fast.next.next;
            }

            if (prev != null)
            {
                prev.next = null;
            }

            return slow;
        }
        #endregion

        #region Problem 110
        public bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;

            if (Math.Abs(IsBalancedHeight(root.left) - IsBalancedHeight(root.right)) > 1) return false;

            return IsBalanced(root.left) && IsBalanced(root.right);
        }

        private int IsBalancedHeight(TreeNode node)
        {
            return 1 + Math.Max(IsBalancedHeight(node.left), IsBalancedHeight(node.right));
        }
        #endregion

        #region Problem 113. Path Sum II
        public IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            IList<IList<int>> result = new List<IList<int>>();

            findPaths(root, targetSum, new List<int>(), result);
            return result;
        }

        private void findPaths(TreeNode root, int targetSum, List<int> list, IList<IList<int>> result)
        {
            if (root == null || root.val > targetSum) return;

            list.Add(root.val);

            if (targetSum - root.val == 0 && root.left == null && root.right == null)
            {
                result.Add(new List<int>(list));
            }
            else
            {
                findPaths(root.left, targetSum - root.val, list, result);
                findPaths(root.right, targetSum - root.val, list, result);
            }
            list.RemoveAt(list.Count - 1);
        }
        #endregion

        #region Problem 114. Flatten Binary Tree to Linked List
        public void Flatten(TreeNode root)
        {
            if (root != null)
            {
                while (root != null)
                {
                    if (root.left != null)
                    {
                        TreeNode left = root.left;
                        TreeNode current = left;

                        while (current.right != null)
                        {
                            current = current.right;
                        }
                        current.right = root.right;

                        root.left = null;
                        root.right = left;
                    }
                    root = root.right;
                }
            }
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
                row[i - 1] = 1;
                var prev = list.LastOrDefault();
                for (int j = 1; j < i - 1; j++)
                {
                    row[j] = prev[j] + prev[j - 1];
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
            for (int i = 1; i <= rowIndex + 1; i++)
            {
                var row = new int[i];
                row[0] = 1;
                row[i - 1] = 1;

                for (int j = 1; j < i - 1; j++)
                {
                    row[j] = list[j] + list[j - 1];
                }
                list = row;
            }

            return list;
        }
        #endregion

        #region Problem 120. Triangle
        public int MinimumTotal(IList<IList<int>> triangle)
        {

            for (int i = 1; i < triangle.Count; i++)
            {
                for (int j = 0; j < triangle[i].Count; j++)
                {
                    int add = 0;
                    if (j == 0)
                    {
                        add = triangle[i - 1][j];
                    }
                    else if (j == triangle[i].Count - 1)
                    {
                        add = triangle[i - 1][j - 1];
                    }
                    else
                    {
                        add = Math.Min(triangle[i - 1][j], triangle[i - 1][j - 1]);
                    }
                    triangle[i][j] += add;
                }
            }
            return triangle.Last().Min();
        }
        #endregion

        #region Problem 121
        public int MaxProfit(int[] prices)
        {
            int[] nextMax = nextMaxElement_MaxProfit(prices);
            int result = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                if (nextMax[i] == -1) continue;

                result = Math.Max(result, prices[nextMax[i]] - prices[i]);
            }
            return result;
        }

        private int[] nextMaxElement_MaxProfit(int[] input)
        {
            int[] output = new int[input.Length];
            Stack<int> stack = new Stack<int>();
            stack.Push(input.Length - 1);
            output[output.Length - 1] = -1;
            for (int i = input.Length - 2; i >= 0; i--)
            {
                if (input[stack.Peek()] < input[i])
                {
                    stack.Push(i);
                    output[i] = -1;
                }
                else
                {
                    output[i] = stack.Peek();
                }
            }

            return output;
        }
        #endregion

        #region Problem 125
        public bool IsPalindrome(string s)
        {
            s = new string(s.ToLower().Where(x => (x >= 'a' && x <= 'z') || (x >= '0' && x <= '9')).ToArray());

            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                if (s[left] != s[right]) return false;
                left++;
                right--;
            }
            return true;
        }
        #endregion

        #region Problem 128. Longest Consecutive Sequence
        public int LongestConsecutive(int[] nums)
        {
            Dictionary<int, int> dct = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!dct.ContainsKey(nums[i]))
                {
                    dct.Add(nums[i], 1);
                }
            }

            IList<int> list = new List<int>();
            foreach (var item in dct.Keys)
            {
                if (dct.ContainsKey(item - 1))
                {
                    dct[item] = 0;
                }
                else
                {
                    list.Add(item);
                }
            }
            int result = 0;
            foreach (var item in list)
            {
                int counter = 1;
                int num = item;
                while (dct.ContainsKey(++num))
                {
                    counter++;
                }

                result = counter <= result ? result : counter;
            }

            return result;
        }

        #endregion

        #region Problem 129. Sum Root to Leaf Numbers
        public int SumNumbers(TreeNode root)
        {
            if (root == null) return 0;

            return calculateSum(root, 0);
        }

        private int calculateSum(TreeNode root, int sum)
        {
            if (root == null) return 0;
            if (root.left == null && root.right == null) return sum + root.val;

            sum += root.val;

            return calculateSum(root.left, sum * 10) + calculateSum(root.right, sum * 10);
        }
        #endregion

        #region Problem 130. Surrounded Regions
        public void Solve(char[][] board)
        {
            bool[][] visited = new bool[board.Length][];
            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = new bool[board[i].Length];

            }


            for (int i = 1; i < board.Length - 1; i++)
            {
                for (int j = 1; j < board[i].Length - 1; j++)
                {
                    if (board[i][j] == 'O')
                    {
                        Queue<(int, int)> queue = new Queue<(int, int)>();
                        //queue.Enqueue((i, j));
                        helper_130(board, visited, queue, i, j);
                    }
                }
            }
        }

        private bool helper_130(char[][] board, bool[][] visited, Queue<(int, int)> queue, int i, int j)
        {
            if (visited[i][j]) return true;
            if (i == 0 || j == 0 || i == board.Length - 1 || j == board[i].Length - 1) return false;

            queue.Enqueue((i, j));
            visited[i][j] = true;
            bool top = board[i - 1][j] == 'X' ? true : helper_130(board, visited, queue, i - 1, j);
            bool bottom = board[i + 1][j] == 'X' ? true : helper_130(board, visited, queue, i + 1, j);
            bool left = board[i][j - 1] == 'X' ? true : helper_130(board, visited, queue, i, j - 1);
            bool right = board[i][j + 1] == 'X' ? true : helper_130(board, visited, queue, i, j + 1);

            if (top && bottom && right && left)
            {
                while (queue.Count > 0)
                {
                    (int x, int y) = queue.Dequeue();
                    board[x][y] = 'X';
                }
            }
            return false;
        }
        #endregion

        #region Problem 136
        public int SingleNumber_v1(int[] nums)
        {
            //List<int> result = new List<int>();

            //foreach (int num in nums)
            //{
            //    if (result.Contains(num))
            //    {
            //        result.Remove(num);
            //    }
            //    else
            //    {
            //        result.Add(num);
            //    }
            //}

            //return result[0];
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 1; i = i + 2)
            {
                if (nums[i] != nums[i + 1]) return nums[i];
            }
            return 0;
        }

        public int SingleNumber(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                nums[i] = nums[i] ^ nums[i - 1];
            }
            return nums[nums.Length - 1];
        }
        #endregion

        #region Problem 141
        public bool HasCycle(ListNode head)
        {
            if (head == null) return false;
            ListNode node1 = head;
            ListNode node2 = head.next;

            while (node2 != node1)
            {
                if (node2 == null || node2.next == null) return false;

                node1 = node1.next;
                node2 = node2.next.next;
            }
            return true;
        }
        #endregion

        #region Problem 144
        public IList<int> PreorderTraversal(TreeNode root)
        {
            IList<int> list = new List<int>();
            preOrder(list, root);
            return list;
        }

        private void preOrder(IList<int> result, TreeNode root)
        {
            if (root == null) return;
            result.Add(root.val);
            preOrder(result, root.left);
            preOrder(result, root.right);
        }
        #endregion

        #region Problem 145
        public IList<int> PostorderTraversal(TreeNode root)
        {
            IList<int> list = new List<int>();
            postOrder(list, root);
            return list;
        }

        private void postOrder(IList<int> result, TreeNode root)
        {
            if (root == null) return;
            postOrder(result, root.left);
            postOrder(result, root.right);
            result.Add(root.val);
        }
        #endregion

        #region Problem 160
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode A = headA;
            ListNode B = headB;

            while (A != B)
            {
                A = A != null ? A.next : headB;
                B = B != null ? B.next : headA;
            }
            return A;
        }
        #endregion

        #region Problem 168
        public string ConvertToTitle(int columnNumber)
        {
            StringBuilder result = new StringBuilder();

            while (columnNumber > 26)
            {
                int rem = columnNumber % 26;
                rem = rem == 0 ? 26 : rem;
                char c = (char)('A' - 1 + rem);
                result.Insert(0, c);
                columnNumber -= rem;
                columnNumber /= 26;

            }
            if (columnNumber <= 26)
            {
                result.Insert(0, (char)('A' + columnNumber - 1));
                columnNumber = 0;
            }

            return result.ToString();
        }
        #endregion

        #region Problem 169
        public int MajorityElement(int[] nums)
        {
            int res = nums[0];
            int cnt = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (cnt == 0)
                {
                    res = nums[i];
                }

                if (nums[i] == res)
                {
                    cnt++;
                }
                else
                {
                    cnt--;
                }
            }
            return res;
        }
        #endregion

        #region Problem 171
        public int TitleToNumber(string columnTitle)
        {
            int index = columnTitle.Length - 1;
            int pow = 0;
            int result = 0;
            while (index >= 0)
            {
                int v = columnTitle[index] - 64;

                int x = (int)Math.Pow(26, pow);

                result += x * v;
                index--;
                pow++;
            }
            return result;
        }
        #endregion

        #region Problem 190
        public uint reverseBits(uint n)
        {
            uint x = 0;

            for (int i = 0; i < 32; i++)
            {
                uint y = (n & 1);
                x = (x << 1) + y;
                n >>= 1;
            }

            return x;
        }
        #endregion

        #region Problem 202
        private List<int> visited_Happy = new List<int>();
        public bool IsHappy(int n)
        {
            if (visited_Happy.Contains(n))
            {
                return false;
            }
            visited_Happy.Add(n);
            if (n == 1) return true;


            //if(n<9) return false;

            int newNumber = 0;
            while (n > 0)
            {

                int rem = n % 10;

                newNumber += rem * rem;

                n /= 10;
            }

            return IsHappy(newNumber);
        }


        #endregion

        #region Problem 203
        public ListNode RemoveElements(ListNode head, int val)
        {
            while (head != null && head.val == val)
            {
                head = head.next;
            }
            ListNode node = head;
            while (node != null && node.next != null)
            {
                if (node.next.val == val)
                {
                    node.next = node.next.next;
                }
                else
                {
                    node = node.next;
                }
            }

            return head;
        }
        #endregion

        #region Problem 205
        public bool IsIsomorphic(string s, string t)
        {
            Dictionary<char, char> map = new Dictionary<char, char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (map.ContainsKey(s[i]))
                {
                    if (map[s[i]] != t[i]) return false;
                }
                else
                {
                    map.Add(s[i], t[i]);
                }
            }
            return true;
        }
        #endregion

        #region Problem 228. Summary Ranges
        public IList<string> SummaryRanges(int[] nums)
        {
            IList<string> result = new List<string>();

            for (int i = 0; i < nums.Length; i++)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(nums[i]);
                bool flag = false;
                while (i < nums.Length - 1 && nums[i] + 1 == nums[i + 1])
                {
                    flag = true;
                    i++;
                }
                if (flag)
                {
                    stringBuilder.Append("->");
                    stringBuilder.Append(nums[i]);
                }
                result.Add(stringBuilder.ToString());   
            }

            return result;
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

        #region Problem 673. Number of Longest Increasing Subsequence
        public int FindNumberOfLIS(int[] nums)
        {
            int result = 0;

            int[] len = new int[nums.Length];
            int[] cnt = new int[nums.Length];

            int maxlen = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i]>nums[j])
                    {
                        if(len[j]+1 > len[i])
                        {
                            len[i] = len[j] + 1;
                            cnt[i] = cnt[j];
                        }
                        else if(len[j]+1 == len[i])
                        {
                            cnt[i] += cnt[j];
                        }
                    }
                }
                maxlen = Math.Max(len[i],maxlen);
            }

            for (int i = 0; i < len.Length; i++)
            {
                if (len[i] == maxlen)
                {
                    result += cnt[i];
                }
            }

            return result;
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

        #region Problem 1381. Design a Stack With Increment Operation
        public class CustomStack
        {
            int[] arr;
            int currIndex;
            int len;
            public CustomStack(int maxSize)
            {
                len = maxSize;
                arr = new int[len];
                currIndex = -1;
            }

            public void Push(int x)
            {
                if (currIndex < len - 1)
                {
                    arr[++currIndex] = x;
                }
            }

            public int Pop()
            {
                if (currIndex == -1) return currIndex;
                return arr[currIndex--];
            }

            public void Increment(int k, int val)
            {
                for (int i = 0; i < Math.Min(k, currIndex + 1); i++)
                {
                    arr[i] += val;
                }
            }
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

        #region Problem 1913. Maximum Product Difference Between Two Pairs
        public int MaxProductDifference(int[] nums)
        {
            Array.Sort(nums);

            return nums[nums.Length - 1] * nums[nums.Length - 2] - nums[0] * nums[1];
        }


        public int MaxProductDifference_V1(int[] nums)
        {
            int min1 = int.MaxValue;
            int min2 = int.MaxValue;

            int max1 = int.MinValue;
            int max2 = int.MinValue;

            for (int i = 0; i < nums.Length; i++)
            {
                if (min1 > nums[i])
                {
                    min2 = min1;
                    min1 = nums[i];
                }
                else if (min2 > nums[i])
                {
                    min2 = nums[i];
                }

                if (max1 < nums[i])
                {
                    max2 = max1;
                    max1 = nums[i];
                }
                else if (max2 < nums[i])
                {
                    max2 = nums[i];
                }

            }
            return (max1 * max2) - (min1 * min2);
        }
        #endregion

        #region Problem 1997. First Day Where You Have Been in All the Rooms
        public int FirstDayBeenInAllRooms(int[] nextVisit)
        {
            long[] dp = new long[nextVisit.Length];
            int mod = (int)1e9 + 7;

            for (int i = 1; i < nextVisit.Length; i++)
            {
                if (nextVisit[i - 1] == i - 1)
                {
                    dp[i] = dp[i - 1] + 2;
                }
                else
                {
                    dp[i] = ((dp[i - 1] + dp[i - 1] - dp[nextVisit[i - 1]] + 2 + mod) % mod);
                }
            }

            return (int)dp[nextVisit.Length - 1];
        }
        #endregion

        #region Problem 2401. Longest Nice Subarray
        public int LongestNiceSubarray(int[] nums)
        {
            int len = nums.Length;

            if (len == 1) return len;
            int n = 0;
            int j = 0;
            int kResult = 0;
            for (int i = 0; i < len; i++)
            {
                while ((n & nums[i]) != 0)
                {
                    n ^= nums[j++];
                }

                n |= nums[i];

                if (i - j + 1 > kResult)
                {
                    kResult = i - j + 1;
                }
            }

            return kResult;
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
