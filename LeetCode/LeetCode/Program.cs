// See https://aka.ms/new-console-template for more information
using LeetCode;
using Problem1116;

ZeroEvenOdd zeroEvenOdd = new ZeroEvenOdd(5);

Thread A = new Thread(() => { zeroEvenOdd.Zero(printNumber); });
Thread B = new Thread(() => { zeroEvenOdd.Odd(printNumber); });
Thread C = new Thread(() => { zeroEvenOdd.Even(printNumber); });
A.Start();
B.Start();
C.Start();

void printNumber(int n)
{
    Console.WriteLine(n);
}