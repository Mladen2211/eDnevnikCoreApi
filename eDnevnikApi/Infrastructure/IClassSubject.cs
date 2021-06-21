using eDnevnik.Model;
using eDnevnik.Model.Helpers;
using eDnevnik.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Interface
{
    public interface IClassSubject
    {
        EDResponse Get();
        EDResponse GetById(int id);
        EDResponse Add(ClassSubjectReq classSubjectToModify);
        EDResponse Update(ClassSubjectReq classSubjectToModify);
        EDResponse Update(ClassSubject classSubjectToModify);
        EDResponse Delete(int id);
    }
}
