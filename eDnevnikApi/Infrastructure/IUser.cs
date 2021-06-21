using eDnevnik.Model;
using eDnevnik.Model.Helpers;
using eDnevnik.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Interface
{
    public interface IUser
    {
        EDResponse Get();
        EDResponse GetStudents();
        EDResponse GetProfessors();
        EDResponse GetById(int id);
        EDResponse Add(UserReq userToModify);
        EDResponse Update(UserReq userToModify);
        EDResponse Update(User userToModify);
        EDResponse Delete(int id);
    }
}
