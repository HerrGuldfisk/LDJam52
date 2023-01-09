using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	private List<AudioSource> audioSources = new List<AudioSource>();

	public List<AudioClip> clips = new List<AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 3; i++)
		{
			audioSources.Add(gameObject.AddComponent<AudioSource>());
			audioSources[0].volume = 0.1f;
			audioSources[0].loop = true;
		}

		audioSources[0].clip = clips[0];
		audioSources[0].Play();
    }

    // Update is called once per frame
    void Update()
    {

    }


}
