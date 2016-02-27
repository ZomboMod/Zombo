namespace ZomboMod.Entity
{
    public interface ILivingEntity
    {
        bool IsDead { get; set; }

        void Kill();
    }
}