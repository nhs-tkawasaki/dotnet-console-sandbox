# dotnet-console-sandbox

## gen-hash-test
```
cd MyConsoleApp
dotnet run [args]
```
* no args : `SHA256.ComputeHash()` - non-thread safe
* any args : `SHA256.HashData()` - thread safe
