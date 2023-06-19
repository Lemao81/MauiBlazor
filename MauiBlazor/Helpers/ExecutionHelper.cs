using Microsoft.Extensions.Logging;

namespace MauiBlazor.Helpers
{
    internal static class ExecutionHelper
    {
        public static void ExecuteErrorHandled(Action action, ILogger? logger = null)
        {
            try
            {
                action();
            }
            catch (Exception exception)
            {
                NotificationHelper.ShowErrorMessage(exception);
                logger?.LogError(exception, exception.Message);
            }
        }

        public static async Task ExecuteErrorHandledAsync(Func<Task> action, ILogger? logger = null)
        {
            try
            {
                await action();
            }
            catch (Exception exception)
            {
                NotificationHelper.ShowErrorMessage(exception);
                logger?.LogError(exception, exception.Message);
            }
        }
    }
}
