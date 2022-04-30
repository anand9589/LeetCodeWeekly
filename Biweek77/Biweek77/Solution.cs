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

        public int CountUnguarded(int m, int n, int[][] guards, int[][] walls)
        {
            int result = 0;
            int[][] guarded = new int[m][];

            for (int i = 0; i < m; i++)
            {
                guarded[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    guarded[i][j] = -1;
                }
            }

            for (int i = 0; i < walls.Length; i++)
            {
                int x = walls[i][0];
                int y = walls[i][1];

                guarded[x][y] = 1;
            }

            for (int i = 0; i < guards.Length; i++)
            {
                int x = guards[i][0];
                int y = guards[i][1];

                guarded[x][y] = 1;

                updateGuarded(guarded, guards, walls, x, y, m, n);
            }

            for (int i = 0; i < guarded.Length; i++)
            {
                for (int j = 0; j < guarded[i].Length; j++)
                {
                    if (guarded[i][j] == -1) result++;
                }
            }

            return result;
        }

        private void updateGuarded(int[][] guarded, int[][] guards, int[][] walls, int x, int y, int m, int n)
        {
            for (int i = x - 1; i >= 0; i--)
            {
                if (isWall(walls, i, y) || isGuard(guards, i, y))
                {
                    break;
                }
                guarded[i][y] = 1;
            }

            for (int i = x + 1; i < m; i++)
            {
                if (isWall(walls,i,y) || isGuard(guards, i, y))
                {
                    break;
                }

                guarded[i][y] = 1;
            }

            for (int i = y - 1; i >= 0; i--)
            {

                if (isWall(walls,x,i) || isGuard(guards, x, i))
                {
                    break;
                }

                guarded[x][i] = 1;
            }

            for (int i = y + 1; i < n; i++)
            {
                if (isWall(walls,x,i) || isGuard(guards, x, i))
                {
                    break;
                }

                guarded[x][i] = 1;
            }
        }

        private bool isWall(int[][] walls, int x, int y)
        {
            foreach (var w in walls)
            {
                if (x == w[0] && y == w[1]) return true;
            }

            return false;
        }

        private bool isGuard(int[][] gurads, int x, int y)
        {
            foreach (var w in gurads)
            {
                if (x == w[0] && y == w[1]) return true;
            }

            return false;
        }

        public int MaximumMinutes(int[][] grid)
        {
            return -1;
        }
    }
}
