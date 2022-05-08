using UnityEngine;

public class StorageObjectPointer : MonoBehaviour
{
    private StorageObject intanceRef;

    public StorageObject IntanceRef { get => intanceRef; set => intanceRef = value; }
}
