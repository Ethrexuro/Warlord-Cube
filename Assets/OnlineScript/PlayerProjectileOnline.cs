using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerProjectileOnline : MonoBehaviour
{
public int shotBy;
public int damage;
public float speed;
public Rigidbody rb;
[SerializeField]
ParticleSystem ps;
void start()
{
    rb = GetComponent<Rigidbody>();
    ps.Play();
    Destroy(gameObject, 10);
}
private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        if (other.GetComponent<PlayerDataOnline>().PlayerNumber == shotBy) return;
        other.GetComponent<HealthOnline>().view.RPC("TakeDamage",RpcTarget.All, damage, shotBy);
    }
    DestroySelf();
}
void FixedUpdate()
{
    rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
}
void DestroySelf()
{
    ps.Play();
    GetComponent<MeshRenderer>().enabled = false;
    GetComponent<Collider>().enabled = false;
    GetComponent<TrailRenderer>().emitting = false;
    Destroy(gameObject, 1);
}
}