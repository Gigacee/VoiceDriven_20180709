using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineController : MonoBehaviour
{
	PlayableDirector timeline;
	Dictionary<string, double> labels;

	void Start()
	{
		timeline = GetComponent<PlayableDirector>();

		labels = ((TimelineAsset)timeline.playableAsset)
			.GetOutputTracks()
			.Single(x => x.name == "Label")
			.GetClips()
			.ToDictionary(
				clip => clip.displayName,
				clip => clip.start);
	}

	public void GotoAndPlay(string label)
	{
		timeline.time = labels[label];
		timeline.Evaluate();
		timeline.Play();
	}

	public void GotoAndStop(string label)
	{
		timeline.time = labels[label];
		timeline.Evaluate();
		timeline.Pause();
	}

	public void Play()
	{
		timeline.Play();
	}

	public void Stop()
	{
		timeline.Pause();
	}
}
