using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 6)
        {
            Destroy(other.transform.parent.gameObject);
        }
    }

    
}
