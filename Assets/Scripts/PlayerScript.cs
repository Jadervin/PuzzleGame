using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : EntityScript
{
    //public GameObject particle;
    public float force = 3;

    //public string hurtingTag= "Enemy";
    public float invincibilityTime = 3;
    bool isInvincibile = false;
    public int keyAmount;
    public Vector3 lastPosition;

    public AudioSource keySoundSource;
    public AudioSource doorSoundSource;
    public AudioSource itemSoundSource;

    public AudioClip keyCollectSound;
    public AudioClip doorExplosion;
    public AudioClip itemCollectSound;

    public KeyCollect collect;

    public ParticleSystem doorExplode;
    public GameObject door;
    public string youWin;

    public float waitTime=2;

    public HitBoxScript hit;
    public string youLose;

    new private void Start()
    {
        base.Start();
        
        

    }

    private void Update()
    {
        if (collect.currentkeyAmount>=3)
        {
            StartCoroutine(Wait(waitTime));
            Instantiate(doorExplode, door.transform.position, Quaternion.identity);
            doorSoundSource.PlayOneShot(doorExplosion);
            Destroy(door);
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

        HitBoxScript hit;

        if (other.CompareTag("Rat"))
        {
            if (!isInvincibile && other.TryGetComponent<HitBoxScript>(out hit))
            {
                Damage((uint)hit.damage);

                if (HP <= 0)
                {
                    //Instantiate(particle, this.transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                    SceneManager.LoadScene(youLose);

                }
                else
                {

                    StartCoroutine(playerInvincibility());
                }
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

    }

    
}
