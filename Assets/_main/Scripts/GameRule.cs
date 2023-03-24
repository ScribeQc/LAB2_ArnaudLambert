using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRule : MonoBehaviour
{
    private int _hitLvl1 = 0;
    private float _timeLvl1 = 0f;
    private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        StartRules();
        _player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        _player.StartTimer(_timeLvl1);
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }

    // Vérifie si un gameObject est déjà présent dans la scène ou non
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameRule>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Affiche les règles du niveau 1
    private static void StartRules()
    {
        Debug.Log("*** Course à obstacles ***");
        Debug.Log("** Niveau 1 **");
        Debug.Log("Les obstacles enlèvent 1 point");
        Debug.Log("Les checkpoints ajoutent 1 point");
    }

    // Ajoute un point au compteur de points
    public void AddHit()
    {
        _hitLvl1++;
    }

    // Renvoie le nombre d'accrochage du niveau 1
    public int GetHit()
    {
        return _hitLvl1;
    }

    // Renvoi le temps du niveau 1
    public float GetTime()
    {
        return _timeLvl1;
    }

    public float GetPoints()
    {
        return _timeLvl1 + _hitLvl1;
    }
}
