using UnityEngine;

namespace Character.Stats
{
    public class BaseStats : MonoBehaviour
    {
        [SerializeField] private int strength = 150;
        [SerializeField] private int energy = 20;
        [SerializeField] private int agility = 5;

        #region Strength Point
        public int Strength { get => strength; set=> strength = value; }
        #endregion

        #region Agility Point
        public int Agility { get => agility; set => agility = value; }
        #endregion

        #region Energy Point
        public int Energy { get => energy; set => energy = value; }
        #endregion
        //============================================================
        #region Energy behavior
        public int MaxEnergyPoints => energy * 2;
        public int CurrentEnergyPoints { get; set; }
        #endregion


        #region Health
        public int MaxHealthPoints => strength * 5;
        public int CurrentHealthPoints { get; set; }
        #endregion



        #region MovementSpeed
        public float MaxMovementSpeed => agility * 3;
        #endregion
    }
}