/*  This script was created by:
 *  Umut Zenger
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSleep : MonoBehaviour
{
    #region Public Members

    #endregion

    #region Private Members

    #endregion

    #region Public Functions

    #endregion

    #region Private Functions
    private void OnEnable()
    {
        foreach(Rigidbody child in GetComponentsInChildren<Rigidbody>())
        {
            child.sleepThreshold = 0;
        }
    }

    void Update()
    {
        
    }
    #endregion
}
