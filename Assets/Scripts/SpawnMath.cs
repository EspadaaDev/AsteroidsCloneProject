using UnityEngine;

public class SpawnMath
{
    // Lower border of objects spawn
    private Vector2 _lowerSpawnBorder;
    // Upper border of objects spawn
    private Vector2 _upperSpawnBorder;

    // Constructor
    public SpawnMath(Vector2 lowerSpawnBorder, float spawnIdent)
    {
        if(spawnIdent < 0)
        {
            spawnIdent *= -1;
        }

        _lowerSpawnBorder = lowerSpawnBorder;
        _upperSpawnBorder = new Vector2(lowerSpawnBorder.x + spawnIdent, lowerSpawnBorder.y + spawnIdent);
    }

    // Return random position for spawn object within the given framework
    public Vector2 GetRandomSpawnPosition()
    {
        // Quarter selection
        switch (Random.Range(0, 4))
        {
            case 0:
                return new Vector2(Random.Range(-_upperSpawnBorder.x, _upperSpawnBorder.x)
            , Random.Range(_lowerSpawnBorder.y, _upperSpawnBorder.y));
            case 1:
                return new Vector2(Random.Range(-_upperSpawnBorder.x, _upperSpawnBorder.x)
            , Random.Range(-_upperSpawnBorder.y, -_lowerSpawnBorder.y));
            case 2:
                return new Vector2(Random.Range(-_upperSpawnBorder.x, -_lowerSpawnBorder.x)
            , Random.Range(-_upperSpawnBorder.y, _upperSpawnBorder.y));
            case 3:
                return new Vector2(Random.Range(_lowerSpawnBorder.x, _upperSpawnBorder.x)
            , Random.Range(-_upperSpawnBorder.y, _upperSpawnBorder.y));
        }

        return new Vector2();
    }

    public Quaternion GetRandomQuaternionToCenter(Vector2 position)
    {
        // vector from this object towards the target location
        Vector3 vectorToTarget = new Vector3(
            Random.Range(-_lowerSpawnBorder.x, _lowerSpawnBorder.x),
            Random.Range(-_lowerSpawnBorder.y, _lowerSpawnBorder.y)) -
            new Vector3(position.x, position.y);
        // rotate that vector by 90 degrees around the Z axis
        Vector3 rotatedVectorToTarget = Quaternion.Euler(0, 0, 1) * vectorToTarget;

        // get the rotation that points the Z axis forward, and the Y axis 90 degrees away from the target
        // (resulting in the X axis facing the target)
        var targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVectorToTarget);

        return targetRotation;
    }
}
