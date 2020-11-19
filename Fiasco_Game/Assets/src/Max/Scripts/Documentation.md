# Demo System
The Demo System plays a series clips when the user is inactive in the menu scenes.

-------------------------------------------------------

## Demo Player
Randomly plays a series of clips from a predefined set.

Attach Demo Player script to video player.
Add desired clips to video player within unity.
### `DemoPlayer()`
Set instance to prevent the initilization of a second DemoPlayer somewhere else.

### `public VideoClip[] VideoClipArray`
Allows user to attach video clips from within Unity.

### `void Awake()`
Get video player component.
Prevent playing.

### `void Start()`
Start next video.

### `void Update()`
Plays clips with a second in between.

-------------------------------------------------------

## Demo Timer
Loads DemoMode scene if the user is inactive for a predetermined set of time.

Attach Demo Timer script to an empty object in a scene to allow for automated transition to Demo Mode.
### `public float timer`
Default is 15.

### `void Update()`
Loads DemoMode scene if the timer reaches zero.

-------------------------------------------------------

## Exit Demo
Exits Demo Mode upon left mouse click.

Add Exit Demo script to empty object in Demo Mode to transition to main menu upon left mouse click input.
### `void Update()`
Wait's for left mouse input to exit demo scene.

# Projectile System

The Projectile System sets up a dictionary of separate pools, which are filled with queues of objects.  These are loaded upon the entering of each scene, and are reused throughout the scene to prevent lagging caused by the alternative large amounts of bullet spawning and destroying during a scene.


-------------------------------------------------------

## Object Pooler 
The Object Pooler creates a dictionary of pools that are filled with queued bullets set by specific tags, prefabs, and sizes within Unity.

Add the object pooler script to an empty object in a scene to begin.  Specify number of pools, then add desired tags, prefabs to spawn, and total amount to spawn upon loading of a scene within Unity. 

### `public class Pool {}`
Allows you to assign specified Tab, Prefab, and Size for each Pool from within Unity.

### `private void Awake()`
Set objectPooler instance to this for utilization from other scripts.

### `void Start()`
Create a dictionary, add pools to dictionary, and fill pools with queued objects.

### `public GameObject SpawnFromPool (string tag, Vector2 position, Quaternion rotation)`
Check to see if object pool exists, and if so, dequeue and set up object for use. 
Find interface of object and call.
Put back in queue.

-------------------------------------------------------

## Pooled Object Interface 
The Pooled Object Interface allows for the designation of a spawned projectile's behavior based on the object's specific tag.  Derive an object from IpooledObject, and define a public void OnObjectSpawn() to assign behavior for object. OnObjectSpawn will be called by the objectPooler script when the object is dequeued from a pool.

```csharp
public class enemyBullet : MonoBehaviour, IpooledObject
{
    public void OnObjectSpawn(){
        ...
    }
}
 ```

### `void OnObjectSpawn()`
Will be defined by each derived object and used when object is spawned.

## Player Bullet Spawner
The Player Bullet Spawner spawns PlayerBullets upon a left mouse click input.  

Add the Player Bullet Spawner script to the desired player game object.  Set the layer of the game object to Player. Edit the Layer Collision Matrix in Physics 2D Settings so that the Player layer does not collide with the PlayerBullet layer.

### `void Start()`
Find existing instance of objectPooler.

### `void Update()`
Upon left mouse click input, spawn PlayerBullet at bullet spawner.
Play PlayerShoot sound.

-------------------------------------------------------

## Player Bullet 
The player bullet will be spawned by the Player Bullet Spawner.  When spawned, the player bullet is sent towards the mouse position.

Create a prefab of a bullet, with a rigidbody 2d (set the gravity to zero), a box collider 2d, and then add the player bullet script to the bullet.
Set the tag and layer to PlayerBullet.
Edit the Layer Collision Matrix in Physics 2D Settings so that the Player layer does not collide with the PlayerBullet layer.

### `public float bulletSpeed`
Default is 5.

### `public float despawnTimer`
Default is 5

### `public void OnObjectSpawn()`
Send bullet in direction of mouse position at speed bulletSpeed.

### `void Update()`
Unset bullet when despawnTimer reaches zero.

### `private void OnCillision Enter2D(Collision2D collision)`
Unset bullet upon collision.

-------------------------------------------------------

## Enemy Bullet Spawner

The enemy bullet spawner spawns an enemy bullet at a set interval. 

Add the Enemy Bullet Spawner script to the desired enemy game object.  Set the layer of the game object to Enemy. 
Edit the Layer Collision Matrix in Physics 2D Settings so that the Enemy layer does not collide with the EnemyBullet layer.
### `public float spawnDelay`
Default is 1.

### `public float spawnFreq`
Default is 1.

### `private void Start()`
Set objectPooler to existing instance and set shootCounter to delay time.

### `void Update()`
Spawn EnemyBullet prefab at frequency of spawnFreq.

-------------------------------------------------------

## Enemy Bullet 
The enemy bullet will be spawned by the enemy Bullet Spawner.  When spawned, the enemy bullet is sent towards the player's current position.

Create a prefab of a bullet, with a rigidbody 2d (set the gravity to zero), a box collider 2d, and then add the enemy bullet script to the bullet.
Set the tag and layer to EnemyBullet.
### `public float bulletSpeed`
Default is 2.5.

### `public float despawnTimer`
Default is 3.

### `public void OnObjectSpawn()`
When a bullet spawns, send in the direction of the player with speed bulletSpeed.

### `void Update()`
Unset bullet when despawnTimer reaches zero.

### `private void OnCollisionEnter2D`
Upon collision, unset bullet and spawn an explosion.

-------------------------------------------------------
## Explosions
The explosion script simply lowers a spawned explosion.

Add script to an explosion prefab. 
Add explosion8 tag to prefab.
### `public void OnObjectSpawn()`
Lowers the position of the explosion to better fit desired location.


