using eDnevnik.Model;
using eDnevnik.Model.Helpers;
using eDnevnik.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Interface
{
    public interface IRolePermission
    {
        EDResponse Get();
        EDResponse GetById(int id);
        EDResponse Add(RolePermissionReq rolePermissionToModify);
        EDResponse Update(RolePermissionReq rolePermissionToModify);
        EDResponse Update(RolePermission rolePermissionToModify);
        EDResponse Delete(int id);
    }
}
