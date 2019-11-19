using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Photon;
using Photon.Pun;


public class PlayerController : MonoBehaviourPunCallbacks
{
    public GameObject target;
    private Vector3 offset;

    private void Start()
    {
        offset = target.transform.position - transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            float y = Input.GetAxis("Horizontal") * Time.deltaTime * 150f;
            float z = Input.GetAxis("Vertical") * Time.deltaTime * 3f;

            target.transform.position = transform.position + offset;
            transform.Rotate(0, y, 0);
            transform.Translate(0, 0, z);
        }


    }





}
