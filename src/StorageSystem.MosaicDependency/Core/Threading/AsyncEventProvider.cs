using System;
using System.Collections.Generic;
using System.Threading;
using CareFusion.Mosaic.Core.Logging;

namespace CareFusion.Mosaic.Core.Threading
{
    /// <summary>
    /// Base class for all components that provide events that are raised asynchronously.
    /// </summary>
    public class AsyncEventProvider : IDisposable
    {
        #region Types

        private class AsyncEvent
        {
            public object Sender { get; set; }
            public Delegate EventMethod { get; set; }
            public object[] Parameters { get; set; }
        }

        #endregion

        #region Members

        private Queue<AsyncEvent> _eventQueue = new Queue<AsyncEvent>();
        private AutoResetEvent _newEvent = new AutoResetEvent(false);
        private ManualResetEvent _shutdown = new ManualResetEvent(false);
        private Thread _eventThread = null;
        protected bool _isDisposed = false;

        #endregion

        protected AsyncEventProvider(bool serializeEvents = true)
        {
            if (serializeEvents)
            {
                _eventThread = new Thread(new ThreadStart(RunAsyncEventProvider));
                _eventThread.Start();
            }            
        }

        ~AsyncEventProvider()
        {
            Dispose(false);
        }

        protected void Raise(Delegate eventMethod, params object[] eventParameters)
        {
            if (eventMethod == null)
                return;

            var asyncEvent = new AsyncEvent() { Sender = this, EventMethod = eventMethod, Parameters = eventParameters };

            if (_eventThread == null)
            {
                if (ThreadPool.QueueUserWorkItem(new WaitCallback(ExecuteAsyncEvent), asyncEvent) == false)
                    this.Error("Asynchronous execution of event method '{0}' failed!", eventMethod.Method.Name);

                return;
            }

            lock (_eventQueue)
            {
                _eventQueue.Enqueue(asyncEvent);
            }

            _newEvent.Set();
        }

        public static void Raise(object sender, Delegate eventMethod, params object[] eventParameters)
        {
            if ((sender == null) || (eventMethod == null))
                return;

            var asyncEvent = new AsyncEvent() { Sender = sender, EventMethod = eventMethod, Parameters = eventParameters };

            if (ThreadPool.QueueUserWorkItem(new WaitCallback(ExecuteAsyncEvent), asyncEvent) == false)
                sender.Error("Asynchronous execution of event method '{0}' failed!", eventMethod.Method.Name);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (_isDisposed)
                return;

            if (isDisposing)
            {
                _shutdown.Set();

                if (_eventThread != null)
                    _eventThread.Join();

                _eventThread = null;
                _eventQueue.Clear();
                _newEvent.Dispose();
                _shutdown.Dispose();                
            }

            _isDisposed = true;
        }

        private void RunAsyncEventProvider()
        {
            var waitHandles = new WaitHandle[] { _newEvent, _shutdown };

            while (waitHandles[WaitHandle.WaitAny(waitHandles)] != _shutdown)
            {
                AsyncEvent asyncEvent = null;

                do
                {
                    lock (_eventQueue)
                    {
                        asyncEvent = _eventQueue.Count > 0 ? _eventQueue.Dequeue() : null;
                    }

                    if (asyncEvent != null)
                    {
                        try
                        {
                            asyncEvent.EventMethod.DynamicInvoke(asyncEvent.Parameters);
                        }
                        catch (Exception ex)
                        {
                            this.Error("Raising event '{0}' failed!", ex, asyncEvent.EventMethod.GetType().Name);
                        }
                    }
                }
                while (asyncEvent != null);
            }
        }

        private static void ExecuteAsyncEvent(object asyncEventParam)
        {
            var asyncEvent = (AsyncEvent)asyncEventParam;

            try
            {                
                asyncEvent.EventMethod.DynamicInvoke(asyncEvent.Parameters);
            }
            catch (Exception ex)
            {
                asyncEvent.Sender.Error("Raising event '{0}' failed!", ex, asyncEvent.EventMethod.GetType().Name);
            }
        }
    }
}
