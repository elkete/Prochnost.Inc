using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float playerVelocity = 0.1f;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D playerRigidBody;
    //Sonidos
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;

    private void OnEnable()
    {
        this.animator = GetComponent<Animator>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.playerRigidBody = GetComponent<Rigidbody2D>();
        this.audioSource = GetComponent<AudioSource>();

    }

    /*void Start()
    {
        
    }*/

    private void Update()
    {
        this.PlayerAnimations();
    }

    void FixedUpdate()
    {
        this.PlayerMovements();
    }

    void PlayerMovements()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(playerVelocity,0,0);
            spriteRenderer.flipX = false;
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-playerVelocity,0,0);
            spriteRenderer.flipX = true;
        }
    }

    
    void PlayerAnimations() // Si colocamos audioSource.Play(); aqui, el sonido se reproducirá y repetirá en ciclo muchas veces y no podrá escucharse bien
    {
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            this.SetAudio(0,true,0.7f);
            animator.SetBool("isWalk",true);
        }
        if(!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            this.SetAudio(0,false,0);
            animator.SetBool("isWalk",false);
        }
    }

    /*private void PonerMusica()
    {
        audioSource.clip = audioclips[0]; // En el vector, el 0 es el sonido de caminata.
        audioSource.volume = 1;
        audioSource.Play();
    }

    private void DetenerMusica()
    {
        audioSource.Stop();
    }*/

    void SetAudio(int index, bool status, float volume)
    {
        this.audioSource.clip = this.audioClips[index];
        if(status)
        {
            this.audioSource.Play();
            this.audioSource.volume = volume;
            return;
        }
        this.audioSource.Stop();
    }

}