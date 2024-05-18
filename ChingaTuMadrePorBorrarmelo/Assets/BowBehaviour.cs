using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BowBehaviour : MonoBehaviour
{

    public Transform[] points;
    public Transform shootPoint;
    public GameObject arrowPrefab;


    public float bowCompression;       // Que tanto se comprime el arco (0.75)
    public float arrowMaxSpeed;        // Rapidez máxima de la flecha (50)
    public float arrowMaxDisplacement; // Desplazamiento máximo de la flecha (0.5)
    public float pullSpeed;            // Qué tan rapido se tensa el arco (1)
    public float releaseSpeed;         // Qué tan rápido de "destensa" el arco (30)

    public RectTransform crossHair;
    public LayerMask layerMask;

    bool applyingTension;
    private GameObject arrow;

    void Start()
    {
        this.gameObject.AddComponent<LineRenderer>();
        GetComponent<LineRenderer>().widthMultiplier = 0.05f;
        GetComponent<LineRenderer>().positionCount = 3;
        shootPoint.localPosition = new Vector3(0, 0, 0.4f);
    }

    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            applyingTension = true;
            SetArrow();
        }

        if (applyingTension)
            PullArrow();
        else
            ReleaseArrow();

        if (Input.GetMouseButtonUp(0))
        {
            applyingTension = false;
            FireArrow();
        }
        if (applyingTension)
        {
            PullArrow();

        }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out hit, Mathf.Infinity, layerMask))
        {
            Vector3 hitPosition = hit.point;
            crossHair.position = Camera.main.WorldToScreenPoint(hitPosition);
        }
        else
        {
            // crossHair.GetComponent<RawImage>().enabled = true; 
            //le cambie a false a true 

            crossHair.anchoredPosition = Vector3.zero;
        }
    }

    private void LateUpdate()
    {
        DrawChord();
    }

    void DrawChord()
    {
        Vector3[] pointPositions = new Vector3[] { points[0].position,
                                                   points[1].position,
                                                   points[2].position };

        GetComponent<LineRenderer>().SetPositions(pointPositions);
    }

    void SetArrow()
    {
        arrow = Instantiate(arrowPrefab, shootPoint.position, shootPoint.rotation);
        arrow.GetComponent<KineticArrow>().shootPoint = shootPoint;
    }

    void PullArrow()
    {
        float dt = Time.deltaTime;
        Vector3 newPosition = new Vector3(0, 0, -arrowMaxDisplacement);
        points[1].localPosition = Vector3.Lerp(points[1].localPosition, newPosition, pullSpeed * dt);

        Vector3 newScale = new Vector3(bowCompression, 1, 1);
        transform.localScale = Vector3.Lerp(transform.localScale, newScale, pullSpeed * dt);
    }





    void ReleaseArrow()
    {
        float dt = Time.deltaTime;
        Vector3 newPosition = Vector3.zero;
        points[1].localPosition = Vector3.Lerp(points[1].localPosition, newPosition, releaseSpeed * dt);

        Vector3 newScale = Vector3.one;
        transform.localScale = Vector3.Lerp(transform.localScale, newScale, releaseSpeed * dt);
    }

    void FireArrow()
    {
        float normArrowDisplacement = points[1].localPosition.magnitude / arrowMaxDisplacement;
        arrow.GetComponent<KineticArrow>().P0 = shootPoint.position;
        arrow.GetComponent<KineticArrow>().V0 = arrowMaxSpeed * normArrowDisplacement * shootPoint.forward;
        arrow.GetComponent<KineticArrow>().fired = true;
        arrow.GetComponent<TrailRenderer>().emitting = true;
    }

    //public Transform[] points;
    //public GameObject arrowPrefab;
    //public Transform shootPoint;
    //public float arrowMaxSpeed;
    //bool applyingTension;
    //private GameObject arrow;

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    DrawChord();
    //    float dt = Time.deltaTime;
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        applyingTension = true;
    //        arrow = Instantiate(arrowPrefab, shootPoint.position, shootPoint.rotation);
    //        arrow.GetComponent<KineticArrow>().shootPoint = shootPoint;
    //    }

    //    if (applyingTension)
    //    {
    //        Vector3 newPosition = new Vector3(0, 0, -0.5f);
    //        points[1].position = Vector3.Lerp(points[1].localPosition, newPosition, dt);
    //        Vector3 newScale = new Vector3(0.75f, 1, 1);
    //        transform.localScale = Vector3.Lerp(transform.localScale, newScale, dt);
    //    }
    //    else
    //    {
    //        Vector3 newPosition = new Vector3(0, 0, 0);
    //        points[1].position = Vector3.Lerp(points[1].localPosition, newPosition, 30 * dt);
    //        Vector3 newScale = new Vector3(1, 1, 1);
    //        transform.localScale = Vector3.Lerp(transform.localScale, newScale, 30 * dt);
    //    }
    //}
    //void DrawChord()
    //{
    //    Vector3[] pointPosition = new Vector3[] {points[0].position,
    //                                                points[1].position,
    //                                                   points[2].position};
    //    GetComponent<LineRenderer>().SetPositions(pointPosition);
    //}
}
