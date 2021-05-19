using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRaycasting : MonoBehaviour
{
    [SerializeField] float range;

    private Interactable currentTarget;
    private Camera mainCam;
    LayerMask noPlayer = ~(1<<8);
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RayCastForInteract();

        if(Input.GetKeyDown(KeyCode.E)){
            if(currentTarget != null){
                currentTarget.OnInteract();
            }
            //Debug.Log("working");
        }
    }

    private void RayCastForInteract(){
        RaycastHit aiming;

        //Ray ray = mainCam.ViewportPointToRay(new Vector3(0.5f,0.5f,.5f));
        //Ray ray = new Ray(transform.position, mainCam.transform.position-transform.position);
        if(Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out aiming, range)){
            Interactable interaction = aiming.collider.GetComponent<Interactable>();
            if (interaction != null){
                if(aiming.distance <= interaction.maxRange){
                    if(currentTarget == null){
                        currentTarget = interaction;
                        currentTarget.OnHoverStart();
                    }else if(currentTarget != interaction){
                        currentTarget.OnHoverEnd();
                        currentTarget = interaction;
                        currentTarget.OnHoverStart();
                    }
                }else{
                    if (currentTarget != null){
                        currentTarget.OnHoverEnd();
                        currentTarget = null;
                    }
                }
            }else{
                if (currentTarget != null){
                        currentTarget.OnHoverEnd();
                        currentTarget = null;
                    }
            }
        }else{
            if (currentTarget != null){
                currentTarget.OnHoverEnd();
                currentTarget = null;
            }
        }
    }
}

