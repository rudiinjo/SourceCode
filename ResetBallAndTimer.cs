﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResetBallAndTimer : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ShootBall.getShootBall.GoBall();
        SceneManager.LoadScene("PongGameOver");
        
    }
}
