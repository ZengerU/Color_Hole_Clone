/*  This script was created by:
 *  Umut Zenger
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTable : MonoBehaviour
{
    #region Public Members
    [HideInInspector]
    public float offset = 0;
    #endregion

    #region Private Members
    [SerializeField]
    private float m_Speed = 1;
    private Logic logic;
    #endregion

    #region Public Functions

    #endregion

    #region Private Functions
    private void Start()
    {
        logic = FindObjectOfType<Logic>();
    }
    void Update()
    {
        if (logic.GamePaused)
            return;
        Vector3 tmp = transform.position;
        tmp.z += Input.GetAxisRaw("Vertical") * Time.deltaTime * m_Speed;
        tmp.x += Input.GetAxisRaw("Horizontal") * Time.deltaTime * m_Speed;
        tmp.x = Mathf.Clamp(tmp.x, -48, 48);
        tmp.z = Mathf.Clamp(tmp.z, -38 + offset, 148+ offset);
        transform.position = tmp;
    }
    #endregion
}
