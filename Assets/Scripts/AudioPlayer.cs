using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
   [Header("Shooting")]
   [SerializeField] AudioClip shootingSFX;
   [SerializeField] [Range(0f, 1f)] float shootVolume = 1f;

    [Header("Hip")]
   [SerializeField] AudioClip hitSFX;
   [SerializeField] [Range(0f, 1f)] float hitVolume = 1f;

   static AudioPlayer instance;

   void Awake()
   {
        ManageSingleton();
   }

   void ManageSingleton()
   {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
   }

   public void PlayShootingSFX()
   {
        PlaySFX(shootingSFX, shootVolume);
   }

   public void PlayHitSFX()
   {
        PlaySFX(hitSFX, hitVolume);
   }

    void PlaySFX(AudioClip sfx, float volume)
    {
        if(sfx != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(sfx, cameraPos, volume);
        }
    }


}
