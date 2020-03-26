using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    [SerializeField]
    private Image foregroundImage;
    [SerializeField]
    private float updateSpeedSounds = 0.5f;
 
    private void Awake()
    {
        GetComponentInParent<EnemyHealth>().OnHealthPctChanged += HandleHealthChanged;
    }

    private void HandleHealthChanged(float pct)
    {
        StartCoroutine(ChangeToPct(pct));
    }
    private IEnumerator ChangeToPct(float pct)
    {
        float preChangePct = foregroundImage.fillAmount;
        float elapsed = 0f;
        while (elapsed < updateSpeedSounds)
        {
            elapsed += Time.deltaTime;
            foregroundImage.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeedSounds);
            yield return null;

        }
        foregroundImage.fillAmount = pct;
    }
    private void LateUpdate()
    {

        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }



}
