using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{

      public Animator animator;
      public List<string> animations = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
         animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.Play(animations[0]);
        
    }
}
