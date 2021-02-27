using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharackterController : MonoBehaviour
{
    public static CharackterController instance;
    public Rigidbody rb;
    public Animator anim;
    public float moveSpeed;
    public HealthSystem healthSystem;

    public bool isAttacking;
    public AnimationListener animationListener;
    public Tree lastcuttingtree;
    public Transform pivot;
    public LayerMask collactible;
    public CharackterShoulderInventory charackterShoulderInventory;
    public LayerMask constructionmask;
    public LayerMask buildmask;
    public LayerMask treemask;
    public bool ısEnter;

    public ParticleSystem footStep;

    public float environmentTimer = 0.33f;

    public int allwoodCount;

    public void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        healthSystem = GetComponent<HealthSystem>();
    }
    public void Start()
    {
        animationListener.allAnims.Add(new AnimationListener.Animationprofil(AnimationListener.AnimType.attacking, () =>
        {
            lastcuttingtree?.Cutting();
        }));
        animationListener.allAnims.Add(new AnimationListener.Animationprofil(AnimationListener.AnimType.attackend, () =>
        {

            isAttacking = false;
        }
      ));
        animationListener.allAnims.Add(new AnimationListener.Animationprofil(AnimationListener.AnimType.walkingstart, () =>
        {
            footStep.Play();
            Debug.Log("Başladı");
        }));
        animationListener.allAnims.Add(new AnimationListener.Animationprofil(AnimationListener.AnimType.walkingend, () =>
        {
            footStep.Stop();
            Debug.Log("Bitti");
        }));

    }
    public void Update()
    {
        float rightleft = Input.GetAxis("Horizontal");
        float updown = Input.GetAxis("Vertical");

        Movement(rightleft, updown, Input.GetKey(KeyCode.LeftShift) ? 1 : 0.4f);
        DetectionEnvironmentController();

    }
    public void Movement(float x, float z, float deltaspeed = 0.4f)
    {

        if (x == 0 && z == 0)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            anim.SetBool("walking", false);
            anim.SetBool("running", false);
            return;

        }

        rb.velocity = new Vector3(x, rb.velocity.y, z) * moveSpeed * deltaspeed;
        anim.SetBool("walking", true);
        anim.SetBool("running", deltaspeed > 0.4f);
        Vector3 target = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);
        float angley = Mathf.Atan2(target.x, target.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angley + 180, Vector3.up), 0.05f);

    }

    public void DetectionEnvironmentController()
    {
        environmentTimer -= Time.deltaTime;
        if (environmentTimer > 0) return;
        environmentTimer = 0.33f;

        if (isAttacking) return;
        pivot.AimAngledCircleOverlap(3,treemask, (Transform touched) =>
            {
                CutTree(touched);
            }, 45);

        transform.AimAngledCircleOverlap(3f, collactible, (Transform touched) =>
        {
            CollectingObjects col = touched.GetComponent<CollectingObjects>();
            if (col)
            {
                col.MagnetToPoint(() =>
                {
                    if (col is CollectibleWood)
                    {
                        allwoodCount++;
                        charackterShoulderInventory.SyncItem(allwoodCount);
                    }
                    Destroy(touched.gameObject);
                }, charackterShoulderInventory.transform.position);
            }
            else
            {
                throw new System.Exception("Not collactable");
            }
        }, 180f);


        transform.AimAngledCircleOverlap(3f, constructionmask, (Transform build) =>
        {
            if (allwoodCount == 0) return;
            allwoodCount--;
            charackterShoulderInventory.SyncItem(allwoodCount);
            build.GetComponent<Construction>().BuildConstruction();
            charackterShoulderInventory.ThrowWood(build.position);
        }, 45f);
        transform.AimAngledCircleOverlap(3f, buildmask, (Transform x) =>
        { 
            if(x.GetComponent<BuildBase>())
            {
                BuildInteraction(x.GetComponent<BuildBase>());
            }
        }, 90);
    }
    public void BuildInteraction(BuildBase buildBase)
    {
        if (buildBase.PercenTime < 1) return;
        if (buildBase is HospitalBuild)
        {
            buildBase.Interact(new System.Action<int>((int x) =>
            {
                healthSystem.health += x;
            }));
        }
        else if (buildBase is WoodBuild)
        {
            buildBase.Interact(new System.Action<int>((int y) =>
            {
                allwoodCount += y;
                charackterShoulderInventory.SyncItem(allwoodCount);
            }));


        }
        else if(buildBase is EnternewWorldBuild)
        {
            buildBase.Interact();

               
          

            



        }
    }
    public void CutTree(Transform tree)
    {
        lastcuttingtree = tree.GetComponent<Tree>();
        anim.SetTrigger("axe");
        isAttacking = true;
    }
    
}
