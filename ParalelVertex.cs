using UnityEngine;
using System;
using System.Threading.Tasks;

public class ParalelVertex : MonoBehaviour
{
    void Awake()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh; //Acessa o Mesh
        Vector3[] verts = mesh.vertices; //Salva os vertices do mesh
        System.Random random = new System.Random((int)DateTime.UtcNow.Ticks); //Unity Random não funciona com PP (?), Usei do C# mesmo


        Parallel.For(0, verts.Length, (i) => //Percorre todos os vertices
        {
            verts[i] = Quaternion.Euler((float)random.NextDouble() * 360.0f, (float)random.NextDouble() * 360.0f, (float)random.NextDouble() * 360.0f) * verts[i]; // Aplica a rotação nos vertices 
        });

        mesh.vertices = verts; // Aplicando os valores de rotação do Vector3 verts nos vertices do mesh
        mesh.RecalculateNormals(); // Recalculca o mapa de normal para corrigir erros de faces
    }
}