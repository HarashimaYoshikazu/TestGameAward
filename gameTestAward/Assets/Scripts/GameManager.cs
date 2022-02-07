using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] CharacterController _human = null;
    [SerializeField] CharacterController _ghost = null;
    [SerializeField] CinemachineVirtualCamera _vcam = default;
    void Start()
    {
        //プレイヤー生成
       _human = Instantiate(_human);
       _ghost = Instantiate(_ghost);

        //最初はゴーストの動きを無効化して、vcamを人間に追従させる
       _ghost.enabled = false;
        _vcam.LookAt = _human.gameObject.transform;
        _vcam.Follow = _human.gameObject.transform;
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

                //カメラの追従を人間に変える
                _vcam.LookAt = _human.gameObject.transform;
                _vcam.Follow = _human.gameObject.transform;
            }
            else
            {
                _ghost.enabled = true;
                _human.enabled = false;
                _vcam.LookAt = _ghost.gameObject.transform;
                _vcam.Follow = _ghost.gameObject.transform;
            }
        }
    }

    /// <summary>
    /// 共に移動する関数
    /// </summary>
    public void MoveTogether()
    {
        if (_ghost.enabled)
        {
            //人間を動かす
            _human.enabled = true;
        }
        else
        {
            _ghost.enabled = true;
        }
    }
}
