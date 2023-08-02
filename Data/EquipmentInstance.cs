using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace HospitalManagementSystem.Data
{
    internal class EquipmentInstance
    {
        public SQLiteAsyncConnection equipmentInstance;

        string equipmentInit;

        public EquipmentInstance(string DoctorInit)
        {
            equipmentInit = DoctorInit;
        }


        private EquipmentInstance() { }

        public async Task InstanceInitialize()
        {
            if (equipmentInstance != null)
            {
                return;
            }
            equipmentInstance = new SQLiteAsyncConnection(equipmentInit);
            await equipmentInstance.CreateTableAsync<Equipment>();

        }

        public async Task<bool> AddEditEquip(Equipment equipArg)
        {
            if (equipArg.equipId > 0)
            {
                await equipmentInstance.UpdateAsync(equipArg);
            }
            else if (equipArg.equipId == 0)
            {
                await equipmentInstance.InsertAsync(equipArg);
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteEquip(int equipId)
        {
            await equipmentInstance.DeleteAsync<Equipment>(equipId);
            return await Task.FromResult(true);
        }

        public async Task<Equipment> SearchEquip(int equipId)
        {
            return await equipmentInstance.Table<Equipment>().Where(i => i.equipId == equipId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Equipment>> SearchEquip()
        {
            await InstanceInitialize();
            return (IEnumerable<Equipment>)await Task.FromResult(await equipmentInstance.Table<Equipment>().ToListAsync());
        }
    }
}
