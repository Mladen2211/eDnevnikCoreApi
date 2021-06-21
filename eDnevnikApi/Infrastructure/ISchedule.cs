using eDnevnik.Model;
using eDnevnik.Model.Helpers;
using eDnevnik.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Interface
{
    public interface ISchedule
    {
        EDResponse Get();
        EDResponse GetById(int id);
        EDResponse Add(ScheduleReq scheduleToModify);
        EDResponse Update(ScheduleReq scheduleToModify);
        EDResponse Update(Schedule scheduleToModify);
        EDResponse Delete(int id);
    }
}
