using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Projectiles;
using StardewValley.TerrainFeatures;

namespace SDVOnePieceFanmod;

public class AnimatedDirectionalProjectile : Projectile
{
    private const int animationFrames = 4;
    private const int frameWidth = 16;
    private const int frameHeight = 16;
    
    private Texture2D texture;
    
    private Vector2 startPosition;

    private float velocityX;
    private float velocityY;
    private float speed = 10f;
    
    private int frameIndex;
    private int animationCounter = 0;

    public AnimatedDirectionalProjectile(Texture2D texture, Vector2 playerPosition, int direction)
    {
        this.texture = texture;
        startPosition = playerPosition;
        position.X = playerPosition.X;
        position.Y = playerPosition.Y;
        switch (direction)
        {
            case 0: 
                velocityY = -speed; break;
            case 1: velocityX = speed; break;
            case 2: velocityY = speed; break;
            case 3: velocityX = -speed; break;
        }
        frameIndex = direction * animationFrames;
    }
    
    public override void behaviorOnCollisionWithPlayer(GameLocation location, Farmer player)
    {
        return;
    }

    public override void behaviorOnCollisionWithTerrainFeature(TerrainFeature t, Vector2 tileLocation, GameLocation location)
    {
        this.destroyMe = true;
    }

    public override void behaviorOnCollisionWithOther(GameLocation location)
    {
        return;
    }

    public override void behaviorOnCollisionWithMonster(NPC n, GameLocation location)
    {
        //TODO
    }

    public override void updatePosition(GameTime time)
    {
        position.X += velocityX;
        position.Y += velocityY;
    }

    public void update(GameTime time, GameLocation location)
    {
        updatePosition(time);
        
        //animation
        animationCounter++;
        if (animationCounter >= animationFrames)
        {
            animationCounter = 0;
        }
    }
}