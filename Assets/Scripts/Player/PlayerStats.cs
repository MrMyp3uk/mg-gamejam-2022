namespace Player
{
    public class PlayerStats
    {
        /// <summary>
        /// Количество падений в бездну
        /// </summary>
        public int CountDeath { get; private set; }

        /// <summary>
        /// Количество столкновений с другими шарами
        /// </summary>
        public int CountCollisionsOtherBalls { get; private set; }

        /// <summary>
        /// Количество столкновений с элементами уровня
        /// </summary>
        public int CountCollisionsLevelItems { get; private set; }

        /// <summary>
        /// Количество подпрыгиваний на батуте
        /// </summary>
        public int CountJump { get; private set; }

        public void Death()
        {
            CountDeath++;
        }

        public void CollisionOtherBall()
        {
            CountCollisionsOtherBalls++;
        }

        public void CollisionLevelItem()
        {
            CountCollisionsLevelItems++;
        }

        public void Jump()
        {
            CountJump++;
        }

        public override string ToString()
        {
            return $"Смерти: {CountDeath}\n" +
                   $"Прыжки: {CountJump}\n" +
                   $"Другие шары: {CountCollisionsOtherBalls}\n" +
                   $"Элементы уровня: {CountCollisionsLevelItems}";
        }
    }
}