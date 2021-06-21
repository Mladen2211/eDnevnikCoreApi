using eDnevnik.Model;
using eDnevnik.Model.Helpers;
using eDnevnik.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Interface
{
    public interface ISubject
    {
        EDResponse Get();
        EDResponse GetById(int id);
        EDResponse Add(SubjectReq subjectToModify);
        EDResponse Update(SubjectReq subjectToModify);
        EDResponse Update(Subject subjectToModify);
        EDResponse Delete(int id);
    }
}
