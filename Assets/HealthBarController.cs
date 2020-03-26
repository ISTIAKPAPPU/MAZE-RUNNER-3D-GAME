using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
   /* [SerializeField]
    private EnemyHealthbar healthBarPrefab;
    private Dictionary<EnemyHealth, EnemyHealthbar> healthBars = new Dictionary<EnemyHealth, EnemyHealthbar>();

    private void Awake()
    {
        EnemyHealth.OnHealthAdded += AddHealthBar;
        EnemyHealth.OnHealthRemoved += RemoveHealthBar;
    }
    private void AddHealthBar(EnemyHealth health)
    {
        if (healthBars.ContainsKey(health) == false)
        {
            var healthBar = Instantiate(healthBarPrefab, transform);
            healthBars.Add(health, healthBar);
            healthBar.SetHealth(health);
        }
    }
    private void RemoveHealthBar(EnemyHealth health)
    {
        if (healthBars.ContainsKey(health))
        {
            Destroy(healthBars[health].gameObject);
            healthBars.Remove(health);

        }
    }
    */
}
