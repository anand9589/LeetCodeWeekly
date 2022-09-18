// See https://aka.ms/new-console-template for more information
using LeetCode;
using Problem1115;

FooBar fooBar = new FooBar(2);

Thread A = new Thread( ()=> { fooBar.Foo(foo); });
Thread B = new Thread(() => { fooBar.Bar(bar); });
A.Start();
B.Start();  

void foo()
{
    Console.WriteLine("foo");
}

void bar()
{
    Console.WriteLine("bar");
}