// todo: document this hack

using System;

// ReSharper disable once CheckNamespace
namespace EmptyStringGuard
{
    /// <summary>
    /// Prevents the injection of empty string checking.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property)]
    internal class AllowEmptyAttribute : Attribute
    {
    }
}