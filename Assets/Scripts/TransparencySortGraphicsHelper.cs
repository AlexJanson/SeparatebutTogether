using UnityEngine;
using UnityEngine.Rendering;
 
#if UNITY_EDITOR
using UnityEditor;
[InitializeOnLoad]
#endif

/// <summary>
/// This is a hack for using transparencySortMode with URP.
/// https://forum.unity.com/threads/transparency-sort-mode-and-lightweight-render-pipeline.651700/
/// </summary>
internal class TransparencySortGraphicsHelper
{
    static TransparencySortGraphicsHelper() => OnLoad();
 
    [RuntimeInitializeOnLoadMethod]
    private static void OnLoad()
    {
        GraphicsSettings.transparencySortMode = TransparencySortMode.CustomAxis;
        GraphicsSettings.transparencySortAxis = new Vector3(0.0f, 1.0f, 0.0f);
    }
}