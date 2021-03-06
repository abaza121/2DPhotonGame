﻿using UnityEngine;

namespace PhotonNetworkingGame.Gameplay
{
    public class PlayerMotor : MonoBehaviour
    {
        public bool IsMine;

        [SerializeField]
        private Rigidbody2D rb;
        [SerializeField]
        private int speed = 1000;

        private Vector3 inputVector;

        public void Initialize()
        {
            if(IsMine == false)
            {
                rb.isKinematic = true;
            }
        }

        private void Update()
        {
            if (IsMine == false)
            {
                return;
            }

            inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        }

        void FixedUpdate()
        {
            if (IsMine == false)
            {
                return;
            }

            if (inputVector != Vector3.zero)
                this.rb.velocity = inputVector * Time.fixedDeltaTime * speed;
            else
                this.rb.velocity = Vector3.zero;
            this.rb.angularVelocity = 0;
        }
    }
}
