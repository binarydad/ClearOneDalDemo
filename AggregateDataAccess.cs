using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BinaryDad.AggregateDal
{
    public class AggregateDataAccess<T> where T : class
    {
        private static ICollection<Type> dataAccessTypes;

        static AggregateDataAccess() => LoadInstances();

        /// <summary>
        /// Invokes a method for all instances of <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        protected TResult Invoke<TResult>(Func<T, TResult> func)
        {
            var results = new List<TResult>();

            foreach (var dataAccessType in dataAccessTypes)
            {
                var instance = Activator.CreateInstance(dataAccessType) as T;

                results.Add(func(instance));
            }

            // if the "EF" version invokes first, return that value
            return results.FirstOrDefault(r => !r.Equals(default(T)));
        }

        private static void LoadInstances()
        {
            if (dataAccessTypes == null)
            {
                var type = typeof(T);
                var aggregateType = typeof(AggregateDataAccess<T>);

                // load all types except for 1) the interface itself, 2) any interface, and 3) is not implementing AggregateDataAccess<T>
                // NOTE: the "EF" version will load first, allowing for the "QuickBase" version to run last, in a separate thread if desired
                dataAccessTypes = Assembly.GetExecutingAssembly()
                    .ExportedTypes
                    .Where(t => type.IsAssignableFrom(t) && !t.IsInterface && !aggregateType.IsAssignableFrom(t))
                    .OrderBy(t => t.Name.StartsWith("QuickBase", StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
        }
    }
}
