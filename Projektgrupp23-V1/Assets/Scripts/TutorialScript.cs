using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    GameObject enemy;
    [SerializeField] TextMeshProUGUI[] tutorialTexts;
    private float timePast;
    [SerializeField] float timer = 5;
    [SerializeField] GameObject doors;
    [SerializeField] BoxCollider2D activateEnemyTrigger;

    enum State
    {
        Welcome1,
        Welcome2,
        Move1,
        Move2,
        Dash1,
        Dash2,
        Shoot1,
        Shoot2,
        Finished1,
        Finished2,
        None
    }
    State state;
    bool deactivate = false;

    void Start()
    {
        timePast = 0;
        enemy = FindObjectOfType<EnemyHealth>().gameObject;
        enemy.SetActive(false);
        state = State.Welcome1;
    }

    void Update()
    {
        switch (state)
        {
            case State.Welcome1:
                tutorialTexts[(int)State.Welcome1].enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    tutorialTexts[(int)State.Welcome1].enabled = false;
                    state++;
                }
                break;

            case State.Welcome2:
                DeactivateTextAfterTimer((int)State.Welcome2);
                break;

            case State.Move1:
                    tutorialTexts[(int)State.Move1].enabled = true;
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                {
                    tutorialTexts[(int)State.Move1].enabled = false;
                    timePast = 0;
                    state++;
                }
                break;

            case State.Move2:
                DeactivateTextAfterTimer((int)State.Move2);
                break;

            case State.Dash1:
                tutorialTexts[(int)State.Dash1].enabled = true;
                if (Input.GetKeyDown(KeyCode.LeftShift) && !deactivate)
                {
                    tutorialTexts[(int)State.Dash1].enabled = false;
                    timePast = 0;
                    state++;
                }
                break;

            case State.Dash2:
                DeactivateTextAfterTimer((int)State.Dash2);
                break;
            case State.Shoot1:
                tutorialTexts[(int)State.Shoot1].enabled = true;
                if (!doors.GetComponent<BoxCollider2D>().enabled)
                {
                    tutorialTexts[(int)State.Shoot1].enabled = false;
                    enemy.SetActive(true);
                    state++;
                }
                break;
            case State.Shoot2:
                if (enemy.activeSelf)
                {
                    tutorialTexts[(int)State.Shoot2].enabled = true;
                }
                else if (!enemy.activeSelf)
                {
                    tutorialTexts[(int)State.Shoot2].enabled = false;
                    state++;
                }
                break;

            case State.Finished1: 
                    DeactivateTextAfterTimer((int)State.Finished1);
                break;

            case State.Finished2:
                DeactivateTextAfterTimer((int)State.Finished2);
                break;

            case State.None:
                break;
        }
    }
    private void DeactivateTextAfterTimer(int indexOfTutorialText)
    {
        if (timePast < timer)
        {
            timePast += Time.deltaTime;
            tutorialTexts[indexOfTutorialText].enabled = true;
        }
        else
        {
            tutorialTexts[indexOfTutorialText].enabled = false;
            timePast = 0;
            state++;
        }
    }

}
