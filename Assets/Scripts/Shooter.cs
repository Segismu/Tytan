using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float bulletMidLife = 5f;
    [SerializeField] float baseFireRate = 0.3f;

    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingVariance = 0f;
    [SerializeField] float minFireRate = 0.1f;

    [HideInInspector] public bool isFiring;
    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();    
    }

    void Start()
    {
        if(useAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuosly());
        }
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuosly()
    {
        while(true)
        {
            GameObject instance = Instantiate(bulletPrefab, transform.position,
                                                Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = transform.up * bulletSpeed;
            }

            Destroy(instance, bulletMidLife);

            float timeToNextBullet = Random.Range(baseFireRate - firingVariance,
                                                  baseFireRate + firingVariance);

            timeToNextBullet = Mathf.Clamp(timeToNextBullet, minFireRate, float.MaxValue);

            audioPlayer.PlayShootingSFX();

            yield return new WaitForSeconds(timeToNextBullet);
        }
    }
}
