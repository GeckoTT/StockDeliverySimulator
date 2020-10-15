using CareFusion.Mosaic.Interfaces.Messages.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystemSimulator.Cores
{
    public class SimulatorStatusCore
    {
        private StatusType status;
        private string stateDescriptions;
        private List<StatusComponent> statusSubComponentList;

        public SimulatorStatusCore()
        {
            this.status = StatusType.Ready;
            this.statusSubComponentList = new List<StatusComponent>();
        }

        public void ProcessStatus(StatusRequest request)
        {
            StatusResponse response = new StatusResponse();
            response.AdoptHeader(request);
            response.Component = new StatusComponent();
            response.Component.Type = "Mosaic";
            response.Component.Description = "Mosaic Service";
            response.Component.State = this.status;
            response.Component.StateDescription = this.stateDescriptions;

            if (request.IncludeDetails)
            {
                response.Component.SubComponents = this.statusSubComponentList.ToArray();
            }

            request.ConverterStream.Write(response);
        }
        public StatusType Status { get { return this.status; } set { this.status = value; } }
        public string StateDescriptions { get { return this.stateDescriptions; } set { this.stateDescriptions = value; } }

        // bad
        public List<StatusComponent> StatusSubComponentList { get { return this.statusSubComponentList; } }
    }
}
