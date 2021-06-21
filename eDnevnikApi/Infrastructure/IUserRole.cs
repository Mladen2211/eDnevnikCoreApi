using eDnevnik.Model;
using eDnevnik.Model.Helpers;
using eDnevnik.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Interface
{
    public interface IUserRole
    {
        EDResponse Get();
        EDResponse GetById(int id);
        EDResponse Add(UserRoleReq userRole);
        EDResponse Update(UserRoleReq userRoleToModify);
        EDResponse Update(UserRole userRoleToModify);
        EDResponse Delete(int id);
    }
}
