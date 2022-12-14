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

        public bool hitTarget = false;


        private void Start()
        {
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

            RaycastHit hit;
            if (Physics.Raycast(barrelTip.position, barrelTip.forward, out hit, range, layer))
            {
                if (hit.collider.gameObject.CompareTag("ENEMY"))
                {
                    Debug.DrawRay(barrelTip.position, barrelTip.forward * range, Color.red, 1);
                    hitTarget = true;
                }
            }
            else
            {
                hitTarget = false;
                Debug.DrawRay(barrelTip.position, (hit.point - barrelTip.position), Color.green, 5);
            }

            body.AddForce(barrelTip.transform.up*recoilPower*5, ForceMode.Impulse);
        }
    }
}
