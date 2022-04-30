// See https://aka.ms/new-console-template for more information
using Week290;

var lines = File.ReadAllLines(@"C:\Users\anand\source\repos\LeetCodeWeekly\Week290\Week290\Input.txt");

string str1 = lines[0].Trim('[',']');
string[] str2 = str1.Split("],[");
int[][] rectangles = new int[str2.Length][];

for (int i = 0; i < str2.Length; i++)
{
    rectangles[i] = Array.ConvertAll(str2[i].Split(','), int.Parse);
}
//string str3 = lines[1].Trim('[', ']');
//string[] str4 = str3.Split("],[");
//int[][] points = new int[str4.Length][];

//for (int i = 0; i < str4.Length; i++)
//{
//    points[i] = Array.ConvertAll(str4[i].Split(','), int.Parse);
//}
Solution solution = new Solution();
solution.CountLatticePoints(rectangles);