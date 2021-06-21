using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eDnevnik.Model;
using Microsoft.AspNetCore.Mvc;
using eDnevnik.Interface;
using eDnevnik.Model.Helpers;
using eDnevnik.Model.Request;

namespace eDnevnikApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]

    [ApiController]

    public class ClassSubjectController : ControllerBase
    {
        private readonly IClassSubject _service;
        private readonly IMapper _mapper;

        public ClassSubjectController(IClassSubject service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
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
        public async Task<EDResponse> Add([FromBody] ClassSubjectReq classSubject)
        {
            EDResponse response;
            try
            {
                response = _service.Add(classSubject);

            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom dodavanja veze!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            return response;
        }

        [HttpPut]
        public async Task<EDResponse> Update([FromBody] ClassSubjectReq classSubject)
        {
            EDResponse response;
            try
            {
                response = _service.Update(classSubject);


            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom uređivanja veze!",
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
                    ResponseMessage = "Dogodila se greška prilikom brisanja veze!",
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
