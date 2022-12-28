#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

public static class MoveControlResigter
{
    [MenuItem("GameObject/UI/MyExtentions/MoveControlResigter")]
    public static void AddDialogPanel(MenuCommand menuCommand)
    {
        var parent = menuCommand.context as GameObject;
        var instance = Object.Instantiate(Resources.Load("MoveControl"), parent.transform) as GameObject;
        instance.name = "MoveControl";
    }
}

#endif
