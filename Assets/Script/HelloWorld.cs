using UnityEngine;
using UnityEngine.UI;

public class HelloWorld : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(tampil);
    }

    // Update is called once per frame
    private void tampil()
    {
        Debug.Log("saya taufiq");
    }

}
