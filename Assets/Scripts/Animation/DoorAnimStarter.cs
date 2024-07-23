using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimStarter : MonoBehaviour
{
    private Animator doorAnimator;
    [SerializeField] private string doorAnimationName;

    private void Start()
    {
        doorAnimator = GetComponent<Animator>();
        doorAnimator.Play(doorAnimationName);
    }

}
