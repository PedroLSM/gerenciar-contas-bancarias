using System;

namespace GCB.Comum.Extensoes
{
    public static class EnumExtensao
    {
        public static T ParseEnum<T>(this string value)
        {
            Enum.TryParse(typeof(T), value, true, out object result);
            return (T)(result ?? 0);
        }
    }
}
