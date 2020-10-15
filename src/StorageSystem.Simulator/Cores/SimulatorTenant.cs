using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystemSimulator.Cores
{
    public class TenantInfo
    {
        private string GetDisplayText()
        {
            return String.Format("[{0}] {1}", this.ID, this.Description);
        }

        public string ID { get; set; }

        public string Description { get; set; }

        public string DisplayText { get { return this.GetDisplayText();  } }
    }

    public class SimulatorTenant
    {
        private List<TenantInfo> tenantList;

        public SimulatorTenant()
        {
            this.tenantList = new List<TenantInfo>();
        }

        public string GetDescription(string id)
        {
            foreach (TenantInfo tenantInfo in this.tenantList)
            {
                if (tenantInfo.ID == id)
                {
                    return tenantInfo.Description;
                }
            }

            return "";
        }

        public List<TenantInfo> TenantList { get { return this.tenantList; } }
    }
}
