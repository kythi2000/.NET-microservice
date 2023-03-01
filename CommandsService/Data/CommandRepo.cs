using CommandsService.Model;
using CommandsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandsService.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly AppDbContext _context;
        public CommandRepo(AppDbContext context) 
        {
            _context = context;
        }
        public void CreateCommand(int platformId, Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            command.PlatformId= platformId;
            _context.Commands.Add(command);
        }

        public void CreatePlatform(Platform platform)
        {
            if(platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }
            _context.Platforms.Add(platform);
        }

        public Command GetCommand(int platformId, int commandId)
        {
            return _context.Commands
                    .Where(c => c.PlatformId == platformId && c.Id == commandId).FirstOrDefault();
        }

        public IEnumerable<Command> GetCommandsForPlatform(int platformId)
        {
            return _context.Commands.Where(p => p.PlatformId == platformId)
                .OrderBy(p => p.Platform.Name);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public bool PlatformExits(int platformId)
        {
            return _context.Platforms.Any(p => p.ID == platformId);
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool ExternalPlatformExists(int externalPlatformID)
        {
            return _context.Platforms.Any(p => p.ExternalID == externalPlatformID);
        }
    }
}
