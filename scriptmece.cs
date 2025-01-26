using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptmece : MonoBehaviour
{
    private Animator animator;
    private float lastClickTime = 0f;
    private float doubleClickThreshold = 0.3f; // Time in seconds
    private bool isFirstClick = true;

    public AudioSource aus;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float timeSinceLastClick = Time.time - lastClickTime;

            if (isFirstClick)
            {
                // Start the first animation on the first click
                StartFirstAnimation();
                isFirstClick = false;
                aus.time = 1f;
                aus.Play();
            }
            else if (timeSinceLastClick <= doubleClickThreshold)
            {
                // Double-click detected; interrupt and start the second animation
                float normalizedTime = Mathf.Clamp01(timeSinceLastClick / doubleClickThreshold);
                StartSecondAnimation(normalizedTime);

                // Reset for next potential double-click
                isFirstClick = true;
            }
            else
            {
                // Reset for slow clicks
                isFirstClick = true;
            }

            lastClickTime = Time.time;
        }
    }

    private void StartFirstAnimation()
    {
        Debug.Log("Starting first animation!");
        animator.Play("bouchmecem", 0, 0); // Start from the beginning
        animator.speed = 1;
    }

    private void StartSecondAnimation(float startTime)
    {
        Debug.Log("Interrupting with second animation!");
        animator.Play("vetsibouchnutimecem", 0, startTime); // Start from elapsed time
        animator.speed = 1;
    }
}
