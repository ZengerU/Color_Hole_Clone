/*  This script was created by:
 *  Umut Zenger
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    #region Public Members

    #endregion

    #region Private Members
    private Logic logic;
    #endregion
    
    #region Public Functions
    
    #endregion
    
    #region Private Functions
    void Start()
    {
        logic = FindObjectOfType<Logic>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Valid")
        {
            Destroy(other.gameObject);
            logic.UpdateProgress();
        }else if(other.tag == "Invalid")
        {
            Destroy(other.gameObject);
            logic.gameOver();
        }
        else
        {
            throw new Exception("Unidentified object in killzone.");
        }
    }
    #endregion
}
