using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;

    public static GameManager instance
    {
        get { return _instance; }
    }

    private GameManager()
    {
        _instance = this;
    }

    [SerializeField] private GameObject bananaUI;
    public GameObject BananaUI { get { return bananaUI; } }

    [SerializeField] private GameObject player;
    public GameObject Player { get { return player; } }

    [SerializeField] private GameObject instantiateManager;
    public GameObject InstantiateManager { get { return instantiateManager; } }

    // Start is called before the first frame update
    void Start()
    {
        //hi
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleBananaUI() => bananaUI.SetActive(!bananaUI.activeSelf);
}
