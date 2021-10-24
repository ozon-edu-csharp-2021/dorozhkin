namespace OzonEdu.MerchApi.HttpModels
{
    public class MerchApiVersionResponse
    {
        public MerchApiVersionResponse(string version, string serviceName)
        {
            Version = version;
            ServiceName = serviceName;
        }

        public string Version { get; }
        public string ServiceName { get; }
    }
}