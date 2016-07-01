using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BTetri1DotPool: MonoBehaviour{

    private Stack<BTetrisTransform> instances = new Stack<BTetrisTransform>();

    public BTetrisTransform prefab;
    public BTetrisTransform Pop()
    {
        if (instances.Count > 0)
        {
            var inst = instances.Pop();
            inst.gameObject.SetActive(true);
            return inst;
        }
        else return (BTetrisTransform)GameObject.Instantiate(prefab);
    }

    public BTetri1DotPool Push(BTetrisTransform inst)
    {
        inst.gameObject.SetActive(false);
        instances.Push(inst);
        return this;
    }

    public BTetri1DotPool Push(List<BTetrisTransform> insts)
    {
        var _this = this;
        insts.ForEach(inst => {
            this.Push(inst);
            return;
            });
        return this;
    }

    public BTetri1DotPool DisposeAndPush(BTetrisTransform inst)
    {
        inst.Dispose();
        instances.Push(inst);
        return this;
    }

}
