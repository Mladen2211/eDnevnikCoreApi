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
    public class SubjectService : ISubject
    {
        private readonly eDnevnikContext _context;
        private readonly IMapper _mapper;
        public SubjectService(eDnevnikContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public EDResponse Get()
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 200
            };
            try
            {
                var query = _context.Subjects.AsQueryable();


                var list = query.Where(s => s.Active == true).Include(x => x.TeachingProfessorNavigation).ToList();

                response.Result = _mapper.Map<List<Model.Subject>>(list);

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
            if(response.Result.Count == 0)
            {
                response.ResponseCode = 404;
                response.ResponseMessage = "Podatci nisu pronađeni!";
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
                var query = _context.Subjects.Where(s => s.Id == id).AsNoTracking().FirstOrDefault();

                response.Result = _mapper.Map<Model.Subject>(query);
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

        public EDResponse Add(SubjectReq subject)
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 201
            };

            try
            {
                var entity = _mapper.Map<Subject>(subject);

                _context.Subjects.Add(entity);
                _context.SaveChanges();

                response.Result = _mapper.Map<Model.Subject>(entity);
                response.ResponseMessage = "Predmet je uspješno kreiran";
            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom dodavanja predmeta!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }

            return response;
        }
        public EDResponse Update(SubjectReq subjectToModify)
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _mapper.Map<Subject>(subjectToModify);
                var subject = _context.Subjects.Attach(entity);
                subject.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom uređivanja predmeta!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            finally
            {

                response.Result = GetById(subjectToModify.Id).Result;
                response.ResponseMessage = "Predmet je uspješno uređen";
            }

            return response;
        }

        public EDResponse Update(Model.Subject subjectToModify)
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _mapper.Map<Subject>(subjectToModify);
                var subject = _context.Subjects.Attach(entity);
                subject.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom uređivanja predmeta!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            finally
            {

                response.Result = GetById(subjectToModify.Id).Result;
                response.ResponseMessage = "Predmet je uspješno uređen";
            }
            return response;
        }
        public EDResponse Delete(int id)
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 201
            };
            Model.Subject subject = new Model.Subject();
            try
            {
                subject = GetById(id).Result;
                subject.Deleted = true;
                subject.Active = false;
            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom brisanja predmeta!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            finally
            {

                response.Result = Update(subject);
                response.ResponseMessage = "Predmet je uspješno izbrisan";
            }
            return response;
        }
    }
}
