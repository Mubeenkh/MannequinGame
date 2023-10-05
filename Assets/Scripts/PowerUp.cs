using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public ParticleSystem burstParticle = null;

    private void Start()
    {
        // burstParticle = GetComponentInChildren<ParticleSystem>();
    }
    
    // Target Manager
    public void OnTriggerEnter(Collider other)
    {
        
        // TODO: When you touch the yellow ball, activate particle effect
        burstParticle.Play();

        // TODO: When you collect the yellow ball, add score
        GameManager.Instance.AddScore();
        
    
        // TODO: When you collect yellow ball, remove it from game
        gameObject.SetActive(false);

    }
    
    void ResetTarget()
    {
        gameObject.SetActive(true);
        
    }

}
