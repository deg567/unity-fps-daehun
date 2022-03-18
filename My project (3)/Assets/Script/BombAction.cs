using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffect;
    public float currentTime = 0f;

    // 충돌체 처리 함수 구현
    private void OnCollisionStay(Collision collision)
    {   
        if(currentTime>=3f)
        {
        // 이펙트 프리팹 생성
        GameObject eff = Instantiate(bombEffect);

        // 이펙트 프리팹 위치 설정 
        eff.transform.position = transform.position;

        //자기 오브젝트를 제거 
        Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
    }


}
