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

    [SerializeField] private GameObject eggUI;
    public GameObject EggUI { get { return eggUI; } }

    [SerializeField] private GameObject flourUI;
    public GameObject FlourUI { get { return flourUI; } }

    [SerializeField] private GameObject chantyUI;
    public GameObject ChantyUI { get { return chantyUI; } }

    [SerializeField] private GameObject runningUI;
    [SerializeField] private GameObject runningUI1Handed;
    [SerializeField] private GameObject runningNoHands;
    public GameObject RunningUI { get {
            if (bananaUI.activeSelf)
                return runningUI1Handed;

            else if (pieUI.activeSelf)
                return runningNoHands;

            return runningUI; 
        } }

    
    [SerializeField] private GameObject pieUI;
    public GameObject PieUI { get {return pieUI; }}

    // Start is called before the first frame update
    void Start()
    {
        //hi
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TogglePieUI() => pieUI.SetActive(!pieUI.activeSelf);

    public void ToggleBananaUI() => bananaUI.SetActive(!bananaUI.activeSelf);

    public void ToggleEggUI() => eggUI.SetActive(!eggUI.activeSelf);

    public void ToggleChantyUI() => chantyUI.SetActive(!chantyUI.activeSelf);

    public void ToggleFlourUI() => flourUI.SetActive(!flourUI.activeSelf);
}
