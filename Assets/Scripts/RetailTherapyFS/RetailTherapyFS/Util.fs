namespace RetailTherapy.Util

open System
open UnityEngine

[<ExecuteInEditMode>]
type DrawExents() =
    inherit MonoBehaviour()

    [<SerializeField>]
    let mutable extents = Vector3()

    [<SerializeField>]
    let mutable color = Color.green

    member __.OnDrawGizmos() =
        Gizmos.color <- color
        Gizmos.DrawWireCube(__.transform.position, extents)