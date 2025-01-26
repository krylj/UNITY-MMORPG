using System.Collections;
using System.Collections.Generic;
using Mirror.Examples.Billiards;
using UnityEngine;

public class scriptcuse : MonoBehaviour
{   
    public AudioSource aso;
    public AudioSource ast;
    public float forceAmount = 50f;
    public Animator animam;
    private bool isPlayingPartialAnimation = false;
    public float animationFrameRate = 60f;
    int byla = 0;
    public Rigidbody sip;
    // Start is called before the first frame update
    void Start()
    {
        animam = GetComponent<Animator>();
        sip.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)){
            animam.Play("sipnabit", 0, 0);
            isPlayingPartialAnimation = true;
            aso.Play();
        }
        if (isPlayingPartialAnimation)
        {
            // Calculate the maximum time for the first 60 frames
            float maxTime = 60f / animationFrameRate;

            // Get the current playback time
            AnimatorStateInfo stateInfo = animam.GetCurrentAnimatorStateInfo(0);
            float currentTime = stateInfo.normalizedTime * stateInfo.length;

            if (currentTime >= maxTime)
            {
                // Stop the animation after 60 frames
                animam.speed = 0;
                isPlayingPartialAnimation = false;
                byla = 1;
            }
        }
        if(byla == 1&&Input.GetKeyDown(KeyCode.K)){
            animam.Play("sipnabit", 0, 1f);
            StartCoroutine(PrintMessageAfterDelay());
        }

    }
    private System.Collections.IEnumerator PrintMessageAfterDelay()
    {
        // Wait for 7/60 seconds (approximately 0.1167 seconds)
        yield return new WaitForSeconds(7f / 60f);

        // Print the message to the console
        Vector3 forceDirection = Vector3.left;
        sip.isKinematic = false;
        sip.AddForce(forceDirection * forceAmount, ForceMode.Impulse);
        ast.Play();
    }
}
