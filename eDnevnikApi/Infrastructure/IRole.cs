using eDnevnik.Model;
using eDnevnik.Model.Helpers;
using eDnevnik.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Interface
{
    public interface IRole
    {
        EDResponse Get();
        EDResponse GetById(int id);
        EDResponse Add(RoleReq roleToModify);
        EDResponse Update(RoleReq roleToModify);
        EDResponse Update(Role roleToModify);
        EDResponse Delete(int id);
    }
}
