using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.AI
{
    [System.Serializable]
    public struct RuleInductionData
    {
        [SerializeField]
        [Range(0, 1f)]
        private float pureness;

        [SerializeField]
        [Range(0, 1f)]
        private float sampleRatio;

        [SerializeField]
        [Range(0, 1f)]
        private float minimalPruneBenefit;

        public float Pureness { get => pureness; }
        public float SampleRatio { get => sampleRatio; }
        public float MinimalPruneBenefit { get => minimalPruneBenefit; }

        public void SetPureness(float val)
        {
            pureness = val;
        }

        public void SetSampleRatio(float val)
        {
            sampleRatio = val;
        }

        public void SetMinimalPruneBenefit(float val)
        {
            minimalPruneBenefit = val;
        }
    }
}
