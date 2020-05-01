# WowzaCloudSharp
Wowza Cloud REST Api C# SDK

Working with the Wowza Cloud API and using C#, this could be useful for you as a startign point.

Not all endpoints have been added. Changes are still be worked on. Code refactoring and Restructuring needs doing too.

It's a .net Standard Library that should work with most applications.

# Sample Code
 var wowza = new Wowza("**API KEY**", "**ACCESS KEY**")
            {
                UseBasicAuth = false,
                IsSandbox = false
            };
            
 var liveStreamService = new LiveStreamService(wowza);
 
 // Use this to create the LiveStream and wait for the result which
 
 var result = await liveStreamService.CreateLiveStreamAsync(liveStreamModel: liveStreamModel);
 
 
