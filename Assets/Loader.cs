using UnityEngine;
using System.Collections;


public class Loader : MonoBehaviour
{
    public GameObject gameManager;            //GameManager prefab to instantiate.
    public GameObject soundManager;            //SoundManager prefab to instantiate.
    public GameObject initialBoard;            //SoundManager prefab to instantiate.
    public GameObject Player;
    private int level =3;
    private  GameObject GM;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Awake()
    {
        Destroy(initialBoard);
        initialPosition = Player.transform.position;
        initialRotation = Player.transform.rotation;

        //Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
        if (GameManager.instance == null)

            //Instantiate gameManager prefab
            gameManager = Instantiate(gameManager);

            gameManager.GetComponent<BoardManager>().level = level;
            gameManager.GetComponent<BoardManager>().Player = Player;
            gameManager.GetComponent<BoardManager>().setPlayer();

        //Check if a SoundManager has already been assigned to static variable GameManager.instance or if it's still null
     //   if (SoundManager.instance == null)

    //        //Instantiate SoundManager prefab
    //        Instantiate(soundManager);
    }


    //Update is called every frame.
    void Update()
    {
        
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            GameState.level += 1;
            GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
            foreach (GameObject wall in walls)
                GameObject.Destroy(wall);
            GameObject[] foods = GameObject.FindGameObjectsWithTag("Food");
            foreach (GameObject food in foods)
                GameObject.Destroy(food);
            level++;
            print("Load");
            gameManager = GameObject.FindGameObjectsWithTag("GameManager")[0];
            Player.transform.position = initialPosition;
            Player.transform.rotation= initialRotation;

            if (GameManager.instance != null)
                gameManager = Instantiate(gameManager);
                gameManager.GetComponent<BoardManager>().Player = Player;
                gameManager.GetComponent<BoardManager>().setPlayer();
                
        }
    }
}
