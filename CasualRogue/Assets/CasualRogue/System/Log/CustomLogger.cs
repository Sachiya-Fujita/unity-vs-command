using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace CasualRogue.System.Log
{
    public static class CustomLogger
    { 
#if !(UNITY_EDITOR || DEVELOPMENT_BUILD)
        [Conditional("CUSTOM_LOGGER")]
#endif
        public static void Log(string msg)
        {
            Debug.Log(msg);
        }

#if !(UNITY_EDITOR || DEVELOPMENT_BUILD)
	    [Conditional("CUSTOM_LOGGER")]
#endif
        public static void LogWarning(string msg)
        {
            Debug.LogWarning(msg);
        }

#if !(UNITY_EDITOR || DEVELOPMENT_BUILD)
	    [Conditional("CUSTOM_LOGGER")]
#endif
        public static void LogError(string msg)
        {
            Debug.LogError(msg);
        }
    }
}