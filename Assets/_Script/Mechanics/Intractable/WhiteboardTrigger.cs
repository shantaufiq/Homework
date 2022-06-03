using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Homework.Interface;

namespace Homework.Mechanics.Object
{
    public class WhiteboardTrigger : TriggerController
    {
        public override IEnumerator OnCollideBehaviour(Icharacter character)
        {
            character.SetActiveWhiteboard = true;
            Debug.Log("tampilkan whiteboard: " + character.SetActiveWhiteboard);

            yield return new WaitForSeconds(TimeToShow);

            character.SetActiveWhiteboard = false;
            Debug.Log("tampilkan whiteboard: " + character.SetActiveWhiteboard);
        }
    }
}

