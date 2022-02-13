using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] CharacterControllerBase _human = null;
    [SerializeField] GhostController _ghost = null;
    public CharacterControllerBase Human => _human;
    public CharacterControllerBase Ghost => _ghost;

    //めんどいからpublic
    [SerializeField] public CinemachineVirtualCamera _vcam = default;
    void Start()
    {
        //プレイヤー生成
       _human = Instantiate(_human);
       _ghost = Instantiate(_ghost);

        //最初はゴーストの動きを無効化して、vcamを人間に追従させる
       _human.IsControll = true;
        _vcam.LookAt = _human.gameObject.transform;
        _vcam.Follow = _human.gameObject.transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ChangePlayer();
        }
    }

    public void ChangePlayer()
    {

            //ゴーストが動いていたら
            if (_ghost.IsControll)
            {
                //ゴーストの動きを止めて人間を動かす
                _ghost.IsControll = false;
                _human.IsControll = true;

                //カメラの追従を人間に変える
                _vcam.LookAt = _human.gameObject.transform;
                _vcam.Follow = _human.gameObject.transform;
            }
            else
            {
                _ghost.IsControll = true;
                _human.IsControll = false;
                //ゴーストの追従を切る
                _ghost._isFollow = false;
                _vcam.LookAt = _ghost.gameObject.transform;
                _vcam.Follow = _ghost.gameObject.transform;
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
