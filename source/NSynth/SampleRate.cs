/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;

namespace NSynth
{
    /// <summary>
    /// Represents a measurement of samples per time unit taken from a
    /// continuous signal to make a discrete signal.
    /// </summary>
    public struct SampleRate
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="SampleRate.Samples"/> property.
        /// </summary>
        private readonly long samples;

        /// <summary>
        /// Backing field for the <see cref="SampleRate.Duration"/> property.
        /// </summary>
        private readonly TimeSpan duration;

        /// <summary>
        /// Backing field for the <see cref="SampleRate.Period"/> property.
        /// </summary>
        private readonly TimeSpan period;

        /// <summary>
        /// Backing field for the <see cref="SampleRate.Frequency"/> property.
        /// </summary>
        private double frequency;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SampleRate"/> struct.
        /// </summary>
        /// <param name="samples">The number of samples.</param>
        /// <remarks>
        /// A duration of 1 second is assumed.
        /// </remarks> 
        public SampleRate(long samples)
        {
            this.samples = samples;
            this.duration = TimeSpan.FromSeconds(1.0);
            this.frequency = samples / 1.0;
            
            if (samples > 0)
                this.period = TimeSpan.FromSeconds(1.0 / samples);
            else
                this.period = TimeSpan.Zero;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SampleRate"/> struct.
        /// </summary>
        /// <param name="samples">The number of samples.</param>
        /// <param name="duration">The duration of the new <see cref="SampleRate"/>.</param>
        public SampleRate(long samples, TimeSpan duration)
        {
            this.samples = samples;
            this.duration = duration;

            if (samples > 0)
                this.period = TimeSpan.FromSeconds(duration.TotalSeconds / samples);
            else
                this.period = TimeSpan.Zero;

            if (duration.TotalSeconds > 0)
                this.frequency = samples / duration.TotalSeconds;
            else
                this.frequency = 0.0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SampleRate"/> struct.
        /// </summary>
        /// <param name="samples">The number of samples.</param>
        /// <param name="seconds">The number of seconds.</param>
        public SampleRate(long samples, double seconds)
        {
            this.samples = samples;
            this.duration = TimeSpan.FromSeconds(seconds);

            if (samples > 0)
                this.period = TimeSpan.FromSeconds(seconds / samples);
            else
                this.period = TimeSpan.Zero;

            if (seconds > 0)
                this.frequency = samples / duration.TotalSeconds;
            else
                this.frequency = 0.0;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets the number of samples.
        /// </summary>
        public long Samples
        {
            get
            {
                return this.samples;
            }
        }

        /// <summary>
        /// Gets the duration of the current <see cref="SampleRate"/>.
        /// </summary>
        public TimeSpan Duration
        {
            get
            {
                return this.duration;
            }
        }

        /// <summary>
        /// Gets the number of samples per second that the current <see cref="SampleRate"/> represents.
        /// </summary>
        public double Frequency
        {
            get
            {
                return this.frequency;
            }
        }

        /// <summary>
        /// Gets the <see cref="TimeSpan"/> between any two ajacent samples.
        /// </summary>
        public TimeSpan Period
        {
            get
            {
                return this.period;
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Gets the duration of the specified number of samples using the current <see cref="SampleRate"/>.
        /// </summary>
        /// <param name="samples">The number of samples.</param>
        /// <returns>A new <see cref="TimeSpan"/> representing the duration of the specified number of samples.</returns>
        public TimeSpan GetDuration(int samples)
        {
            return TimeSpan.FromSeconds(this.Period.TotalSeconds * samples);
        }

        /// <summary>
        /// Returns a new <see cref="SampleRate"/> that is the reduced form of the current instance.
        /// </summary>
        /// <returns>A new <see cref="SampleRate"/> instance that is the reduced form of the current instance.</returns>
        /// <remarks>
        /// Sample rates with durations less than 1.0 are not reduceable.
        /// </remarks>
        public SampleRate Reduce()
        {
            // 96 (frames) / 4 (seconds) == 24 / 1
            var seconds = this.duration.TotalSeconds;
            long samples = this.samples;

            if (seconds >= 1.0)
                if (samples % seconds == 0.0)
                {
                    samples = (long)(samples / seconds);
                    seconds = 1.0;
                }
                else
                    while (samples % 2 == 0 && seconds % 2 == 0)
                    {
                        samples /= 2;
                        seconds /= 2.0;
                    }

            // Can't reduce any farther.
            return new SampleRate(samples, seconds);
        }
        #endregion
    }
}
