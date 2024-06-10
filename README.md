# dotnet-console-sandbox

## gen-hash-test
[![Open in GitHub Codespaces](https://github.com/codespaces/badge.svg)](https://codespaces.new/nhs-tkawasaki/dotnet-console-sandbox/tree/get-hash-test)
```
cd MyConsoleApp
dotnet run [args]
```
* no args : `SHA256.ComputeHash()` - non-thread safe
* any args : `SHA256.HashData()` - thread safe
