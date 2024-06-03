using Core.DataAccess;

namespace Domain.Entities
{
    public enum UserRole
    {
        Patient,
        Doctor,
        Admin
    }
    public class User:Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public UserRole Role { get; set; }
        public string Address { get; set; }

        public ICollection<Appointment> PatientAppointments { get; set; } //Bir hasta, birden fazla randevuya sahip olabilir.
        public ICollection<Appointment> DoctorAppointments { get; set; } //Bir doktor, birden fazla randevuya sahip olabilir.
        public ICollection<DoctorSchedule> DoctorSchedules { get; set; } //Bir doktorun birden fazla çalışma zaman dilimi olabilir.
        public ICollection<Feedback> Feedbacks { get; set; } //Bir user birden fazla feedback verebilir
        public ICollection<AdminAction> AdminActions { get; set; } //Bir adminin birden fazla actionı olabilir
        public ICollection<PatientReport> PatientReports { get; set; } //Bir hasta ve bir doktorun birden fazla raporu olabilir
        public ICollection<PatientReport> DoctorReports { get; set; } //Bir hasta ve bir doktorun birden fazla raporu olabilir
        public ICollection<Notification> Notifications { get; set; }




    }
}
