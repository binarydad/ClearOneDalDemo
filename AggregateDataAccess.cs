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

        protected TResult Invoke<TResult>(Func<T, TResult> func)
        {
            var results = new List<TResult>();

            foreach (var dataAccessType in dataAccessTypes)
            {
                var instance = Activator.CreateInstance(dataAccessType) as T;

                results.Add(func(instance));
            }

            return results.LastOrDefault();
        }

        private static void LoadInstances()
        {
            // this would load all instances of type T

            if (dataAccessTypes == null)
            {
                var type = typeof(T);
                var aggregateType = typeof(AggregateDataAccess<T>);

                // load all types except for 1) the interface itself, 2) any interface, and 3) is not implementing AggregateDataAccess<T>
                dataAccessTypes = Assembly.GetExecutingAssembly()
                    .ExportedTypes
                    .Where(t => type.IsAssignableFrom(t) && !t.IsInterface && !aggregateType.IsAssignableFrom(t))
                    .OrderBy(t => t.Name.StartsWith("QuickBase", StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
        }
    }
}
