using UnityEngine;

namespace CasualRogue
{
    /// <summary>
    /// シングルトン用MonoBehaviourクラス
    /// </summary>
    /// Note: 参考サイト("https://rurugamedev-blog.com/entry/2023/04/13/%E3%80%90Unity%E3%80%91SingletonMonobehaviour%E3%81%A8%E3%81%AF%EF%BC%9F%E7%9B%AE%E7%9A%84%E3%82%84%E4%BD%BF%E3%81%84%E6%96%B9%E3%81%AB%E3%81%A4%E3%81%84%E3%81%A6%E8%A7%A3%E8%AA%AC#SingletonMonobehaviour%E3%81%AE%E7%89%B9%E5%BE%B4")
    /// <typeparam name="T"></typeparam>
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T : Component
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    //  アクセスされたらまずは、インスタンスがあるか調べる
                    _instance = (T)FindObjectOfType(typeof(T));

                    if (_instance == null)
                    {
                        //  なかったら作る
                        SetupInstance();
                    }
                    else
                    {
                        //  既に生成済みの時のデバッグログ
                        string typeName = typeof(T).Name;

                        CustomLogger.Log("[Singleton] " + typeName + " instance already created: " +
                                  _instance.gameObject.name);
                    }
                }

                return _instance;
            }
        }

        /// <summary>
        /// 起動時
        /// </summary>
        public virtual void Awake()
        {
            //  重複回避のためのチェック
            RemoveDuplicates();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        private static void SetupInstance()
        {  
            _instance = (T)FindObjectOfType(typeof(T));

            if (_instance == null)
            {
                GameObject gameObj = new GameObject();
                gameObj.name = typeof(T).Name;

                _instance = gameObj.AddComponent<T>();
                DontDestroyOnLoad(gameObj);
            }
        }

        /// <summary>
        /// 重複削除
        /// </summary>
        private void RemoveDuplicates()
        {
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}