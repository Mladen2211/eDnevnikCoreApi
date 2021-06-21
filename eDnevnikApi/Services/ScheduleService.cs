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
    public class ScheduleService: ISchedule
    {
        private readonly eDnevnikContext _context;
        private readonly IMapper _mapper;
        public ScheduleService(eDnevnikContext context, IMapper mapper)
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
                var query = _context.Schedules.AsQueryable();


                var list = query.Where(s => s.Active == true).ToList();

                response.Result = _mapper.Map<List<Model.Schedule>>(list);

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
                var query = _context.Schedules.Where(s => s.Id == id).AsNoTracking().FirstOrDefault();

                response.Result = _mapper.Map<Model.Schedule>(query);
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

        public EDResponse Add(ScheduleReq schedule)
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 201
            };

            try
            {
                var entity = _mapper.Map<Schedule>(schedule);

                _context.Schedules.Add(entity);
                _context.SaveChanges();

                response.Result = _mapper.Map<Model.Schedule>(entity);
                response.ResponseMessage = "Raspored je uspješno kreiran";
            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom dodavanja rasporeda!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }

            return response;
        }
        public EDResponse Update(ScheduleReq scheduleToModify)
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _mapper.Map<Schedule>(scheduleToModify);
                var schedule = _context.Schedules.Attach(entity);
                schedule.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom uređivanja rasporeda!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            finally
            {

                response.Result = GetById(scheduleToModify.Id).Result;
                response.ResponseMessage = "Raspored je uspješno uređen";
            }

            return response;
        }

        public EDResponse Update(Model.Schedule scheduleToModify)
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _mapper.Map<Schedule>(scheduleToModify);
                var schedule = _context.Schedules.Attach(entity);
                schedule.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom uređivanja rasporeda!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            finally
            {

                response.Result = GetById(scheduleToModify.Id).Result;
                response.ResponseMessage = "Raspored je uspješno uređen";
            }
            return response;
        }
        public EDResponse Delete(int id)
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 201
            };
            Model.Schedule schedule = new Model.Schedule();
            try
            {
                schedule = GetById(id).Result;
                schedule.Deleted = true;
                schedule.Active = false;
            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom brisanja rasporeda!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            finally
            {

                response.Result = Update(schedule);
                response.ResponseMessage = "Raspored je uspješno izbrisan";
            }
            return response;
        }
    }
}
