using eDnevnik.Model;
using eDnevnik.Model.Helpers;
using eDnevnik.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Interface
{
    public interface IAcademicDiscipline
    {
        EDResponse Get();
        EDResponse GetById(int id);
        EDResponse Add(AcademicDisciplineReq academicDisciplineToModify);
        EDResponse Update(AcademicDisciplineReq academicDisciplineToModify);
        EDResponse Update(AcademicDiscipline academicDisciplineToModify);
        EDResponse Delete(int id);
    }
}
