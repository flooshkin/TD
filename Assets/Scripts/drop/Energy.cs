using UnityEngine;

namespace drop
{
    public class Energy : BaseDropItem
    {
        private const float EnergyAmount = 0.1f;
        protected override void Update()
        {
            base.Update();
            if (IsPickedUp)
            {
                var energy = GameObject.Find("EnergyPosition");
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
            if (triggeredObject.Equals("EnergyPosition"))
            {
                if (gameManager.Energy <= 1f)
                {
                    gameManager.Energy += EnergyAmount;
                }
                Destroy(gameObject);
            }
        }
    }
}