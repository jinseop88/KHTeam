using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterSpawner : MonoBehaviour
{
    public class Request
    {
        public Request(GameObject monsterPrefab, int monsterCount)
        {
            this.monsterPrefab = monsterPrefab;
            this.monsterCount = monsterCount;
        }

        public GameObject MonsterPrefab
        {
            get
            {
                return monsterPrefab;
            }
        }

        public int MonsterCount
        {
            get
            {
                return monsterCount;
            }
        }

        private GameObject monsterPrefab;
        private int monsterCount;
    }

    private Queue<Request> requests = new Queue<Request>();

    public void SendRequest(Request request)
    {
        requests.Enqueue(request);
    }

    private void Start()
    {
        StartCoroutine(ProcessingRequest());
    }

    private IEnumerator ProcessingRequest()
    {
        while (true)
        {
            if (requests.Count != 0)
            {
                yield return StartCoroutine(ActionMonsters(requests.Dequeue()));
            }
            else
            {
                yield return new WaitUntil(() => requests.Count != 0);
            }
        }
    }

    private IEnumerator ActionMonsters(Request request)
    {
        int standbyMonsterCount = request.MonsterCount;

        do
        {
            Monster monster = ((GameObject)Instantiate(request.MonsterPrefab, transform.position, transform.rotation)).GetComponent<Monster>();
            monster.thisTransform.parent = transform.parent;

            yield return new WaitUntil(() => monster == null);
        } while (--standbyMonsterCount != 0);
    }
}
