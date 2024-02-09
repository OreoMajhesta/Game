using UnityEngine;
using UnityEngine.Tilemaps;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private Tilemap groundTilemap; // Reference to the ground Tilemap

    private void Start()
    {
        // Spawn or move the existing player to a random position within the terrain
        MoveOrSpawnPlayer();
    }

    private void MoveOrSpawnPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // Assuming "Player" is the tag of your player object

        if (player == null)
        {
            Debug.LogError("Player not found in the scene. Make sure the player has the correct tag.");
            return;
        }

        if (groundTilemap == null)
        {
            Debug.LogError("Ground Tilemap not assigned in Character Spawner.");
            return;
        }

        // Get the bounds of the tilemap
        BoundsInt bounds = groundTilemap.cellBounds;

        // Get a random position within the bounds of the tilemap
        Vector3Int randomCellPosition = new Vector3Int(
            Random.Range(bounds.x, bounds.x + bounds.size.x),
            Random.Range(bounds.y, bounds.y + bounds.size.y),
            bounds.z
        );

        // Convert the random cell position to world position
        Vector3 spawnPosition = groundTilemap.GetCellCenterWorld(randomCellPosition);

        // Set the position of the player to the randomly calculated position
        player.transform.position = new Vector3(spawnPosition.x, spawnPosition.y, player.transform.position.z);
    }
}
