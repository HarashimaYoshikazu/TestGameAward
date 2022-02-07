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
        //�v���C���[����
       _human = Instantiate(_human);
       _ghost = Instantiate(_ghost);

        //�ŏ��̓S�[�X�g�̓����𖳌������āAvcam��l�ԂɒǏ]������
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
            //�S�[�X�g�������Ă�����
            if (_ghost.enabled)
            {
                //�S�[�X�g�̓������~�߂Đl�Ԃ𓮂���
                _ghost.enabled = false;
                _human.enabled = true;

                //�J�����̒Ǐ]��l�Ԃɕς���
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
