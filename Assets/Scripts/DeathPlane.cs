using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour
{

    void OnTriggerEnter(Collider collider)
    {
        //TODO: Reset game
        if (collider.gameObject.tag == "Player")
        {
            // Debug.Log("Rip...You Died!");
            GameManager.Instance.ResetScore();
        }
    }
    
}
