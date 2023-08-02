using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace HospitalManagementSystem.Data
{
    public class Equipment
    {
        [PrimaryKey, AutoIncrement]
        public int equipId { get; set; }
        public string toolName { get; set; }
        public int qty { get; set; }

        public Equipment() { }

        public Equipment(int EquipId, string ToolName, int EquipQty)
        {
            EquipId = equipId;
            ToolName = toolName;
            EquipQty = qty;
        }

        public override string ToString()
        {
            return "";
        }
    }
}
