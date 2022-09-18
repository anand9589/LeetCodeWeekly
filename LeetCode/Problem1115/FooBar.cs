namespace Problem1115
{
    public class FooBar
    {
        private int n;
        ManualResetEventSlim foo_event;
        ManualResetEventSlim bar_event;
        public FooBar(int n)
        {
            this.n = n;
            foo_event = new ManualResetEventSlim();
            bar_event = new ManualResetEventSlim(true);
        }

        public void Foo(Action printFoo)
        {

            for (int i = 0; i < n; i++)
            {

                bar_event.Wait();
                bar_event.Reset();
                // printFoo() outputs "foo". Do not change or remove this line.
                printFoo();
                foo_event.Set();
                
            }
        }

        public void Bar(Action printBar)
        {

            for (int i = 0; i < n; i++)
            {
                foo_event.Wait();
                foo_event.Reset();

                // printBar() outputs "bar". Do not change or remove this line.
                printBar();
                bar_event.Set();
            }
        }
    }
}