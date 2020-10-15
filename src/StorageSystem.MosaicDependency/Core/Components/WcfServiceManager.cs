using System;
using System.Collections.Generic;
using System.ServiceModel;
using CareFusion.Mosaic.Core.Logging;
using CareFusion.Mosaic.DB;
using CareFusion.Mosaic.Interfaces.BoxSystem;
using CareFusion.Mosaic.Interfaces.Components;
using CareFusion.Mosaic.Interfaces.Types.Components;
using CareFusion.Mosaic.Interfaces.WcfServices;
using CareFusion.Mosaic.Native;
using System.Runtime.InteropServices;
using System.Threading;

namespace CareFusion.Mosaic.Core.Components
{
    /// <summary>
    /// Class which manages the initialization and creation of the configured WCF services.
    /// </summary>
    public class WcfServiceManager : IDisposable
    {
        #region Members

        /// <summary>
        /// The list of active WCF service instances in form of their according service host.
        /// </summary>
        private List<ServiceHost> _serviceList = new List<ServiceHost>();

        #endregion

        /// <summary>
        /// Initializes the WCF service manager with all configured services.
        /// </summary>
        /// <param name="dbSet">The set of active Mosaic databases.</param>
        /// <param name="packConveyorManager">The currently active pack conveyor manager.</param>
        /// <param name="orchestrationManager">The currently active orchestration manager.</param>
        /// <param name="boxSystem">The currently active box system implementation.</param>
        /// <returns>
        ///   <c>true</c> if initialization was successful;<c>false</c> otherwise.
        /// </returns>
        public bool Initialize(DatabaseSet dbSet, PackConveyorManager packConveyorManager, OrchestrationManager orchestrationManager, IBoxSystem boxSystem)
        {
            if (dbSet == null)
                throw new ArgumentException("Invalid dbSet specified.");

            if (packConveyorManager == null)
                throw new ArgumentException("Invalid packConveyorManager specified.");

            if (orchestrationManager == null)
                throw new ArgumentException("Invalid orchestrationManager specified.");

            _serviceList.Clear();

            this.Trace("Initializing WCF service manager...");

            try
            {
                List<Component> componentList = dbSet.Productive.Query<Component>(new CommandFilter("Type", ComponentType.WcfService.ToString()));

                foreach (Component component in componentList)
                {
                    if (component.IsActive == false)
                    {
                        continue;
                    }

                    this.Info("Initializing WCF service '{0}' with ID '{1}'.", component.Description, component.ID);
                    IWcfService service = ComponentLoader.LoadInterface<IWcfService>(component.Assembly, component.ClassName);

                    if (service == null)
                    {
                        this.Fatal("WCF service '{0}' with ID '{1}' in assembly '{2}' and class '{3}' could not be found.",
                                   component.Description, component.ID, component.Assembly, component.ClassName);
                        return false;
                    }

                    ServiceHost svcHost = service.Initialize(component.ID,
                                                             dbSet.Productive.Query<ConfigurationValue>(new CommandFilter("ComponentID", component.ID)),
                                                             dbSet,
                                                             packConveyorManager.PackConveyors,
                                                             orchestrationManager.Orchestrations,
                                                             boxSystem);

                    if (svcHost == null)
                    {
                        this.Error("Initializing WCF service '{0}' with ID '{1}' failed.", component.Description, component.ID);
                        return false;
                    }

                    try
                    {
                        svcHost.Open();
                        _serviceList.Add(svcHost);
                    }
                    catch (Exception ex)
                    {
                        this.Error("Starting WCF service '{0}' failed.", ex, component.Description);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                this.Error("Initializing WCF services failed.", ex);
            }

            return false;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Trace("Cleanup all running WCF service instances...");

            foreach (var service in _serviceList)
            {
                try
                {
                    service.Abort();
                    service.Close();
                }
                catch (Exception ex)
                {
                    this.Error("Stopping WCF service failed.", ex);
                }
            }

            _serviceList.Clear();
        }
    }
}
