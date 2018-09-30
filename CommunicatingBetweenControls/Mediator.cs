using CommunicatingBetweenControls.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicatingBetweenControls
{
    public sealed class Mediator
    {
        // static members handle Singleton Functionality
        private static readonly Mediator _Instance = new Mediator(); // Singleton - single instance that we want to share that will only be created one time
        private Mediator() {} // hides constructor, don't want people to new it up.
        public static Mediator GetInstance()
        {
            return _Instance;
        }

        //Instance functionlity
        public event EventHandler<JobChangedEventArgs> JobChanged; // event delegate

        public void OnJobChanged(object sender, Job job) // raise event to notify listeners about job being changed
        {
            // raise the event
            (JobChanged as EventHandler<JobChangedEventArgs>)?.Invoke(sender, new JobChangedEventArgs { Job = job });

            //var jobChangeDelegate = JobChanged as EventHandler<JobChangedEventArgs>;
            //if (jobChangeDelegate != null)
            //{
            //    jobChangeDelegate(sender, new JobChangedEventArgs { Job = job });
            //}
        }
    }
}
