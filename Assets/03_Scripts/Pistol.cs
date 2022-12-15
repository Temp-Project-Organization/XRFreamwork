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

        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform muzzlePosition;

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
            
            body.AddForce(barrelTip.transform.up * recoilPower * 5, ForceMode.Impulse);

            //RaycastHit hit;
            //if (Physics.Raycast(barrelTip.position, barrelTip.forward, out hit, range, layer))
            //{
            //    var hitBody = hit.transform.GetComponent<Rigidbody>();
            //    if (hitBody != null)
            //    {
            //        Debug.DrawRay(barrelTip.position, (hit.point - barrelTip.position), Color.green, 5);
            //        hitBody.GetComponent<Smash>()?.DoSmash();
            //        hitBody.AddForceAtPosition((hit.point - barrelTip.position).normalized * hitPower * 10, hit.point, ForceMode.Impulse);
            //    }
            //}
            //else
            //{
            //    Debug.DrawRay(barrelTip.position, (hit.point - barrelTip.position), Color.green, 5);
            //}


            StartCoroutine(FireCoolTime());

           
        }

        private IEnumerator FireCoolTime()
        {
            yield return new WaitForSeconds(0.2f);

            Instantiate(bullet, muzzlePosition.transform.position, muzzlePosition.transform.rotation);
        }
    }
}
