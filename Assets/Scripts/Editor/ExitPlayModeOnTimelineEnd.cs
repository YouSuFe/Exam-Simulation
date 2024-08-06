using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;

public class ExitPlayModeOnTimelineEnd : PlayableBehaviour
{
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        base.OnBehaviourPause(playable, info);

        if (!playable.IsValid() || EditorApplication.isPlaying == false)
            return;

        // Check if the timeline has finished playing
        if (info.evaluationType == FrameData.EvaluationType.Playback && playable.GetTime() >= playable.GetDuration())
        {
            EditorApplication.isPlaying = false;
        }
    }
}
