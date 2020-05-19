namespace Features.Core
{
    public class CpfValidation
    {
        public bool IsValid(string cpf)
        {
            var mult1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var mult2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            var tempCpf = cpf.Substring(0, 9);
            var sum = 0;

            for (var i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * mult1[i];
            var rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            var digit = rest.ToString();
            tempCpf += digit;
            sum = 0;
            for (var i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * mult2[i];
            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit += rest.ToString();
            return cpf.EndsWith(digit);
        }
    }
}
