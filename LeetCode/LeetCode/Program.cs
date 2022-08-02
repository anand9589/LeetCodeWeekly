// See https://aka.ms/new-console-template for more information
using LeetCode;
using LeetCode.Weekly.FoodRating;

Problems problems = new Problems();
//problems.EqualPairs( new int[][] { new int[] { 3, 2, 1 },new int[] { 1,7,6 }, new int[] { 2, 7, 7 } });

FoodRatings foodRatings = new FoodRatings(new string[] { "czopaaeyl", "lxoozsbh", "kbaxapl" }, new string[] { "dmnuqeatj", "dmnuqeatj", "dmnuqeatj" }, new int[] { 11, 2, 15 });
foodRatings.ChangeRating("czopaaeyl", 12);
foodRatings.HighestRated("dmnuqeatj");
foodRatings.ChangeRating("kbaxapl", 8);
foodRatings.ChangeRating("lxoozsbh", 5);
foodRatings.HighestRated("dmnuqeatj");


ListNode buildList(int[] arr)
{
    ListNode head = new ListNode(0);
    ListNode temp = head;
    for (int i = 0; i < arr.Length; i++)
    {
        temp.next = new ListNode(arr[i]);
        temp = temp.next;
    }
    return head.next;
}
//Console.WriteLine("Hello, World!");

//TextEditor textEditor = new TextEditor();

//textEditor.AddText("leetcode");
//Console.WriteLine(textEditor.DeleteText(4));
//textEditor.AddText("practice");
//Console.WriteLine(textEditor.CursorRight(3));
//Console.WriteLine(textEditor.CursorLeft(8));
//Console.WriteLine(textEditor.DeleteText(10));
//Console.WriteLine(textEditor.CursorLeft(2));
//Console.WriteLine(textEditor.CursorRight(6));
