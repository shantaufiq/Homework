using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Homework.Interface;
using Homework.View.CanvasManager;

namespace Homework.Mechanics.Object
{
    public class WhiteboardTrigger : TriggerController
    {
        public override IEnumerator OnColliderBehaviour(Icharacter character, bool status)
        {
            yield return new WaitForSeconds(TimeToShow);

            if (status == true)
            {
                character.SetActiveWhiteboard = true;
                WhiteboardManager.instance.BtnSetActive.SetActive(true);

                // Debug.Log("tampilkan whiteboard: " + character.SetActiveWhiteboard);
            }
            else
            {
                character.SetActiveWhiteboard = false;
                WhiteboardManager.instance.BtnSetActive.SetActive(false);
                // Debug.Log("tampilkan whiteboard: " + character.SetActiveWhiteboard);
            }
        }
    }
}

