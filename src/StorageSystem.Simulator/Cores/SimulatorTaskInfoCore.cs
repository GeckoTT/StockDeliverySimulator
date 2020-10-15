using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CareFusion.Mosaic.Interfaces.Messages.Task;

namespace StorageSystemSimulator.Cores
{
    class SimulatorTaskInfoCore
    {
        private SimulatorStockDeliverySetCore stockDeliverySetCore;
        private SimulatorOutputCore outputCore;

        public SimulatorTaskInfoCore()
        {
        }
        public void Initialize(SimulatorOutputCore outputCore,
            SimulatorStockDeliverySetCore stockDeliverySetCore)
        {
            this.outputCore = outputCore;
            this.stockDeliverySetCore = stockDeliverySetCore;
        }

        public void ProcessTaskInfoRequest(TaskInfoRequest taskInfoRequest)
        {
            TaskInfoResponse taskInfoResponse = new TaskInfoResponse();
            taskInfoResponse.AdoptHeader(taskInfoRequest);

            foreach (Task task in taskInfoRequest.Tasks)
            {
                switch (task.Type)
                {
                    case TaskType.Output:
                        taskInfoResponse.Tasks.Add(this.outputCore.GetTaskInformation(task, taskInfoRequest.IncludeTaskDetails));
                        break;
                    case TaskType.StockDelivery:
                        taskInfoResponse.Tasks.Add(this.stockDeliverySetCore.GetTaskInformation(task, taskInfoRequest.IncludeTaskDetails));
                        break;
                    default:
                        break;
                }
            }

            taskInfoResponse.ConverterStream.Write(taskInfoResponse);
        }
    }
}
