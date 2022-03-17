using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public bool isOnGround = true;
    private Rigidbody PlayerRB;
    private Animator PlayerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    private AudioSource playerAudio;
    public AudioClip crashSound;
    public AudioClip jumpSound;
    public float jumpForce =10f;
    public float gravityModifier = 2f;
    public bool isGameOver= false;
    private int jumpsCounter = 0;
    public bool nitroMode = false;


    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        PlayerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)  && jumpsCounter<2 && !isGameOver)
        {
            PlayerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpsCounter++;
            isOnGround = false;
            PlayerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
        if(Input.GetKeyDown(KeyCode.RightShift ) && !isGameOver)
        {
            PlayerAnim.SetFloat("Speed_Multiplier", 2.0f);
            nitroMode = true;
        }
        if(Input.GetKeyUp(KeyCode.RightShift) && !isGameOver)
        {
            PlayerAnim.SetFloat("Speed_Multiplier", 1.0f);
            nitroMode = false;

        }
        if(isGameOver)
        {
            dirtParticle.Stop();

        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        { 
            isOnGround = true;
            jumpsCounter = 0;
            dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Obsticle"))
        {
            Debug.Log("Game OVer");
            isGameOver = true;
            PlayerAnim.SetBool("Death_b", true);
            PlayerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }


}
