using System.Collections;
using System.Collections.Generic;
using UndefinedBehaviour.Input;
using UnityEngine;
using UnityEngine.UI;

namespace UndefinedBehaviour.MultiplayerPlatformer
{
    public class AssignementHelper : MonoBehaviour
    {
        [SerializeField] private InputAssignment.Assignements _assignement;
        [SerializeField] private TestChangeKey testChangeKey;

        public void OnClick()
        {
            testChangeKey.ChangeInput(_assignement);
        }

    }
}
