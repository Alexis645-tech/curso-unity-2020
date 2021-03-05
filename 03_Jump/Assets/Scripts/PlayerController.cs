using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRB;
    public float jumpForce;
    public float gravityMultiplier;
    public bool IsOnGround = true;
    
    private bool _gameOver;
    public bool GameOver => _gameOver;

    const string speedMultiplier = "Speed_Multiplier";
    private Animator _animator;
    private float speedMultiplayer = 1;

    public ParticleSystem explosion;
    public ParticleSystem walk;

    public AudioClip jumpSound, crashSound;
    private AudioSource _audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMultiplier;
        _animator = GetComponent<Animator>();
        _animator.SetFloat("Speed_f", 1);
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        speedMultiplayer += Time.deltaTime/50;
        _animator.SetFloat(speedMultiplier, speedMultiplayer);
        
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround && !GameOver)
        {
            playerRB.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
            IsOnGround = false;
            _animator.SetTrigger("Jump_trig");
            walk.Stop();
            _audioSource.PlayOneShot(jumpSound, 1);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Run"))
        {
            if (!GameOver)
            {
                IsOnGround = true;
                walk.Play();
            }
        } else if (other.gameObject.CompareTag("obstacle"))
        {
            _gameOver = true;
            explosion.Play();
            _animator.SetBool("Death_b", true);
            _animator.SetInteger("DeathType_int", Random.Range(1,3));
            walk.Stop();
            _audioSource.PlayOneShot(crashSound, 1);
            Invoke("RestartGame", 2f);
        }
    }

    void RestartGame()
    {
        speedMultiplayer = 1;
        SceneManager.UnloadSceneAsync("Prototype 3");
        SceneManager.LoadScene("Prototype 3", LoadSceneMode.Single);
    }
}
