using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace HospitalManagementSystem.Data
{
    public class Patient
    {
        [PrimaryKey, AutoIncrement]
        public int patientId { get; set; }
        public string patientName { get; set; }
        public int patientAge { get; set; }
        public string patientDisease { get; set; }


        public Patient() { }

        public Patient(int PatientId, string PatientName, int PatientAge, string PatientDisease) 
        {
            PatientId = patientId;
            PatientName = patientName;
            PatientAge = patientAge;
            PatientDisease = patientDisease;
        }

        public override string ToString()
        {
            return "";
        }
    }
}
