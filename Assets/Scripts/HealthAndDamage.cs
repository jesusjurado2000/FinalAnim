using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDamage : MonoBehaviour
{
    public int vida = 100;
    public bool invencible = false;
    public float tiempoInvencible = 1f;
    public float tiempoFrenado = 0.2f;
    private Animator anim;
    private AudioSource damage;
    private AudioSource die;


    private void Start()
    {
        anim = GetComponent<Animator>();
        AudioSource[] audioSources = GetComponents<AudioSource>();
        damage = audioSources[0];
        die = audioSources[1];
    }

    public void RestarVida(int cantidad)
    {
        if (!invencible && vida > 0)
        {
            vida -= cantidad;
            damage.Play();
            anim.Play("Damage");
            StartCoroutine(Invulnerabilidad());
            StartCoroutine(FrenarVelocidad());
            if(vida == 0)
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        die.Play();
        anim.Play("Die");
    }

    IEnumerator Invulnerabilidad()
    {
        invencible = true;
        yield return new WaitForSeconds(tiempoInvencible);
        invencible = false;
    }

    IEnumerator FrenarVelocidad()
    {
        var velocidadActual = GetComponent<ThirdPersonController>().MoveSpeed;
        GetComponent<ThirdPersonController>().MoveSpeed = 0f;
        var sprintActual = GetComponent<ThirdPersonController>().SprintSpeed;
        GetComponent<ThirdPersonController>().SprintSpeed = 0f;
        yield return new WaitForSeconds(tiempoFrenado);
        GetComponent<ThirdPersonController>().MoveSpeed = velocidadActual;
        GetComponent<ThirdPersonController>().SprintSpeed = sprintActual;
    }
}
