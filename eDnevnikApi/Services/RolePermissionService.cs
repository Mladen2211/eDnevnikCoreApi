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
    public class RolePermissionService : IRolePermission
    {
        private readonly eDnevnikContext _context;
        private readonly IMapper _mapper;
        public RolePermissionService(eDnevnikContext context, IMapper mapper)
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
                var query = _context.RolePermissions.AsQueryable();


                var list = query.Where(s => s.Active == true).ToList();

                response.Result = _mapper.Map<List<Model.RolePermission>>(list);

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
                var query = _context.RolePermissions.Where(s => s.Id == id).AsNoTracking().FirstOrDefault();

                response.Result = _mapper.Map<Model.RolePermission>(query);
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

        public EDResponse Add(RolePermissionReq rolePermission)
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 201
            };

            try
            {
                var entity = _mapper.Map<RolePermission>(rolePermission);

                _context.RolePermissions.Add(entity);
                _context.SaveChanges();

                response.Result = _mapper.Map<Model.RolePermission>(entity);
                response.ResponseMessage = "Veza je uspješno kreirana";
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
        public EDResponse Update(RolePermissionReq permissionToModify)
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _mapper.Map<RolePermission>(permissionToModify);
                var rolePermission = _context.RolePermissions.Attach(entity);
                rolePermission.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
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
            finally
            {

                response.Result = GetById(permissionToModify.Id).Result;
                response.ResponseMessage = "Veza je uspješno uređena";
            }

            return response;
        }

        public EDResponse Update(Model.RolePermission permissionToModify)
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _mapper.Map<RolePermission>(permissionToModify);
                var rolePermission = _context.RolePermissions.Attach(entity);
                rolePermission.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
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
            finally
            {

                response.Result = GetById(permissionToModify.Id).Result;
                response.ResponseMessage = "Veza je uspješno uređena";
            }
            return response;
        }
        public EDResponse Delete(int id)
        {
            EDResponse response = new EDResponse
            {
                ResponseCode = 201
            };
            Model.RolePermission rolePermission = new Model.RolePermission();
            try
            {
                rolePermission = GetById(id).Result;
                rolePermission.Deleted = true;
                rolePermission.Active = false;
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
            finally
            {

                response.Result = Update(rolePermission);
                response.ResponseMessage = "Veza je uspješno izbrisana";
            }
            return response;
        }
    }
}
