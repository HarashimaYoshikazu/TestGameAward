using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    [SerializeField] CharacterController _human = null;
    [SerializeField] CharacterController _ghost = null;
    [SerializeField] CinemachineVirtualCamera _vcam = default;
    void Start()
    {
       _human = Instantiate(_human);
       _ghost = Instantiate(_ghost);
       _ghost.enabled = false;
        _vcam.LookAt = _human.gameObject.transform;
    }

    void Update()
    {
        ChangePlayer();
    }

    void ChangePlayer()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //ゴーストが動いていたら
            if (_ghost.enabled)
            {
                //ゴーストの動きを止めて人間を動かす
                _ghost.enabled = false;
                _human.enabled = true;
                //カメラのフォローを人間に変える
                _vcam.LookAt = _human.gameObject.transform;
            }
            else
            {
                _ghost.enabled = true;
                _human.enabled = false;
                _vcam.LookAt = _ghost.gameObject.transform;
            }
        }
    }
}
