using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDeneme : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered!");
    }
}
