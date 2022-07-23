// See https://aka.ms/new-console-template for more information
using LeetCode;

Problems problems = new Problems();
problems.DeleteDuplicates(buildList(new int[] { 1, 1, 1, 2, 2, 3 }));


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
