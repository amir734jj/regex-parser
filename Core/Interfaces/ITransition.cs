namespace Core.Interfaces
{
    public interface ITransition
    {
        /// <summary>
        /// Returns true if we can move given the char
        /// </summary>
        public bool CanMove(char ch);
        
        /// <summary>
        /// Returns true if we consume char or not
        /// </summary>
        public bool Move(char ch);
    }
}