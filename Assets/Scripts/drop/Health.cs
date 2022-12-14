using UnityEngine;

namespace drop
{
    public class Health : BaseDropItem
    {
        protected override void Update()
        {
            base.Update();
            if (IsPickedUp)
            {
                var energy = GameObject.Find("HealthPosition");
                transform.position =
                    Vector3.MoveTowards(transform.position, energy.transform.position, 50f * Time.deltaTime);
            }
        }
    
        private void OnMouseDown()
        
        {
            IsPickedUp = true;
        }
    
        private void OnTriggerEnter2D(Collider2D col)
        {
            var triggeredObject = col.gameObject.tag;
            if (triggeredObject.Equals("HealthPosition"))
            {
                gameManager.Health += 1;
                Destroy(gameObject);
            }
        }
    }
}