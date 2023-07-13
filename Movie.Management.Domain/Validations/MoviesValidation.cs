namespace Movie.Management.Domain.Validations
{
    public static class MoviesValidation
    {
        public static bool IsValidYear(int year)
        {
            return DateTime.TryParseExact(year.ToString(), "yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date);
        }
    }
}