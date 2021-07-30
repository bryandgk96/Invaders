using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ReSharper disable All

public class DataController : MonoBehaviour
{
    [System.Serializable]
    public struct EstDatos
    {
        [System.Serializable]
        public struct EstRegistro
        {
            public string nombre;
            public int puntaje;
        }

        public List<EstRegistro> registros;
    }

    public EstDatos datos;

    [ContextMenu("Leer")]
    public void Leer()
    {
        StartCoroutine(CorrutinaLeer());
    }

    private IEnumerator CorrutinaLeer()
    {
        throw new System.NotImplementedException();
    }
}
