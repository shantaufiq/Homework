using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace Homework.View.LoadingScreen
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField][Range(1.5f, 4f)] float _LoadingDuration = 3f;
        public GameObject _LoadingScreen;
        public TextMeshProUGUI _LoadingMessage;

        public void CallLoadingScreen(string loadingMessage)
        {
            _LoadingMessage.text = loadingMessage;

            StartCoroutine(StartLoadingScreen());
        }

        IEnumerator StartLoadingScreen()
        {
            _LoadingScreen.SetActive(true);
            yield return new WaitForSeconds(_LoadingDuration);
            _LoadingScreen.SetActive(false);
            // SceneManager.LoadScene(whichScene.name);
        }
    }
}
