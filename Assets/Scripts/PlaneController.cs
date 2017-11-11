﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {

    private const float _movementIncrement = .15f;
    private const float _playerUpperMovementLimit = 4.25f;
    private const float _playerLowerMovementLimit = -4.25f;
    private const float _playerRightMovementLimit = 1.25f;
    private const float _playerLeftMovementLimit = -5.25f;
    private Vector3 _playerStartingPosition;
    private bool _plane1SpriteIsShown;
    private bool _enemiesHaveHadTimeToDespawn;

    public static int _playerHealth = 3;
    public static bool _gameIsActive;

    public GameObject _candyCorn, _firingPoint;
    public Sprite _plane1, _plane2;

    void Start()
    {
        _playerStartingPosition = transform.position;
        _gameIsActive = false;
        _plane1SpriteIsShown = true;
        _enemiesHaveHadTimeToDespawn = false;
        StartCoroutine(switchPlaneSprites());
    }

    // Update is called once per frame
    void Update () {
        if (GameMenuVariables._atMainMenu || _gameIsActive)
        {
            if (Input.GetKey(KeyCode.W))
                moveUp();
            if (Input.GetKey(KeyCode.S))
                moveDown();
            if (Input.GetKey(KeyCode.A))
                moveLeft();
            if (Input.GetKey(KeyCode.D))
                moveRight();
            if (Input.GetKeyDown(KeyCode.Space))
                fireStandard();
        }
        else if (!_gameIsActive && _enemiesHaveHadTimeToDespawn)
        {
            if (Input.GetKeyDown(KeyCode.R))
                restartGame();
            else if (Input.GetKeyDown(KeyCode.Q))
                returnToMainMenu();
        }
    }

    private void moveUp()
    {
        if (transform.position.y < _playerUpperMovementLimit)
            transform.position += new Vector3(0, _movementIncrement, 0);
    }

    private void moveDown()
    {
        if (transform.position.y > _playerLowerMovementLimit)
            transform.position -= new Vector3(0, _movementIncrement, 0);
    }

    private void moveRight()
    {
        if (transform.position.x < _playerRightMovementLimit)
            transform.position += new Vector3(_movementIncrement, 0, 0);
    }

    private void moveLeft()
    {
        if (transform.position.x > _playerLeftMovementLimit)
            transform.position -= new Vector3(_movementIncrement, 0, 0);
    }

    private void fireStandard()
    {
        GameObject _candyCornBulletClone = Instantiate(_candyCorn, _firingPoint.transform.position, Quaternion.identity);
        _candyCornBulletClone.GetComponent<Rigidbody2D>().velocity = new Vector3(5, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D col) {
        //If player was hit by an enemy or attack, grant temporary invincibility
        if (col.gameObject.tag != "CandyCorn" && col.gameObject.tag!="HealthUp")
        {
            GetComponent<Collider2D>().enabled = false;
            _playerHealth -= 1;
            Debug.Log("Warning, player damaged!  Health: "+_playerHealth);

            if (_playerHealth <= 0)
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                _gameIsActive = false;
                StartCoroutine(allowEnemiesTimeToDespawn());
            }
            else
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f);
                StartCoroutine(reApplyVulnerability());
            }
        }
    }

    private IEnumerator reApplyVulnerability() {
        yield return new WaitForSeconds(3);
        if (_playerHealth <= 0) //Fixes a bug where player could re-appear after death
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
        else
        {
            GetComponent<Collider2D>().enabled = true;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
   }

    private IEnumerator switchPlaneSprites()
    {
        yield return new WaitForSeconds(0.05f);
        if (_plane1SpriteIsShown)
        {
            GetComponent<SpriteRenderer>().sprite = _plane2;
            _plane1SpriteIsShown = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = _plane1;
            _plane1SpriteIsShown = true;
        }
        StartCoroutine(switchPlaneSprites());
    }

    private IEnumerator allowEnemiesTimeToDespawn()
    {
        yield return new WaitForSeconds(2);
        _enemiesHaveHadTimeToDespawn = true;
    }

    private void restartGame()
    {
        respawnCharacter();
        _gameIsActive = true;
    }

    private void returnToMainMenu()
    {
        respawnCharacter();
        GameMenuVariables._atMainMenu = true;
        GameMenuVariables._atDefaultMenu = true;//this sets bothe of these variables back to true
    }

    private void respawnCharacter()
    {
        transform.position = _playerStartingPosition;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        _playerHealth = 3;
        ScoreManager._score = 0;
        SpawnManager._currentScoreTier = 0;
        _enemiesHaveHadTimeToDespawn = false;
        GetComponent<Collider2D>().enabled = true;
    }
}
