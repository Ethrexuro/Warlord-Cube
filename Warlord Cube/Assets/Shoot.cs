using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
int PlayerNNumber;
public PlayerProjectile projectile;
public Transform spawnPoint;
void Start()
{
    PlayerNNumber = GetComponentInParent<PlayerData>().PlayerNumber;
}
void Update()
{
    if(Input.GetKeyDown(KeyCode.F) && PlayerNNumber == 1 || Input.GetKeyDown(KeyCode.RightControl) && PlayerNNumber == 2)
    {
        var projectileInst = Instantiate(projectile, spawnPoint.position, Quaternion.LookRotation(spawnPoint.forward, spawnPoint.up));
        projectileInst.shotBy = PlayerNNumber;
    }
}
}
