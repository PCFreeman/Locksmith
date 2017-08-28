using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

	private AudioSource mBGM;
	private AudioSource mSFX;

	void Awake()
	{
		mSFX = GameObject.Find ("SFX").GetComponent<AudioSource> ();
		mBGM = GameObject.Find ("BackgroundMusic").GetComponent<AudioSource> ();
		mBGM.Play (44100);
	}
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void ClickSFX()
	{
		mSFX.Play ();
	}
}
