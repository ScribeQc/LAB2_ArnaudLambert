using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private GameObject _door;

    // Start is called before the first frame update
    void Start()
    {
        _door.transform.position = new Vector3(-1f, 2, 3.05f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _door.transform.position = new Vector3(1f, 2, 3.05f);
            Debug.Log("Porte ouverte !");
        }
    }
}
