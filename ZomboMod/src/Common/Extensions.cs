using System;
using System.Collections.Generic;

namespace ZomboMod.Common
{
    public static class Extensions
    {
        public static void ForEach<T>( this T[] array, Action<T> act )
        {
            foreach ( var obj in array ) act( obj );
        }

        public static void ForEach<T>( this IEnumerable<T> enumerable, Action<T> act )
        {
            foreach ( var obj in enumerable ) act( obj );
        }

        public static V GetOrDefault<K, V>( this Dictionary<K, V> dict, K key, V def )
        {
            V value;
            return dict.TryGetValue( key, out value ) ? value : def;
        }
    }
}