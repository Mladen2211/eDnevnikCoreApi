using eDnevnik.Model;
using eDnevnik.Model.Helpers;
using eDnevnik.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Interface
{
    public interface ICity
    {
        EDResponse Get();
        EDResponse GetById(int id);
        EDResponse Add(CityReq cityToModify);
        EDResponse Update(CityReq cityToModify);
        EDResponse Update(City cityToModify);
        EDResponse Delete(int id);
    }
}
