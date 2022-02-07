using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] CharacterController _human = null;
    [SerializeField] CharacterController _ghost = null;
    void Start()
    {
       _human = Instantiate(_human);
       _ghost = Instantiate(_ghost);
       _ghost.enabled = false;
    }

    void Update()
    {
        ChangePlayer();
    }

    void ChangePlayer()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (_ghost.enabled)
            {
                _ghost.enabled = false;
                _human.enabled = true;
            }
            else
            {
                _ghost.enabled = true;
                _human.enabled = false;
            }
        }
    }
}
