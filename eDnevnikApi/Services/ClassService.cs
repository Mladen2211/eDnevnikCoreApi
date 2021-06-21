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
    public class ClassService : IClass
    {
        private readonly eDnevnikContext _context;
        private readonly IMapper _mapper;
        public ClassService(eDnevnikContext context, IMapper mapper)
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
                var query = _context.Classes.AsQueryable();


                var list = query.Where(s => s.Active == true).ToList();

                response.Result = _mapper.Map<List<Model.Class>>(list);

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
                var query = _context.Classes.Where(s => s.Id == id).AsNoTracking().FirstOrDefault();

                response.Result = _mapper.Map<Model.Class>(query);
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

        public EDResponse Add(ClassReq classReq)
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 201
            };

            try
            {
                var entity = _mapper.Map<Class>(classReq);

                _context.Classes.Add(entity);
                _context.SaveChanges();

                response.Result = _mapper.Map<Model.Class>(entity);
                response.ResponseMessage = "Razred je uspješno kreiran";
            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom dodavanja razreda!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }

            return response;
        }
        public EDResponse Update(ClassReq classToModify)
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _mapper.Map<Class>(classToModify);
                var class1 = _context.Classes.Attach(entity);
                class1.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom uređivanja razreda!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            finally
            {

                response.Result = GetById(classToModify.Id).Result;
                response.ResponseMessage = "Razred je uspješno uređen";
            }

            return response;
        }

        public EDResponse Update(Model.Class classToModify)
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _mapper.Map<Class>(classToModify);
                var class1 = _context.Classes.Attach(entity);
                class1.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom uređivanja razreda!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            finally
            {

                response.Result = GetById(classToModify.Id).Result;
                response.ResponseMessage = "Razred je uspješno uređen";
            }
            return response;
        }
        public EDResponse Delete(int id)
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 201
            };
            Model.Class class1 = new Model.Class();
            try
            {
                class1 = GetById(id).Result;
                class1.Deleted = true;
                class1.Active = false;
            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom brisanja razreda!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            finally
            {

                response.Result = Update(class1);
                response.ResponseMessage = "Razred je uspješno izbrisan";
            }
            return response;
        }
    }
}
