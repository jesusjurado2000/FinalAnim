using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionPersonaje : MonoBehaviour
{
    public Avatar[] avatars;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ChangeAvatarByIndex(int index)
    {
        if (index >= 0 && index < avatars.Length)
        {
            animator.avatar = avatars[index];
        }
    }
}
