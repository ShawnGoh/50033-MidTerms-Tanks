using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHeart : MonoBehaviour
{
    public FloatVariable PlayerHealth;
    public AudioSource pickupSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RealPlayer")
        {
            pickupSound.time = 0.3f;
            pickupSound.PlayOneShot(pickupSound.clip);
            PlayerHealth.ApplyChange(50f);
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}

