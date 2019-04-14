using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    AudioHandler audioHandler;
    CoinWallet script;

    public int coinValue;
    
    void Start()
    {
        // bind audio
        audioHandler = AudioHandler.instance;
        // target the global wallet
        script = GameObject.FindWithTag("GameController").GetComponent<CoinWallet>();
    }

    // add to wallet on collision
    void OnTriggerEnter(Collider other)
    {
        script.amount += coinValue;
        audioHandler.PlayAudio("coin pickup");
        Destroy(gameObject);
    }
}
