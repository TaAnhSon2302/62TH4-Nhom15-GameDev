using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public bool isRun;
    public PlayerHealth player;

    private void Update()
    {
        if(player.isDead && !isRun)
        {
            isRun = true;

            StartCoroutine(DelayDead());
        }
    }




    IEnumerator DelayDead()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(0);
    }
}
