namespace RetailTherapy.Player

open System
open UnityEngine

type Test() =
    inherit MonoBehaviour()

    member x.Awake() = Debug.Log("I'm awake!")

[<RequireComponent(typeof<Rigidbody2D>)>]
type PlayerMovementController() =
    inherit MonoBehaviour()

    [<Literal>]
    let horizontal = "Horizontal"

    [<Literal>]
    let vertical = "Vertical"

    [<SerializeField>]
    let mutable speed = 2.0f

    let mutable rb = Unchecked.defaultof<Rigidbody2D>
    let mutable tf = Unchecked.defaultof<Transform>
    let mutable inp = Vector2()

    member __.Awake() = 
        tf <- __.GetComponent<Transform>()
        rb <- __.GetComponent<Rigidbody2D>()

    member __.Update() =
        inp.x <- Input.GetAxis(horizontal)
        inp.y <- Input.GetAxis(vertical)

    member __.FixedUpdate() =
        rb.MovePosition(Vector2(tf.position.x,tf.position.y) + inp * speed)

[<RequireComponent(typeof<Rigidbody2D>)>]
type PlayerRotationController() =
    inherit MonoBehaviour()

    [<SerializeField>]
    let mutable speed = 2.0f

    let mutable gm = Unchecked.defaultof<RetailTherapy.Game.GameManager>
    let mutable rb = Unchecked.defaultof<Rigidbody2D>
    let mutable tf = Unchecked.defaultof<Transform>
    let mutable angle = 0.f

    member __.Awake() =
        gm <- GameObject.FindObjectOfType<RetailTherapy.Game.GameManager>() 
        tf <- __.GetComponent<Transform>()
        rb <- __.GetComponent<Rigidbody2D>()

    member __.Update() =
        let v = Input.mousePosition - (Camera.main.WorldToScreenPoint(tf.position))
        angle <- Mathf.Atan2(v.x, v.y) * Mathf.Rad2Deg
    
    member __.FixedUpdate() =
        rb.MoveRotation(-angle)  
        
type PlayerGunController() =
    inherit MonoBehaviour()
    
    [<SerializeField>]
    let mutable spray = Unchecked.defaultof<ParticleSystem>

    member __.Update() =
        while Input.GetMouseButtonDown(0) && spray.isStopped do
            spray.Play()
            if Input.GetMouseButtonUp(0) then
                spray.Stop()
    
      