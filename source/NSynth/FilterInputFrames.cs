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
    public class FilterInputFrames
    {
        private long currentIndex;
        private Filter owner;
        private Dictionary<string, Dictionary<long, Frame>> frames;
        private readonly object locker;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterInputFrames"/> class.
        /// </summary>
        /// <param name="owner">The filter that is rendering a frame to which the input frames will be used.</param>
        /// <param name="currentIndex">The frame index being rendered.</param>
        public FilterInputFrames(Filter owner, long currentIndex)
        {
            Contract.Requires(owner != null);

            this.locker = new object();
            this.currentIndex = currentIndex;
            this.owner = owner;
            this.frames = new Dictionary<string, Dictionary<long, Frame>>();

            foreach (var slot in owner.Inputs)
            {
                var neededFrames = new Dictionary<long, Frame>();

                // Build a list of indices of frames we need for each input slot.
                foreach (var i in owner.GetInputFramesRequired(slot, currentIndex))
                    neededFrames.Add(i, null);

                this.frames.Add(slot.Name, neededFrames);
            }
        }

        /// <summary>
        /// Raised when all the frames needed have been rendered.
        /// </summary>
        public EventHandler AllFramesReady;

        public void SetFrame(string slot, long index, Frame frame)
        {
            Contract.Requires(frame != null);

            lock (this.locker)
            {
                if (!this.frames.ContainsKey(slot))
                    throw new NotImplementedException();
                else if (!this.frames[slot].ContainsKey(index))
                    throw new NotImplementedException();
                else if (this.frames[slot][index] != null)
                    throw new NotImplementedException();


                this.frames[slot][index] = frame;

                foreach (var s in this.frames)
                    foreach (var n in s.Value)
                        if (n.Value == null)
                            return; // not ready

            }
            // must be ready
            this.AllFramesReady(this, EventArgs.Empty);
        }
    }
}
