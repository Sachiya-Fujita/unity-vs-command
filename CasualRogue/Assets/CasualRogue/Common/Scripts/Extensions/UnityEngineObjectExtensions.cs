using System.Runtime.CompilerServices;

namespace CasualRogue
{
    /// <summary>
    /// Extension methods for UnityEngine.Object
    /// </summary>
    public static class UnityEngineObjectExtensions
    {
        /// <summary>
        /// Gets a value that indicates whether the UnityEngine.Object is null or destroyed.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullOrDestroyed(this UnityEngine.Object o)
        {
            // 殆どの場合は null がどうかのチェックなので, C# 的に null ならすぐ返す方が軽い.
            // implicit operator bool(Object exists) が最適化されたら, どんな場面でもこっちの方が確実に軽い.
            return o is null || !o;

            // Unity 的に破棄されたかどうかの判定ならこっちの方が早い.
            // return o == null;
        }

        /// <summary>
        /// Gets a value that indicates whether the UnityEngine.Object is not null and alive.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ExistsAlive(this UnityEngine.Object o)
        {
            // implicit operator bool(Object exists) が最適化されたらこっちの方が確実に軽い
            // return o is object && o;

            return o != null;
        }
    }
}