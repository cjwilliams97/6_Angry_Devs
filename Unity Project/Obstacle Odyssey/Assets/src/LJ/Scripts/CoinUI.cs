using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CoinUI : MonoBehaviour
{
    public Text coinAmt;

    public void Start()
    {
       // get the wallet amount
        coinAmt.text = "Coins: " + readFromWallet().ToString();
    }
    public void Update()
    {
        // update the wallet amount
        coinAmt.text = "Coins: " + readFromWallet().ToString();
    }

    // read in the wallet amount
    public int readFromWallet()
    {
        int amount;
        string line;
        string path = Path.Combine(Application.persistentDataPath, "Wallet.txt");

        // read the current amount
        StreamReader file = new StreamReader(path);
        line = file.ReadLine();

        // make sure the amount isn't empty
        if (line != null)
            int.TryParse(line, out amount);
        else
            amount = 0;

        // close the file
        file.Close();

        return amount;
    }
}
