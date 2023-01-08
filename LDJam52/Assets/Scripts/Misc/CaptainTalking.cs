using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CaptainTalking : MonoBehaviour
{
	public List<AudioClip> clips = new List<AudioClip>();

	AudioSource source;

	public bool playOnAwake = false;

    // Start is called before the first frame update
    void Start()
    {
		source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

	public void RandomPhrase()
	{
		int index = Random.Range(0, clips.Count);
		source.PlayOneShot(clips[index]);
	}

	private void OnEnable()
	{
		if (playOnAwake)
		{
			RandomPhrase();
		}
	}
}
