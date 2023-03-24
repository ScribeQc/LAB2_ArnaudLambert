using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLvl1 : MonoBehaviour
{
    private GameRule _gameRule;
    private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _gameRule = FindObjectOfType<GameRule>();
        _player = FindObjectOfType<Player>();
    }

    private void OnCollisionEnter(Collision collision){
        int noScene = SceneManager.GetActiveScene().buildIndex; 
        if (noScene == 1)
        {
            int hits = _gameRule.GetHit();
            Debug.Log("** Fin du niveau 1 **");
            Debug.Log("Le temps est de: " + _gameRule.GetTime() + " secondes");
            Debug.Log("Nombre de collisions: " + hits);
            Debug.Log("Nombre de points: " + _gameRule.GetPoints());
            SceneManager.LoadScene(2);
        }
        if (noScene == 2)
        {
            Debug.Log("** Fin du niveau 2 **");
            Debug.Log("Le temps est de: " + _gameRule.GetTime() + " secondes");
            Debug.Log("Nombre de collisions: " + _gameRule.GetHit());
            Debug.Log("Nombre de points: " + _gameRule.GetPoints());
            SceneManager.LoadScene(3);
        }
        if (noScene == 3)
        {
            Debug.Log("** Fin du niveau 3 **");
            Debug.Log("Le temps est de: " + _gameRule.GetTime() + " secondes");
            Debug.Log("Nombre de collisions: " + _gameRule.GetHit());
            Debug.Log("Nombre de points: " + _gameRule.GetPoints());
            Application.Quit();
        }
    }
}
