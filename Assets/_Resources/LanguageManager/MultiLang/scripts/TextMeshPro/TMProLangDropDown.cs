using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Homework.View.LoadingScreen;


public class TMProLangDropDown : MonoBehaviour
{
    [SerializeField] string[] myLangs;
    TMP_Dropdown drp;
    int index;
    Scene _scene;
    [SerializeField] private LoadingScreen Loading;

    void Awake()
    {
        if (!Loading) Loading = FindObjectOfType<LoadingScreen>();
        _scene = SceneManager.GetActiveScene();

        drp = this.GetComponent<TMP_Dropdown>();
        int v = PlayerPrefs.GetInt("_language_index", 0);
        drp.value = v;

        drp.onValueChanged.AddListener(delegate
        {
            index = drp.value;
            PlayerPrefs.SetInt("_language_index", index);
            PlayerPrefs.SetString("_language", myLangs[index]);

            //apply changes
            // StartCoroutine(ApplyLanguageChanges());

            Loading.CallLoadingScreen("wait a minute");
            SceneManager.LoadScene(_scene.name);
        });
    }

    IEnumerator ApplyLanguageChanges()
    {
        Debug.Log("Try to change language to " + myLangs[index]);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(_scene.name);
    }

    void OnDestroy()
    {
        drp.onValueChanged.RemoveAllListeners();
    }
}
