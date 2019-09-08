using System;

namespace Softplan.CalcTest.CalculateInterestApi.Infra
{
    /// <summary>
    /// 
    /// </summary>
    public class ArgumentValueException: Exception
    {

        /// <summary>
        /// 
        /// </summary>
        public object ArgumentValue { get; private set; }

        /// <summary>
        /// Exceção customizada usada na validação de parâmetros.
        /// </summary>
        /// <param name="message">Mensagem da exceção.</param>
        /// <param name="value">Valor do parâmetro inválido.</param>
        public ArgumentValueException(object value, string message): base(message)
        {
            ArgumentValue = value;
        }

        /// <summary>
        /// Exceção customizada usada na validação de parâmetro.
        /// </summary>
        /// <param name="message">Mensagem da exceção.</param>
        /// <param name="value">Valor do parâmetro inválido.</param>
        /// <param name="inner">Inner exception.</param>
        public ArgumentValueException(object value, string message, Exception inner):base(message,inner)
        {
            ArgumentValue = value;
        }
    }
}