## NET9 Android Crash with Assembly Compression disabled

Tracking Issues
* https://github.com/dotnet/android/issues/9752
* https://github.com/getsentry/sentry-dotnet/issues/3920

The following code:
```csharp
using var sha = SHA1.Create();
var hash = sha.ComputeHash(bytes);
var hi = Convert.ToHexString(hash);
```

Causes this:
```
android.runtime.JavaProxyThrowable: [System.Security.Cryptography.CryptographicException]: Cryptography_ConcurrentUseNotSupported
at System.Security.Cryptography.ConcurrencyBlock.Enter + 0x1a(Unknown Source)
at System.Security.Cryptography.HashProviderDispenser+EvpHashProvider.FinalizeHashAndReset + 0x0(Unknown Source)
at System.Security.Cryptography.HashProvider.FinalizeHashAndReset + 0x13(Unknown Source)
at System.Security.Cryptography.SHA1+Implementation.HashFinal + 0x0(Unknown Source)
at System.Security.Cryptography.HashAlgorithm.CaptureHashCodeAndReinitialize + 0x0(Unknown Source)
at System.Security.Cryptography.HashAlgorithm.ComputeHash + 0x22(Unknown Source)
at Sentry.Internal.Extensions.HashExtensions.GetHashString + 0x12(Unknown Source)
```

