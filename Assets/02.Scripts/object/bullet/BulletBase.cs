using UnityEngine;

public abstract class BulletBase : MonoBehaviour
{
    public Vector3 location;
    public float speed;

   protected void DestroyBullet()
   {
        this.gameObject.SetActive(false);
   }


}
