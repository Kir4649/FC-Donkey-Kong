using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject ball;
    public Transform bulletPoint;       // �e�̔��ˈʒu�i�q�I�u�W�F�N�g�
    private Rigidbody2D rb;
    private bool rightGround = false;
    private bool leftGround = false;
    private float time = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
           
            GameObject shotObj = Instantiate(ball, bulletPoint.position, bulletPoint.rotation);
            time = 3.0f;
        }
       
        //if (Probability(80))
        //{
        //    time -= Time.deltaTime;
        //    if(time < 0)
        //    {
        //        Debug.Log("弾出すよ");
        //        time = 1.0f;
        //        GameObject shotObj = Instantiate(ball, bulletPoint.position, bulletPoint.rotation);
        //    }

        //}
        //if (Probability(10))
        //{
        //    time -= Time.deltaTime;
        //    if (time <= 0)
        //    {
        //        time = 1.0f;
        //        StartCoroutine(a());
        //    }
        //}
        //if (Probability(10))
        //{

        //}
    }
    //IEnumerator a()
    //{
    //    for(int i = 0; i < 2; i++)
    //    {
    //        GameObject shotObj = Instantiate(ball, bulletPoint.position, bulletPoint.rotation);
    //        yield return null;
    //    }
    //}    
    //public static bool Probability(float fPercent)
    //{
    //    float fProbabilityRate = UnityEngine.Random.value * 100.0f;

    //    if (fPercent == 100.0f && fProbabilityRate == fPercent)
    //    {
    //        return true;
    //    } else if (fProbabilityRate < fPercent)
    //    {
    //        return false;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    
}
