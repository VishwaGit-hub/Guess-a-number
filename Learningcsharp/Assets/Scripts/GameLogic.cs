using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
    
{
    public int RandomNum;
    public int maxvalue;
    public int minvalue;
    public TMP_InputField userinput;
    public TextMeshProUGUI gamelable;
    public Button gamebutton;
    private bool isgamewon = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
       
        RestartGame();
         
    }

    // Update is called once per frame
    
    public void  OnButtonClick()
    {
        string userinputvalue = userinput.text;
        if(userinputvalue!="")
        {
            int answer = int.Parse(userinputvalue);
            if (answer == RandomNum)
            {
                gamelable.text = "Correct!";
                // gamebutton.interactable = false;
                isgamewon = true;
                RestartGame();               
                Debug.Log("correct");
               
            }
            else if (answer > RandomNum)
            {
                gamelable.text = "Try Lower";
                Debug.Log("Try lower");
            }
            else if (answer < RandomNum)
            {
                {
                    gamelable.text = "Try Higher";
                    Debug.Log("Try higher");
                }
            }
            else
            {
                gamelable.text = "Incorrect";
                Debug.Log("incorrect");
            }
           
        }
        else
        {
            gamelable.text = "Please enter a  number";
            Debug.Log("Please enter a number");
        }


        
         
    }
    private int  GetRandomNumber(int min,int max)
    {
        int random = Random.Range(min, max);
        return random;
    }
    private void RestartGame()
    {
       
        if (isgamewon)
        {
           
            gamelable.text = " You won! Guess a number between " + minvalue + "and" + (maxvalue - 1);
            isgamewon = false;

        }
    else
        {
            gamelable.text = "Guess a number between" + minvalue + "and" + (maxvalue-1);
        }
        userinput.text = "";
        RandomNum = GetRandomNumber(minvalue, maxvalue);


    }
}
