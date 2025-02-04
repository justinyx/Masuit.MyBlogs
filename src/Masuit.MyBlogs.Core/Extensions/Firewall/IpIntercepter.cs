﻿namespace Masuit.MyBlogs.Core.Extensions.Firewall
{
    public class IpIntercepter
    {
        public string IP { get; set; }
        public string RequestUrl { get; set; }
        public string Referer { get; set; }
        public string Address { get; set; }
        public string UserAgent { get; set; }
        public DateTime Time { get; set; }
        public string Remark { get; set; }
        public string HttpVersion { get; set; }
        public string Headers { get; set; }
    }
}