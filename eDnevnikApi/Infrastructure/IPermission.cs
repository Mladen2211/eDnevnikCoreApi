using eDnevnik.Model;
using eDnevnik.Model.Helpers;
using eDnevnik.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Interface
{
    public interface IPermission
    {
        EDResponse Get();
        EDResponse GetById(int id);
        EDResponse Add(PermissionReq permissionToModify);
        EDResponse Update(PermissionReq permissionToModify);
        EDResponse Update(Permission permissionToModify);
        EDResponse Delete(int id);
    }
}
