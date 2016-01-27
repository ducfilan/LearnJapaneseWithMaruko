// FacebookUtils/ResponseData.cs

namespace Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers.FacebookIntegrationHelpers
{
    public class ResponseData
    {
        public string id { get; set; }
        public ErrorData error { get; set; }
    }

    public class ErrorData
    {
        public int code { get; set; }
        public int error_subcode { get; set; }
    }
}
