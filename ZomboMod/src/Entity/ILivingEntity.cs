namespace ZomboMod.Entity
{
    public interface ILivingEntity
    {
        bool IsDead { get; }

        void Kill();
    }
}