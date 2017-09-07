using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTNodeNoChild : BTNode {

    public override bool AddChild(BTNode node)
    {
        return false;
    }
}
