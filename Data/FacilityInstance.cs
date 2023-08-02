using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Data
{
    internal class FacilityInstance
    {
        public SQLiteAsyncConnection facilityInstance;

        string facilityInit;

        public FacilityInstance(string FacilityInit)
        {
            facilityInit = FacilityInit;
        }


        private FacilityInstance() { }

        public async Task InstanceInitialize()
        {
            if (facilityInstance != null)
            {
                return;
            }
            facilityInstance = new SQLiteAsyncConnection(facilityInit);
            await facilityInstance.CreateTableAsync<Facility>();

        }

        public async Task<bool> AddEditFacility(Facility facilityArg)
        {
            if (facilityArg.facilityId > 0)
            {
                await facilityInstance.UpdateAsync(facilityArg);
            }
            else if (facilityArg.facilityId == 0)
            {
                await facilityInstance.InsertAsync(facilityArg);
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteFacility(int facilityId)
        {
            await facilityInstance.DeleteAsync<Facility>(facilityId);
            return await Task.FromResult(true);
        }

        public async Task<Facility> SearchFacility(int facilityId)
        {
            return await facilityInstance.Table<Facility>().Where(i => i.facilityId == facilityId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Facility>> SearchFacility()
        {
            await InstanceInitialize();
            return (IEnumerable<Facility>)await Task.FromResult(await facilityInstance.Table<Facility>().ToListAsync());
        }
    }
}
