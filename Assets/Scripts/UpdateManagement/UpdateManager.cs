using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace UpdateManagement
{
    public class UpdateManager : MonoBehaviour
    {
        [SerializeField] private Transform player = null;

        private static UpdateManager instance;
        public static UpdateManager Instance
        {
            get
            {
                return instance;
            }
        }

        private HashSet<IUpdateable> updateables = new HashSet<IUpdateable>();

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
        }

        public void Register(IUpdateable updateable)
        {
            updateables.Add(updateable);
        }

        public void Unregister(IUpdateable updateable)
        {
            updateables.Remove(updateable);
        }

        private void Update()
        {
            foreach (IUpdateable updateable in updateables)
            {
                updateable.Tick(player.transform.position);
            }
        }
    }
}
