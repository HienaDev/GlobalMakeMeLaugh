using UnityEngine;

public class ThrowPie : MonoBehaviour {

    [SerializeField] private GameObject pie;
    [SerializeField] private GameObject firePoint;

    [SerializeField] private float strength;

    [SerializeField] private PlayerSounds playerSounds;

    // Start is called before the first frame update
    void Start()
    {
        playerSounds = GetComponent<PlayerSounds>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (GameManager.instance.PieUI.activeSelf)
            {
                PieThrow();

                playerSounds.PlayThrowSoundSound();

                GameManager.instance.TogglePieUI();
            }
        }
    }

    private void PieThrow()
    {
        GameObject pieClone = Instantiate(pie, firePoint.transform.position, transform.rotation, GameManager.instance.InstantiateManager.transform);

        Vector3 v3Force = strength * transform.forward;
        v3Force.y += 150f;
        pieClone.GetComponent<Rigidbody>().AddForce(v3Force);
    }
}