﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LivesManager : MonoBehaviour
{    
    public int lives;
    public GameObject[] hearts;
    
    public void RemoveLife()
    {
        lives -= 1;
        hearts[lives].SetActive(false);
        
    }
}
