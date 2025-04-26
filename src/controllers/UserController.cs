using System.ComponentModel.DataAnnotations;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using yume_api.src.dtos;
using yume_api.src.managers.hadlers.user.get;
using yume_api.src.repository.entities;

namespace yume_api.src.controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IValidator<User> _validator;

        public UserController(IMediator mediator, IMapper mapper, IValidator<User> validator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet("email")]
        public async Task<IActionResult> Get([Required] string email)
        {
            var contract = new GetUserMiddleData(email);
            var middleResponse = await _mediator.Send(contract);
            var student = _mapper.Map<UserDTO>(middleResponse);

            return Ok(student);
        }
    }
}