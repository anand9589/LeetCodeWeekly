using System.Text;

namespace Week291
{
    internal class Solution
    {
        //        "7795478535679443616467964135298543163376223791274561861738666981419251859535331546947347395531332878"
        //         "5"
        //"779547853679443616467964135298543163376223791274561861738666981419251859535331546947347395531332878"
        public string RemoveDigit(string number, char digit)
        {
            int index = 0;
            StringBuilder sb1 = new StringBuilder();
            while (index < number.Length)
            {
                char c = number[index];

                if (c == digit)
                {
                    if (sb1.Length == 0)
                    {
                        sb1.Append(number.Remove(index, 1));
                        if (index == number.Length - 1 || number[index + 1] > digit) return sb1.ToString();
                    }
                    else
                    {
                        sb1.Clear();
                        sb1.Append(number.Remove(index, 1));
                    }
                }
                index++;
            }


            return sb1.ToString();
        }

        public int MinimumCardPickup(int[] cards)
        {
            Dictionary<int, (int, int)> cardMap = new Dictionary<int, (int, int)>();
            int result = int.MaxValue;
            for (int i = 0; i < cards.Length; i++)
            {
                if (cardMap.ContainsKey(cards[i]))
                {
                    var c = cardMap[cards[i]];

                    int pick = i - c.Item2 + 1;

                    result = Math.Min(result, pick);

                    cardMap[cards[i]] = (c.Item1++, i);
                }
                else
                {
                    cardMap.Add(cards[i], (1, i));
                }
            }
            return result == int.MaxValue ? -1 : result;
        }

        public int CountDistinct(int[] nums, int k, int p)
        {
            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < nums.Length; i++)
            {
                StringBuilder stringBuilder = new StringBuilder();
                int divCounter = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    stringBuilder.Append(nums[j] + ",");

                    if (nums[j] % p == 0)
                    {
                        divCounter++;
                    }

                    if (divCounter > k)
                    {
                        break;
                    }
                    if (!set.Contains(stringBuilder.ToString()))
                    {
                        set.Add(stringBuilder.ToString());
                    }
                }
            }

            return set.Count;
        }

        public long AppealSum(string s)
        {
            long sum = 0;

            for (int i = 1; i <= s.Length; i++)
            {
                int index = 0;

                while (index + i - 1 < s.Length)
                {
                    string p = s.Substring(index, i);

                    var k = p.Distinct();
                    sum += k.Count();
                    index++;
                }
            }
            return sum;
        }
    }
}
