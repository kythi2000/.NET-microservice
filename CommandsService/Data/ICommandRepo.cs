using CommandsService.Model;
using CommandsService.Models;
using System.Collections.Generic;

namespace CommandsService.Data
{
    public interface ICommandRepo
    {
        bool SaveChange();

        // Platform
        IEnumerable<Platform> GetAllPlatforms();
        void CreatePlatform(Platform platform);
        bool PlatformExits(int platformId);
        bool ExternalPlatformExists(int externalPlatformID);

        // Command
        IEnumerable<Command> GetCommandsForPlatform(int platformId);
        Command GetCommand(int platformId, int commandId);
        void CreateCommand(int platformId, Command command);

    }
}
