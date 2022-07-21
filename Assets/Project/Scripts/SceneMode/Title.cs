using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using Tables;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace SceneMode
{
    public class Title : MonoBehaviour
    {
        public void Start()
        {
            TableMan.In.Init();
            DataMan.In.Init();
            UIMan.In.OnSceneChanged();
            SceneManager.LoadScene( "Game" );
        }
    }
}