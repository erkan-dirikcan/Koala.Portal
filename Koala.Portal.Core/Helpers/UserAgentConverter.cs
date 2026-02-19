using Koala.Portal.Core.Dtos;

namespace Koala.Portal.Core.Helpers
{
    public static class UserAgentConverter
    {
        public static UserAgentDto GetDecryptedUserAgent(string agent)
        {
            var agentList = new List<UserAgentDto>{
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 78.0.3904.108 Safari / 537.36",BrowserSoftware = "Chrome 78",LayoutEngine = "Blink",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 5.1; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 60.0.3112.90 Safari / 537.36",BrowserSoftware = "Chrome 60",LayoutEngine = "Blink",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 6.2; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 60.0.3112.90 Safari / 537.36",BrowserSoftware = "Chrome 60",LayoutEngine = "Blink",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(iPhone; CPU iPhone OS 13_4_1 like Mac OS X) AppleWebKit / 605.1.15(KHTML, like Gecko) Version / 13.1 Mobile / 15E148 Safari / 604.1",BrowserSoftware = "Safari 13.1",LayoutEngine = "WebKit",OperatingSystem = "iOS"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Macintosh; Intel Mac OS X 10_14_4) AppleWebKit / 605.1.15(KHTML, like Gecko)",BrowserSoftware = "Webkit based browser",LayoutEngine = "WebKit",OperatingSystem = "macOS"},
            new UserAgentDto{Agent = "Mozilla / 5.0(iPad; CPU OS 9_3_5 like Mac OS X) AppleWebKit / 601.1.46(KHTML, like Gecko) Mobile / 13G36",BrowserSoftware = "Webkit based browser",LayoutEngine = "WebKit",OperatingSystem = "iOS"},
            new UserAgentDto{Agent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 79.0.3945.130 Safari / 537.36",BrowserSoftware = "Chrome 79",LayoutEngine = "Blink",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 4.0(compatible; MSIE 6.0; Windows 98)",BrowserSoftware = "Internet Explorer 6",LayoutEngine = "Trident",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(iPhone; CPU iPhone OS 12_4_1 like Mac OS X) AppleWebKit / 605.1.15(KHTML, like Gecko) Version / 12.1.2 Mobile / 15E148 Safari / 604.1",BrowserSoftware = "Safari 12.1",LayoutEngine = "WebKit",OperatingSystem = "iOS"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 84.0.4147.105 Safari / 537.36",BrowserSoftware = "Chrome 84",LayoutEngine = "Blink",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 52.0.2743.116 Safari / 537.36 Edge / 15.15063",BrowserSoftware = "Edge 40",LayoutEngine = "EdgeHTML",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 6.3; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 60.0.3112.113 Safari / 537.36",BrowserSoftware = "Chrome 60",LayoutEngine = "Blink",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(iPhone; CPU iPhone OS 12_3_1 like Mac OS X) AppleWebKit / 605.1.15(KHTML, like Gecko) Version / 12.1.1 Mobile / 15E148 Safari / 604.1",BrowserSoftware = "Safari 12.1",LayoutEngine = "WebKit",OperatingSystem = "iOS"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 67.0.3396.99 Safari / 537.36",BrowserSoftware = "Chrome 67",LayoutEngine = "Blink",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 6.3; WOW64; Trident / 7.0; rv: 11.0) like Gecko",BrowserSoftware = "Internet Explorer 11",LayoutEngine = "Trident",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla/5.0 (Windows NT 5.1; rv: 36.0) Gecko / 20100101 Firefox / 36.0",BrowserSoftware = "Firefox 36",LayoutEngine = "Gecko",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Macintosh; Intel Mac OS X 10_12_6) AppleWebKit / 603.3.8(KHTML, like Gecko)",BrowserSoftware = "Webkit based browser",LayoutEngine = "WebKit",OperatingSystem = "macOS"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Macintosh; Intel Mac OS X 10_15_4) AppleWebKit / 605.1.15(KHTML, like Gecko) Version / 13.1 Safari / 605.1.15",BrowserSoftware = "Safari 13.1",LayoutEngine = "WebKit",OperatingSystem = "macOS"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 81.0.4044.138 Safari / 537.36",BrowserSoftware = "Chrome 81",LayoutEngine = "Blink",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 83.0.4103.116 Safari / 537.36",BrowserSoftware = "Chrome 83",LayoutEngine = "Blink",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 4.0(compatible; MSIE 6.0; Windows NT 5.0; .NET CLR 1.1.4322)",BrowserSoftware = "Internet Explorer 6",LayoutEngine = "Trident",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 5.1; rv: 33.0) Gecko / 20100101 Firefox / 33.0",BrowserSoftware = "Firefox 33",LayoutEngine = "Gecko",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(iPhone; CPU iPhone OS 11_4_1 like Mac OS X) AppleWebKit / 605.1.15(KHTML, like Gecko) Version / 11.0 Mobile / 15E148 Safari / 604.1",BrowserSoftware = "Safari 11",LayoutEngine = "WebKit",OperatingSystem = "iOS"},
            new UserAgentDto{Agent = "Mozilla / 5.0(compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident / 5.0)",BrowserSoftware = "Internet Explorer 9",LayoutEngine = "Trident",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 58.0.3029.110 Safari / 537.36 Edge / 16.16299",BrowserSoftware = "Edge 41",LayoutEngine = "EdgeHTML",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 80.0.3987.132 Safari / 537.36",BrowserSoftware = "Chrome 80",LayoutEngine = "Blink",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 68.0.3440.106 Safari / 537.36",BrowserSoftware = "Chrome 68",LayoutEngine = "Blink",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 74.0.3729.131 Safari / 537.36",BrowserSoftware = "Chrome 74",LayoutEngine = "Blink",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 72.0.3626.121 Safari / 537.36",BrowserSoftware = "Chrome 72",LayoutEngine = "Blink",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(compatible; MSIE 9.0; Windows NT 6.1; Win64; x64; Trident / 5.0)",BrowserSoftware = "Internet Explorer 9",LayoutEngine = "Trident",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 4.0(compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322)",BrowserSoftware = "Internet Explorer 7",LayoutEngine = "Trident",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64; rv: 66.0) Gecko / 20100101 Firefox / 66.0",BrowserSoftware = "Firefox 66",LayoutEngine = "Gecko",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 6.1; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 79.0.3945.88 Safari / 537.36",BrowserSoftware = "Chrome 79",LayoutEngine = "Blink",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(compatible; MSIE 10.0; Windows NT 6.2)",BrowserSoftware = "Internet Explorer 10",LayoutEngine = "Trident",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Macintosh; Intel Mac OS X 10_14_5) AppleWebKit / 605.1.15(KHTML, like Gecko) Version / 12.1.1 Safari / 605.1.15",BrowserSoftware = "Safari 12.1",LayoutEngine = "WebKit",OperatingSystem = "macOS"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 65.0.3325.181 Safari / 537.36",BrowserSoftware = "Chrome 65",LayoutEngine = "Blink",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 10.0; WOW64; rv: 50.0) Gecko / 20100101 Firefox / 50.0",BrowserSoftware = "Firefox 50",LayoutEngine = "Gecko",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 10.0; WOW64; rv: 52.0) Gecko / 20100101 Firefox / 52.0",BrowserSoftware = "Firefox 52",LayoutEngine = "Gecko",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 84.0.4147.135 Safari / 537.36",BrowserSoftware = "Chrome 84",LayoutEngine = "Blink",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 80.0.3987.163 Safari / 537.36",BrowserSoftware = "Chrome 80",LayoutEngine = "Blink",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 85.0.4183.102 Safari / 537.36",BrowserSoftware = "Chrome 85",LayoutEngine = "Blink",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident / 6.0)",BrowserSoftware = "Internet Explorer 10",LayoutEngine = "Trident",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64; rv: 67.0) Gecko / 20100101 Firefox / 67.0",BrowserSoftware = "Firefox 67",LayoutEngine = "Gecko",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 6.1; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 69.0.3497.100 Safari / 537.36",BrowserSoftware = "Chrome 69",LayoutEngine = "Blink",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(compatible; MSIE 9.0; Windows NT 6.1; Trident / 5.0)",BrowserSoftware = "Internet Explorer 9",LayoutEngine = "Trident",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(iPhone; CPU iPhone OS 13_6_1 like Mac OS X) AppleWebKit / 605.1.15(KHTML, like Gecko) Version / 13.1.2 Mobile / 15E148 Safari / 604.1",BrowserSoftware = "Safari 13.1",LayoutEngine = "WebKit",OperatingSystem = "iOS"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 64.0.3282.186 Safari / 537.36",BrowserSoftware = "Chrome 64",LayoutEngine = "Blink",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 6.1; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 63.0.3239.132 Safari / 537.36",BrowserSoftware = "Chrome 63",LayoutEngine = "Blink",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 57.0.2987.133 Safari / 537.36",BrowserSoftware = "Chrome 57",LayoutEngine = "Blink",OperatingSystem = "Windows"},
            new UserAgentDto{Agent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 61.0.3163.100 Safari / 537.36",BrowserSoftware = "Chrome 61",LayoutEngine = "Blink",OperatingSystem = "Windows"},
            };
            var retVal = agentList.FirstOrDefault(x => x.Agent == agent);
            return retVal;
        }
    }
}
