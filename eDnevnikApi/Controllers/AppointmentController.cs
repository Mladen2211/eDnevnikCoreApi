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

    public class AppointmentController : ControllerBase
    {
        private readonly IAppointment _service;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointment service, IMapper mapper)
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
        public async Task<EDResponse> Add([FromBody] AppointmentReq appointment)
        {
            EDResponse response;
            try
            {
                response = _service.Add(appointment);

            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom dodavanja događaja!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            return response;
        }

        [HttpPut]
        public async Task<EDResponse> Update([FromBody] AppointmentReq appointment)
        {
            EDResponse response;
            try
            {
                response = _service.Update(appointment);


            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom uređivanja događaja!",
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
                    ResponseMessage = "Dogodila se greška prilikom brisanja događaja!",
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
