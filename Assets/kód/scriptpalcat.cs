using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scriptpalcat : MonoBehaviour
{
    public Animator ani;
    public AudioSource ass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            ani.Play("palcatani");
            ass.Play();
        }
    }
}
