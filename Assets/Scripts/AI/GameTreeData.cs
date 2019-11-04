using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.AI
{
    [System.Serializable]
    public struct GameTreeData
    {
        [SerializeField]
        [Range(0, 1f)]
        private float minimalLeafSize;

        [SerializeField]
        [Range(0, 1f)]
        private float minimalSizeForSplit;

        [SerializeField]
        [Range(0, 1f)]
        private float maximalDepth;

        [SerializeField]
        [Range(0, 1f)]
        private float confidence;

        [SerializeField]
        [Range(0, 1f)]
        private float minimalGain;

        public float MinimalLeafSize { get => minimalLeafSize; }
        public float MinimalSizeForSplit { get => minimalSizeForSplit; }
        public float MaximalDepth { get => maximalDepth; }
        public float Confidence { get => confidence; }
        public float MinimalGain { get => minimalGain; }

        public void SetMinimalLeafSize(float val)
        {
            minimalLeafSize = val;
        }

        public void SetMinimalSizeForSplit(float val)
        {
            minimalSizeForSplit = val;
        }

        public void SetMaximalDepth(float val)
        {
            maximalDepth = val;
        }

        public void SetConfidence(float val)
        {
            confidence = val;
        }

        public void SetMinimalGain(float val)
        {
            minimalGain = val;
        }
    }
}
