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

                if(result == m*n) return result;
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
            return -1;
        }
    }
}
