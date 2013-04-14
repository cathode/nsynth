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
using System.Diagnostics.Contracts;

namespace NSynth
{
    public class AsyncResult<TResult> : AsyncResultEmpty
    {
        private TResult value = default(TResult);

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncResult"/> class.
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <param name="owner"></param>
        /// <param name="operationId"></param>
        protected AsyncResult(AsyncCallback callback, object state, object owner, string operationId)
            : base(callback, state, owner, operationId)
        {
        }

        new public static TResult End(IAsyncResult result, object owner, string operationId)
        {
            Contract.Requires(result is AsyncResult<TResult>);
            var r = (AsyncResult<TResult>)result;

            AsyncResultEmpty.End(r, owner, operationId);

            return r.value;
        }

        protected void SetResult(TResult value)
        {
            this.value = value;
        }


    }
}
