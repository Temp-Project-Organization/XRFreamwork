using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autohand.Demo
{
    public class Pistol : MonoBehaviour
    {
        public Rigidbody body;
        public Transform barrelTip;
        public LayerMask layer;
        public AudioClip shootSound;

        public float hitPower = 1;
        public float recoilPower = 1;
        public float range = 100;
        public float shootVolume = 1f;

        private bool hitTarget;

        private void Start()
        {
            hitTarget = false;

            if (body == null && GetComponent<Rigidbody>() != null)
            {
                body = GetComponent<Rigidbody>();
            }
        }

        public void Shoot()
        {
            //Play the audio sound
            if (shootSound)
            {
                AudioSource.PlayClipAtPoint(shootSound, transform.position, shootVolume);
            }
            
            body.AddForce(barrelTip.transform.up * recoilPower * 5, ForceMode.Impulse);

            RaycastHit hit;
            if (Physics.Raycast(barrelTip.position, barrelTip.forward, out hit, range, layer))
            {
                // 해당 코드에서 hitTarget을 True로 바꿔주는 것
                if (hit.collider.gameObject.CompareTag("ENEMY"))
                {
                    hitTarget = true;
                    Debug.Log(hitTarget);
                }
            }
            else
            {
                Debug.DrawRay(barrelTip.position, (hit.point - barrelTip.position), Color.green, 5);
            }

        }

        public bool GetHitTarget()
        {
            return hitTarget;
        }
    }
}
