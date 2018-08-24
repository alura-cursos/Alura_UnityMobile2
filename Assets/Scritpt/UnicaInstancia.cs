using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnicaInstancia : MonoBehaviour
{
    [SerializeField]
    private bool sobrescreverExiste;
    private void Start()
    {
        var outros = GameObject.FindGameObjectsWithTag(this.tag);

        for (var i = 0; i < outros.Length; i++)
        {
            var outro = outros[i];

            if (outro != this.gameObject)
            {
                if (this.sobrescreverExiste)
                {
                    GameObject.Destroy(outro);
                }
                else
                {
                    GameObject.Destroy(this.gameObject);
                }
            }
        }
    }
}