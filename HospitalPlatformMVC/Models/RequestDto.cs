using HospitalPlatformMVC.Utility;
using System.Net.Mime;
using System.Security.AccessControl;
using static HospitalPlatformMVC.Utility.SD;

namespace HospitalPlatformMVC.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }

        public SD.ContentType ContentType { get; set; } = SD.ContentType.Json;
    }
}
