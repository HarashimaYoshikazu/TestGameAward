using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : CharacterControllerBase
{
    //ここもPublicはよくないから変える
    public bool _isFollow = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isFollow = true;
            //操作を人間側に変える
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
            //人間の場所を取得
            Vector2 toVector = Vector2.MoveTowards(transform.position, GameManager.Instance.Human.transform.position, _speed * Time.deltaTime);

            //ポイントへ移動
            _rb.MovePosition(toVector);
        }
    }





}
