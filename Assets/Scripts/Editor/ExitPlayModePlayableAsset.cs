using UnityEngine;
using UnityEngine.Playables;

[CreateAssetMenu(fileName = "ExitPlayModePlayableAsset", menuName = "ScriptableObjects/ExitPlayModePlayableAsset", order = 1)]
public class ExitPlayModePlayableAsset : PlayableAsset
{
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<ExitPlayModeOnTimelineEnd>.Create(graph);
        return playable;
    }
}
