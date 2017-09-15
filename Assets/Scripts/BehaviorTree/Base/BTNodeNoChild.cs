using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BTNodeNoChild : BTNode {

	protected override bool AddChild(BTNode node)
    {
        return false;
    }
}
