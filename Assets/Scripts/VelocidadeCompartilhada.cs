using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Variavel Compartilhada", menuName = "Variavel Compartilhada / velocidade")]

public class VelocidadeCompartilhada : ScriptableObject {

	[Range (1, 10)] public float velocidade;
}
