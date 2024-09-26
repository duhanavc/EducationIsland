using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Matching : MonoBehaviour
{

    public Button audioSoruceButton;
    
    public Button button_wrong1;
    public Button button_wrong2;
    public Button button_correct;

    private AudioSource audioSource;
    public AudioClip lionSound;
    public AudioClip wrongAnswer;
    public AudioClip correctAnswer;

    private void Start()
    {
        audioSource = GameObject.FindWithTag("AudioButton").GetComponent<AudioSource>();
    }

    public void AudioButtonClicked()
    {
        audioSource.clip = lionSound;
        audioSource.Play();
    }

    public void CorrectAnswer()
    { 
        audioSource.clip = correctAnswer;
        audioSource.Play();
    }
    public void WrongAnswer()
    {
        audioSource.clip = wrongAnswer;
        audioSource.Play();
    }

}
