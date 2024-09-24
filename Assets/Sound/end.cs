using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public float stopXPosition = 32f;   
    public AudioClip successSound;      
    private AudioSource audioSource;    
    private Rigidbody rb;               
    private bool hasStopped = false;    

    void Start()
    {
        rb = GetComponent<Rigidbody>();        
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!hasStopped && transform.position.x >= stopXPosition)
        {
            PlaySuccessSound();  
        }
    }

    void PlaySuccessSound()
    {
        if (successSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(successSound);  
        }
    }
}
