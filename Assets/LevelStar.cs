using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStar : MonoBehaviour
{
    public FloatVariable ScoreVariable;
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
            pickupSound.PlayOneShot(pickupSound.clip);
            ScoreVariable.ApplyChange(1);
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
