using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Rummage.Tests.TestHelpers
{
    internal class PerformanceGovernor
    {
        /// <summary>
        /// runs the given action and returns the time it took to execute
        /// </summary>
        public double Time(Action actionToTime)
        {
            var timer = Stopwatch.StartNew();
            actionToTime();
            timer.Stop();
            return timer.ElapsedMilliseconds;
        }

        /// <summary>
        /// Calculates the average time it took to execute each action given
        /// </summary>
        /// <param name="actionsToTime">list of actions to take to have their execution time averaged together</param>
        /// <returns>The average time it took for the list of actions to execute</returns>
        public double Time(params Action[] actionsToTime)
        {
            var times = new ConcurrentBag<double>();
            Parallel.ForEach(actionsToTime, actionToTime =>
            {
                times.Add(Time(actionToTime));
            });
            return times.ToList().Average();
        }
    }
}
