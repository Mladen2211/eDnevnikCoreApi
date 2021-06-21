using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eDnevnik.Model;
using Microsoft.AspNetCore.Mvc;
using eDnevnik.Interface;
using eDnevnik.Model.Request;
using eDnevnik.Model.Helpers;

namespace eDnevnikApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]

    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUser _service;
        private readonly IUserRole _urservice;
        private readonly IMapper _mapper;

        public UserController(IUser service, IMapper mapper, IUserRole  urservice)
        {
            _service = service;
            _mapper = mapper;
            _urservice = urservice;
        }
        [HttpGet]
        public async Task<EDResponse> GetAll()
        {
            EDResponse response;
            try
            {
                response = _service.Get();

            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom dohvaćanja podataka!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            return response;

        }
        [HttpGet("students")]
        public async Task<EDResponse> GetStudents()
        {
            EDResponse response;
            try
            {
                response = _service.GetStudents();

            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom dohvaćanja podataka!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            return response;
        }

        [HttpGet("profesors")]
        public async Task<EDResponse> GetProfesors()
        {
            EDResponse response;
            try
            {
                response = _service.GetProfessors();

            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom dohvaćanja podataka!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            return response;
        }

            [HttpGet("{id}")]
        public async Task<EDResponse> GetById([FromRoute] int id)
        {
            EDResponse response;
            try
            {
                response = _service.GetById(id);

            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom dohvaćanja podataka!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            return response;
        }

        [HttpPost("create")]
        public async Task<EDResponse> Add([FromBody] UserReq user)
        {
            EDResponse response;
            try
            {
                response = _service.Add(user);

            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom dodavanja korisnika!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            return response;
        }

        [HttpPost("create/student")]
        public async Task<EDResponse> AddStudent([FromBody] UserReq user)
        {
            EDResponse response;
            try
            {
                response = _service.Add(user);

            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom dodavanja korisnika!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            if(response.ResponseCode == 201)
            {
                
                try
                {
                    UserRoleReq userRole = new UserRoleReq()
                    {
                        UserId = response.Result.Id,
                        RoleId = 1003,
                        Active = true,
                        Deleted = false
                    };
                    response = _urservice.Add(userRole);


                }
                catch (Exception e)
                {
                    response = new EDResponse
                    {
                        ResponseCode = 500,
                        ResponseMessage = "Dogodila se greška prilikom dodavanja korisnika!",
                        ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                    };
                }
            }
            return response;
        }

        [HttpPost("create/professor")]
        public async Task<EDResponse> AddProfessor([FromBody] UserReq user)
        {
            EDResponse response;
            try
            {
                response = _service.Add(user);

            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom dodavanja korisnika!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            if (response.ResponseCode == 201)
            {

                try
                {
                    UserRoleReq userRole = new UserRoleReq()
                    {
                        UserId = response.Result.Id,
                        RoleId = 1,
                        Active = true,
                        Deleted = false
                    };
                    response = _urservice.Add(userRole);


                }
                catch (Exception e)
                {
                    response = new EDResponse
                    {
                        ResponseCode = 500,
                        ResponseMessage = "Dogodila se greška prilikom dodavanja korisnika!",
                        ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                    };
                }
            }
            return response;
        }

        [HttpPut]
        public async Task<EDResponse> Update([FromBody] UserReq user)
        {
            EDResponse response;
            try
            {
                response = _service.Update(user);


            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom uređivanja korisnika!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            return response;
        }

        [HttpDelete("{id}")]
        public async Task<EDResponse> Delete([FromRoute] int id)
        {
            EDResponse response;
            try
            {
                response = _service.Delete(id);


            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom brisanja korisnika!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            return response;
        }
    }
}
