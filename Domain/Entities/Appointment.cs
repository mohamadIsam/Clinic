using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int StatusId { get; set; }
        public string Reason { get; set; }

        public AppointmentStatus Status { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}