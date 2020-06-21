using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Moving Box")
        {
            float distance = Vector3.Distance(transform.position, other.transform.position);
            
            if(distance < 0.4f)
            {
                MeshRenderer boxMat = other.GetComponent<MeshRenderer>();
                if (boxMat != null)
                {
                   boxMat.material.color = Color.blue;
                   
                }

                Rigidbody boxRb = other.GetComponent<Rigidbody>();
                if(boxRb != null)
                {
                    boxRb.isKinematic = true;
                }
                
                Destroy(this);
            }

        }
    }
}
