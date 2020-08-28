using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MemeSharingAPI.Data.Dtos;
using MemeSharingAPI.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemeSharingAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/types")]
    [ApiController]
    public class MemeTypesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMemeTypeRepository _repo;

        public MemeTypesController(IMapper mapper, IMemeTypeRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMemeTypes()
        {
            var memeTypes = await _repo.GetAllTypes();
            var memeTypesReadDto = _mapper.Map<IEnumerable<MemeTypeReadDto>>(memeTypes);

            return Ok(memeTypesReadDto);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetAllMemeTypesWithId()
        {
            var memeTypes = await _repo.GetAllTypes();
            var memeTypesReadIdDto = _mapper.Map<IEnumerable<MemeTypeReadIdDto>>(memeTypes);

            return Ok(memeTypesReadIdDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMemeTypeById(int id)
        {
            var memeTypeFromDb = await _repo.GetMemeTypeById(id);
            if (memeTypeFromDb == null)
                return NotFound("Type with that id was not found!");

            var memeTypeReadDto = _mapper.Map<MemeTypeReadDto>(memeTypeFromDb);

            return Ok(memeTypeReadDto);
        }
    }
}