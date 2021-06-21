using eDnevnik.Model;
using eDnevnik.Model.Helpers;
using eDnevnik.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Interface
{
    public interface IUserSchool
    {
        EDResponse Get();
        EDResponse GetById(int id);
        EDResponse Add(UserSchoolReq userSchoolToModify);
        EDResponse Update(UserSchoolReq userSchoolToModify);
        EDResponse Update(UserSchool userSchoolToModify);
        EDResponse Delete(int id);
    }
}
