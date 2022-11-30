using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
{
    Playercontroller controller = other.GetComponent<Playercontroller>();

        if (controller != null)
        {
            if(controller.health  < controller.maxHealth)
            {
                controller.ChangeHealth(5);
                Destroy(gameObject);
            }
        }
}
}