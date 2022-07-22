using System.Linq;
namespace LeetCode.Weekly
{
    public class TextEditor
    {
        List<char> TextData;       
        int cursorPosition = 0;


        public TextEditor()
        {
            TextData = new List<char>();
            cursorPosition = 0;
        }

        public void AddText(string text)
        {
            TextData.InsertRange(cursorPosition, text);
           
        }

        public int DeleteText(int k)
        {
            int deletedChar = 0;
            int oldCursorPosition = cursorPosition;

            int newCursor = cursorPosition - k;

            if (newCursor >= 0)
            {
                deletedChar = k;
                cursorPosition = newCursor;
            }
            else
            {
                deletedChar = oldCursorPosition;
                cursorPosition = 0;
            }

            TextData.RemoveRange(cursorPosition, deletedChar);

            //while (k>0 && cursorPosition>0)
            //{
            //    deletedChar++;
            //    cursorPosition--;
            //    TextData.RemoveAt(cursorPosition);
            //    k--;
            //}
            //if (cursorPosition < 0)
            //{
            //    cursorPosition = 0;
            //}
            return deletedChar;
        }

        public string CursorLeft(int k)
        {
            if(cursorPosition-k < 0)
            {
                cursorPosition = 0;
            }
            else
            {
                cursorPosition = cursorPosition - k;
            }

            //while (cursorPosition>0 && k>0)
            //{
            //    k--;
            //    cursorPosition--;
            //}

            var p = TextData.Take(cursorPosition).TakeLast(10);

            return String.Join("", p);
        }

        public string CursorRight(int k)
        {
            if (cursorPosition + k >= TextData.Count)
            {
                cursorPosition = TextData.Count;
            }
            else
            {
                cursorPosition = cursorPosition + k;
            }
            //while (cursorPosition < TextData.Count && k > 0)
            //{
            //    k--;
            //    cursorPosition++;
            //}

            var p = TextData.Take(cursorPosition).TakeLast(10);

            return String.Join("", p);

        }
    }
}
