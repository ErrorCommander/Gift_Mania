using System;

namespace Gameplay.Extensions
{
    public static class BuilderExtensions
    {
        public static TValue With <TValue>(this TValue value, Action<TValue> action)
        {
            action(value);
            return value;
        }
    }
}
