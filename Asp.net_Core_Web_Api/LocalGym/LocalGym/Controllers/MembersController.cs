﻿using AutoMapper;
using LocalGym.Models;
using LocalGym.Profiles;
using LocalGym.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace LocalGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private ILocalGymRepository _localGymRepository;
        private IMapper _mapper;
        public MembersController(ILocalGymRepository localGymRepository, IMapper mapper)
        {
            _localGymRepository = localGymRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllMembers()
        {
            var members = await _localGymRepository.GetMembersAsync();

            return Ok(_mapper.Map<IEnumerable<MemberDto>>(members));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMemberByID(int id)
        {
            var members = await _localGymRepository.GetMemberAsync(id);
            if(members==null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<MemberDto>(members));
        }
    }
}