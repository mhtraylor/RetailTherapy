namespace RetailTherapy.Player

open System
open UnityEngine

type Test() =
    inherit MonoBehaviour()

    member x.Awake() = Debug.Log("I'm awake!")

