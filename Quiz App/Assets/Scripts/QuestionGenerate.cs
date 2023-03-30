using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionGenerate : MonoBehaviour
{
    public static string actualAnswer;
    public static bool displayingQuestion = false;
    public int questionNumber;
    public int numberOfQuestions = 5;
    public GameObject visual001;


    public List<int> usedQuestions = new List<int>();

    void Update()
    {
        if (displayingQuestion == false)
        {
            displayingQuestion = true;
            questionNumber = Random.Range(0, numberOfQuestions);
            //Check is question has been used already
            //for (int i = 0; i < numberOfQuestions; i++)
            //{
                //if
            //}


            if (questionNumber == 0)
            {
                QuestionDisplay.newQuestion = "Which of these champions was released after the original 17?";
                QuestionDisplay.newA = "A. Singed";
                QuestionDisplay.newB = "B. Alistar";
                QuestionDisplay.newC = "C. Master Yi";
                QuestionDisplay.newD = "D. Teemo";
                actualAnswer = "A";
            }
            if (questionNumber == 1)
            {
                QuestionDisplay.newQuestion = "What is the name of Miss Fortunes ultimate ability?";
                QuestionDisplay.newA = "A. Make It Rain";
                QuestionDisplay.newB = "B. Bullet Time";
                QuestionDisplay.newC = "C. Bullet Barrage";
                QuestionDisplay.newD = "D. Blunder Buster";
                actualAnswer = "B";
            }
            if (questionNumber == 2)
            {
                QuestionDisplay.newQuestion = "What champion has the most skins in the game?";
                QuestionDisplay.newA = "A. Ezreal";
                QuestionDisplay.newB = "B. Ahri";
                QuestionDisplay.newC = "C. Lux";
                QuestionDisplay.newD = "D. Miss Fortune";
                actualAnswer = "C";
            }
            if (questionNumber == 3)
            {
                QuestionDisplay.newQuestion = "What is the name of Viktors ultimate ability?";
                QuestionDisplay.newA = "A. Hextech Ultimatum";
                QuestionDisplay.newB = "B. UPGRADE!!!";
                QuestionDisplay.newC = "C. Static Field";
                QuestionDisplay.newD = "D. Chaos Storm";
                actualAnswer = "D";
            }
            if (questionNumber == 3)
            {
                QuestionDisplay.newQuestion = "What is the name of this item?";
                QuestionDisplay.newA = "A. Spellbinder";
                QuestionDisplay.newB = "B. Zhonya's Hourglass";
                QuestionDisplay.newC = "C. Spellbreaker";
                QuestionDisplay.newD = "D. Spirit Stone";
                visual001.SetActive(true);
                actualAnswer = "A";
            }

            //all questions go above this line
            QuestionDisplay.pleaseUpdate = false;
        }
    }
}
