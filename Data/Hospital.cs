using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Data
{
    public abstract class Hospital
    {
        [PrimaryKey, AutoIncrement]
        public int doctorId { get; set; }
        public string doctorName { get; set; }
        public string doctorEmail { get; set; }
        public string doctorOffice { get; set; }
        public string doctorDepartment { get; set; }
        public string doctorSpecialist { get; set; }

        [PrimaryKey, AutoIncrement]
        public int equipId { get; set; }
        public string equipName { get; set; }
        public int equipQty { get; set; }


        [PrimaryKey, AutoIncrement]
        public int facilityId { get; set; }
        public string facilityName { get; set; }
        public string facilityAddress { get; set; }


        [PrimaryKey, AutoIncrement]
        public int patientId { get; set; }
        public string patientName { get; set; }
        public int patientAge { get; set; }
        public string patientDisease { get; set; }
        public int patientDoctorId { get; set; }

        public abstract override string ToString();
    }
}
