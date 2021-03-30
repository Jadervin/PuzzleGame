using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : EntityScript
{
    
    [Header("Booleans")]
    bool isInvincibile = false;

    
    [Header("Values")]
     public float force = 3;
    public Vector3 lastPosition;
    public float waitTime=3;
    public float invincibilityTime = 3;
    public int keyAmount;


    [Header ("Sound Sources")]
    public AudioSource keySoundSource;
    public AudioSource doorSoundSource;
    public AudioSource itemSoundSource;
    //public AudioSource hitSoundSource;

    [Header("Sound Clip")]
    public AudioClip keyCollectSound;
    public AudioClip doorExplosion;
    public AudioClip itemCollectSound;
    //public AudioClip hitSound;

    [Header("Object References")]
    public GameObject door;
    public SkinnedMeshRenderer mesh;

    [Header("Scene Names")]
    public string youWin;
    public string youLose;

    [Header("Script References")]
    public HitBoxScript hit;
    public KeyCollect collect;

    [Header("Particles")]
    public ParticleSystem playerExplosion;
    public ParticleSystem doorExplode;


    new private void Start()
    {
        base.Start();
        
        

    }

    private void Update()
    {
        if (collect.currentkeyAmount>=3)
        {
            //StartCoroutine(Wait(waitTime));
            Instantiate(doorExplode, door.transform.position, Quaternion.identity);
            doorSoundSource.PlayOneShot(doorExplosion);
            door.SetActive(false);
            collect.currentkeyAmount = 0;
        }
    }

    private void LateUpdate()
    {
        lastPosition = transform.position;
    }


   

    private void OnCollisionEnter(Collision collision)
    {


    }

    private void OnTriggerEnter(Collider other)
    {


        //doorSoundSource.PlayOneShot(hitSound);
        HitBoxScript hit;

            if (!isInvincibile && other.TryGetComponent<HitBoxScript>(out hit))
            {

                Damage((uint)hit.damage);
                hitSoundSource.PlayOneShot(hitSound);

                if (HP <= 0)
                {
                mesh.GetComponent<SkinnedMeshRenderer>().enabled = false;
                Instantiate(playerExplosion, this.transform.position, Quaternion.identity);
                StartCoroutine(Wait(waitTime));

            }
                else
                {

                    StartCoroutine(playerInvincibility());
                }
            }

        

        if (other.CompareTag("Key"))
        {
            keySoundSource.PlayOneShot(keyCollectSound);
            GetKey();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Win"))
        {
            itemSoundSource.PlayOneShot(itemCollectSound);
            Destroy(other.gameObject);
            StartCoroutine(Wait(waitTime));
            SceneManager.LoadScene(youWin);
        }
        if (other.CompareTag("Lose"))
        {
            
            mesh.GetComponent<SkinnedMeshRenderer>().enabled=false;
            Instantiate(playerExplosion, this.transform.position, Quaternion.identity);
            StartCoroutine(Wait(waitTime));
            
        }
    }

    IEnumerator playerInvincibility()
    {
        isInvincibile = true;
        yield return new WaitForSeconds(invincibilityTime);
        isInvincibile = false;
    }

    void GetKey()
    {
        collect.currentkeyAmount =
            collect.currentkeyAmount + collect.getKeyAmount;
    }

    IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration);   //Wait
        SceneManager.LoadScene(youLose);
    }

    
}
