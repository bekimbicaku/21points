using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public int RadNum = 0;
    int MyScore = 0;
    public GameObject victoryPanel;
    public GameObject currentPanel;
    public TextMeshProUGUI panelText;
    public TextMeshProUGUI myScoreText;

    public Sprite guessedSprite;
    public Sprite notGuessedSprite;

    private int countGuesses;

    public TextMeshProUGUI devisionText;

    public TextMeshProUGUI buttonText;

    // Start is called before the first frame update
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
        RadNum = Random.Range(1, 11);
        myScoreText.text = "Score: " + MyScore.ToString();
        if(MyScore > 21)
        {
            devisionText.text = "You passed 21 points.Your points are divided by 2!";
            MyScore = MyScore / 2;
            StartCoroutine(ShowText());
        }
        


    }
    void LateUpdate()
    {
        if (MyScore == 21)
        {
            victoryPanel.SetActive(true);
            currentPanel.SetActive(false);
            panelText.text = "Well done you collected 21 points";
            buttonText.text = "Play Again";
        }
        if (MyScore >= 60)
        {
            victoryPanel.SetActive(true);
            currentPanel.SetActive(false);
            panelText.text = "You have reached 60 points.Try again";
            buttonText.text = "Try Again";
        }
    }
    public void Retry()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
    public void SetNumber(TextMeshProUGUI numberText)
    {
        numberText.text = RadNum.ToString();
        
        MyScore = MyScore + RadNum;
        StartCoroutine(ShowNumber(numberText));

    }
    public void SetColor(Button button)
    {
        button.image.sprite = guessedSprite;
        StartCoroutine(ShowSprite(button));
    }



    IEnumerator ShowText()
    {
        yield return new WaitForSeconds(1f);
        devisionText.text = " ";
    }
    IEnumerator ShowSprite(Button button)
    {
        yield return new WaitForSeconds(1f);
        button.image.sprite = notGuessedSprite;
    }

    IEnumerator ShowNumber(TextMeshProUGUI numberText)
    {
        yield return new WaitForSeconds(1f);
        numberText.text = " ";
    }
   
}
