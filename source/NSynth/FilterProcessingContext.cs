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
    /// <summary>
    /// Represents the frames used as inputs to a given render task for a filter.
    /// </summary>
    public class FilterProcessingContext
    {
        private long currentIndex;
        private Filter owner;

        /// <summary>
        /// Holds the frames that are necessary for rendering.
        /// </summary>
        private readonly Dictionary<string, Dictionary<int, Frame>> frames;

        /// <summary>
        /// Thread safety object.
        /// </summary>
        private readonly object sync;

        /// <summary>
        /// Holds a value indicating whether the instance contains all the frames necessary to proceed with rendering.
        /// </summary>
        private bool isReady = false;

        public long FrameIndex
        {
            get
            {
                return this.currentIndex;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterProcessingContext"/> class.
        /// </summary>
        /// <param name="owner">The filter that is rendering a frame to which the input frames will be used.</param>
        /// <param name="currentIndex">The frame index being rendered.</param>
        public FilterProcessingContext(Filter owner, long currentIndex)
        {
            Contract.Requires(owner != null);
            Contract.Requires(currentIndex >= 0);

            this.sync = new object();
            this.currentIndex = currentIndex;
            this.owner = owner;
            this.frames = new Dictionary<string, Dictionary<int, Frame>>();

            foreach (var slot in owner.Inputs)
            {
                var neededFrames = new Dictionary<int, Frame>();

                // Build a list of indices of frames we need for each input slot.
                foreach (var i in owner.GetInputFramesRequired(slot, currentIndex))
                    neededFrames.Add(i, null);

                this.frames.Add(slot.Name, neededFrames);
            }
        }

        /// <summary>
        /// Raised when all the prerequisite frames needed have been rendered.
        /// </summary>
        public event EventHandler InputFramesReady;

        public void SetFrame(string slot, int offset, Frame frame)
        {
            Contract.Requires(frame != null);
            Contract.Requires(slot != null);

            lock (this.sync)
            {
                if (!this.frames.ContainsKey(slot))
                    throw new NotImplementedException();
                else if (!this.frames[slot].ContainsKey(offset))
                    throw new NotImplementedException();
                else if (this.frames[slot][offset] != null)
                    throw new NotImplementedException();


                this.frames[slot][offset] = frame;

                foreach (var s in this.frames)
                    foreach (var n in s.Value)
                        if (n.Value == null)
                            return; // not ready

                this.isReady = true;
            }


            // must be ready
            if (this.isReady)
                if (this.InputFramesReady != null)
                    this.InputFramesReady(this, EventArgs.Empty);
        }

        public Frame GetFrame(string slot, int offset = 0)
        {
            Contract.Ensures(Contract.Result<Frame>() != null);
            return this.frames[slot][offset];
        }

        /// <summary>
        /// Gets the frames that need to be rendered.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Tuple<string, int>> GetRemainingFrames()
        {
            foreach (var kp in this.frames)
            {
                foreach (var kp2 in kp.Value)
                    if (kp2.Value == null)
                        yield return new Tuple<string, int>(kp.Key, kp2.Key);
            }
        }

        [ContractInvariantMethod]
        private void Invariants()
        {
            Contract.Invariant(this.frames != null);
        }
    }
}
