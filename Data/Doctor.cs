using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Data
{
    public class Doctor
    {
        [PrimaryKey, AutoIncrement]
        public int doctorId { get; set; }
        public string doctorName { get; set; }
        public string doctorEmail { get; set; }
        public string doctorOffice { get; set; }
        public string doctorDepartment { get; set; }
        public string doctorSpecialist { get; set; }

        public Doctor() { }

        public Doctor(int DoctorId, string DoctorName, string DoctorEmail, string DoctorOffice, string DoctorDepartment, string DoctorSpecialist)
        {
            DoctorId = doctorId;
            DoctorName = doctorName;
            DoctorEmail = doctorEmail;
            DoctorOffice = doctorOffice;
            DoctorDepartment = doctorDepartment;
            DoctorSpecialist = doctorSpecialist;
        }

        public override string ToString()
        {
            return "";
        }
    }
}
