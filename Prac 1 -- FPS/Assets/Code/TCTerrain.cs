using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class TCTerrain : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int m_Heightmap;
    public float m_Width;
    public float m_Lenght;
    public float m_Height;
    public int m_Divisions = 50;
    public void Start()
    {
        GenerateMesh();
    }
    void GenerateMesh()
    {
        List<Vector3> l_Vertices = new List<Vector3> ();
        List <int> l_Indices = new List<int> ();
        Mesh l_Mesh = new Mesh (); 

        for (int z = 0; z<= m_Divisions; z++)
        {
            for(int x = 0; x<=m_Divisions; x++) 
            { 
                l_Vertices.Add(GetVertex (x,z));
                //l_UVs.Add (GetUV (x,z));
            }
        }
        for (int z = 0;z<= m_Divisions; z++)
        {
            for (int x = 0;x<=m_Divisions; x++)
            {

            }
        }
        l_Mesh.SetVertices(l_Vertices);
        l_Mesh.SetIndices(l_Indices, MeshTopology.Triangles, 0);
        //l_Mesh.SetUVs(0, l_UVs);
        GetComponent<MeshFilter>().mesh = l_Mesh;
    }
    Vector3 GetVertex(int x, int z)
    {
        Vector2 l_NormalizedPosition = GetNormalizedPosition(x, z);
        //Color l_Color = m_Heightmap.GetPixel((int)(l_NormalizedPosition.x * m_Heightmap.width, l_NormalizedPosition.y * m_Heightmap.height));

        float l_Height = 0.0f;
        return new Vector3(l_NormalizedPosition.x*m_Width,l_Height, l_NormalizedPosition.y*m_Height);
    }
    Vector2 GetUV(int x, int z) 
    {
        return GetNormalizedPosition(x, z);
    }
    Vector2 GetNormalizedPosition(int x, int z) 
    {
        return new Vector2(x/(float)m_Divisions, z/(float)m_Divisions);
    }
}
