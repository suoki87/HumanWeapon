using System;
using System.Collections;
using System.Collections.Generic;
using Tables;
using UnityEngine;

namespace SceneMode
{
    public class Game : MonoBehaviour
    {
        public void Start()
        {
            UIMan.In.OnSceneChanged();
            StageMan.In.OnEnter();
        }
    }
}