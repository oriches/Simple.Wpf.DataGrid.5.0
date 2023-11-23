using System;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;

namespace Simple.Wpf.DataGrid.Extensions;

public static class SchedulerExtensions
{
    public static IDisposable Schedule(this IScheduler scheduler, TimeSpan timeSpan, Action action) =>
        scheduler.Schedule(action, timeSpan, (_, s2) =>
        {
            s2();
            return Disposable.Empty;
        });

    public static IDisposable Schedule(this IScheduler scheduler, Action action) =>
        scheduler.Schedule(action, (_, s2) =>
        {
            s2();
            return Disposable.Empty;
        });
}