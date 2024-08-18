using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FI.WebAtividadeEntrevista.Validation
{
    public class ValidaCPF
    {
        public static bool validarCPF(string numeroCPF)
        {
            bool cpfValido = true;

            // tirando os "." e "-"
            numeroCPF = numeroCPF.Trim().Replace(".", "").Replace("-", "");

            if (numeroCPF.Length != 11) cpfValido = false;
            else
            {
                //verificando se tem letras
                for (int i = 0; i < numeroCPF.Length; i++)
                {
                    if (!Char.IsDigit(numeroCPF[i]))
                    {
                        cpfValido = false;
                        break;
                    }
                }
            }

            // verificando se é 0000000000,...,9999999999
            bool cacteresIguais = numeroCPF.Distinct().Count() == 1;
            if (cacteresIguais)
            {
                cpfValido = false;
            }

            //Verificar dígito de controle cpf
            if (cpfValido)
            {
                var soma = 0;
                var digito1 = 0;
                var digito2 = 0;

                //validando primeiro dígito
                for (int i = 10; i > 1; i--)
                {
                    digito1 += Convert.ToInt32(numeroCPF.Substring(soma, 1)) * i;
                    soma++;
                }            
                digito1 = (digito1 * 10) % 11;
                if (digito1 > 9) digito1 = 0;

                //verificar se o primeiro dígito é o mesmo da 9º posição
                if (digito1 != Convert.ToInt32(numeroCPF.Substring(9, 1))) cpfValido = false;

                //validando o segundo dígito
                if (cpfValido)
                {
                    soma = 0;
                    for (int i = 11; i > 1; i--)
                    {
                        digito2 += Convert.ToInt32(numeroCPF.Substring(soma, 1)) * i;
                        soma++;
                    }
                    digito2 = (digito2 * 10) % 11;
                    if (digito2 > 9) digito2 = 0;

                    //verificar se o segundo dígito é mesmo da 10º posição
                    if (digito2 != Convert.ToInt32(numeroCPF.Substring(10, 1))) cpfValido = false;
                }
            }

            return cpfValido;
        }
    }
}