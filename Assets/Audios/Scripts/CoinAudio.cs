using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAudio : MonoBehaviour
{
    public AudioClip coinAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            AudioSource.PlayClipAtPoint(coinAudio, transform.position);
    }
}
