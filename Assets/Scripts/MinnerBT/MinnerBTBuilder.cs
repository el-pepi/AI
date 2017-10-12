using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinnerBTBuilder {
	
	public static SequencerNode<MinnerBlackboard> Build(MinnerBlackboard blackboard){
		SequencerNode<MinnerBlackboard> root = new SequencerNode<MinnerBlackboard> ();
		root.SetBlackBoard (blackboard);

			SequencerNode<MinnerBlackboard> findRocks = new SequencerNode<MinnerBlackboard> ();
			root.AddChild (findRocks);
				RockCheckNode<MinnerBlackboard> rockChecker = new RockCheckNode<MinnerBlackboard> ();
				findRocks.AddChild (rockChecker);
				BagSpaceCheckNode<MinnerBlackboard> bagChecker = new BagSpaceCheckNode<MinnerBlackboard> ();
				findRocks.AddChild (bagChecker);
				GoToRocksNode<MinnerBlackboard> goToRocks = new GoToRocksNode<MinnerBlackboard> ();
				findRocks.AddChild (goToRocks);
				GetRocksNode<MinnerBlackboard> getRocks = new GetRocksNode<MinnerBlackboard> ();
				findRocks.AddChild (getRocks);

			SequencerNode<MinnerBlackboard> goBack = new SequencerNode<MinnerBlackboard> ();
			root.AddChild (goBack);
				HasRocksCheckNode<MinnerBlackboard> hasRocks = new HasRocksCheckNode<MinnerBlackboard> ();
				goBack.AddChild (hasRocks);
				GoToHomeNode<MinnerBlackboard> goHome = new GoToHomeNode<MinnerBlackboard> ();
				goBack.AddChild (goHome);
				DropRocksNode<MinnerBlackboard> dropRocks = new DropRocksNode<MinnerBlackboard> ();
				goBack.AddChild (dropRocks);
				

		return root;
	}
}