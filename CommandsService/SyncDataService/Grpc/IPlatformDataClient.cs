using CommandsService.Models;
using System.Collections;
using System.Collections.Generic;

namespace CommandsService.SyncDataService.Grpc
{
    public interface IPlatformDataClient
    {
        IEnumerable<Platform> ReturnAllPlatforms();
    }
}
