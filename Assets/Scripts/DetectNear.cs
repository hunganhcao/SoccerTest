using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectNear : MonoBehaviour
{
    public static bool isInBox;
    

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")){
            isInBox = true;
            UIController.Instance.EnableButton();
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (isInBox) return;

        if (other.CompareTag("Ball"))
        {
            isInBox = true;
            UIController.Instance.EnableButton();

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball")){
            isInBox = false;
            UIController.Instance.DisableButton();
        }
    }
}
