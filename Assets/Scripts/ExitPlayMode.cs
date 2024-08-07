#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class ExitPlayMode : MonoBehaviour
{
    public void ExitPlay()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;

#elif UNITY_WEBGL
        Debug.Log("Animation is Over. Please Close the tab!");

#else
        Application.Quit();

#endif
    }
}