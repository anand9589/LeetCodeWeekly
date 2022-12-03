using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace December22
{
    public class Solution
    {
        #region Day 1 Problem 1704. Determine if String Halves Are Alike
        public bool HalvesAreAlike(string s)
        {
            int count = 0;
            HashSet<char> vowels = new HashSet<char> { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U' };

            int low = 0;
            int high = s.Length - 1;

            while (low < high)
            {
                if (vowels.Contains(s[low]))
                {
                    count++;
                }
                if (vowels.Contains(s[high]))
                {
                    count--;
                }
                low++;
                high--;
            }

            return count == 0;
        }
        #endregion

        #region Day 2 Problem 1657. Determine if Two Strings Are Close
        public bool CloseStrings(string word1, string word2)
        {
            if (word1.Length != word2.Length) return false;

            int[] arr1 = new int[26];
            int[] arr2 = new int[26];

            int index = 0;
            while (index < word1.Length)
            {
                arr1[word1[index] - 'a']++;
                arr2[word2[index] - 'a']++;

                index++;
            }

            for (int i = 0; i < arr1.Length; i++)
            {
                if ((arr1[i] == 0 && arr2[i] != 0) || (arr2[i] == 0 && arr1[i] != 0)) return false;
            }

            Array.Sort(arr1);
            Array.Sort(arr2);

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i]) return false;
            }

            return true;
        }

        public bool CloseStrings_V1(string word1, string word2)
        {
            if (word1.Length != word2.Length) return false;

            SortedDictionary<char, int> word1Map = new SortedDictionary<char, int>();
            SortedDictionary<char, int> word2Map = new SortedDictionary<char, int>();

            int i = 0;

            while (i < word1.Length)
            {
                if (!word1Map.ContainsKey(word1[i]))
                {
                    word1Map.Add(word1[i], 0);
                }
                word1Map[word1[i]]++;

                if (!word2Map.ContainsKey(word2[i]))
                {
                    word2Map.Add(word2[i], 0);
                }
                word2Map[word2[i]]++;

                i++;
            }

            foreach (var key in word1Map.Keys)
            {
                if (!word2Map.ContainsKey(key)) return false;
                var k = word2Map.Keys.FirstOrDefault(x => word2Map[x] == word1Map[key]);

                if (k == '\0') return false;

                word2Map[k] = -1;
            }

            return true;
        }
        #endregion

        #region Day 3 Problem 451. Sort Characters By Frequency
        public string FrequencySort(string s)
        {
            Dictionary<char, int> word1Map = new Dictionary<char, int>();
            int index = 0;

            while (index < s.Length)
            {
                if (!word1Map.ContainsKey(s[index]))
                {
                    word1Map.Add(s[index], 0);
                }
                word1Map[s[index]]++;
                index++;
            }

            word1Map = word1Map.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (char key in word1Map.Keys)
            {
                for (int i = 0; i < word1Map[key]; i++)
                {
                    stringBuilder.Append(key);
                }
            }



            return stringBuilder.ToString();
        }
        #endregion

        #region Day 4 Problem
        #endregion

        #region Day 5 Problem
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

        #region Day 11 Problem
        #endregion

        #region Day 12 Problem
        #endregion

        #region Day 13 Problem
        #endregion

        #region Day 14 Problem
        #endregion

        #region Day 15 Problem
        #endregion

        #region Day 16 Problem
        #endregion

        #region Day 17 Problem
        #endregion

        #region Day 18 Problem
        #endregion

        #region Day 19 Problem
        #endregion

        #region Day 20 Problem
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

        #region Day 31 Problem
        #endregion
    }
}
