using eDnevnik.Model;
using eDnevnik.Model.Helpers;
using eDnevnik.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Interface
{
    public interface IMunicipality
    {
        EDResponse Get();
        EDResponse GetById(int id);
        EDResponse Add(MunicipalityReq municipalityToModify);
        EDResponse Update(MunicipalityReq municipalityToModify);
        EDResponse Update(Municipality municipalityToModify);
        EDResponse Delete(int id);
    }
}
