using UnityEngine;

public class Flag : MonoBehaviour
{
    public int team;

    private Vector3 initPosition;

    public bool held = false;
    public GameObject holdingPlayer;

    private void Start()
    {
        initPosition = transform.position;
    }

    void Update()
    {
        if (held)
        {
            if (holdingPlayer.GetComponent<Player>().dead)
            {
                // reset if played died
                transform.parent = null;
                transform.position = initPosition;
                held = false;

                holdingPlayer.GetComponent<Player>().hasFlag = false;
            }
            else
            {
                // fix position
                transform.localPosition = Vector3.zero;
                transform.rotation = Quaternion.identity;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.GetComponent<Player>().team != team && !held)
            {
                // attach flag to player
                transform.parent = collision.transform;
                holdingPlayer = collision.gameObject;
                held = true;

                holdingPlayer.GetComponent<Player>().hasFlag = true;
            }
        }
    }
}
