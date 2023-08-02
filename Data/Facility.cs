using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace HospitalManagementSystem.Data
{
    public class Facility
    {
        [PrimaryKey, AutoIncrement]
        public int facilityId {get; set;}
        public string facilityName { get; set; }
        public string facilityAddress { get; set; }

        public Facility() { }

        public Facility(int FacilityId, string FacilityName, string FacilityAddress)
        {
            FacilityId = facilityId;
            FacilityName = facilityName;
            FacilityAddress = facilityAddress;
        }

        public override string ToString()
        {
            return "";
        }
    }
}
