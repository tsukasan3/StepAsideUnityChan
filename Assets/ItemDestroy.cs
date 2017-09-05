using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    //画面内にあるかどうかの判定
    private bool _enabled = false;
    //レンダラーのコンポーネントを入れる
    private Renderer _renderer;

    // Use this for initialization
    void Start()
    {
        //レンダラーのコンポーネントを取得
        this._renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //画面外に出たときに破壊する
        if(!_enabled && this._renderer.isVisible)
        {
            _enabled = true;
        }
        if(_enabled && !this._renderer.isVisible)
        {
            Destroy(this.gameObject);
        }

    }

}