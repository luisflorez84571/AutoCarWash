using System.Runtime.InteropServices;

namespace CarWashing.API.Data
{
    public interface IRuntimeInformationWrapper
    {
        bool IsOSPlatform(OSPlatform osPlatform);
    }
}