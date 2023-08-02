using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace HospitalManagementSystem.Data
{
    public class DoctorInstance
    {
        public SQLiteAsyncConnection doctorInstance;

        string _doctorInit;

        public DoctorInstance(string DoctorInit)
        {
            _doctorInit = DoctorInit;
        }


        private DoctorInstance() { }

        public async Task InstanceInitialize()
        {
            if (doctorInstance != null)
            {
                return;
            }
            doctorInstance = new SQLiteAsyncConnection(_doctorInit);
            await doctorInstance.CreateTableAsync<Doctor>();
            
        }

        public async Task<bool> AddEditDoctor(Doctor doctorArg)
        {
            if(doctorArg.doctorId > 0)
            {
                await doctorInstance.UpdateAsync(doctorArg);
            }
            else if (doctorArg.doctorId == 0)
            {
                await doctorInstance.InsertAsync(doctorArg);
            }
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<Doctor>> FindDoctor(int doctorId)
        {
            var results = new List<Doctor>();
            var findDoc = await doctorInstance.FindAsync<Doctor>(doctorId);
            if(findDoc != null)
            {
                results.Add(findDoc);
            }
            return results;
        }

        public async Task<bool> DeleteDoctor(int doctorId)
        {
            await doctorInstance.DeleteAsync<Doctor>(doctorId);
            //return await Task.FromResult(true);
            return await Task.FromResult(true);
        }

        public async Task<Doctor> SearchDoctor(int doctorId)
        {
            return await doctorInstance.Table<Doctor>().Where(i => i.doctorId == doctorId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Doctor>> SearchDoctor()
        {
            await InstanceInitialize();
            return (IEnumerable<Doctor>)await Task.FromResult(await doctorInstance.Table<Doctor>().ToListAsync());
        }
    }
}
