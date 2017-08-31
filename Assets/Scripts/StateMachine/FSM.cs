public class FSM {

    int[,] stateMatrix;

    int currentState;

    public int GetState()
    {
        return currentState;
    }
    
    public FSM(int states, int events)
    {
        stateMatrix = new int[states,events];
        for (int x = 0; x < states; x++)
        {
            for (int y = 0; y < events; y++)
            {
                stateMatrix[x, y] = -1;
            }
        }
    }

    public void SetTrigger(int state, int trigger, int endState)
    {
        stateMatrix[state, trigger] = endState;
    }

    public int SendEvent(int trigger)
    {
        if (stateMatrix.GetLength(1) > trigger)
        {
            if(stateMatrix[currentState,trigger] != -1)
            {
                currentState = stateMatrix[currentState, trigger];
            }
        }
        return currentState;
    }
}
