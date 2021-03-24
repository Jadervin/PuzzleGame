using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public bool isPushed;
    public PlayerScript player;

    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player" && TryGetComponent<PlayerScript>(out player))
        {
            if((collision.collider.transform.position-player.lastPosition).normalized==
                this.transform.position-collision.collider.transform.position)
            {
                
                this.transform.SetParent(player.transform);
            }

        }
        
    }
}
