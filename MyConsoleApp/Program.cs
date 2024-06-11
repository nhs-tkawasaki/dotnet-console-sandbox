using System.Collections.Concurrent;
using System.Diagnostics;
using System.Security.Cryptography;

//  no args : instance
// any args : static
bool flag = args.Length > 0;

const int N = 10;
Stopwatch sw = new();
var sha256 = SHA256.Create();
var bag = new ConcurrentBag<byte[]>();

sw.Start();
Parallel.ForEach(Enumerable.Range(0, N), i => {
    byte[] b = { (byte)i };
    bag.Add(
        flag ? SHA256.HashData(b) : sha256.ComputeHash(b)
    );
});
sw.Stop();

Console.WriteLine(flag ? "static" : "instance");
;
var distinct = bag.Select(b => BitConverter.ToString(b)).Distinct().ToArray();
foreach (var b in distinct) {
    Console.WriteLine(b);
}
if (distinct.Length < N) Console.WriteLine("Duplicated!");
Console.WriteLine(sw.Elapsed);
