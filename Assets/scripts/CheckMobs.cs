using BLINK.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BLINK.RPGBuilder.AI
{
    public class CheckMobs : MonoBehaviour
    {
        GameObject obj;
        [SerializeField] public RPGBThirdPersonController ThirdPersonController;
        [SerializeField] public GameObject cube;

        public CharacterController controller_player;
        // Start is called before the first frame update

        private void Start()
        {
        }
        // Update is called once per frame
        void Update()
        {
            if (obj.GetComponent<CapsuleCollider>() == null)
            {
                ThirdPersonController.RotationSettings.OrientRotationToMovement = true;
                controller_player.enabled = true;
                cube.SetActive(false);
            }
        }
       
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CapsuleCollider>() != null)
            {
                obj = other.gameObject;
                ThirdPersonController.RotationSettings.OrientRotationToMovement = false;
                controller_player.enabled = false;


            }
        }
   
    }
}
