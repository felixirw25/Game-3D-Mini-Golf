using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Ball ball;
    [SerializeField] LayerMask ballLayer;
    [SerializeField] LayerMask rayLayer;
    [SerializeField] FollowBall cameraPivot;
    [SerializeField] Camera cam;
    [SerializeField] Vector2 camSensitivity;
    [SerializeField] float shootForce;
    [SerializeField] GameObject arrow;
    [SerializeField] Image aim;
    [SerializeField] LineRenderer line;
    [SerializeField] TMP_Text shootCountText;
    Vector3 lastMousePosition;
    float ballDistance;
    bool isShooting;
    Vector3 forceDir;
    float forceFactor;
    Renderer[] arrowRends;
    Color[] arrowOriginalColors;
    int shootCount=0;

    public int ShootCountText { get => shootCount; }

    private void Start(){
        ballDistance = Vector3.Distance(cam.transform.position, ball.Position)+1;
        arrowRends = arrow.GetComponentsInChildren<Renderer>();
        arrowOriginalColors = new Color[arrowRends.Length];
        for(int i=0;i<arrowRends.Length;i++){
            arrowOriginalColors[i] = arrowRends[i].material.color;
        }
        arrow.SetActive(false);
        shootCountText.text = "Attempt: " + shootCount;

        line.enabled=false;
    }
    // Update is called once per frame
    void Update()
    {
        if(ball.IsMoving || ball.IsTeleporting)
            return;

        // if(cameraPivot.isMoving && aim.gameObject.activeInHierarchy==false){
            aim.gameObject.SetActive(true);
            var rectx = aim.GetComponent<RectTransform>();
            rectx.anchoredPosition = cam.WorldToScreenPoint(ball.Position);
        // }
        
        if(this.transform.position != ball.Position){
            this.transform.position = ball.Position;
            aim.gameObject.SetActive(true);
            var rect = aim.GetComponent<RectTransform>();
            rect.anchoredPosition = cam.WorldToScreenPoint(ball.Position);
        }

        if(Input.GetMouseButtonDown(0)){
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            // Debug.DrawLine(ray.origin, ray.origin+ray.direction*100);
            
            if(Physics.Raycast(ray, ballDistance, ballLayer)){
                isShooting=true;
                arrow.SetActive(true);
                line.enabled = true;
            }
        }

        // shooting mode
        if(Input.GetMouseButton(0) && isShooting==true){
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // Debug.DrawRay(ray.origin, ray.origin+ray.direction*100);
            if(Physics.Raycast(ray, out hit, ballDistance*2, rayLayer)){
                Debug.DrawLine(ball.Position, hit.point);
                // Debug.Log(hit.point);
                
                var forceVector = ball.Position-hit.point;
                forceVector = new Vector3(forceVector.x, 0, forceVector.z);
                forceDir = forceVector.normalized;
                var forceMagnitude = forceVector.magnitude; // jarak dalam satuan unit
                forceMagnitude = Mathf.Clamp(forceMagnitude,0,5);
                Debug.Log(forceMagnitude);
                forceFactor = forceMagnitude/5;
            }

            // arrow
            this.transform.LookAt(this.transform.position+forceDir);
            arrow.transform.localScale = new Vector3(1+0.5f*forceFactor, 1+0.5f*forceFactor, 1+2*forceFactor);

            for(int i=0;i<arrowRends.Length;i++){
                arrowRends[i].material.color = Color.Lerp(arrowOriginalColors[i],Color.red,forceFactor);
            }

            // aim
            var rect = aim.GetComponent<RectTransform>();
            rect.anchoredPosition = Input.mousePosition;

            // line
            var ballScrPos = cam.WorldToScreenPoint(ball.Position);
            line.SetPositions(new Vector3[] {ballScrPos, Input.mousePosition});
        }

        // camera mode
        if(Input.GetMouseButton(0) && isShooting==false){
            var current = cam.ScreenToViewportPoint(Input.mousePosition);
            var last = cam.ScreenToViewportPoint(lastMousePosition);
            var delta = current - last;

            cameraPivot.transform.RotateAround(ball.Position,Vector3.up,camSensitivity.x*delta.x);
            cameraPivot.transform.RotateAround(ball.Position,cam.transform.right,camSensitivity.y*(-delta.y));

            var angle = Vector3.SignedAngle(Vector3.up, cam.transform.up, cam.transform.right);
            //Debug.Log(angle);
            if(angle<0){
                cameraPivot.transform.RotateAround(ball.Position,cam.transform.right,0-angle);
            }
            if(angle>70){
                cameraPivot.transform.RotateAround(ball.Position,cam.transform.right,70-angle);
            }
            isShooting=false;
            arrow.SetActive(false);
        }
        
        if(Input.GetMouseButtonUp(0) && isShooting){
            ball.AddForce(forceDir*shootForce*forceFactor);
            shootCount+=1;
            shootCountText.text = "Attempt: " + shootCount;
            forceFactor=0;
            forceDir=Vector3.zero;
            isShooting=false;
            arrow.SetActive(false);
            aim.gameObject.SetActive(false);
            line.enabled = false;
        }

        lastMousePosition = Input.mousePosition;
    }
}
