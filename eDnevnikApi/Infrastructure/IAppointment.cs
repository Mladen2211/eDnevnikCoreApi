using eDnevnik.Model;
using eDnevnik.Model.Helpers;
using eDnevnik.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Interface
{
    public interface IAppointment
    {
        EDResponse Get();
        EDResponse GetById(int id);
        EDResponse Add(AppointmentReq appointmentToModify);
        EDResponse Update(AppointmentReq appointmentToModify);
        EDResponse Update(Appointment appointmentToModify);
        EDResponse Delete(int id);
    }
}
