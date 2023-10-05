using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BluePickUp : MonoBehaviour
{
    CharacterMovement character;
    public ParticleSystem burstParticle = null;

    private GameObject playerGameObject;
    private void Start()
    {
        playerGameObject = GameObject.FindWithTag("Player");
        character = (CharacterMovement) playerGameObject.GetComponent(typeof(CharacterMovement));
        
    }
    
    public void OnTriggerEnter(Collider other)
    {
        // TODO: When you collect the blue ball, you should be able to double jump
        
        if (other.gameObject.tag == "Player")
        {

            // TODO: When you touch the yellow ball, activate particle effect
            burstParticle.Play();
                
            character.DoubleJump();

            // TODO: When you collect blue ball, remove it from game
            gameObject.SetActive(false);
            // TODO: After 30 seconds, bring blue ball back
            Invoke("ResetTarget",30.0f);
        }
    }
    
    void ResetTarget()
    {
        gameObject.SetActive(true);
        
    }
}
