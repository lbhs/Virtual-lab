using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
	public static AudioClip fizzSound;
	public static AudioClip pourSound;
	static AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
		fizzSound = Resources.Load<AudioClip>("Sounds/fizz");
		pourSound = Resources.Load<AudioClip>("Sounds/pour");
    }

    /*example for playing a sound anywhere in the code:
	SoundManagerScript.audioSource.PlayOneShot(SoundManagerScript.fizzSound);
	*/
}
