using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using System.Linq;
using System.Collections.Generic;
#endif
public class SceneNameAttribute : PropertyAttribute
{
    public int selectedValue = 0;
    public bool enableOnly = true;
    public SceneNameAttribute(bool enableOnly = true)
    {
        this.enableOnly = enableOnly;
    }
}
