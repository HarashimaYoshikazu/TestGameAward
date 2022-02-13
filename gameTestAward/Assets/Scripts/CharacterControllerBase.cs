using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerBase : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D _rb;
    [SerializeField] protected float _speed = 3.0f;

    //�Z�b�^�[�悭�Ȃ�����֐��Ƃ��ɂ��悤��
    /// <summary>���ݑ��쒆���ǂ����̃t���O</summary>
    protected bool _isControll = false;
    public bool IsControll { get => _isControll; set => _isControll = value; }




    void Update()
    {
        //�I������Ă���Ȃ瓮����
        if (_isControll)
        {
            Move();
        }
        OnUpdate();
    }

    /// <summary>
    /// �h���p��OnUpdate�֐�
    /// </summary>
    public virtual void OnUpdate()
    {
        
    }

    /// <summary>
    /// ���������߂̊֐�
    /// </summary>
    protected void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(h,v).normalized;
        _rb.velocity = _speed * dir;
    }

    
}
