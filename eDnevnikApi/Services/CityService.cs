using AutoMapper;
using eDnevnik.Interface;
using eDnevnik.Model.Helpers;
using eDnevnik.Model.Request;
using eDnevnikApi.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Services
{
    public class CityService : ICity
    {
        private readonly eDnevnikContext _context;
        private readonly IMapper _mapper;
        public CityService(eDnevnikContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public EDResponse Get()
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 201
            };
            try
            {
                var query = _context.Cities.AsQueryable();


                var list = query.Where(s => s.Active == true).ToList();

                response.Result = _mapper.Map<List<Model.City>>(list);

            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom dohvaćanja podataka",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }

            return response;
        }

        public EDResponse GetById(int id)
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 201
            };
            try
            {
                var query = _context.Cities.Where(s => s.Id == id).AsNoTracking().FirstOrDefault();

                response.Result = _mapper.Map<Model.City>(query);
            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom dohvaćanja podataka",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }

            return response;
        }

        public EDResponse Add(CityReq city)
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 201
            };

            try
            {
                var entity = _mapper.Map<City>(city);

                _context.Cities.Add(entity);
                _context.SaveChanges();

                response.Result = _mapper.Map<Model.City>(entity);
                response.ResponseMessage = "Grad je uspješno kreiran";
            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom dodavanja grada!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }

            return response;
        }
        public EDResponse Update(CityReq cityToModify)
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _mapper.Map<City>(cityToModify);
                var city = _context.Cities.Attach(entity);
                city.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom uređivanja grada!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            finally
            {

                response.Result = GetById(cityToModify.Id).Result;
                response.ResponseMessage = "Grad je uspješno uređen";
            }

            return response;
        }

        public EDResponse Update(Model.City cityToModify)
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _mapper.Map<City>(cityToModify);
                var city = _context.Cities.Attach(entity);
                city.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom uređivanja grada!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            finally
            {

                response.Result = GetById(cityToModify.Id).Result;
                response.ResponseMessage = "Grad je uspješno uređen";
            }
            return response;
        }
        public EDResponse Delete(int id)
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 201
            };
            Model.City city = new Model.City();
            try
            {
                city = GetById(id).Result;
                city.Deleted = true;
                city.Active = false;
            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom brisanja grada!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            finally
            {

                response.Result = Update(city);
                response.ResponseMessage = "Grad je uspješno izbrisan";
            }
            return response;
        }
    }
}
