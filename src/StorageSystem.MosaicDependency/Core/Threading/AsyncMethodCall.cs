using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using CareFusion.Mosaic.Core.Logging;

namespace CareFusion.Mosaic.Core.Threading
{
    /// <summary>
    /// Delegate which defines a method that can be called asynchronously.
    /// </summary>
    /// <param name="parameters">The parameters of the method.</param>
    public delegate void AsyncMethod(params object[] parameters);

    /// <summary>
    /// Class which provides the functionality to asynchronously call methods.
    /// </summary>
    public static class AsyncMethodCall
    {
        #region Types

        /// <summary>
        /// Small helper class to use when calling methods asynchronously.
        /// </summary>
        private class AsyncCall
        {
            /// <summary>
            /// Method to call asynchronously.
            /// </summary>
            public AsyncMethod Method { get; set; }

            /// <summary>
            /// Method parameters to use.
            /// </summary>
            public object[] Parameters { get; set; }
        }

        #endregion

        /// <summary>
        /// Initiates an asynchronous call of the specified method with the specified parameters.
        /// </summary>
        /// <param name="method">The method to call.</param>
        /// <param name="parameters">The parameters to use when calling the method.</param>
        public static void Call(AsyncMethod method, params object[] parameters)
        {
            if (method == null)
            {
                throw new ArgumentException("Invalid method specified!");
            }

            var asyncCall = new AsyncCall() { Method = method, Parameters = parameters };

            if (ThreadPool.QueueUserWorkItem(new WaitCallback(ExecuteAsyncCall), asyncCall) == false)
            {
                asyncCall.Error("Asynchronous execution of method '{0}' failed!", method.Method.Name);
            }
        }

        /// <summary>
        /// Executes the asynchronous call of the specified method.
        /// </summary>
        /// <param name="asyncParameter">The asynchronous method.</param>
        private static void ExecuteAsyncCall(object asyncParameter)
        {
            var asyncCall = (AsyncCall)asyncParameter;
            
            try
            {
                asyncCall.Method(asyncCall.Parameters);
            }
            catch (Exception ex)
            {
                asyncCall.Error("Asynchronous execution of method '{0}' failed!", ex, asyncCall.Method.Method.Name);
            }
        }
    }
}
