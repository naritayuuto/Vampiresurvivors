using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Unity上の、特定の型のオブジェクトプール
/// </summary>
/// <typeparam name="T"></typeparam>
public class ObjectPool<T> where T : UnityEngine.Object, IObjectPool
{
    T BaseObj = null;
    Transform Parent = null;
    List<T> Pool = new List<T>();//Tはジェネリック、何の型でも大丈夫
    int Index = 0;

    public void SetBaseObj(T obj, Transform parent)
    {
        BaseObj = obj;
        Parent = parent;
    }

    public void Pooling(T obj)
    {
        obj.DisactiveForInstantiate();
        Pool.Add(obj);
    }

    public void SetCapacity(int size)
    {
        //既にオブジェクトサイズが大きいときは更新しない
        if (size < Pool.Count) return;

        for (int i = Pool.Count - 1; i < size; ++i)
        {
            T Obj = default(T);
            if (Parent)
            {
                Obj = GameObject.Instantiate(BaseObj, Parent);
            }
            else
            {
                Obj = GameObject.Instantiate(BaseObj);
            }
            Pooling(Obj);
        }
    }

    public T Instantiate()
    {
        T ret = null;
        for (int i = 0; i < Pool.Count; ++i)
        {
            int index = (Index + i) % Pool.Count;//要素数分回す
            if (Pool[index].IsActive) continue;//実体があったら

            Pool[index].Create();//なかったら実体を出す
            ret = Pool[index];//出しましたという情報を変数に入れて
            break;
        }

        return ret;
    }
}