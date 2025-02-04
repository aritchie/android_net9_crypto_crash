using System.Security.Cryptography;
using System.Text;
using System;

namespace AndroidApp1;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : Activity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);
        
        var bytes = Encoding.UTF8.GetBytes("Hello World");
// #if NET9_0 && ANDROID
//  this will cause an internal crash with mono
//         var hash = SHA1.HashData(bytes);
//         var hi = Convert.ToHexString(hash);
//         
// #else
        using var sha = SHA1.Create();
        var hash = sha.ComputeHash(bytes);
        var hi = Convert.ToHexString(hash);
// #endif
        Console.WriteLine("SAMPLE HASH: " + hi);
    }
}