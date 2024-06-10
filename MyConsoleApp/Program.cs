using System.Collections.Concurrent;
using System.Diagnostics;
using System.Security.Cryptography;

//  no args : instance
// any args : static
bool flag = args.Length > 0;

Stopwatch sw = new();
var sha256 = SHA256.Create();
var queue = new ConcurrentQueue<byte[]>();

sw.Start();
Parallel.ForEach(Enumerable.Range(0, 10), i => {
    byte[] b = { (byte)i };
    queue.Enqueue(
        flag ? SHA256.HashData(b) : sha256.ComputeHash(b)
    );
});
sw.Stop();

Console.WriteLine(flag ? "static" : "instance");
foreach (var q in queue) {
    Console.WriteLine(BitConverter.ToString(q));
}
Console.WriteLine(sw.Elapsed);
