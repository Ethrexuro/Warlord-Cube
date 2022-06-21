using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ShootOnline : MonoBehaviour
{
    int PlayerNumber;
    public PlayerProjectileOnline projectile;
    public Transform spawnPoint;
    PhotonView view;
    void start(){
        PlayerNumber = GetComponentInParent<PlayerDataOnline>().PlayerNumber;
        view = GetComponent<PhotonView>();
    }
    void Update(){
        if (!view.IsMine) return;
        if (Input.GetKeyDown(KeyCode.F)){
            Shoot();
        }
    }
    [PunRPC]
    public void Shoot(){
        var projectileInst = PhotonNetwork.Instantiate(projectile.name, spawnPoint.position, spawnPoint.rotation, 0);
        projectileInst.GetComponent<PlayerProjectileOnline>().shotBy = PlayerNumber;
    }
}
