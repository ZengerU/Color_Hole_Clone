/*  This script was created by:
 *  Umut Zenger
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullTowards : MonoBehaviour
{
    #region Public Members

    #endregion

    #region Private Members
    [SerializeField]
    private float m_pullForce = 1;
    #endregion

    #region Public Functions

    #endregion

    #region Private Functions
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Valid" || other.tag == "Invalid")
        {
            Vector3 forceDirection = transform.position - other.transform.position;
            other.GetComponent<Rigidbody>().AddForce(forceDirection.normalized * m_pullForce * Time.fixedDeltaTime);
        }
    }
    #endregion
}
