using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sea : MonoBehaviour
{
	  float scale = 0.13f;
     float speed = 1.0f;
 
     private Vector3[] baseHeight;
    void Update()
    {

        Mesh mesh = GetComponent<MeshFilter>().mesh;
   
         if (baseHeight == null)
             baseHeight = mesh.vertices;
   
         Vector3[] vertices = new Vector3[baseHeight.Length];
         for (int i=0;i<vertices.Length;i++)
         {
             Vector3 vertex = baseHeight[i];
             vertex.z += Mathf.Sin(Time.time * speed+ baseHeight[i].x + baseHeight[i].y + baseHeight[i].z) * scale;
             vertices[i] = vertex;
         }
         mesh.vertices = vertices;
         mesh.RecalculateNormals();
    }
};
