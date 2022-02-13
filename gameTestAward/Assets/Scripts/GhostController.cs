using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : CharacterControllerBase
{
    //������Public�͂悭�Ȃ�����ς���
    public bool _isFollow = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isFollow = true;
            //�����l�ԑ��ɕς���
            _isControll = false;
            GameManager.Instance.Human.IsControll = true;
            GameManager.Instance._vcam.LookAt = GameManager.Instance.Human.gameObject.transform;
            GameManager.Instance._vcam.Follow = GameManager.Instance.Human.gameObject.transform;
            //GameManager.Instance.ChangePlayer();
        }
    }


    public override void OnUpdate()
    {
        if (_isFollow)
        {
            //�l�Ԃ̏ꏊ���擾
            Vector2 toVector = Vector2.MoveTowards(transform.position, GameManager.Instance.Human.transform.position, _speed * Time.deltaTime);

            //�|�C���g�ֈړ�
            _rb.MovePosition(toVector);
        }
    }





}
