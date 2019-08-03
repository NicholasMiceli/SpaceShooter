using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
public GameObject[] hazards;
public Vector3 spawnValues;
public int hazardCount;
public float spawnWait;
public float startWait;
public float waveWait;

public Text ScoreText;
public Text RestartText;
public Text GameOverText;
public Text WinText;
public Text HardModeText;
public Text TimedText;
private bool gameOver;
private bool restart;
public bool hard;
public int score;
public float timeLeft = 30;
private Mover mover;
public bool firstTime = true;

void Start()
{
gameOver = false;
restart = false;
hard = true;
RestartText.text = "";
GameOverText.text = "";
WinText.text = "";
HardModeText.text = "Press H for Hard Mode!";
TimedText.text = "Hold T for Timed Mode!";
score = 0;
UpdateScore();
StartCoroutine(SpawnWaves());
}

void Update()
{

    if (Input.GetKey (KeyCode.T) && firstTime)
    {
      firstTime = false;
    }
    if (firstTime == false)
    {
      timeLeft -= Time.deltaTime;
      TimedText.text = (timeLeft).ToString("0");
      if(timeLeft < 0)
       {
          GameOver();
       }
    }

  if (restart)
  {
    if (Input.GetKeyDown (KeyCode.K))
    { 
      SceneManager.LoadScene("Main");
    }
  }
}

IEnumerator SpawnWaves()
{
yield return new WaitForSeconds(startWait);
while (true)
{
for (int i = 0; i < hazardCount; i++)
{
GameObject hazard = hazards[Random.Range(0, hazards.Length - 1)]; 
Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
Quaternion spawnRotation = Quaternion.identity;
Instantiate(hazard, spawnPosition, spawnRotation);
yield return new WaitForSeconds(spawnWait);
}
yield return new WaitForSeconds(waveWait);
if (gameOver)
{
  RestartText.text = "Press 'K' for restart";
  restart = true;
  break;
}
}
}

public void AddScore(int newScoreValue)
{
score += newScoreValue;
UpdateScore();
}

void UpdateScore()
{
ScoreText.text = "Points: " + score;
 if(score >= 100)
 {
    WinText.text = "You win!";
    gameOver = true;
    restart = true;
 }
}
public void GameOver ()
{
 GameOverText.text = "GAME CREATED BY NICHOLAS MICELI";
 TimedText.text = "";
 gameOver = true;
}
public void TimeAttack()
{
  timeLeft -= Time.deltaTime;
  TimedText.text = (timeLeft).ToString("0");
  if(timeLeft < 0)
  {
    GameOver();
  }
}
}