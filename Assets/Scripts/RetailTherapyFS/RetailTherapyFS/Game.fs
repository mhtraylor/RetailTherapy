namespace RetailTherapy.Game

open System
open UnityEngine

type GameManager() =
    inherit MonoBehaviour()

    [<SerializeField>]
    let mutable debug = false;

    member __.IsDebug
        with get() = debug

