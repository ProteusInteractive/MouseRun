using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseKiller : MonoBehaviour
{
    public float killerSpeed;
    public float playerXHeadstart;

    float targetXDir;
    float targetZDir;
    GameObject player;
    //SceneController scene;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}

    void Update ()
    {
        FollowPlayer();

        Vector3 down = transform.TransformDirection(Vector3.down);

        //if (Physics.Raycast(transform.position, down, 50))
        //{
        //    scene.TogglePausePanelOn();
        //}

    }

    private void FollowPlayer()
    {
        targetXDir = (player.transform.position.x - this.transform.position.x) * Time.deltaTime * killerSpeed;
        targetZDir = (player.transform.position.z - this.transform.position.z) * Time.deltaTime * killerSpeed;

        transform.position += new Vector3(targetXDir, 0f, targetZDir);
    }
}
