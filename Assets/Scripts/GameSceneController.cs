using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// ReSharper disable All
public class GameSceneController : MonoBehaviour
{
    //public Scene _scene;
    
    public Text gameText;
    public Text scoreText;
    public ShipController ship;
    
    public GameObject enemyContainer;
    public float enemyMovementDuration = 0.2f;
    public float enemyMovementStep = 0.5f;
    public float enemyLimit = 4.0f;
    
    private bool _enemiesMovingRight;
    private float _enemyMovementTimer;

    private int _enemiesToDestroy;
    private int _puntoEnemigo = 10;
    private int _score = 0;
    private bool _end = false;
    private bool _start = true;
    private bool active;
    public void ScoreFinal(int _scoreFinal)
    {
        Debug.Log("Puntaje Final: "+ _scoreFinal);
        //Time.timeScale = (_end) ? 0 : 1f;
    }

    void Start()
    {
        
        EnemyController[] enemies = enemyContainer.GetComponentsInChildren<EnemyController>();
        _enemiesToDestroy = enemies.Length;
        Debug.Log("'Enemigos: '"+  _enemiesToDestroy);
        foreach (EnemyController enemy in enemies)
        {
            enemy.onEnemyDestroyed = () =>
            {
                _enemiesToDestroy--;
                _score = _score + _puntoEnemigo;
                scoreText.text = "Points: " + _score;     
                Debug.Log("Puntaje: "+ _score);
            };
        }
        
    }

    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            active = !active;
            Time.timeScale = (_end) ? 0 : 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
        
        _enemyMovementTimer -= Time.deltaTime;
        
        if (_enemyMovementTimer <= 0)
        {
            _enemyMovementTimer = enemyMovementDuration;
            enemyContainer.transform.position = new Vector3( enemyContainer.transform.position.x + (_enemiesMovingRight ? enemyMovementStep: -enemyMovementStep),
                enemyContainer.transform.position.y,
                enemyContainer.transform.position.z);

            if (Mathf.Abs(enemyContainer.transform.position.x) > enemyLimit)
            {
                _enemiesMovingRight = !_enemiesMovingRight;
                enemyContainer.transform.position += Vector3.down * enemyMovementStep;
            }
        }

        if (ship == null)
        {
            gameText.text = "You Lost!\nPress R to Restart the game";
            _end = true;
            active = !active;
            Time.timeScale = (_end) ? 0 : 1f;
        }

        if (_enemiesToDestroy == 0)
        {
            gameText.text = "You Won!\nPress R to Restart the game";
            _end = true;
            active = !active;
            Time.timeScale = (_end) ? 0 : 1f;
        }

        if (_end == true)
        {
            ScoreFinal(_score);
        }
    
    }
}