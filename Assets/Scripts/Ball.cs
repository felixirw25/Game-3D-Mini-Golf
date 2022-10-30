using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip shootClip;
    [SerializeField] AudioClip collisionClip;
    public Vector3 Position => rb.position;
    [SerializeField] Vector3 lastPosition;
    bool isTeleporting;
    public bool IsMoving => rb.velocity!=Vector3.zero;
    public bool IsTeleporting => isTeleporting;

    // Start is called before the first frame update
    private void Awake()
    {
        if(rb==null){
            rb = GetComponent<Rigidbody>();
        }
        lastPosition = this.transform.position;
    }

    internal void AddForce(Vector3 force)
    {
        rb.isKinematic=false;
        lastPosition = this.transform.position;
        rb.AddForce(force, ForceMode.Impulse);
        audioSource.PlayOneShot(shootClip);
    }

    private void FixedUpdate(){
        if(rb.velocity!=Vector3.zero && rb.velocity.magnitude<0.8f){
            rb.velocity=Vector3.zero;
            rb.isKinematic=true;
        }
    }

    private void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Out"){
            StopAllCoroutines();
            StartCoroutine(DelayedTeleport());
            audioSource.PlayOneShot(collisionClip);
        }
    }

    IEnumerator DelayedTeleport(){
        isTeleporting=true;
        yield return new WaitForSeconds(3);
        rb.isKinematic=true;
        this.transform.position = lastPosition;
        isTeleporting=false;
    }
}
