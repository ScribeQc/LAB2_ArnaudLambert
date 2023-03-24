using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCollision : MonoBehaviour
{
    private GameRule _gameRule;
    private bool _isObstacleTouched;

    private void Start() {
        _gameRule = FindObjectOfType<GameRule>();
        _isObstacleTouched = false;
    }

    private void OnCollisionEnter(Collision collision){
        if(!_isObstacleTouched){
            if(collision.gameObject.tag == "Player"){
                _isObstacleTouched = true;
                Debug.Log("Obstacle touché !");
                Disappear();
                InvokeRepeating("Appear", 4f, 0);
            }
        }
    }

    private void Disappear(){
            gameObject.SetActive(false);
    }

    private void Appear(){
        gameObject.SetActive(true);
    }
}
