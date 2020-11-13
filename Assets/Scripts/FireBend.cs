using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBend : MonoBehaviour
{
    private Transform transformComponent;

    private Vector3 prevPos;
    public Vector3 velocity;
    private Vector3 smoothVel;
    private Vector3 refVel;
    public MeshRenderer fireMeshRenderer;

    private Material fireMat;

    public float velocityDamp = 2;

    public float smoothTime = 0.2f;

    public Vector3 worldRot;

    private Vector3 startRot;
    // Start is called before the first frame update
    void Start()
    {
        transformComponent = GetComponent<Transform>();
        prevPos = transformComponent.position;

        fireMeshRenderer = GetComponent<MeshRenderer>();
        fireMat = fireMeshRenderer.material;
        startRot = transformComponent.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        worldRot = transformComponent.rotation.eulerAngles;
        velocity = (transformComponent.position - prevPos) / Time.deltaTime;
        
        prevPos = transformComponent.position;
        
        smoothVel = Vector3.SmoothDamp(smoothVel, velocity / velocityDamp, ref refVel, smoothTime);
        fireMat.SetVector("Velocity", new Vector3(- smoothVel.x, smoothVel.z, -smoothVel.y));
        transformComponent.rotation = Quaternion.Euler(startRot);
    }
}
