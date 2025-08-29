using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 3.0f;
    public ParticleSystem SmokeEffect;
    private Animator Anim;
    public AudioClip hitclip;
    private AudioSource audioSource;
    private void Start()
    {
        Anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
       
        if (GameManager.Instance.isGameOver)
        {
            Anim.SetTrigger("die");
            //transform.position = Vector3.zero;
            return; 
        }

        HandleMovement();
    }

    private void HandleMovement()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        if (vertical > 0)
        {
            Anim.SetBool("walk", true);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            transform.Translate(Vector3.forward * Speed * Time.deltaTime, Space.Self);
        }
        else if (horizontal != 0)
        {
            Anim.SetBool("walk", true);
            transform.rotation = Quaternion.Euler(0f, horizontal > 0 ? 90f : -90f, 0f);
            transform.Translate(Vector3.forward * Speed * Time.deltaTime, Space.Self);
        }
        else
        {
            Anim.SetBool("walk", false);
            //Vector3.rotation(Quaternion.Euler(0f, 0f, 0f));   
        }

        float clampedX = Mathf.Clamp(transform.position.x, -9f, 16f);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Gem"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.Score();
        }
        else if (collision.gameObject.CompareTag("car"))
        {
           audioSource.PlayOneShot(hitclip);
            SmokeEffect.transform.position = collision.contacts[0].point;
            
            SmokeEffect.Play();          
                     
            GameManager.Instance.GameOver();
        }
        
    }
}
