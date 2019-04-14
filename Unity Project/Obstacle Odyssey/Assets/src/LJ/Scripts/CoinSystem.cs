using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CoinSystem : MonoBehaviour
{
    AudioHandler audioHandler;

    public int coinValue;
    string line;
    string fileName = "Wallet.txt";
    
    void Start()
    {
        // bind audio
        audioHandler = AudioHandler.instance;

        string path = Path.Combine(Application.persistentDataPath, fileName);

        // check to see if wallet file exists
        if (!File.Exists(path))
        {
            Debug.Log("Creating wallet file\n");
            File.Create(path);
        }
    }

    // add to wallet on collision
    void OnTriggerEnter(Collider other)
    {
        // play pickup sound
        audioHandler.PlayAudio("coin pickup");

        // add amount to persistent wallet
        writeToWallet();

        // destroy the coin
        Destroy(gameObject);
    }

    // write the coin amount to the wallet
    void writeToWallet()
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);

        // read in the old amount and add new amount
        int amount = readFromWallet();
        amount += coinValue;

        // write in new amount
        StreamWriter file = new StreamWriter(path);
        file.WriteLine(amount.ToString());

        file.Close();
    }

    // read current coin amount and return it
    public int readFromWallet()
    {
        int amount = 0;
        string path = Path.Combine(Application.persistentDataPath, fileName);

        // read the current amount
        StreamReader file = new StreamReader(path);
        line = file.ReadLine();

        // make sure the amount isn't empty
        if (line != null)
            int.TryParse(line, out amount);
        else
            amount = 0;

        file.Close();
        return amount;
    }
}
