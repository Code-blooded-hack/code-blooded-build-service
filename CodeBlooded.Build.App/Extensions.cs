using System;
using System.Collections.Generic;


namespace CodeBlooded.Build.App
{
    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> target, Action<T> action)
        {
            foreach (var item in target)
            {
                action.Invoke(item);
            }
        }
    }
}