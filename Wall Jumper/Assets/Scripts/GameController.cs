using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text restartText;
    public Text gameOverText;
    private bool restart;
    private bool gameOver;

    void Start()
    {
        restart = false;
        gameOver = false;
        restartText.text = "";
        gameOverText.text = "";
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (restart) {
            if (Input.GetKeyDown (KeyCode.Space)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
            }
        }
    }

    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(startWait);
        while (true) {
            for (int i = 0; i < hazardCount; i++)
            {
                if (gameOver)
                {
                    restartText.text = "Press spacebar to Restart";
                    restart = true;
                    break;
                }

                int chance = Random.Range(1, 6);

                Vector3 spawnPosition = new Vector3(0,0,0);
                if (chance == 1) {
                    spawnPosition = new Vector3(Random.Range(-4.5f, 4.5f), spawnValues.y, spawnValues.z);
                } else if (chance == 2 || chance == 3) {
                    spawnPosition = new Vector3(-6.5f, spawnValues.y, spawnValues.z);
                } else if (chance == 4 || chance == 5) {
                    spawnPosition = new Vector3(6.5f, spawnValues.y, spawnValues.z);
                }

                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void GameOver() {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}