using PlatformService.DTOs;
using System.Threading.Tasks;

namespace CommandsService.SyncDataService.Http
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformReadDTO plat);
    }
}
