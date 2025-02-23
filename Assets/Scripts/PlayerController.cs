using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    public float speed = 5f;
    CurrentDirection cr;
    public bool isPlayerDead;
    private GameManager gameManager;
    public ParticleSystem deadEffect;
    public AudioSource deadSound;
    



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cr = CurrentDirection.right;
        isPlayerDead = false;
        gameManager = FindFirstObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayerDead)
        {
            RaycastDetector();

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)//Input.GetKeyDown("space") For the PC
            {
                ChangeDirection();
                PlayerStop();
            }

        }
        else
        {
            return;
        }

        
    }
    

    private void RaycastDetector()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position,Vector3.down, out hit))
        {
            MovePlayer();
        }
        else
        {
            deadSound.Play();
            PlayerStop();
            isPlayerDead = true;
            this.gameObject.SetActive(false);
            gameManager.LevelEnd();
            Instantiate(deadEffect, this.transform.position, Quaternion.identity);
            
        }
    }


    private enum CurrentDirection
    {
        right,
        left
    }

    private void ChangeDirection()
    {

        MovePlayer();
        if(cr == CurrentDirection.right)
        {
            cr = CurrentDirection.left;
        }
        else if (cr == CurrentDirection.left)
        {
            cr = CurrentDirection.right;
        }
    }

    private void MovePlayer()
    {
        if(cr == CurrentDirection.right)
        {
            rb.AddForce((Vector3.left).normalized * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
        else if (cr == CurrentDirection.left)
        {
            rb.AddForce((Vector3.forward).normalized * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
    }

    private void PlayerStop()
    {
        rb.linearVelocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndTrigger"))
        {
            UnlockNewLevel();
            gameManager.WinLevel();
            PlayerStop();
            this.gameObject.SetActive(false);
        }
    }
    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("EndTrigger"))
        {
            PlayerPrefs.SetInt("EndTrigger", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}


