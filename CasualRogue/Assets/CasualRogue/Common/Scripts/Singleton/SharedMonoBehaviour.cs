using System.Runtime.CompilerServices;
using UnityEngine;

namespace CasualRogue
{
    /// <summary>
    /// SharedMonoBehaviour
    /// </summary>
    public abstract class SharedMonoBehaviour<T> : MonoBehaviour
        where T : MonoBehaviour
    {
        /// <summary>
        /// インスタンス
        /// </summary>
        public static T Instance { get; private set; }

        /// <summary>
        /// インスタンス存在かどうか
        /// </summary>
        public static bool Exists => Instance;

        /// <summary>
        /// Gets a value that indicates whether the UnityEngine.Object is null or destroyed.
        /// </summary>
        public static bool IsNullOrDestroyed
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Instance.IsNullOrDestroyed();
        }

        /// <summary>
        /// Override用Awake
        /// </summary>
        protected virtual void AwakeInternal()
        {
        }

        /// <summary>
        /// Override用OnDestroy
        /// </summary>
        protected virtual void OnDestroyInternal()
        {
        }

        /// <summary>
        /// 生成時処理
        /// </summary>
        protected virtual void Awake()
        {
            if (CheckInstance())
            {
                AwakeInternal();
            }
            else
            {
                if (gameObject.GetComponents<MonoBehaviour>().Length <= 2)
                {
                    CustomLogger.Log("Destroy gameObject. [" + gameObject.name + "]");
                    Destroy(gameObject);
                }
                else
                {
                    CustomLogger.Log("Destroy component. [" + gameObject.name + ":" + typeof(T).Name + "]");
                    Destroy(this);
                }
            }
        }

        /// <summary>
        /// 破棄時の処理
        /// </summary>
        protected virtual void OnDestroy()
        {
            if (Instance != this)
            {
                return;
            }
            Instance = null;
            OnDestroyInternal();
        }

        /// <summary>
        /// インスタンスのチェック
        /// </summary>
        private bool CheckInstance()
        {
            if (Instance == null)
            {
                Instance = this as T;
                return true;
            }
            if (Instance == this)
            {
                return true;
            }
            return false;
        }
    }
}
