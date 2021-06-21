using AutoMapper;
using eDnevnik.Interface;
using eDnevnik.Model.Helpers;
using eDnevnik.Model.Request;
using eDnevnikApi.Database;
using eDnevnikApi.Helpers;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Services
{
    public class UserService : IUser
    {
        private readonly eDnevnikContext _context;
        private readonly IMapper _mapper;
        public UserService(eDnevnikContext context, IMapper mapper)
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
                var query = _context
                    .Users
                    .AsQueryable()
                    .Include(x => x.Class)
                    .Include(x => x.BirthPlace)
                    .Include(x => x.Residence)
                    .AsNoTracking();

                var list = query.Where(s => s.Active == true && s.Deleted == false).ToList();
                var roles = _context.UserRoles.Include(x => x.User).Include(x => x.Role).AsQueryable().Where(s => s.Active == true && s.Deleted == false);
                var userList = _mapper.Map<List<Model.User>>(list);
                foreach(var user in userList)
                {
                    var userRoles = roles.Where(s => user.Id == s.UserId).ToList().Select(x => x.Role);

                    user.Roles = _mapper.Map<List<Model.Role>>(userRoles);
                }

                response.Result = userList;
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

        public EDResponse GetStudents()
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 201
            };
            try
            {
                var query = _context
                    .Users
                    .AsQueryable()
                    .Include(x => x.Class)
                    .Include(x => x.BirthPlace)
                    .Include(x => x.Residence)
                    .AsNoTracking();

                var list = query.Where(s => s.Active == true && s.Deleted == false).ToList();
                var roles = _context.UserRoles.Include(x => x.User).Include(x => x.Role).AsQueryable().Where(s => s.Active == true && s.Deleted == false && s.Role.Name == "Student");
                var userList = _mapper.Map<List<Model.User>>(list);
                foreach (var user in userList)
                {
                    var userRoles = roles.Where(s => user.Id == s.UserId).ToList().Select(x => x.Role);

                    user.Roles = _mapper.Map<List<Model.Role>>(userRoles);
                }

                response.Result = userList.Where(x => x.Roles.Count > 0);
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

        public EDResponse GetProfessors()
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 201
            };
            try
            {
                var query = _context
                    .Users
                    .AsQueryable()
                    .Include(x => x.Class)
                    .Include(x => x.BirthPlace)
                    .Include(x => x.Residence)
                    .AsNoTracking();

                var list = query.Where(s => s.Active == true && s.Deleted == false).ToList();
                var roles = _context.UserRoles.Include(x => x.User).Include(x => x.Role).AsQueryable().Where(s => s.Active == true && s.Deleted == false && s.Role.Name == "Profesor");
                var userList = _mapper.Map<List<Model.User>>(list);
                foreach (var user in userList)
                {
                    var userRoles = roles.Where(s => user.Id == s.UserId).ToList().Select(x => x.Role);

                    user.Roles = _mapper.Map<List<Model.Role>>(userRoles);
                }

                response.Result = userList.Where(x => x.Roles.Count > 0);
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
                var query = _context
                    .Users
                    .AsQueryable()
                    .Include(x => x.Class)
                    .Include(x => x.BirthPlace)
                    .Include(x => x.Residence)
                    .Where(s => s.Id == id)
                    .AsNoTracking()
                    .FirstOrDefault();
                var roles = _context
                    .UserRoles
                    .Include(x => x.User)
                    .Include(x => x.Role)
                    .AsQueryable()
                    .Where(s => s.Active == true && s.Deleted == false);
                var school = _context.
                    Schools
                    .AsQueryable()
                    .Where(x => x.PrincipalId == id)
                    .AsNoTracking()
                    .FirstOrDefault();

                var user = _mapper.Map<Model.User>(query);
                user.School = _mapper.Map<Model.School>(school);
                user.Roles = _mapper.Map<List<Model.Role>>(roles.Where(s => user.Id == s.UserId).ToList().Select(x => x.Role));
                response.Result = user;
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

        public EDResponse Add(UserReq user)
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 201
            };
            //string pass = Password.Generate(8, 2);
            try
            {
                var entity = _mapper.Map<User>(user);
                entity.Password = PasswordGenerator.GenerateHash(user.Password);
                _context.Users.Add(entity);
                _context.SaveChanges();

                response.Result = _mapper.Map<Model.User>(entity);
                response.ResponseMessage = "Korisnik je uspješno kreiran";
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
        public EDResponse Update(UserReq userToModify)
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _mapper.Map<User>(userToModify);
                var user = _context.Users.Attach(entity);
                user.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
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
            finally
            {

                response.Result = GetById(userToModify.Id).Result;
                response.ResponseMessage = "Korisnik je uspješno uređen";
            }

            return response;
        }

        public EDResponse Update(Model.User userToModify)
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _mapper.Map<User>(userToModify);
                var user = _context.Users.Attach(entity);
                user.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                response = new EDResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom uređivanja krisnika!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            finally
            {

                response.Result = GetById(userToModify.Id).Result;
                response.ResponseMessage = "Korisnik je uspješno uređen";
            }
            return response;
        }
        public EDResponse Delete(int id)
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 201
            };
            Model.User user = new Model.User();
            try
            {
                user = GetById(id).Result;
                user.Deleted = true;
                user.Active = false;
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
            finally
            {

                response.Result = Update(user);
                response.ResponseMessage = "Korisnik je uspješno izbrisan";
            }
            return response;
        }
    }
}
