/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics.Contracts;

namespace NSynth
{
    public class AsyncResultEmpty : IAsyncResult
    {
        private readonly AsyncCallback callback;
        private readonly object asyncState;
        private const int StatePending = 0;
        private const int StateCompletedSynchronously = 1;
        private const int StateCompletedAsynchronously = 2;
        private int completionState = AsyncResultEmpty.StatePending;

        private ManualResetEvent waitHandle;

        private Exception innerException;

        private object owner;

        private string operationId;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncResultEmpty"/> class.
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <param name="owner"></param>
        /// <param name="operationId"></param>
        protected AsyncResultEmpty(AsyncCallback callback, object state, object owner, string operationId)
        {
            Contract.Requires(callback != null);
            Contract.Requires(owner != null);

            this.callback = callback;
            this.asyncState = state;
            this.owner = owner;
            this.operationId = operationId ?? string.Empty;
        }

        protected virtual void Process()
        {

        }

        protected bool Complete(Exception ex, bool completedSynchronously = false)
        {
            bool result = false;

            var newState = completedSynchronously
                ? AsyncResultEmpty.StateCompletedSynchronously
                : AsyncResultEmpty.StateCompletedAsynchronously;
            var prevState = Interlocked.Exchange(ref this.completionState, newState);

            if (prevState == AsyncResultEmpty.StatePending)
            {
                this.innerException = ex;

                this.Completing(ex, completedSynchronously);

                if (this.waitHandle != null)
                    this.waitHandle.Set();

                this.MakeCallback(this.callback, this);

                this.Completed(ex, completedSynchronously);

                result = true;
            }
            return result;
        }

        private void Completed(Exception ex, bool completedSynchronously)
        {
            throw new NotImplementedException();
        }

        private void MakeCallback(AsyncCallback asyncCallback, AsyncResultEmpty asyncResultEmpty)
        {
            throw new NotImplementedException();
        }

        private void CheckUsage(object owner, string operationId)
        {
            Contract.Requires<InvalidOperationException>(owner == this.owner, "End was called on a different object than Begin");
            Contract.Requires<InvalidOperationException>(null != this.operationId, "End was called multiple times for this operation.");
            Contract.Requires<InvalidOperationException>(operationId == this.operationId, "End operation type was different than Begin.");

            // cleanup
            this.operationId = null;
        }

        public static void End(IAsyncResult result, object owner, string operationId)
        {
            Contract.Requires<ArgumentException>(result is AsyncResultEmpty, "Unsupported IAsyncResult implementation");

            var r = (AsyncResultEmpty)result;

            r.CheckUsage(owner, operationId);

            if (!r.IsCompleted)
            {
                r.AsyncWaitHandle.WaitOne();
                r.AsyncWaitHandle.Close();
                r.waitHandle = null;
            }

            if (null != r.innerException)
                throw r.innerException;
        }

        protected virtual void Completing(Exception ex, bool completedSynchronously)
        {
            throw new NotImplementedException();
        }

        public object AsyncState
        {
            get
            {
                return this.asyncState;
            }
        }

        public WaitHandle AsyncWaitHandle
        {
            get
            {
                if (this.waitHandle == null)
                {
                    var done = this.IsCompleted;
                    var reset = new ManualResetEvent(done);
                    if (Interlocked.CompareExchange(ref this.waitHandle, reset, null) != null)
                        reset.Close();
                    else
                        if (!done && this.IsCompleted)
                            this.waitHandle.Set();
                }

                return this.waitHandle;
            }
        }

        public bool CompletedSynchronously
        {
            get
            {
                return Thread.VolatileRead(ref this.completionState) == AsyncResultEmpty.StateCompletedSynchronously;
            }
        }

        public bool IsCompleted
        {
            get
            {
                return Thread.VolatileRead(ref this.completionState) != AsyncResultEmpty.StatePending;
            }
        }
    }
}
