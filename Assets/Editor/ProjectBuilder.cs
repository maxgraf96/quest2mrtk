using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectBuilder
{
    [MenuItem("GameObject/MyMenu/FindMRTKStandard", false, 0)]
    static void Run() {
        
        foreach (var obj in Selection.gameObjects) 
        {
            FindShader(obj);
        }
    }

    static void FindShader(GameObject obj)
    {
        var materialOld = Shader.Find("Mixed Reality Toolkit/Standard");
        try
        {
            var mat = obj.GetComponent<Renderer>().sharedMaterial;
            if (mat.shader == materialOld)
            {
                Debug.Log(obj.name);
            }
        } catch (Exception e)
        {
            
        }
        
        if (obj.transform.childCount > 0)
        {
            foreach (Transform childTransform in obj.transform)
            {
                FindShader(childTransform.gameObject);
            }
        }
    }
    
    [MenuItem("GameObject/MyMenu/Do Something", false, 0)]
    static void Init() {
        
        foreach (var obj in Selection.gameObjects) 
        {
            ReplaceMaterial(obj);
        }
    }

    static void ReplaceMaterial(GameObject obj)
    {
        var materialOld = Shader.Find("Mixed Reality Toolkit/Standard");
        var materialNew = Shader.Find("Graphics Tools/Standard");

        try
        {
            var mats = obj.GetComponent<Renderer>().sharedMaterials;
            foreach (var mat in mats)
            {
                if (mat.shader == materialOld)
                {
                    mat.shader = materialNew;
                }
            }
        }
        catch (Exception e)
        {

        }

        if (obj.transform.childCount > 0)
        {
            foreach (Transform childTransform in obj.transform)
            {
                ReplaceMaterial(childTransform.gameObject);
            }
        }
    }
}
