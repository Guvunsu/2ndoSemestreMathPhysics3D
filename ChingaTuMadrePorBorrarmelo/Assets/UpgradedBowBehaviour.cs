//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class UpgradedBowBehaviour : MonoBehaviour
//{
//    public float bowCompression;       // Que tanto se comprime el arco (0.75)
//    public float arrowMaxSpeed;        // Rapidez máxima de la flecha (50)
//    public float arrowMaxDisplacement; // Desplazamiento máximo de la flecha (0.5)
//    public float pullSpeed;            // Qué tan rapido se tensa el arco (1)
//    public float releaseSpeed;         // Qué tan rápido se "destensa" el arco (30)
//    public Material[] bowMaterials;

//    public GameObject arrowPrefab;

//    private Transform[] points;
//    private bool applyingTension;
//    private GameObject arrow;
//    private Transform shootPoint;

//    void Start()
//    {
//        CreateChordPoints();
//        SetLineRenderer();
//        GetComponent<MeshRenderer>().material = bowMaterials[0];
//    }

//    void Update()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            applyingTension = true;
//            SetArrow();
//        }

//        if (applyingTension)
//            PullArrow();
//        else
//            ReleaseArrow();

//        if (Input.GetMouseButtonUp(0))
//        {
//            applyingTension = false;
//            FireArrow();
//        }

//    }

//    private void LateUpdate()
//    {
//        DrawChord();
//    }

//    void DrawChord()
//    {
//        Vector3[] pointPositions = new Vector3[] { points[0].position,
//                                                   points[1].position,
//                                                   points[2].position };

//        GetComponent<LineRenderer>().SetPositions(pointPositions);
//    }

//    void SetArrow()
//    {
//        arrow = Instantiate(arrowPrefab, shootPoint.position, shootPoint.rotation);
//        arrow.GetComponent<KinematicArrow>().shootPoint = shootPoint;
//    }

//    void PullArrow()
//    {
//        float dt = Time.deltaTime;
//        Vector3 newPosition = new Vector3(0, 0, -arrowMaxDisplacement);
//        points[1].localPosition = Vector3.Lerp(points[1].localPosition, newPosition, pullSpeed * dt);

//        Vector3 newScale = new Vector3(bowCompression, 1, 1);
//        transform.localScale = Vector3.Lerp(transform.localScale, newScale, pullSpeed * dt);
//    }

//    void ReleaseArrow()
//    {
//        float dt = Time.deltaTime;
//        Vector3 newPosition = Vector3.zero;
//        points[1].localPosition = Vector3.Lerp(points[1].localPosition, newPosition, releaseSpeed * dt);

//        Vector3 newScale = Vector3.one;
//        transform.localScale = Vector3.Lerp(transform.localScale, newScale, releaseSpeed * dt);
//    }

//    void FireArrow()
//    {
//        float normArrowDisplacement = points[1].localPosition.magnitude / arrowMaxDisplacement;
//        arrow.GetComponent<KinematicArrow>().P0 = shootPoint.position;
//        arrow.GetComponent<KinematicArrow>().V0 = arrowMaxSpeed * normArrowDisplacement * shootPoint.forward;
//        arrow.GetComponent<KinematicArrow>().fired = true;
//        arrow.GetComponent<TrailRenderer>().emitting = true;
//    }

//    void SetLineRenderer()
//    {
//        this.gameObject.AddComponent<LineRenderer>();
//        GetComponent<LineRenderer>().widthMultiplier = 0.05f;
//        GetComponent<LineRenderer>().positionCount = 3;
//        GetComponent<LineRenderer>().material = bowMaterials[2];
//    }

//    void CreateChordPoints()
//    {
//        GameObject pt0 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
//        GameObject pt1 = new GameObject();
//        GameObject pt2 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
//        GameObject sp = new GameObject();

//        pt0.GetComponent<MeshRenderer>().material = bowMaterials[1];
//        pt2.GetComponent<MeshRenderer>().material = bowMaterials[1];

//        pt0.name = "Point (0)";
//        pt1.name = "Point (1)";
//        pt2.name = "Point (2)";
//        sp.name = "ShootPoint";

//        pt0.transform.parent = transform;
//        pt1.transform.parent = transform;
//        pt2.transform.parent = transform;

//        pt0.transform.localScale = new Vector3(0.15f, 0.05f, 0.15f);
//        pt2.transform.localScale = new Vector3(0.15f, 0.05f, 0.15f);

//        pt0.transform.localRotation = Quaternion.Euler(90, 0, 0);
//        pt2.transform.localRotation = Quaternion.Euler(90, 0, 0);

//        pt0.transform.localPosition = new Vector3(1f, 0f, 0f);
//        pt2.transform.localPosition = new Vector3(-1f, 0f, 0f);

//        sp.transform.parent = pt1.transform;
//        sp.transform.localPosition = Vector3.zero;
//        shootPoint = sp.transform;

//        points = new Transform[] { pt0.transform, pt1.transform, pt2.transform };

