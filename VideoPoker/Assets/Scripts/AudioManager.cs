using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	[SerializeField]
	private AudioClip[] _audioClipArray;

	private AudioSource _audioManager;

	void Start()
	{
		_audioManager = gameObject.GetComponent<AudioSource>();

		if (_audioManager == null)
			print("AudioSource is null");
	}
	public void PressButton()
	{
		_audioManager.clip = _audioClipArray[11];
		_audioManager.Play();
	}
	public void DealButton()
	{
		_audioManager.clip = _audioClipArray[12];
		_audioManager.Play();
	}
	public void BigWin()
	{
		_audioManager.clip = _audioClipArray[Random.Range(0, 5)];
		_audioManager.PlayOneShot(_audioManager.clip);
	}
	public void SmallWin()
	{
		_audioManager.clip = _audioClipArray[Random.Range(5, 11)];
		_audioManager.PlayOneShot(_audioManager.clip);
	}


    // Start is called before the first frame update
    
}
