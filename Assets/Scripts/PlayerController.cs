using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private AudioClip beepSound;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement(GetInputs());
    }

    private Vector3 GetInputs()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new(xInput, 0f, zInput);
        moveDirection.Normalize();

        return moveDirection;
    }

    private void Movement(Vector3 moveDir)
    {
        rb.AddForce(moveDir * moveSpeed, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("SoundPlayer")) return;
        Debug.Log(other.gameObject.name);
        SoundManager.Instance.PlaySound(beepSound, other.transform.position);
    }
}
