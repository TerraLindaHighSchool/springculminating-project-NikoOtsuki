using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Player.transform.position;   
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(0, Player.transform.position.y, Player.transform.position.z);
    }
}
