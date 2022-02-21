using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FrogController : MonoBehaviour
{
    [SerializeField] private float jumpHeight;
    [SerializeField] private Vector3 landingOffset;
    [SerializeField] LayerMask leafLayer;


    [SerializeField] Material highLightedMaterial;


    public void Update()
    {
        Jump();
    }
   
    private void Jump()
    {
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hit,Mathf.Infinity,leafLayer))
        {
            

            if(Input.GetMouseButtonDown(0))
            {
                if (Vector3.Distance(this.transform.position, hit.transform.position) > 10) return;  //too long to take a jump


                hit.transform.GetComponent<MeshRenderer>().material = highLightedMaterial;
                this.transform.DOJump(hit.transform.position + landingOffset, jumpHeight, 1, 0.6f); //DOTween package is used
            }
           
           
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Spike"))
        {
            GameManager.instance.GameOver();
        }
    }
   
    //public void Jump(Vector3 jumpPoint)
    //{
    //float interp;
    // Vector3 landPoint = Vector3.Lerp(this.transform.position, jumpPoint,interp)
    //landPoint.y += Mathf.Sin(Mathf.PI * interp)* jumpHeight;
    //this.transform.position = landPoint;
    //interp += Time.deltaTime* speed;
    //}


}
