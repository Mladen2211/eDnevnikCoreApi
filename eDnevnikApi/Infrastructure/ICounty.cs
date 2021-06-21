using eDnevnik.Model;
using eDnevnik.Model.Helpers;
using eDnevnik.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Interface
{
    public interface ICounty
    {
        EDResponse Get();
        EDResponse GetById(int id);
        EDResponse Add(CountyReq countyToModify);
        EDResponse Update(CountyReq countyToModify);
        EDResponse Update(County countyToModify);
        EDResponse Delete(int id);
    }
}
