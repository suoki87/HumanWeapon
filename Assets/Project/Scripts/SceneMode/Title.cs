using System;
using System.Collections;
using System.Collections.Generic;
using Tables;
using UnityEngine;
using UnityEngine.SceneManagement;



namespace SceneMode
{
    public class Title : MonoBehaviour
    {
        public void Start()
        {
            SceneManager.LoadScene( "Game" );
        }
    }
}