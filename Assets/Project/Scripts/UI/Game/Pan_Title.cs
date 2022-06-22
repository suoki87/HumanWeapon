using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class Pan_Title : UIObject
    {
        public void OnBtnStart()
        {
            SceneManager.LoadScene( "Game" );
        }
    }
}