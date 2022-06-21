using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovementOnline : MonoBehaviour{

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnSpeed = 360;
    private Vector3 _input;
Animator animator;
PhotonView view;
void Start(){
    animator = GetComponentInChildren <Animator>();
    view = GetComponent<PhotonView>();
}

    void Update() {
        if (!view.IsMine) return;
        GatherInput();
        Look();
        animator.SetFloat("Speed", _input.magnitude);
    }

    void FixedUpdate() {
        if (!view.IsMine) return;
        Move();
    }

    void GatherInput() {
        _input = new Vector3(Input.GetAxisRaw("Horizontal P1"),0,Input.GetAxisRaw("Vertical P1"));
    }

    void Look() 
    {

        if (_input != Vector3.zero) {

        var relative = (transform.position + _input.ToIso()) - transform.position;
        var rot = Quaternion.LookRotation(relative,Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation,rot, _turnSpeed * Time.deltaTime);            
        }

    }

    void Move() {
        _rb.MovePosition(transform.position + (transform.forward * _input.magnitude) * _speed * Time.deltaTime);
    }
}
