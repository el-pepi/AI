using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinnerBTBuilder : MonoBehaviour {
	
	public SequencerNode<MinnerBlackboard> Build(MinnerBlackboard blackboard){
		SequencerNode<MinnerBlackboard> root = new SequencerNode<MinnerBlackboard> ();
		root.SetBlackBoard (blackboard);

			SequencerNode<MinnerBlackboard> findRocks = new SequencerNode<MinnerBlackboard> ();
			root.AddChild (findRocks);
				RockCheckNode<MinnerBlackboard> rockChecker = new RockCheckNode<MinnerBlackboard> ();
				findRocks.AddChild (rockChecker);
				BagSpaceCheckNode<MinnerBlackboard> bagChecker = new BagSpaceCheckNode<MinnerBlackboard> ();
				findRocks.AddChild (bagChecker);


		return root;
	}
}
/*TODO:
 * 					->
 * (empiezo, busco y mino)				(termino de minar, si tengo algo, vuelvo a base)
 * ->									->
 * hay? espacio? Ir! Minar!				tengo? Ir! Dejar!	
 * 
 * 
 * 
 * /