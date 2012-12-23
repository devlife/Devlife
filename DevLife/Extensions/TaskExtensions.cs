using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Extensions
{
    public static class TaskExtensions
    {
        /// <summary>
        /// Retrieves a result from a Task with exception handlling
        /// </summary>
        /// <typeparam name="TResult">The type returned by the Task</typeparam>
        /// <param name="task">The Task that contains the result</param>
        /// <param name="defaultValue">Optional parameter which contains the value to be returned in case of an AggregateException</param>
        /// <param name="onError">Optional Action that will be executed in case of an AggregateException</param>
        /// <returns>Object of type TResult</returns>
        public static TResult SafeResult<TResult>(this Task<TResult> task, TResult defaultValue = default(TResult), Action<AggregateException> onError = null)
        {
            try
            {
                TResult result = task.Result;

                Type type = typeof(TResult);
                Type nullableType = Nullable.GetUnderlyingType(type);
                if (nullableType != null)
                {
                    return (TResult)Convert.ChangeType(result, nullableType);
                }

                return (TResult)Convert.ChangeType(result, type);
            }
            catch (AggregateException ae)
            {
                var sb = new StringBuilder();
                ae.InnerExceptions.ToList().ForEach(e => sb.AppendLine(e.ToString()));

                ae.Handle(e => true);

                if (onError != null)
                    onError(ae);
            }

            return defaultValue;
        }
    }
}