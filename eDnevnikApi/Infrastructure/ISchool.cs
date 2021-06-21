using eDnevnik.Model;
using eDnevnik.Model.Helpers;
using eDnevnik.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Interface
{
    public interface ISchool
    {
        EDResponse Get();
        EDResponse GetById(int id);
        EDResponse Add(SchoolReq schoolToModify);
        EDResponse Update(SchoolReq schoolToModify);
        EDResponse Update(School schoolToModify);
        EDResponse Delete(int id);
    }
}
