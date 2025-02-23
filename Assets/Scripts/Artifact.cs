using UnityEngine;

public class Artifact : MonoBehaviour
{
    public int minScore, maxScore;
    private GameManager gameManager;
    public ParticleSystem collectEffect;
    public AudioSource coinSound;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void Update()
    {
        transform.Rotate(180f * Time.deltaTime, 0f, 0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coinSound.Play();
            gameManager.AddScore(Random.Range(minScore, maxScore));
            collectEffect.Play();
            Destroy(this.gameObject, 0.5f);
            
        }
        
    }

}
