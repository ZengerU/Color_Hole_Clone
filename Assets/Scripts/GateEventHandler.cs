/*  This script was created by:
 *  Umut Zenger
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateEventHandler : MonoBehaviour
{
    #region Public Members
    
    #endregion
    
    #region Private Members
    
    #endregion
    
    #region Public Functions
    public void GateOpenedEvent()
    {
        FindObjectOfType<Logic>().TransmissionStage();
    }
    #endregion
    
    #region Private Functions
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
    #endregion
}
