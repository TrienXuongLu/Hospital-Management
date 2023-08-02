using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Data
{
    internal class PatientInstance
    {
        public SQLiteAsyncConnection patientInstance;

        string patientInit;

        public PatientInstance(string PatientInt)
        {
            patientInit = PatientInt;
        }



        private PatientInstance() { }

        public async Task InstanceInitialize()
        {
            if (patientInstance != null)
            {
                return;
            }
            patientInstance = new SQLiteAsyncConnection(patientInit);
            await patientInstance.CreateTableAsync<Patient>();
        }

        public async Task<bool> AddEditPatient(Patient patientArg)
        {
            if (patientArg.patientId > 0)
            {
                await patientInstance.UpdateAsync(patientArg);
            }
            else if (patientArg.patientId == 0)
            {
                await patientInstance.InsertAsync(patientArg);
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeletePatient(int patientId)
        {
            await patientInstance.DeleteAsync<Patient>(patientId);
            return await Task.FromResult(true);
        }

        public async Task<Patient> SearchPatient(int patientId)
        {
            return await patientInstance.Table<Patient>().Where(i => i.patientId == patientId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Patient>> SearchPatient()
        {
            await InstanceInitialize();
            return (IEnumerable<Patient>)await Task.FromResult(await patientInstance.Table<Patient>().ToListAsync());
        }
    }
}
