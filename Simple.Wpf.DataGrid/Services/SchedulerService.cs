using System;
using System.Reactive.Concurrency;
using System.Threading;

namespace Simple.Wpf.DataGrid.Services
{
    public sealed class SchedulerService : ISchedulerService
    {
        public SchedulerService()
        {
            var dispatcher = System.Windows.Threading.Dispatcher.FromThread(Thread.CurrentThread);
            if (dispatcher == null)
                throw new ArgumentNullException(nameof(dispatcher));

            Dispatcher = new SynchronizationContextScheduler(SynchronizationContext.Current);
        }

        public IScheduler Dispatcher { get; }

        public IScheduler Current => CurrentThreadScheduler.Instance;

        public IScheduler TaskPool => TaskPoolScheduler.Default;

        public IScheduler EventLoop => new EventLoopScheduler();

        public IScheduler NewThread => NewThreadScheduler.Default;

        public IScheduler StaThread
        {
            get
            {
                Func<ThreadStart, Thread> func = x =>
                {
                    var thread = new Thread(x) { IsBackground = true };
                    thread.SetApartmentState(ApartmentState.STA);

                    return thread;
                };

                return new EventLoopScheduler(func);
            }
        }
    }
}