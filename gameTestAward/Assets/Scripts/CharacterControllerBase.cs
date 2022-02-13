using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerBase : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D _rb;
    [SerializeField] protected float _speed = 3.0f;

    //セッターよくないから関数とかにしようね
    /// <summary>現在操作中かどうかのフラグ</summary>
    protected bool _isControll = false;
    public bool IsControll { get => _isControll; set => _isControll = value; }




    void Update()
    {
        //選択されているなら動かす
        if (_isControll)
        {
            Move();
        }
        OnUpdate();
    }

    /// <summary>
    /// 派生用のOnUpdate関数
    /// </summary>
    public virtual void OnUpdate()
    {
        
    }

    /// <summary>
    /// 動かすための関数
    /// </summary>
    protected void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(h,v).normalized;
        _rb.velocity = _speed * dir;
    }

    
}
