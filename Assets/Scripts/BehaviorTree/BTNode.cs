using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTNode {

    List<BTNode> children = new List<BTNode>();

    public List<BTNode> Children
    {
        get
        {
            return children;
        }
    }

    public virtual bool AddChild(BTNode node)
    {
        children.Add(node);
        return true;
    }
}
