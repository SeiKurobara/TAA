using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameManager : MonoBehaviour
{

    public int currentGold;
    public TextMeshProUGUI goldText;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
      

     

    }
    
    public void AddGold(int goldToAdd)
    {
       currentGold = PlayerPrefs.GetInt("Gold");
        currentGold += goldToAdd;
        PlayerPrefs.SetInt("Gold", currentGold);
    }



}
