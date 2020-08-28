using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MemeSharingAPI.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemeSharingAPI.Controllers
{
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
    }
}