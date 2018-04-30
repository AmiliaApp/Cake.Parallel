using System;
using System.Collections.Generic;
using System.Text;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.Diagnostics;

namespace Cake.Parallel.Module
{
    public static class LoggingWithTaskAliases
    {
        /// <summary>
        /// Writes an informational message to the log using the specified string value.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="taskName">The task name.</param>
        /// <param name="value">The value.</param>
        /// <example>
        /// <code>
        /// Information("{string}");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void InformationWithTask(this ICakeContext context, string taskName, string value)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            context.Log.Information(PrependTaskName(taskName, value));
        }

        /// <summary>
        /// Writes an error message to the log using the specified string value.
        /// </summary>
        /// <param name="context">the context.</param>
        /// <param name="taskName">The task name.</param>
        /// <param name="value">The value.</param>
        /// <example>
        /// <code>
        /// Error("{string}");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Error")]
        public static void ErrorWithTask(this ICakeContext context, string taskName, string value)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            context.Log.Error(PrependTaskName(taskName, value));
        }

        private static string PrependTaskName(string taskName, string value)
        {
            return $"<{taskName}> {value}";
        }
    }
}
