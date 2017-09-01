using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Miner : MonoBehaviour {

    enum states
    {
        idle,
        goingToMine,
        minning,
        goingToBase,
        dumping,
        count
    }

    enum events
    {
        foundGold,
        goldFinished,
        done,
        count
    }

    states state;
    FSM stateMachine;
    float timer = 1f;
    int baseX;
    int baseY;
    int nodeIndex;

    PathFinder pathFinder;

    List<Node> nodes;

    public Text info;
    public Rock rock;
    public float walkSpeed = 3;
    public int bagSize = 3;
    public int carrying = 0;


	public void Init () {
        baseX = Mathf.RoundToInt(transform.position.x);
        baseY = Mathf.RoundToInt(transform.position.y);


        state = states.idle;
        stateMachine = new FSM((int)states.count, (int)events.count);

        stateMachine.SetTrigger((int)states.idle,(int)events.foundGold,(int)states.goingToMine);
        stateMachine.SetTrigger((int)states.goingToMine,(int)events.done,(int)states.minning);
        stateMachine.SetTrigger((int)states.minning,(int)events.done,(int)states.goingToBase);
        stateMachine.SetTrigger((int)states.goingToBase,(int)events.done,(int)states.dumping);
        stateMachine.SetTrigger((int)states.dumping,(int)events.foundGold,(int)states.goingToMine);
        stateMachine.SetTrigger((int)states.dumping,(int)events.goldFinished,(int)states.idle);

        pathFinder = new PathFinder();
        pathFinder.Init(Map.tiles, Map.weights);
        nodes = new List<Node>(pathFinder.GetPath(baseX, baseY, Mathf.RoundToInt(rock.transform.position.x), Mathf.RoundToInt(rock.transform.position.y), PathFinder.Algorithm.AStar));
    }

    void Update () {
        switch (state)
        {
            case states.idle:
                UpdateIdle();
                break;
            case states.goingToMine:
                UpdateGoingMine();
                break;
            case states.minning:
                UpdateMinning();
                break;
            case states.goingToBase:
                UpdateGoingToBase();
                break;
            case states.dumping:
                UpdateDumping();
                break;
        }
        info.text = "Gold on rock: " + rock.ammount + "\nCarrying: " + carrying + "/" + bagSize;
	}

    float UpdateTimer()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        return timer;
    }

    void UpdateIdle()
    {
        if (UpdateTimer() <= 0)
        {
            timer = 1;

            if (rock.ammount > 0)
            {
                nodeIndex = nodes.Count - 1;
                state = (states)stateMachine.SendEvent((int)events.foundGold);
            }
        }
    }

    void UpdateGoingMine()
    {
        Node n = nodes[nodeIndex];
        Vector3 dir = new Vector3(n.x, n.y, 0) - transform.position;

        if((dir.normalized * walkSpeed * Time.deltaTime).magnitude >= dir.magnitude )
        {
            transform.position += dir;
            nodeIndex--;
            if (nodeIndex == -1)
            {
                nodeIndex = 0;
                state = (states)stateMachine.SendEvent((int)events.done);
            }
        }
        else
        {
            transform.position += (dir).normalized * walkSpeed * Time.deltaTime;
        }
    }

    void UpdateGoingToBase()
    {
        Node n = nodes[nodeIndex];
        Vector3 dir = new Vector3(n.x, n.y, 0) - transform.position;

        if ((dir.normalized * walkSpeed * Time.deltaTime).magnitude >= dir.magnitude)
        {
            transform.position += dir;
            nodeIndex++;
            if (nodeIndex == nodes.Count)
            {
                state = (states)stateMachine.SendEvent((int)events.done);
            }
        }
        else
        {
            transform.position += (dir).normalized * walkSpeed * Time.deltaTime;
        }
    }

    void UpdateMinning()
    {
        if (UpdateTimer() <= 0)
        {
            timer = 1;

            if (rock.ammount > 0)
            {
                rock.ammount--;
                carrying++;
                if (carrying >= bagSize)
                {
                    state = (states)stateMachine.SendEvent((int)events.done);
                }
            }
            else
            {
                state = (states)stateMachine.SendEvent((int)events.done);
            }
        }
    }

    void UpdateDumping()
    {
        if (UpdateTimer() <= 0)
        {
            timer = 1;
            carrying--;
            if (carrying <= 0)
            {
                if (rock.ammount>0)
                {
                    nodeIndex = nodes.Count - 1;
                    state = (states)stateMachine.SendEvent((int)events.foundGold);
                }
                else
                {
                    state = (states)stateMachine.SendEvent((int)events.goldFinished);
                }
            }
        }
    }
}
