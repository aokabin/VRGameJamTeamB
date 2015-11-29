using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    enum ActionID {
        None,
        Walk,
        Atk1,
        Atk2,
        Atk3,
        ReMove
    };
    public int EnemyHP = 30;//敵の体力
    public float EnemyMoveSpeed = 0.5f;//敵の動く速さ
    public float EnemyMoveDistance = 60;//敵の動ける範囲

    private NavMeshAgent agent;// the navmesh agent required for the path finding


    public Transform target;

    private ActionID Action = ActionID.ReMove;
    private Animation EnemyAnime;
    private bool FirstFpsAnime = false;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        EnemyAnime = GetComponent<Animation>();
        if(EnemyAnime)EnemyAnime.wrapMode = WrapMode.Once;
        Random.seed = (int)System.DateTime.Now.Second * System.DateTime.Now.Minute + System.DateTime.Now.Hour + System.DateTime.Now.Month;

	}
	
	// Update is called once per frame
	void Update () {
        #region***アニメーション***

        if(Action == ActionID.Walk){
          EnemyAnime.Play("walk");
        }
        else if (Action == ActionID.Atk1)
        {
            #region***攻撃1***
            if (FirstFpsAnime == false && !EnemyAnime.IsPlaying("attack1"))
            {
                Action = ActionID.ReMove;
            }
            else
            {
                EnemyAnime.Play("attack1");
            }
            #endregion
        }
        else if (Action == ActionID.Atk2)
        {
            #region***攻撃2***
            if (FirstFpsAnime == false && !EnemyAnime.IsPlaying("attack2"))
            {
                Action = ActionID.ReMove;
            }
            else
            {
                EnemyAnime.Play("attack2");
            }
            #endregion
        }
        else if (Action == ActionID.Atk3)
        {
            #region***攻撃3***
            if (FirstFpsAnime == false && !EnemyAnime.IsPlaying("attack3"))
            {
                Action = ActionID.ReMove;
            }
            else
            {
                EnemyAnime.Play("attack3");
            }
            #endregion
        }

        EnemyRandamAnimePlay();
        #endregion
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
        #region***アニメーションのランダムな選択***
        if (col.gameObject.CompareTag("Target"))
        {
            Action = ActionID.ReMove;
            EnemyRandamAnimePlay();
        }
        #endregion
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            //EnemyHP--;
            print("Hit Enemy");
        }
    }

    void EnemyRandamAnimePlay() {
        if (Action == ActionID.ReMove)
        {
            FirstFpsAnime = true;
            switch (Random.Range(0, 4))
            {
                case 0:
                    Action = ActionID.Atk1;
                    print("atk1");
                    break;
                case 1:
                    Action = ActionID.Atk2;
                    print("atk2");
                    break;
                case 2:
                    Action = ActionID.Atk3;
                    print("atk3");
                    break;
                default:
                        Action = ActionID.Walk;
                    break;
            }
            Vector3 vec3;
            if (target)
            {
                //ランダムで目的地を変える
                vec3.x = Random.Range(-EnemyMoveDistance, EnemyMoveDistance);
                vec3.y = 0;
                vec3.z = Random.Range(-EnemyMoveDistance, EnemyMoveDistance);
                target.transform.localPosition = vec3;
            }
        }
        else
        {
            FirstFpsAnime = false;
        }
    }
}
