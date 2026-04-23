using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
    [SerializeField] int hitPoints = 3;
    [SerializeField] int scoreValue = 10;

    Scoreboard scoreboard;
    private void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
        // scoreboard = FindObjectOfType<Scoreboard>(); dersek 8. satırdaki 'Scoreboard' 'Scoreboard[]' olmalı.
    }
    // Bu, tüm projemizi gözden geçirecek ve çetele türüne göre ilk nesneyi bulacak ve ardından referans çetelemizi buna ayarlayacaktır.
    
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoints--;
        // hitPoints = hitPoints - 1;

        if (hitPoints <= 0)
        {
        scoreboard.IncreaseScore(scoreValue);
        Instantiate(destroyedVFX, transform.position, Quaternion.identity);
        //Instantiate(destroyedVFX, transform.position, destroyedVFX.transform.rotation);
        Destroy(this.gameObject);
        }
    }
}
