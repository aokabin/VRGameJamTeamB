using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour
{
    #region***PlayerControll2の変数***
    
    public float PlayerFallSpeed = 1.0f;//プレイヤーの落ちる速さ
    public int ShotTime = 60;//弾の打つ間隔
    public GameObject Bullet;//プレイヤーから発射される弾

    private int ShotTimeCount = 0;//弾の打つ間隔を数える

    #endregion
    public float power = 1.0f;
    public float score = 1.0f;
    public Text scoretext;
    //#region***GUI***
    //public Texture3D Text;
    //#endregion

    // Use this for initialization
	void Start () {
        //Text.text = "Score : " + score.ToString();
        //Text.
	}
	
	// Update is called once per frame
	void Update ()
    {
        scoretext.text = "Score : " + score;
        //Text.
        #region***射撃の処理***
        //ショットをカウントする
        ShotTimeCount++;
        //特定の操作が行われたら
        if (Input.GetKey("up"))
        {
            //生成されるオブジェクト
            GameObject CreatObject;
            if(ShotTimeCount > ShotTime){
                if(Bullet){
                    ShotTimeCount = 0;
                    //弾の生成
                    CreatObject = (GameObject)Instantiate(Bullet, this.transform.position, this.transform.rotation);
                    CreatObject.transform.Rotate(90,0,0);
                }
            }
        }
        #endregion
    }

    void FixedUpdate()
    {
        #region***落下処理***
        Vector3 vec3;
        vec3 = this.transform.localPosition;
        vec3.y -= PlayerFallSpeed;
        this.transform.localPosition = vec3;
        #endregion
    }

    public void PowerUP()
    {
        Debug.Log("Power UP!!");
        power *= 2.0f;
    }

    public void ScoreUP()
    {
        Debug.Log("Score UP!!");
        score *= 1.1f;
    }
}
