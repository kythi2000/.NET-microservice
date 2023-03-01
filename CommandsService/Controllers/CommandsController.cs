using AutoMapper;
using CommandsService.Data;
using CommandsService.DTOs;
using CommandsService.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CommandsService.Controllers
{

    [Route("api/c/platforms/{platformId}/[controller]")]
    [ApiController]
    public class CommandsController : Controller
    {
        private readonly ICommandRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommandRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDTO>> GetCommandsForPlatform(int platformId)
        {
            Console.WriteLine($"--> Hit GetCommandsForPlatform: {platformId}");

            if(!_repository.PlatformExits(platformId))
            {
                return NotFound();
            }

            var commands = _repository.GetCommandsForPlatform(platformId);

            return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(commands));
        }

        [HttpGet("{commandId}", Name = "GetCommandForPlatform")]
        public ActionResult<CommandReadDTO> GetCommandForPlatform(int platformId, int commandId) 
        {
            Console.WriteLine($"--> Hit GetCommandForPlatform: {platformId} / {commandId}");

            if (!_repository.PlatformExits(platformId))
            {
                return NotFound();
            }

            var command = _repository.GetCommand(platformId, commandId);

            if(command == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CommandReadDTO>(command));
        }

        [HttpPost]
        public ActionResult<CommandCreateDTO> CreateCommandForPlatform(int platformId, CommandCreateDTO commandDTO)
        {
            Console.WriteLine($"--> Hit CreateCommandForPlatform: {platformId}");

            if (!_repository.PlatformExits(platformId))
            {
                return NotFound();
            }

            var command = _mapper.Map<Command>(commandDTO);

            _repository.CreateCommand(platformId, command);
            _repository.SaveChange();

            var commandReadDTO = _mapper.Map<CommandReadDTO>(command);

            return CreatedAtRoute(nameof(GetCommandForPlatform), 
                new { platformId = platformId, commandId = commandReadDTO.Id }, commandReadDTO);

        }
    }
}
