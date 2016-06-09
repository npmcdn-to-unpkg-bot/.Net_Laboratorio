namespace InteractionSdk.Interfaces
{
    public interface IDestacamento
    {
        int GetId();
        float GetAtaque();
        float GetEscudo();
        float GetEfectividad();
        float GetVida();
        float GetVelocidad();
        string GetName();
        int GetAmount();
        void SetAmount(int i);
        int GetCapacidad();
    }
}