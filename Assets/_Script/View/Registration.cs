using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Registration : MonoBehaviour
{
    string playerName;

    public GameObject textDisplay;
    public GameObject inputField;
    public Button btn;

    public void CollectName(){
        playerName = inputField.GetComponent<TextMeshProUGUI>().text;
        textDisplay.GetComponent<TextMeshProUGUI>().text = "Hello " +playerName+ " Welcome to the game"; 

        // btn.GetComponent<
    }

}
