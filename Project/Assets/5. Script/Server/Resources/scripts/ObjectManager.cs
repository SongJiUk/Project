using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager current;
    private void Awake()
    {
        if (current == null)
            current = this;
        else
            Debug.LogError("Not Single ObjectManager");

    }

    Player player;

    [SerializeField]
    GameObject ObjectPrefab;

    [SerializeField]
    GameObject OtherPrefab;

    List<NetObject> ObjectArray= new List<NetObject>();

    public NetObject FindObject(int playerindex)
    {
        for(int i=0; i < ObjectArray.Count;++i)
        {
            if (ObjectArray[i].player_index == playerindex)
                return ObjectArray[i];
        }

        return null;
    }

    private void Update()
    {
        if (player == null)
        {
            player = Player.GetInstance;
        }
    }

        public void MoveObject(int playerindex,Vector3 position,float Angle)
    {
        Debug.LogError(playerindex+ "_" + position);
        NetObject findNetObject = FindObject(playerindex);
        if(findNetObject == null)
        {
            if (player == null)
            {
                GameObject obj = Instantiate(ObjectPrefab);
                findNetObject = obj.GetComponent<NetObject>();
                findNetObject.CreateObejct(playerindex);
                ObjectArray.Add(findNetObject);
                obj.name = "Net_" + playerindex;
            }else
            {
                GameObject obj = Instantiate(OtherPrefab);
                findNetObject = obj.GetComponent<NetObject>();
                findNetObject.CreateObejct(playerindex);
                ObjectArray.Add(findNetObject);
                obj.name = "Net_" + playerindex;
            }
        }
        findNetObject.TargetPos = position;
        findNetObject.Angle = Angle;
       // findNetObject.transform.position = position;
    }


}
