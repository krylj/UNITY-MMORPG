using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class SpellDrawing : MonoBehaviour
{
    public GameObject nodePrefab;
    public LineRenderer lineRenderer;
    public Transform canvas;
    public Text spellOutput;

    private List<Vector2> drawnNodes = new List<Vector2>();
    private bool isDrawing = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDrawing();
        }
        else if (Input.GetMouseButton(0) && isDrawing)
        {
            Draw();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndDrawing();
        }
    }

    void StartDrawing()
    {
        drawnNodes.Clear();
        lineRenderer.positionCount = 0;
        isDrawing = true;
    }

    void Draw()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (drawnNodes.Count == 0 || Vector2.Distance(drawnNodes[drawnNodes.Count - 1], mousePos) > 0.2f)
        {
            drawnNodes.Add(mousePos);
            lineRenderer.positionCount = drawnNodes.Count;
            lineRenderer.SetPosition(drawnNodes.Count - 1, mousePos);
        }
    }

    void EndDrawing()
    {
        isDrawing = false;
        RecognizeSpell();
    }

    void RecognizeSpell()
    {
        if (drawnNodes.Count > 2) // Jednoduchá logika pro testovací kouzlo
        {
            spellOutput.text = "Fireball";
        }
        else
        {
            spellOutput.text = "Unknown Spell";
        }
    }
}
