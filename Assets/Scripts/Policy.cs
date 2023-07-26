using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Policy : MonoBehaviour
{
    [SerializeField] GameObject _policy;

    [SerializeField] string _policyKey = "Policy";
    private void Start()
    {
        bool accepted = PlayerPrefs.GetInt(_policyKey, 0) == 1;

        if (!accepted)
        {
            _policy.SetActive(true);
        }
    }

    public void OnAccepted()
    {
        PlayerPrefs.SetInt(_policyKey, 1);
        _policy.SetActive(false);
    }
}
