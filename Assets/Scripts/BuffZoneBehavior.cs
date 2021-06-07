using UnityEngine;

namespace UnityStandardAssets.Utility
{
    public class BuffZoneBehavior : MonoBehaviour
    {
        public bool isDeBuff;
        public bool isActive;

        public int buffDeBuffType;

        private const int NO_SHOOTING = 1;
        private const int NO_MOVE = 2;
        
        private const int BLOOD_RETURN = 3;
        private const int SUPPLIER = 4;

        public bool IsDeBuff
        {
            get => isDeBuff;
            set => isDeBuff = value;
        }

        public bool IsActive
        {
            get => isActive;
            set => isActive = value;
        }

        public int BuffDeBuffType
        {
            get => buffDeBuffType;
            set => buffDeBuffType = value;
        }
    }
}