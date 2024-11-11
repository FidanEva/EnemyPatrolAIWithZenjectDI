namespace Character
{
    public interface ICharacter
    {
        public int Health { get; set; }
        public bool IsDead => Health <= 0;

        public void Attack(ICharacter argCharacter);
    }
}