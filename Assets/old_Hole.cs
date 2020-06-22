/*  This script was created by:
 *  Umut Zenger
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hole : MonoBehaviour
{
    #region Public Members

    #endregion

    #region Private Members

    #endregion

    #region Public Functions

    #endregion

    #region Private Functions
    public GameObject table;
    Collider m_Collider;
    Mesh mesh;
    Dictionary<int, List<int>> verticeTriDic;

    void Start()
    {
        verticeTriDic = new Dictionary<int, List<int>>();
        m_Collider = GetComponent<Collider>();
        mesh = table.GetComponent<MeshFilter>().mesh;
        populateDictionary();
        carveHole();
    }
    void populateDictionary()
    {
        int[] triangles = mesh.triangles;
        for (int i = 0; i < triangles.Length; i++)
        {
            if (verticeTriDic.ContainsKey(triangles[i]))
            {
                verticeTriDic[triangles[i]].Add(i - i % 3);
            }
            else
            {
                verticeTriDic.Add(triangles[i], new List<int> { (i - i % 3) });
            }
        }
    }
    void carveHole()
    {
        Destroy(table.GetComponent<MeshCollider>());
        mesh = table.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        List<int> removeList = new List<int>();
        for(int k = 0; k < vertices.Length; k++)
        {
            //print(vertices[k]);
            //print(transform.TransformPoint(vertices[k]));
            if (m_Collider.bounds.Contains(table.transform.TransformPoint(vertices[k])))
            {
                removeList.Add(k);
            }
        }
        HashSet<int> triList = new HashSet<int>();
        foreach(int index in removeList)
        {
            foreach(int tmp in verticeTriDic[index])
            {
                triList.Add(tmp);
            }
        }
        int[] old = mesh.triangles;
        int[] newOne = new int[mesh.triangles.Length - triList.Count];
        print(old.Length);
        int i = 0, j = 0;
        while (j < mesh.triangles.Length)
        {
            if (!triList.Contains(j))
            {
                newOne[i++] = old[j++];
                newOne[i++] = old[j++];
                newOne[i++] = old[j++];
            }
            else
            {
                j += 3;
            }
        }
        print(newOne.Length);
        table.GetComponent<MeshFilter>().mesh.triangles = newOne;
        table.AddComponent<MeshCollider>();
    }

    #endregion
}
