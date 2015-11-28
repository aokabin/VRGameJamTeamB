using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    enum ActionID {
        None,
        Walk,
        Atk
    };
    public int EnemyHP = 30;//敵の体力
    public float EnemyMoveSpeed = 0.5f;//敵の動く速さ
    public float EnemyMoveDistance = 60;//敵の動ける範囲

    private NavMeshAgent agent;// the navmesh agent required for the path finding


    public Transform target;
    private Vector3 StartPosition;

    private ActionID Action = ActionID.None;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        StartPosition = this.transform.position;
        Random.seed = (int)System.DateTime.Now.Second * System.DateTime.Now.Minute + System.DateTime.Now.Hour + System.DateTime.Now.Month;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 vec3;
        if (target) {
            if (Action == ActionID.None)
            {
                //ランダムで目的地を変える
                Action = ActionID.Walk;
                vec3.x = Random.Range(-EnemyMoveDistance, EnemyMoveDistance);
                vec3.y = 0;
                vec3.z = Random.Range(-EnemyMoveDistance, EnemyMoveDistance);
                target.transform.localPosition = vec3;
            }
        }
	}
    void FixedUpdate()
    {
        #region ***敵を動かす処理***
        if (Action == ActionID.Walk)
        {
            if (target) agent.SetDestination(target.position);
        }
        #endregion
    }
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Target"))
            Action = ActionID.None;
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            //EnemyHP--;
            print("Hit Enemy");
        }
    }
}
