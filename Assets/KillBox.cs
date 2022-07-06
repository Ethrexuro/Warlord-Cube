using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    public int Damage;
    void OnTriggerEnter(Collider Other){
        if(Other.tag == "Player"){
            Other.GetComponent<Health>().TakeDamage(Damage);
        }
        if (Other.tag == "Player1" || Other.tag == "Player2"){
            Other.GetComponent<HealthOnline>().TakeDamage(Damage);
        }
    }
}
