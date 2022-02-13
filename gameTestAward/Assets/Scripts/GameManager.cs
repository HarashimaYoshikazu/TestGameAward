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

    //�߂�ǂ�����public
    [SerializeField] public CinemachineVirtualCamera _vcam = default;
    void Start()
    {
        //�v���C���[����
       _human = Instantiate(_human);
       _ghost = Instantiate(_ghost);

        //�ŏ��̓S�[�X�g�̓����𖳌������āAvcam��l�ԂɒǏ]������
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

            //�S�[�X�g�������Ă�����
            if (_ghost.IsControll)
            {
                //�S�[�X�g�̓������~�߂Đl�Ԃ𓮂���
                _ghost.IsControll = false;
                _human.IsControll = true;

                //�J�����̒Ǐ]��l�Ԃɕς���
                _vcam.LookAt = _human.gameObject.transform;
                _vcam.Follow = _human.gameObject.transform;
            }
            else
            {
                _ghost.IsControll = true;
                _human.IsControll = false;
                //�S�[�X�g�̒Ǐ]��؂�
                _ghost._isFollow = false;
                _vcam.LookAt = _ghost.gameObject.transform;
                _vcam.Follow = _ghost.gameObject.transform;
            }
    }

    /// <summary>
    /// ���Ɉړ�����֐�
    /// </summary>
    public void MoveTogether()
    {
        if (_ghost.enabled)
        {
            //�l�Ԃ𓮂���
            _human.enabled = true;
        }
        else
        {
            _ghost.enabled = true;
        }
    }
}
