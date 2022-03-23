using UnityEngine;
using UnityEngine.UI;

public class Registration : MonoBehaviour
{
    string playerName;

    [SerializeField] public GameObject textDisplay;
    [SerializeField] public GameObject inputField;

    public void CollectName(){
        playerName = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = "Hello " +playerName+ " Welcome to game"; 

        print (playerName);
    }

}
