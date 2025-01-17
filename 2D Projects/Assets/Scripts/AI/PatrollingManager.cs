﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PatrollingManager : MonoBehaviour
{
    //Variables
    public int patrollingType;
    public bool debugMode;
    public bool shootingMode;
    public GameObject aiObject;

    //UI Variables
    public Button randomPatrolButton;
    public Button preSetPatrolButton;
    public Button randomGeneratedPatrolButton;
    public Button followPatrolButton;
    public Button retreatPatrolButton;
    public Button stealthPatrolAddOnButton;
    public Button jumpingPatrolAddOnButton;

    public Button exampleOneButton;
    public Button exampleTwoButton;

    public Button debugModeButton;
    public Button shootingModeButton;
    public Button infoButton;

    public bool infoOn;
    public GameObject[] infoUI;

    //Scene SetUp
    public GameObject platformerSetUp;
    public GameObject topDownSetUp;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate Buttons
        //Patrol Options
        randomPatrolButton.onClick.AddListener(RandomPatrolButtonTask);
        preSetPatrolButton.onClick.AddListener(PreSetPatrolButtonTask);
        randomGeneratedPatrolButton.onClick.AddListener(RandomGeneratedPatrolButtonTask);
        followPatrolButton.onClick.AddListener(FollowPatrolButtonTask);
        retreatPatrolButton.onClick.AddListener(RetreatPatrolButtonTask);
        stealthPatrolAddOnButton.onClick.AddListener(StealthPatrolAddOnButtonTask);
        jumpingPatrolAddOnButton.onClick.AddListener(JumpingPatrolAddOnButtonTask);

        //Example Patrols (State Machine)
        exampleOneButton.onClick.AddListener(ExampleOneButtonTask);
        exampleTwoButton.onClick.AddListener(ExampleTwoButtonTask);

        //Extra 
        debugModeButton.onClick.AddListener(DebugModeButtonTask);
        shootingModeButton.onClick.AddListener(ShootingModeButtonTask);
        infoButton.onClick.AddListener(InfoButtonTask);

        infoOn = false;
    }

    void Update()
    {
        SceneSetUp();
    }

    //Check if Jumping or Not (If jumping switch to jumping scene set-up)
    void SceneSetUp()
    {
        if (patrollingType == 7) //Platformer Mode
        {
            platformerSetUp.SetActive(true);
            topDownSetUp.SetActive(false);
        }
        else
        {
            platformerSetUp.SetActive(false);
            topDownSetUp.SetActive(true);
        }
    }

    //Selected Random Patrol
    void RandomPatrolButtonTask()
    {
        patrollingType = 1;
    }

    //Selected Predetermined Patrol
    void PreSetPatrolButtonTask()
    {
        patrollingType = 2;
    }

    //Randomly Generated Patrol
    void RandomGeneratedPatrolButtonTask()
    {
        patrollingType = 3;
    }

    //Follow Patrol
    void FollowPatrolButtonTask()
    {
        patrollingType = 4;
    }

    //Retreat Patrol
    void RetreatPatrolButtonTask()
    {
        patrollingType = 5;
    }

    //Stealth Patrol Add-On
    void StealthPatrolAddOnButtonTask()
    {
        patrollingType = 6;
    }

    //Jumping Patrol Add-On
    void JumpingPatrolAddOnButtonTask()
    {
        patrollingType = 7;
    }

    //State Machine - Example One: PreSet Path & Follow Patrol
    void ExampleOneButtonTask()
    {
        patrollingType = 8;
    }

    //State Machine - Example Two: Preset Path & Retreat Patrol
    void ExampleTwoButtonTask()
    {
        patrollingType = 9;
    }

    //Turn On Debug Mode
    void DebugModeButtonTask()
    {
        if(debugMode)
        {
            debugMode = false;
            aiObject.GetComponent<PatrollingAlgorithms>().debugLocationMarker.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            debugMode = true;
            aiObject.GetComponent<PatrollingAlgorithms>().debugLocationMarker.GetComponent<Renderer>().enabled = true;
        }
    }

    //Turn On Shooting Mode
    void ShootingModeButtonTask()
    {
        if(shootingMode)
        {
            shootingMode = false;
        }
        else
        {
            shootingMode = true;
        }
    }

    //Turn On and Off Info Boxes
    void InfoButtonTask()
    {
        if(infoOn)
        {
            infoOn = false;
            infoUI[patrollingType].GetComponent<Renderer>().enabled = false;
        }
        else
        {
            infoOn = true;
            infoUI[patrollingType].GetComponent<Renderer>().enabled = true;
        }
    }
}
