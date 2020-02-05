# Twi<span>tchApi.N</span>et

[![Nuget](https://img.shields.io/nuget/v/TwitchApi.Net?style=flat-square)](https://www.nuget.org/packages/TwitchApi.Net/)
[![NuGet](https://img.shields.io/nuget/dt/TwitchApi.Net?style=flat-square)](https://www.nuget.org/packages/TwitchApi.Net/)

Twi<span>tchApi.N</span>et aims to provide easy, thread-safe access to the Twitch Helix API. Under the hood it is targeting `netstandard2.0`, so it can be use with either .NET Framework or .NET Core. The libray also ships with a rate-limit bypass, which enforces waits between requests so you won't exceed the Helix API rate-limiting.

# Installation
To install this library via [NuGet](https://www.nuget.org/packages/TwitchApi.Net/), use:
```ps
Install-Package TwitchApi.Net
```

# Supported Helix API sections
* [Clips](https://dev.twitch.tv/docs/api/reference#get-clips)
* [Users](https://dev.twitch.tv/docs/api/reference#get-users)
* [User Follows](https://dev.twitch.tv/docs/api/reference#get-users-follows)
* [Games](https://dev.twitch.tv/docs/api/reference#get-games)
* [Top Games](https://dev.twitch.tv/docs/api/reference#get-top-games)
* [Streams](https://dev.twitch.tv/docs/api/reference#get-streams)
* [Videos](https://dev.twitch.tv/docs/api/reference#get-videos)

# MIT License
Copyright (c) 2019 Fabian Vowie

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
