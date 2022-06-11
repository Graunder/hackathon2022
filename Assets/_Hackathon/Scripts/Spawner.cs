using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField]
    Color[] colors;

    // Update is called once per frame
    public void StartGame()
    {
        if(startGame){
            StartCoroutine(SpawningEnemies());
            startGame = false;
        }
    }
    
    IEnumerator SpawningEnemies(){
        while(true){
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
    }
}
