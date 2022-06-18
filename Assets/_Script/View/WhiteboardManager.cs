using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Homework.View.CanvasManager
{
    public class WhiteboardManager : MonoBehaviour
    {
        public static WhiteboardManager instance;

        [Header("whiteboard monobehaviour")]
        public GameObject BtnSetActive;
        public GameObject Whiteboard;

        private void Start() => instance = this;

    }
}

