/*  This script was created by:
 *  Umut Zenger
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System;

public class Logic : MonoBehaviour
{
    #region Public Members
    public GameObject StageParent;
    [HideInInspector]
    public bool GamePaused = false;
    #endregion

    #region Private Members
    private List<GameObject> m_Stages = new List<GameObject>();
    private int currentStage = 0, m_ObjectCount;
    [SerializeField]
    private Transform hole, cam;
    [SerializeField]
    private Animator gate, secondGate;
    private Vector3 m_HoleStartPos;
    #endregion

    #region Public Functions
    public void UpdateProgress()
    {
        m_ObjectCount--;
        if (m_ObjectCount == 0)
        {
            FreezeObjects();
            GamePaused = true;
            if (currentStage >= m_Stages.Count - 1)
                NextLevel();
            currentStage++;
            ResetHole();
        }
    }
    public void gameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void TransmissionStage()
    {
        float distance = m_Stages[currentStage].transform.position.z - m_Stages[currentStage - 1].transform.position.z;
        hole.GetComponent<MoveTable>().offset = distance;
        hole.transform.DOLocalMove(m_HoleStartPos, 2);
        cam.DOMoveZ(cam.position.z + distance, 4).OnComplete(StartStage);
    }
    #endregion

    #region Private Functions
    void Start()
    {
        foreach(Transform child in StageParent.transform)
        {
            m_Stages.Add(child.gameObject);
        }
        FreezeObjects();
        StartStage();
    }
    void StartStage()
    {
        if(currentStage != 0)
            secondGate.Play("CloseGate");
        GamePaused = false;
        m_HoleStartPos = hole.localPosition;
        m_ObjectCount = 0;
        foreach(Rigidbody rb in m_Stages[currentStage].GetComponentsInChildren<Rigidbody>())
        {
            rb.isKinematic = false;
            if (rb.gameObject.tag == "Valid")
                m_ObjectCount++;
        }
    }
    void FreezeObjects()
    {
        foreach (GameObject child in m_Stages)
        {
            foreach (Rigidbody rb in child.GetComponentsInChildren<Rigidbody>())
            {
                rb.isKinematic = true;
            }
        }
    }
    void ResetHole()
    {
        hole.DOMoveX(0, 1).OnComplete(() => gate.Play("OpenGate"));
    }
    void NextLevel()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        string[] scenes = new string[sceneCount];
        for (int i = 0; i < sceneCount; i++)
        {
            scenes[i] = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
            print(scenes[i]);
        }
        int current = int.Parse(SceneManager.GetActiveScene().name.Split(' ')[1]);
        foreach(string child in scenes)
        {
            if(int.Parse(child.Split(' ')[1]) == current + 1)
            {
                SceneManager.LoadScene(child);
            }
        }
    }
    #endregion
}
