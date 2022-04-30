namespace Week290
{
    internal class Solution
    {
        public IList<int> Intersection(int[][] nums)
        {
            IList<int> result = new List<int>();
            List<int> list = new List<int>(nums[0]);
            for (int i = 1; i < nums.Length; i++)
            {
                if (list.Count > nums[i].Length)
                {
                    list = new List<int>(nums[i]);
                }
            }
            list.Sort();
            foreach (var item in list)
            {
                bool flag = true;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (!nums[i].Contains(item))
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    result.Add(item);
                }
            }


            return result;
        }

        public int[] CountRectangles(int[][] rectangles, int[][] points)
        {
            Dictionary<int, List<int>> dctheights = new Dictionary<int, List<int>>();

            for (int i = 1; i <= 100; i++)
            {
                dctheights.Add(i, new List<int>());
            }

            rectangles = rectangles.OrderBy(x => x[0]).ToArray();
            for (int i = 0; i < rectangles.Length; i++)
            {
                int height = rectangles[i][1];
                int length = rectangles[i][0];

                if (dctheights.ContainsKey(height))
                {
                    dctheights[height].Add(length);
                }
            }

            foreach (var h in dctheights.Keys)
            {
                dctheights[h].Sort();
            }

            int[] result = new int[points.Length];

            for (int i = 0; i < points.Length; i++)
            {
                int y = points[i][1];
                int x = points[i][0];
                int cnt = 0;

                for (int j = y; j <= 100; j++)
                {
                    cnt += dctheights[j].Count - getCounts(dctheights[j], x);
                }
                result[i] = cnt;
            }

            return result;
        }

        private int getCounts(List<int> nums, int x)
        {
            int l = 0;
            int r = nums.Count - 1;

            while (l < r)
            {
                int mid = l + (r - l) / 2;

                if (nums[mid] == x)
                {
                    while (mid > 0 && nums[mid] == nums[mid - 1])
                    {
                        mid--;
                    }
                    return mid;
                }

                if (nums[mid] < x)
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
            }
            return l;

        }

        public int[] FullBloomFlowers(int[][] flowers, int[] persons)
        {
            int[] result = new int[persons.Length];
            flowers = flowers.OrderBy(x => x[1]).ToArray();

            for (int i = 0; i < persons.Length; i++)
            {
                int cnt = 0;
                foreach (var item in flowers)
                {
                    if (item[1] > persons[i]) break;
                    if (persons[i] >= item[0] && persons[i] <= item[1])
                    {
                        cnt++;
                    }
                }
                result[i] = cnt;
            }

            return result;
        }

        public int CountLatticePoints(int[][] circles)
        {
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            foreach (var circle in circles)
            {
                int x = circle[0];
                int y = circle[1];
                int r = circle[2];

                addInMap(map, x, y);
                for (int i = x - r; i <= r + x; i++)
                {
                    for (int j = y - r; j <= y + r; j++)
                    {
                        if ((i - x) * (i - x) + (j - y) * (j - y) <= r * r)
                        {
                            addInMap(map, i, j);
                        }
                    }

                }
            }
            int res = 0;
            foreach (var m in map.Values)
            {
                res += m.Count;
            }
            return res;
        }

        private void addInMap(Dictionary<int, List<int>> map, int x, int y)
        {
            if (map.ContainsKey(x))
            {
                if (!map[x].Contains(y))
                {
                    map[x].Add(y);
                }
            }
            else
            {
                map.Add(x, new List<int>() { y });
            }
        }
    }
}
