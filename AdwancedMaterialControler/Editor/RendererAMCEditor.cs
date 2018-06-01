using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AdwancedMaterialControler
{
    [CustomEditor(typeof(RenderAMC))]
    public sealed class RendererAMCEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            RenderAMC r = (RenderAMC) target;

            DrawDefaultInspector();


            r.SliderNameBase = EditorGUILayout.IntSlider(r.SliderNameBase,0,CoreAMC.istance.amcData.Count-1);
            GUILayout.Label("Name In Data Base Is: " + CoreAMC.istance.amcData[r.SliderNameBase].DataName);

            r.UseCustomShader = GUILayout.Toggle(r.UseCustomShader, "Use Custom Shader");

            if (r.UseCustomShader)
            {
                EditorGUILayout.BeginHorizontal();
                GUILayout.Label("Custom Shader Field: ");
                r.CustomShader = (Shader) EditorGUILayout.ObjectField(r.CustomShader,typeof(Shader),true);
                EditorGUILayout.EndHorizontal();
            }

           r.UseCustomTexture = GUILayout.Toggle(r.UseCustomTexture, "Use Custom Texture");

            if (r.UseCustomTexture)
            {
                EditorGUILayout.BeginHorizontal();
                GUILayout.Label("Custom Texture Field: ");
                r.CustomTexture = (Texture)EditorGUILayout.ObjectField(r.CustomTexture, typeof(Texture), true);
                EditorGUILayout.EndHorizontal();
            }

            if (GUILayout.Button("Update Components"))
            {
                r.UpdateComponets();
            }

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("-"))
            {
                if (r.Value > 0)
                {
                    r.Value--;
                }
                r.UpdateRender(r.Value);
            }

            
            if (GUILayout.Button("+"))
            {
                if (r.Value < r.CoreAmc.amcData[r.NameBaseCount].Textures.Length-1)
                {
                    r.Value++;
                }
                r.UpdateRender(r.Value);
            }

            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("Remove This Component"))
            {
                r.RemoveThisComponent();
            }

        }
    }
}

