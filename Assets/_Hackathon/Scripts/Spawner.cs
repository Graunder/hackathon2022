using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRate;
    [SerializeField]
    private float enemySpeed = 10f;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private int range;
    [SerializeField]
    private Transform target;

    private bool startGame = true;
    public bool playing = true;

    [SerializeField]
    Color[] colors;
    public int totalScore;
    public int totalLives;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI livesText;
    [SerializeField]
    private GameObject gameOverScreen;

    // Update is called once per frame
    public void StartGame()
    {
        if(startGame){
            gameOverScreen.SetActive(false);
            ResetScore();
            ResetLives();
            playing = true;
            StartCoroutine(SpawningEnemies());
            startGame = false;
        }
    }

    private void FixedUpdate() {
        if(totalLives == 0){
            StopGame();
            gameOverScreen.SetActive(true);
        }
    }

    public void StopGame(){
        playing = false;
        startGame = true;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach(GameObject enemy in enemies){
            Destroy(enemy);
        }
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        foreach(GameObject projectile in projectiles){
            Destroy(projectile);
        }
    }

    public void ResetScore(){
        totalScore = 0;
        scoreText.SetText(totalScore.ToString());
    }

    public void ResetLives(){
        totalLives = 10;
        livesText.SetText(totalLives.ToString());
    }
    
    public void UpdateScore(){
        totalScore += 10;
        scoreText.SetText(totalScore.ToString());
    }

    public void UpdateLives(){
        totalLives--;
        livesText.SetText(totalLives.ToString());
    }
    
    IEnumerator SpawningEnemies(){
        while(playing){
            GameObject newEnemy = Instantiate(
                enemy, 
                new Vector3(Random.Range(-range, range), transform.position.y, transform.position.z), 
                Quaternion.identity
            );
            newEnemy.GetComponent<Rigidbody>().AddForce(transform.forward * enemySpeed);
            newEnemy.GetComponent<Enemy>().mix = Random.value < 0.5f;
            if(newEnemy.GetComponent<Enemy>().mix){
                newEnemy.GetComponent<Enemy>().targetColor = colors[Random.Range(1, colors.Length)];
                newEnemy.GetComponent<Enemy>().targetColor2 = colors[Random.Range(1, colors.Length)];
            }else{
                newEnemy.GetComponent<Enemy>().targetColor = colors[Random.Range(0, colors.Length)];
            }
            

            yield return new WaitForSeconds(spawnRate);
        }
        yield return new WaitForSeconds(spawnRate);
    }
}
