using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Homework.Interface;

namespace Homework.Mechanics.Object
{
    public abstract class TriggerController : MonoBehaviour
    {
        [SerializeField] protected float TimeToShow = 1.5f;
        protected void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Icharacter character))
                StartCoroutine(OnColliderBehaviour(character, true));
        }

        protected void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Icharacter character))
                StartCoroutine(OnColliderBehaviour(character, false));
        }

        public abstract IEnumerator OnColliderBehaviour(Icharacter character, bool status);
    }
}

