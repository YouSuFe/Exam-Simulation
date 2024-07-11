using UnityEditor;
using UnityEngine;
using System.Linq;

public class IncrementalRenamer : EditorWindow
{
    // Variable to hold the base name for renaming objects
    private string baseName = "Book";

    // Menu item to open the Incremental Renamer window
    [MenuItem("Tools/Incremental Renamer")]
    public static void ShowWindow()
    {
        // Create and show the Incremental Renamer window
        GetWindow<IncrementalRenamer>("Incremental Renamer");
    }

    // Method to draw the GUI for the Incremental Renamer window
    private void OnGUI()
    {
        // Label for the base name input field
        GUILayout.Label("Base Name", EditorStyles.boldLabel);

        // Input field to enter the base name
        baseName = EditorGUILayout.TextField("Base Name", baseName);

        // Button to trigger the renaming of selected objects
        if (GUILayout.Button("Rename Selected"))
        {
            RenameSelectedObjects();
        }
    }

    // Method to rename the selected objects incrementally
    private void RenameSelectedObjects()
    {
        // Get the currently selected game objects in the scene
        var selectedObjects = Selection.gameObjects;

        // Sort the selected objects by their order in the hierarchy
        var sortedObjects = selectedObjects.OrderBy(go => go.transform.GetSiblingIndex()).ToArray();

        // Loop through each sorted object
        for (int i = 0; i < sortedObjects.Length; i++)
        {
            // Construct the new name based on the base name and an incrementing index
            string newName = baseName;
            if (i > 0)
            {
                newName += $" ({i})";
            }

            // Record the current state of the object for undo functionality
            Undo.RecordObject(sortedObjects[i], "Rename Objects");

            // Set the new name to the object
            sortedObjects[i].name = newName;
        }
    }
}
