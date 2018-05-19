namespace Domain
{
    /// <summary>
    /// Serviço para exposição de estados de R.O.B.O.
    /// </summary>
    public interface IRoboService
    {
        /// <summary>
        /// Retorna R.O.B.O.
        /// </summary>
        /// <returns></returns>
        Robo GetRobo();

        /// <summary>
        /// Atualiza estados de R.O.B.O.
        /// </summary>
        /// <returns></returns>
        Robo UpdateRobo(Robo robo);
    }
}
