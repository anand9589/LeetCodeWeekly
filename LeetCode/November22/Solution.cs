using Common;
using System.Text;

namespace November22
{
    public class Solution
    {
        #region Daily

        #region Day 1 Problem 1706. Where Will the Ball Fall
        public int[] FindBall(int[][] grid)
        {
            int[][] dp = new int[grid.Length][];
            //Array.Copy(grid, dp, dp.Length);

            for (int i = 0; i < grid.Length; i++)
            {
                dp[i] = new int[grid[i].Length];
                for (int j = 0; j < grid[i].Length; j++)
                {
                    dp[i][j] = grid[i][j];
                }
            }

            int m = grid.Length;
            int n = grid[0].Length;
            int[] result = new int[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = getBallTrack(grid, dp, 0, i);
            }

            return result;

        }

        private int getBallTrack(int[][] grid, int[][] dp, int i, int j)
        {

            while (i < grid.Length)
            {
                if (dp[i][j] == -2) return -1;
                if (grid[i][j] == 1)
                {
                    if (j == grid[0].Length - 1) return -1;
                    if (grid[i][j] != grid[i][j + 1])
                    {
                        dp[i][j] = -2;
                        return -1;
                    }
                    j++;
                }
                else
                {
                    if (j == 0) return -1;
                    if (grid[i][j] != grid[i][j - 1])
                    {
                        dp[i][j] = -2;
                        return -1;
                    }
                    j--;
                }
                i++;
            }
            return j;
        }



        #endregion

        #region Day 2 Problem 433. Minimum Genetic Mutation
        public int MinMutation(string start, string end, string[] bank)
        {
            Queue<string> queue = new Queue<string>();
            HashSet<string> set = new HashSet<string>();


            queue.Enqueue(start);
            set.Add(start);

            char[] chs = new char[] { 'A', 'C', 'G', 'T' };
            int steps = 0;

            while (queue.Count > 0)
            {
                int len = queue.Count;

                for (int i = 0; i < len; i++)
                {
                    string node = queue.Dequeue();

                    if (node.Equals(end))
                    {
                        return steps;
                    }


                    foreach (char c in chs)
                    {
                        for (int j = 0; j < node.Length; j++)
                        {
                            string n = node.Substring(0, j) + c + node.Substring(j + 1);

                            if (!set.Contains(n) && bank.Contains(n))
                            {
                                queue.Enqueue(n);
                                set.Add(n);
                            }
                        }
                    }
                }
                steps++;
            }

            return -1;
        }
        #endregion

        #region Day 3 Problem 2131. Longest Palindrome by Concatenating Two Letter Words

        public int LongestPalindrome(string[] words)
        {
            int result = 0;

            if (words != null && words.Length > 0)
            {
                //Dictionary<string, int> wordMap = words.ToDictionary(key=>key, value=>ke.Count());
                var p = words.GroupBy(x => x).ToDictionary(key => key.Key, value => value.Count());

                foreach (var item in p.Keys)
                {
                    int wordCount = p[item];
                    if (wordCount > 0)
                    {

                        if (item[0] == item[1])
                        {

                            if (wordCount % 2 == 0)
                            {
                                result += wordCount * item.Length;
                                p[item] = 0;
                            }
                            else
                            {
                                result += (wordCount - 1) * item.Length;
                                p[item] = 1;
                            }
                        }
                        else
                        {
                            string rev = new string(new char[] { item[1], item[0] });

                            if (p.ContainsKey(rev))
                            {
                                int min = Math.Min(p[rev], p[item]);
                                result += (item.Length * 2 * min);

                                p[rev] -= min;
                                p[item] -= min;
                            }
                        }
                    }
                }

                foreach (var item in p.Keys)
                {
                    int wordCount = p[item];
                    if (item[0] == item[1] && wordCount > 0)
                    {
                        result += 2;
                        break;
                    }
                }

            }

            return result;
        }
        #endregion

        #region Day 4 Problem
        #endregion

        #region Day 5 Problem 212. Word Search II
        private HashSet<string> res = new HashSet<string>();
        private bool[,] visited = null;
        private Trie trie = new Trie();
        private int[] dx = new int[] { 0, 0, 1, -1 },
                      dy = new int[] { 1, -1, 0, 0 };

        public IList<string> FindWords(char[][] board, string[] words)
        {
            if (board == null || board.Length == 0)
                return new List<string>();

            foreach (var word in words)
                trie.Insert(word);

            for (int i = 0; i < board.Length; i++)
                for (int j = 0; j < board[0].Length; j++)
                {
                    visited = new bool[board.Length, board[0].Length];

                    visited[i, j] = true;
                    DFS_FindWords(board, i, j, trie.Head, new StringBuilder(board[i][j].ToString()));
                }

            return res.ToList<string>();
        }


        private void DFS_FindWords(char[][] board, int x, int y, TrieNode node, StringBuilder cur)
        {
            if (!node.ContainsChar(board[x][y]))
                return;

            if (node[board[x][y]].IsEnd && !res.Contains(cur.ToString()))
                res.Add(cur.ToString());

            for (int i = 0; i < 4; i++)
            {
                int newX = x + dx[i],
                    newY = y + dy[i];

                if (newX > -1 && newX < board.Length && newY > -1 && newY < board[0].Length && !visited[newX, newY])
                {
                    visited[newX, newY] = true;
                    cur.Append(board[newX][newY]);

                    DFS_FindWords(board, newX, newY, node[board[x][y]], cur);

                    visited[newX, newY] = false;
                    cur.Remove(cur.Length - 1, 1);
                }
            }
        }

        public class Trie
        {
            public TrieNode Head { get; } = new TrieNode();

            public void Insert(string str)
            {
                Insert(str, 0, Head);
            }

            private void Insert(string str, int i, TrieNode cur)
            {
                if (str.Length == i)
                {
                    cur.IsEnd = true;
                    return;
                }

                if (!cur.ContainsChar(str[i]))
                    cur.AddChar(str[i], new TrieNode());

                Insert(str, i + 1, cur[str[i]]);
            }
        }

        public class TrieNode
        {
            private Dictionary<char, TrieNode> chars = new Dictionary<char, TrieNode>();

            public bool IsEnd = false;

            public void AddChar(char c, TrieNode node)
            {
                chars.Add(c, node);
            }

            public bool ContainsChar(char c)
            {
                return chars.ContainsKey(c);
            }

            public TrieNode this[char c]
            {
                get => chars[c];
            }
        }

        public IList<string> FindWords_V3(char[][] board, string[] words)
        {
            IList<string> list = new List<string>();

            IList<string> list2 = new List<string>(words);
            bool[,] visited = new bool[board.Length, board[0].Length];
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    char c = board[i][j];
                    var k = words.Any(w => w.StartsWith(c));
                    if (k)
                    {
                        visited = new bool[board.Length, board[0].Length];
                        Queue<(int, int, StringBuilder)> q = new Queue<(int, int, StringBuilder)>();
                        StringBuilder sb = new StringBuilder();
                        sb.Append(c);
                        q.Enqueue((i, j, sb));
                        visited[i, j] = true;
                        traveseQueue(q, board, visited, list2);
                    }
                }
            }

            list = words.Where(w => !list2.Contains(w)).ToList();

            return list;
        }

        private void traveseQueue(Queue<(int, int, StringBuilder)> q, char[][] board, bool[,] visited, IList<string> list2)
        {
            (int i, int j, StringBuilder sb) = q.Dequeue();

            while (list2.Contains(sb.ToString()))
            {
                list2.Remove(sb.ToString());
            }
            //top i-1
            if (i - 1 >= 0 && !visited[i - 1, j])
            {
                newMethod1(q, board, visited, list2, i - 1, j, sb);

            }
            //bottom i+1
            if (i + 1 < board.Length && !visited[i + 1, j])
            {
                newMethod1(q, board, visited, list2, i + 1, j, sb);
            }
            //left j-1
            if (j - 1 >= 0 && !visited[i, j - 1])
            {
                newMethod1(q, board, visited, list2, i, j - 1, sb);
            }
            //right j+1
            if (j + 1 < board[0].Length && !visited[i, j + 1])
            {
                newMethod1(q, board, visited, list2, i, j + 1, sb);
            }
            visited[i, j] = false;
        }

        private void newMethod1(Queue<(int, int, StringBuilder)> q, char[][] board, bool[,] visited, IList<string> list2, int i, int j, StringBuilder sb)
        {
            sb.Append(board[i][j]);

            var k = list2.Any(w => w.StartsWith(sb.ToString()));
            if (k)
            {
                visited[i, j] = true;
                q.Enqueue((i, j, sb));

                traveseQueue(q, board, visited, list2);
            }
            sb.Remove(sb.Length - 1, 1);
        }

        Dictionary<char, List<(int, int)>> dct212 = new Dictionary<char, List<(int, int)>>();

        public IList<string> FindWords_V2(char[][] board, string[] words)
        {
            IList<string> result = new List<string>();

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (dct212.ContainsKey(board[i][j]))
                    {
                        dct212[board[i][j]].Add((i, j));
                    }
                    else
                    {
                        dct212.Add(board[i][j], new List<(int, int)> { (i, j) });
                    }
                }
            }
            bool[][] visited = new bool[board.Length][];

            foreach (var word in words)
            {
                if (dct212.ContainsKey(word[0]))
                {
                    char key = word[0];

                    for (int i = 0; i < board.Length; i++)
                    {
                        visited[i] = new bool[board[i].Length];
                    }
                    Queue<(int, int, int)> q = new Queue<(int, int, int)>();

                    foreach ((int i, int j) in dct212[key])
                    {
                        visited[i][j] = true;
                        q.Enqueue((i, j, 0));

                        if (found(board, word, visited, q))
                        {
                            result.Add(word);
                            break;
                        }

                    }
                }
            }

            return result;
        }
        public IList<string> FindWords_V1(char[][] board, string[] words)
        {
            IList<string> result = new List<string>();


            foreach (string word in words)
            {

                if (word.Length > board.Length * board[0].Length) continue;
                if (isWordFound(board, word))
                {
                    result.Add(word);
                }
            }

            return result;
        }

        private bool isWordFound(char[][] board, string word)
        {
            bool[][] visited = new bool[board.Length][];
            for (int i = 0; i < board.Length; i++)
            {
                visited[i] = new bool[board[i].Length];
            }


            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (word[0] == board[i][j])
                    {
                        Queue<(int, int, int)> q = new Queue<(int, int, int)>();
                        visited[i][j] = true;
                        q.Enqueue((i, j, 0));
                        if (found(board, word, visited, q))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool found(char[][] board, string word, bool[][] visited, Queue<(int, int, int)> q)
        {
            (int i, int j, int k) = q.Dequeue();

            int nxtIndex = k + 1;

            if (nxtIndex == word.Length) return true;

            //top i-1
            if (i - 1 >= 0 && !visited[i - 1][j] && board[i - 1][j] == word[nxtIndex])
            {
                visited[i - 1][j] = true;
                q.Enqueue((i - 1, j, nxtIndex));
                if (found(board, word, visited, q)) return true;
            }
            //bottom i+1
            if (i + 1 < board.Length && !visited[i + 1][j] && board[i + 1][j] == word[nxtIndex])
            {
                visited[i + 1][j] = true;
                q.Enqueue((i + 1, j, nxtIndex));
                if (found(board, word, visited, q)) return true;
            }
            //left j-1
            if (j - 1 >= 0 && !visited[i][j - 1] && board[i][j - 1] == word[nxtIndex])
            {
                visited[i][j - 1] = true;
                q.Enqueue((i, j - 1, nxtIndex));
                if (found(board, word, visited, q)) return true;
            }
            //right j+1
            if (j + 1 < board[i].Length && !visited[i][j + 1] && board[i][j + 1] == word[nxtIndex])
            {
                visited[i][j + 1] = true;
                q.Enqueue((i, j + 1, nxtIndex));
                if (found(board, word, visited, q)) return true;
            }
            visited[i][j] = false;
            return false;
        }

        #endregion

        #region Day 6 Problem
        #endregion

        #region Day 7 Problem
        #endregion

        #region Day 8 Problem
        #endregion

        #region Day 9 Problem
        #endregion

        #region Day 10 Problem
        #endregion

        #region Day 11 Problem 26. Remove Duplicates from Sorted Array
        public int RemoveDuplicates(int[] nums)
        {
            int indexJ = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                while (i < nums.Length && nums[i] == nums[i - 1])
                {
                    i++;
                }
                if (i < nums.Length)
                {
                    nums[indexJ] = nums[i];
                    indexJ++;
                }
            }

            return indexJ;
        }
        #endregion

        #region Day 12 Problem 295. Find Median from Data Stream
        public class MedianFinder
        {

            PriorityQueue<int, int> leftQueue;
            PriorityQueue<int, int> rightQueue;

            public MedianFinder()
            {
                leftQueue = new PriorityQueue<int, int>();
                rightQueue = new PriorityQueue<int, int>();
            }

            public void AddNum(int num)
            {
                if (leftQueue.Count == rightQueue.Count)
                {
                    if (leftQueue.Count == 0)
                    {
                        leftQueue.Enqueue(num, -num);
                    }
                    else
                    {
                        var rightTop = rightQueue.Peek();
                        //add in leftQueue
                        if (num < rightTop)
                        {
                            leftQueue.Enqueue(num, -num);
                        }
                        else
                        {
                            rightQueue.Dequeue();
                            leftQueue.Enqueue(rightTop, -rightTop);
                            rightQueue.Enqueue(num, num);
                        }

                    }
                }
                else
                {
                    //add in rightQueue
                    var leftTop = leftQueue.Peek();

                    if (num > leftTop)
                    {
                        rightQueue.Enqueue(num, num);
                    }
                    else
                    {
                        leftQueue.Dequeue();
                        rightQueue.Enqueue(leftTop, leftTop);
                        leftQueue.Enqueue(num, -num);
                    }

                }
            }

            public double FindMedian()
            {

                if (leftQueue.Count == rightQueue.Count)
                {
                    return (double)(leftQueue.Peek() + rightQueue.Peek()) / 2;
                }
                else
                {
                    return leftQueue.Peek();
                }
            }
        }

        #endregion

        #region Day 13 Problem 151. Reverse Words in a String
        public string ReverseWords(string s)
        {
            string[] strs = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < strs.Length / 2; i++)
            {
                string word = strs[i];
                strs[i] = strs[strs.Length - 1 - i];
                strs[strs.Length - 1 - i] = word;
            }
            return string.Join(" ", strs);
        }
        #endregion

        #region Day 14 Problem 947. Most Stones Removed with Same Row or Column
        public int RemoveStones(int[][] stones)
        {
            int result = 0;

            HashSet<int[]> visited = new HashSet<int[]>();

            foreach (var stone in stones)
            {
                if (!visited.Contains(stone))
                {
                    DFS_RemoveStones(stone, stones, visited);
                    result++;
                }
            }

            //IList<(int, int)> list = new List<(int, int)>();

            //for (int i = 0; i < stones.Length; i++)
            //{
            //    list.Add((stones[i][0], stones[i][1]));
            //}

            //int maxX = list.Select(x => x.Item1).Max();
            //int maxY = list.Select(x => x.Item2).Max();

            //int[][] matrix = new int[maxX + 1][];

            //for (int i = 0; i < matrix.Length; i++)
            //{
            //    matrix[i] = new int[maxY + 1];
            //}
            //for (int i = 0; i < stones.Length; i++)
            //{
            //    matrix[stones[i][0]][stones[i][1]] = 1;
            //}

            //for (int i = 0; i < matrix.Length; i++)
            //{
            //    for (int j = 0; j < matrix[i].Length; j++)
            //    {
            //        if (matrix[i][j] == 1)
            //        {
            //            bool found1 = false;
            //            for (int k = 0; k < matrix.Length; k++)
            //            {
            //                if (k == i) continue;

            //                if (matrix[k][j] == 1)
            //                {
            //                    found1 = true;
            //                    matrix[i][j] = 0;
            //                    break;
            //                }
            //            }
            //            if (!found1)
            //            {
            //                for (int k = 0; k < matrix[i].Length; k++)
            //                {
            //                    if (k == j) continue;

            //                    if (matrix[i][k] == 1)
            //                    {
            //                        found1 = true;
            //                        matrix[i][j] = 0;
            //                        break;
            //                    }
            //                }
            //            }
            //            if (found1) result++;
            //        }
            //    }
            //}

            return stones.Length - result;
        }

        private void DFS_RemoveStones(int[] stone, int[][] stones, HashSet<int[]> visited)
        {
            visited.Add(stone);
            foreach (var nextStone in stones)
            {
                if (!visited.Contains(nextStone))
                {
                    if (stone[0] == nextStone[0] || stone[1] == nextStone[1])
                        DFS_RemoveStones(nextStone, stones, visited);
                }
            }
        }
        #endregion

        #region Day 15 Problem 222. Count Complete Tree Nodes
        public int CountNodes(TreeNode root)
        {
            if (root == null) return 0;
            int left = leftCount(root.left);
            int right = rightCount(root.right);

            if (left == right)
            {
                return (int)Math.Pow(2, left + 1) - 1;
            }

            return 1 + CountNodes(root.left) + CountNodes(root.right);
        }

        private int leftCount(TreeNode root)
        {
            if (root == null) return 0;

            int count = 1;

            while (root.left != null)
            {
                count++;
                root = root.left;
            }
            return count;
        }

        private int rightCount(TreeNode root)
        {
            if (root == null) return 0;

            int count = 1;

            while (root.right != null)
            {
                count++;
                root = root.right;
            }
            return count;
        }
        #endregion

        #region Day 16 Problem 374. Guess Number Higher or Lower
        public int GuessNumber(int n)
        {

            int low = 0;
            int high = n;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                int res = guess(mid);

                if (res == 0) return mid;

                if (res == 1)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return -1;
        }

        private int guess(int n)
        {
            return 0;
        }
        #endregion

        #region Day 17 Problem 223. Rectangle Area
        public int ComputeArea(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2)
        {
            int result = Math.Abs(ax1 - ax2) * Math.Abs(ay1 - ay2) + Math.Abs(bx1 - bx2) * Math.Abs(by1 - by2);

            IList<int> xAxis = new List<int>();
            for (int i = ax1; i < ax2; i++)
            {
                xAxis.Add(i);
            }

            IList<int> yAxis = new List<int>();
            for (int i = ay1; i < ay2; i++)
            {
                yAxis.Add(i);
            }

            int commLen = 0;
            int commWid = 0;

            for (int i = bx1; i < bx2; i++)
            {
                if (xAxis.Contains(i))
                {
                    commLen++;
                }
                else
                {
                    xAxis.Add(i);
                }
            }

            for (int i = by1; i < by2; i++)
            {
                if (yAxis.Contains(i))
                {
                    commWid++;
                }
                else
                {
                    yAxis.Add(i);
                }
            }

            return Math.Abs(ax1 - ax2) * Math.Abs(ay1 - ay2) + Math.Abs(bx1 - bx2) * Math.Abs(by1 - by2) - commLen * commWid;
        }
        public int ComputeArea_V1(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2)
        {
            int result = 0;

            int xMin = Math.Min(ax1, bx1);
            int xMax = Math.Max(ax2, bx2);
            int yMin = Math.Min(ay1, by1);
            int yMax = Math.Max(ay2, by2);

            int m = Math.Abs(xMax - xMin);
            int n = Math.Abs(yMax - yMin);

            int[][] matrix = new int[m][];
            for (int i = 0; i < m; i++)
            {
                matrix[i] = new int[n];
            }
            int diff = 0;
            if (ax1 == xMin)
            {
                diff = 0 - ax1;

                ax1 = 0;
                ax2 += diff;
                bx1 += diff;
                bx2 += diff;
            }
            else
            {
                diff = 0 - bx1;

                bx1 = 0;
                bx2 += diff;
                ax1 += diff;
                ax2 += diff;
            }

            if (ay1 == yMin)
            {
                diff = 0 - ay1;
                ay1 = 0;
                ay2 += diff;
                by1 += diff;
                by2 += diff;
            }
            else
            {
                diff = 0 - by1;
                by1 = 0;
                by2 += diff;
                ay1 += diff;
                by1 += diff;
            }


            for (int i = ax1; i < ax2; i++)
            {
                for (int j = ay1; j < ay2; j++)
                {
                    matrix[i][j] = 1;
                }
            }


            for (int i = bx1; i < bx2; i++)
            {
                for (int j = by1; j < by2; j++)
                {
                    matrix[i][j] = 1;
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == 1)
                    {
                        result++;
                    }
                }
            }

            //int rect1Len = Math.Abs(ax1 - ax2);
            //int rect2Len = Math.Abs(bx1 - bx2);
            //int rect1Width = Math.Abs(ay1 - ay2);
            //int rect2Width = Math.Abs(by1 - by2);

            //int rect1Area = rect1Len * rect1Width;
            //int rect2Area = rect2Len * rect2Width;


            //if(bx1 > ax1 && bx1 < ax2)
            //{

            //}

            return result;
        }
        #endregion

        #region Day 18 Problem 263. Ugly Number
        public bool IsUgly(int n)
        {
            int factor = 2;
            while (Math.Abs(n) > 1)
            {
                while (n % factor != 0 && factor < 5)
                {
                    factor++;
                }
                if (n % factor == 0)
                {
                    n /= factor;
                }
                else
                {
                    return false;
                }
            }


            return n == 1;
        }
        #endregion

        #region Day 19 Problem 587. Erect the Fence
        public int[][] OuterTrees(int[][] trees)
        {

            Array.Sort(trees, (x, y) => x[0] == y[0] ? y[1] - x[1] : x[0] - y[0]);

            Stack<int[]> stack = new();

            for (int i = 0; i < trees.Length; i++)
            {
                while (stack.Count >= 2 && Orientation(stack.Peek(), trees[i], stack.ElementAt(1)) > 0)
                {
                    stack.Pop();
                }
                stack.Push(trees[i]);
            }

            for (int j = trees.Length - 1; j >= 0; j--)
            {
                while (stack.Count >= 2 && Orientation(stack.Peek(), trees[j], stack.ElementAt(1)) > 0)
                {
                    stack.Pop();
                }
                stack.Push(trees[j]);
            }

            return stack.Distinct().ToArray();
        }

        private int Orientation(int[] p, int[] q, int[] r)
        {
            return (q[1] - p[1]) * (r[0] - q[0]) - (q[0] - p[0]) * (r[1] - q[1]);
        }

        private int[] bottomLeft(int[][] trees)
        {
            int[] bleft = trees[0];

            for (int i = 1; i < trees.Length; i++)
            {
                if (trees[i][1] < bleft[1])
                {
                    bleft = trees[i];
                }
            }

            return bleft;
        }
        #endregion

        #region Day 20 Problem 224. Basic Calculator
        public int Calculate(string s)
        {
            int result = 0;
            int i = 0;
            Stack<int> stack = new Stack<int>();
            int sign = 1;
            int num = 0;
            while (i < s.Length)
            {
                switch (s[i])
                {
                    case '+':
                        sign = 1;
                        break;
                    case '-':
                        sign = -1;
                        break;
                    case '(':
                        stack.Push(result);
                        stack.Push(sign);
                        result = 0;
                        sign = 1;
                        break;
                    case ')':
                        int lastSign = stack.Pop();
                        result *= lastSign;
                        int lastNum = stack.Pop();
                        result += lastNum;

                        break;
                    case ' ':
                        break;
                    default:
                        if (char.IsDigit(s[i]))
                        {
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.Append(s[i]);
                            while (i+1 < s.Length && char.IsDigit(s[i+1]))
                            {
                                stringBuilder.Append(s[++i]);
                            }

                            num = int.Parse(stringBuilder.ToString());
                            num *= sign;
                            result+=num;
                            sign = 1;
                        }
                        break;
                }
                i++;
            }

            return result;
        }
        #endregion
        #region Day 21 Problem
        #endregion
        #region Day 22 Problem
        #endregion
        #region Day 23 Problem
        #endregion
        #region Day 24 Problem
        #endregion
        #region Day 25 Problem
        #endregion
        #region Day 26 Problem
        #endregion
        #region Day 27 Problem
        #endregion
        #region Day 28 Problem
        #endregion
        #region Day 29 Problem
        #endregion
        #region Day 30 Problem
        #endregion
        #endregion

        #region Problems

        #region Problem 128. Longest Consecutive Sequence
        public int LongestConsecutive(int[] nums)
        {
            int result = 0;
            HashSet<int> set = new HashSet<int>();
            foreach (int n in nums)
            {
                set.Add(n);
            }


            for (int i = 0; i < nums.Length; i++)
            {
                int counter = 1;
                int curr = nums[i];

                if (!set.Contains(curr - 1))
                {
                    while (set.Contains(++curr))
                    {
                        counter++;
                    }
                }
                result = Math.Max(result, counter);
            }

            return result;
        }
        #endregion

        #region Problem 191. Number of 1 Bits
        public int HammingWeight(uint n)
        {
            int counter = 0;

            while (n > 0)
            {
                counter += (int)n & 1;
                n >>= 1;
            }
            return counter;
        }
        #endregion

        #region Problem 1281. Subtract the Product and Sum of Digits of an Integer
        public int SubtractProductAndSum(int n)
        {
            int product = 1;
            int sum = 0;

            while (n > 0)
            {
                int rem = n % 10;

                product *= rem;
                sum += rem;
                n /= 10;
            }

            return product - sum;
        }
        public int SubtractProductAndSum_v1(int n)
        {
            int product = 1;

            int sum = 0;

            while (n > 0)
            {
                int rem = n % 10;

                product *= rem;
                sum += rem;
                n /= 10;
            }

            return product - sum;
        }
        #endregion

        #region Problem 1491. Average Salary Excluding the Minimum and Maximum Salary
        public double Average(int[] salary)
        {
            return (double)(salary.Sum() - salary.Max() - salary.Min()) / (salary.Length - 2);
        }
        #endregion

        #region Problem 1523. Count Odd Numbers in an Interval Range
        public int CountOdds(int low, int high)
        {
            int result = 0;
            if (low % 2 == 1)
            {
                result++;
                low++;
            }
            if (low < high)
            {

                if (high % 2 == 1)
                {
                    result++;
                    high--;
                }
                result += (high - low) / 2;
            }

            return result;
        }
        #endregion
        #endregion

        #region Weekly
        #region 318
        public int[] ApplyOperations(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i + 1])
                {
                    nums[i] = nums[i] * 2;
                    nums[i + 1] = 0;
                }
            }

            int[] result = new int[nums.Length];
            int k = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    result[k++] = nums[i];
                }
            }
            return result;
        }

        public long MaximumSubarraySum(int[] nums, int k)
        {
            long result = 0;

            Dictionary<int, int> map = new Dictionary<int, int>();
            int startIndex = 0;
            int endIndex = startIndex + k - 1;
            int i = 0;
            long sum = 0;
            while (startIndex < nums.Length && endIndex < nums.Length)
            {
                while (endIndex < nums.Length && i <= endIndex)
                {
                    if (!map.ContainsKey(nums[i]))
                    {
                        map.Add(nums[i], i);
                        sum += nums[i];
                        if (i == endIndex)
                        {
                            result = Math.Max(sum, result);
                            map.Remove(nums[startIndex]);
                            sum -= nums[startIndex];
                            startIndex++;
                            endIndex++;
                        }
                        i++;

                    }
                    else
                    {
                        startIndex = map[nums[i]] + 1;
                        map.Clear();
                        i = startIndex;
                        endIndex = startIndex + k - 1;
                        sum = 0;
                    }

                }
            }

            return result;
        }

        public long MinimumTotalDistance(IList<int> robot, int[][] factory)
        {
            long result = 0;

            robot = robot.OrderBy(x => x).ToList();
            IList<(int, int)> factories = new List<(int, int)>();
            for (int i = 0; i < robot.Count; i++)
            {
                factories.Add((factory[i][0], factory[i][1]));
            }

            factories = factories.OrderBy(x => x.Item1).ToList();

            return result;
        }
        #endregion

        #region Problem 977. Squares of a Sorted Array
        public int[] SortedSquares(int[] nums)
        {
            int[] result = new int[nums.Length];

            int l = 0;
            int r = nums.Length - 1;

            while (l <= r)
            {
                int lSquare = nums[l] * nums[l];
                int rSquare = nums[r] * nums[r];

                if (rSquare > lSquare)
                {
                    result[r] = rSquare;
                    r--;
                }
                else
                {
                    result[r] = lSquare;
                    nums[l] = nums[r];
                    r--;
                }
            }

            return result;
        }
        #endregion

        #region Problem 791. Custom Sort String

        public string CustomSortString(string order, string s)
        {
            int[] charArr = new int[26];

            foreach (var ch in s)
            {
                charArr[ch - 'a']++;
            }

            StringBuilder sb = new();

            foreach (var ch in order)
            {
                int ind = ch - 'a';

                for (int i = 0; i < charArr[ind]; i++)
                {
                    sb.Append(ch);
                }

                charArr[ind] = 0;
            }

            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < charArr[i]; j++)
                {
                    sb.Append((char)('a' + i));
                }
            }

            return sb.ToString();
        }
        #endregion
        #endregion
    }
}