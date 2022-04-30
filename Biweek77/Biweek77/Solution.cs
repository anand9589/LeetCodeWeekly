namespace Biweek77
{
    public class Solution
    {
        public int CountPrefixes(string[] words, string s)
        {
            int result = 0;

            foreach (var w in words)
            {
                if (s.StartsWith(w)) result++;
            }
            return result;
        }

        public int MinimumAverageDifference(int[] nums)
        {
            long result = int.MaxValue;
            int index = -1;
            long sum1 = 0;
            long sum = nums.Sum(x => (long)x);
            long sum2 = sum - sum1;
            long avg1 = 0;
            long avg2 = 0;
            long ans = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {

                sum1 += nums[i];
                sum2 = sum - sum1;

                avg1 = sum1 / (i + 1);
                avg2 = nums.Length - i - 1 == 0 ? 0 : sum2 / (nums.Length - i - 1);

                ans = Math.Abs(avg1 - avg2);
                if (ans == 0) return i;
                if (ans < result)
                {
                    result = ans;
                    index = i;
                }
            }

            return index;
        }

        int result = 0;
        public int CountUnguarded(int m, int n, int[][] guards, int[][] walls)
        {
            int[][] guarded = new int[m][];

            for (int i = 0; i < m; i++)
            {
                guarded[i] = new int[n];
            }

            for (int i = 0; i < walls.Length; i++)
            {
                int x = walls[i][0];
                int y = walls[i][1];

                guarded[x][y] = 2;
                result++;
            }

            for (int i = 0; i < guards.Length; i++)
            {
                int x = guards[i][0];
                int y = guards[i][1];

                if (guarded[x][y] == 0)
                {
                    guarded[x][y] = 1;
                    result++;
                }
                updateGuarded(guarded, guards, walls, x, y, m, n);

                if (result == m * n) return result;
            }

            return m * n - result;
        }

        private void updateGuarded(int[][] guarded, int[][] guards, int[][] walls, int x, int y, int m, int n)
        {
            for (int i = x - 1; i >= 0; i--)
            {
                if (guarded[i][y] == 0)
                {
                    guarded[i][y] = 1;
                    result++;
                }
                else if (guarded[i][y] == 2)
                {
                    break;
                }
            }
            for (int i = x + 1; i < m; i++)
            {
                if (guarded[i][y] == 0)
                {
                    guarded[i][y] = 1;
                    result++;
                }
                else if (guarded[i][y] == 2)
                {
                    break;
                }
            }

            for (int i = y - 1; i >= 0; i--)
            {
                if (guarded[x][i] == 0)
                {
                    guarded[x][i] = 1;
                    result++;
                }
                else if (guarded[x][i] == 2)
                {
                    break;
                }
            }

            for (int i = y + 1; i < n; i++)
            {
                if (guarded[x][i] == 0)
                {
                    guarded[x][i] = 1;
                    result++;
                }
                else if (guarded[x][i] == 2)
                {
                    break;
                }
            }
        }

        public int MaximumMinutes(int[][] grid)
        {
            int x = 0;
            int y = 0;
            Dictionary<int, List<List<int>>> map = new Dictionary<int, List<List<int>>>();
            map.Add(0, new List<List<int>>());
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        map[0].Add(new List<int>() { i, j });
                    }
                }
            }
            int k = 0;
            for (int i = 1; i <= 1000000000; i++)
            {
                map.Add(i, new List<List<int>>());
                foreach (var fire in map[i - 1])
                {

                    int x1 = fire[0];
                    int y1 = fire[1];

                    if (
                        (x1 == 0 && y1 - 1 == 0) ||
                        (x1 == 0 && y1 + 1 == 0) ||
                        (x1 - 1 == 0 && y1 == 0) ||
                        (x1 + 1 == 0 && y1 == 0)
                        )
                    {
                        k = i;
                        break;
                    }
                    updateFireValue(grid, x1, y1 - 1, map[i]);
                    updateFireValue(grid, x1, y1 + 1, map[i]);
                    updateFireValue(grid, x1 + 1, y1, map[i]);
                    updateFireValue(grid, x1 - 1, y1, map[i]);
                }
                if (k == i) break;
                if (map[i].Count == 0) return 1000000000;
            }
            for (int i = k; i >= 1; i--)
            {

            }
            return -1;
        }


        private void updateFireValue(int[][] grid, int x1, int y1, List<List<int>> fires)
        {
            if (x1 < 0 || y1 < 0 || x1 >= grid.Length || y1 >= grid[x1].Length) return;
            if (grid[x1][y1] == 0)
            {
                grid[x1][y1] = 1;
                fires.Add(new List<int>() { x1, y1 });
            }
        }
    }
}
