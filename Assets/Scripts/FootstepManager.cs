using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FootstepManager : MonoBehaviour
{
    public List<AudioClip> hallSteps = new List<AudioClip>();
    public List<AudioClip> clasroomSteps = new List<AudioClip>();
    public List<AudioClip> meetingroomSteps = new List<AudioClip>();

    private const string SCHOOL_HALL = "SchoolHall";
    private const string MEETINGROOM_FLOOR = "MeetingroomFloor";
    private const string CLASSROOM_FLOOR = "ClassroomFloor";

    private enum Surface { schoolHall, classroomFloor, meetingroomFloor};
    private Surface surface;

    private List<AudioClip> currentList;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();            
    }

    public void PlayStep ()
    {
        Debug.Log("Audio is : " + source.name);
        if(currentList == null)
            return;
        
        AudioClip clip = currentList[Random.Range(0, currentList.Count)];
        source.PlayOneShot(clip);
    }

    private void SelectStepList ()
    {
        switch (surface)
        {
            case Surface.schoolHall:
                currentList = hallSteps;
                break;
            case Surface.classroomFloor:
                currentList = clasroomSteps;
                break;
            case Surface.meetingroomFloor:
                currentList = meetingroomSteps;
                break;
            default:
                currentList = null;
                break;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == SCHOOL_HALL)
        {
            surface = Surface.schoolHall;
        }

        if (hit.transform.tag == MEETINGROOM_FLOOR)
        {
            surface = Surface.meetingroomFloor;
        }

        if (hit.transform.tag == CLASSROOM_FLOOR)
        {
            surface = Surface.classroomFloor;
        }

        SelectStepList();
        
    }

}
