namespace LeetCode.Weekly
{
    public class Solution
    {
        #region Problem1
        public int MinMaxGame(int[] nums)
        {
            if(nums.Length == 1) return nums[0];

            int[] newNums = new int[nums.Length/2];

            for(int i = 0; i < newNums.Length; i++)
            {
                if (i % 2 == 0)
                {
                    newNums[i] = Math.Min(nums[i * 2], nums[i * 2 + 1]);
                }
                else
                {
                    newNums[i] = Math.Max(nums[i * 2], nums[i * 2 + 1]);
                }
            }
            return MinMaxGame(newNums);

        }
        #endregion

        #region Problem3
        public int[] ArrayChange(int[] nums, int[][] operations)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                map.Add(nums[i], i);
            }

            foreach (var item in operations)
            {
                int num = item[0];
                int newNum = item[1];

                int index = map[num];
                map.Remove(num);
                map.Add(newNum, index);

                nums[index] = newNum;
            }
            return nums;
        }
        #endregion
    }
}
