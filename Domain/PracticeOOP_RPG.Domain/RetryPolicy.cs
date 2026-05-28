using System.Threading;

namespace PracticeOOP_RPG.Domain;

public static class RetryPolicy
{
    public static void Execute(Action action, int maxAttempts = 3, TimeSpan? delay = null, Func<Exception, bool>? shouldRetry = null)
    {
        if (action == null) throw new ArgumentNullException(nameof(action));
        if (maxAttempts < 1) throw new ArgumentOutOfRangeException(nameof(maxAttempts));

        var attempts = 0;
        var wait = delay ?? TimeSpan.FromMilliseconds(100);

        while (true)
        {
            try
            {
                attempts++;
                action();
                return;
            }
            catch (Exception ex) when (attempts < maxAttempts && (shouldRetry?.Invoke(ex) ?? true))
            {
                Thread.Sleep(wait);
                wait = TimeSpan.FromMilliseconds(wait.TotalMilliseconds * 2);
            }
        }
    }

    public static T Execute<T>(Func<T> action, int maxAttempts = 3, TimeSpan? delay = null, Func<Exception, bool>? shouldRetry = null)
    {
        if (action == null) throw new ArgumentNullException(nameof(action));
        if (maxAttempts < 1) throw new ArgumentOutOfRangeException(nameof(maxAttempts));

        var attempts = 0;
        var wait = delay ?? TimeSpan.FromMilliseconds(100);

        while (true)
        {
            try
            {
                attempts++;
                return action();
            }
            catch (Exception ex) when (attempts < maxAttempts && (shouldRetry?.Invoke(ex) ?? true))
            {
                Thread.Sleep(wait);
                wait = TimeSpan.FromMilliseconds(wait.TotalMilliseconds * 2);
            }
        }
    }
}
