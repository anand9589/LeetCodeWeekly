namespace Problem1116
{
    public class ZeroEvenOdd
    {
        private int n;
        AutoResetEvent m_eventZero;
        AutoResetEvent m_eventOdd;
        AutoResetEvent m_eventEven;
        public ZeroEvenOdd(int n)
        {
            this.n = n;
            m_eventZero = new AutoResetEvent(true);
            m_eventOdd = new AutoResetEvent(false);
            m_eventEven = new AutoResetEvent(false);

        }

        // printNumber(x) outputs "x", where x is an integer.
        public void Zero(Action<int> printNumber)
        {
            for (int i = 0; i < n; i++)
            {
                m_eventZero.WaitOne();
                printNumber(0);
                if (i%2==0)
                {
                    m_eventOdd.Set();
                }
                else
                {
                    m_eventEven.Set();
                }
            }
        }

        public void Even(Action<int> printNumber)
        {
            for (int i = 2; i <= n; i += 2)
            {
                m_eventEven.WaitOne();
                printNumber(i);
                m_eventZero.Set();
            }
        }

        public void Odd(Action<int> printNumber)
        {
            for (int i = 1; i <= n; i += 2)
            {
                m_eventOdd.WaitOne();
                printNumber(i);
                m_eventZero.Set();
            }

        }
    }
}